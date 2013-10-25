using System;
using Server;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Fourth;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		public sealed class HearthSpell : Spell
		{
			public override TimeSpan CastDelayBase { get { return DefSpellCastDelay; } }

			private Hearthstone _Stone;

			public HearthSpell(Hearthstone hs, Mobile caster)
				: base(caster, null, DefSpellInfo)
			{
				_Stone = hs;
			}

			public override int GetMana()
			{
				return DefSpellManaCost;
			}

			public override void OnCast()
			{
				Effect(_Stone.Home.Location, _Stone.Home.Map, true);
			}

			public override bool CheckCast()
			{
				if (!_Stone.Home.IsValid())
				{
					Caster.SendMessage(0x22, "You have not yet set your Hearthstones' Home location.");
					return false;
				}
				else if (Factions.Sigil.ExistsOn(Caster))
				{
					Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
					return false;
				}
				/*else if (Caster.Criminal)
				{
					Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
					return false;
				}*/
				else if (SpellHelper.CheckCombat(Caster))
				{
					Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
					return false;
				}
				else if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
				{
					Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
					return false;
				}

				return SpellHelper.CheckTravel(Caster, TravelCheckType.RecallFrom);
			}

			public override void OnDisturb(DisturbType type, bool message)
			{
				base.OnDisturb(type, message);

				_Stone.LastUsed = DateTime.Now.Subtract(_Stone.Cooldown);
			}

			public void Effect(Point3D loc, Map map, bool checkMulti)
			{
				if (Factions.Sigil.ExistsOn(Caster))
				{
					Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
				}
				/*else if (map == null || (!Core.AOS && Caster.Map != map))
				{
					Caster.SendLocalizedMessage(1005569); // You can not recall to another facet.
				}*/
				else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.RecallFrom))
				{
				}
				else if (!SpellHelper.CheckTravel(Caster, map, loc, TravelCheckType.RecallTo))
				{
				}
				else if (map == Map.Felucca && Caster is PlayerMobile && ((PlayerMobile)Caster).Young)
				{
					Caster.SendLocalizedMessage(1049543); // You decide against traveling to Felucca while you are still young.
				}
				/*else if (Caster.Kills >= 5 && map != Map.Felucca)
				{
					Caster.SendLocalizedMessage(1019004); // You are not allowed to travel there.
				}*/
				/*else if (Caster.Criminal)
				{
					Caster.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily.
				}*/
				else if (SpellHelper.CheckCombat(Caster))
				{
					Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
				}
				else if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
				{
					Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
				}
				/*else if (!map.CanSpawnMobile(loc.X, loc.Y, loc.Z))
				{
					Caster.SendLocalizedMessage(501942); // That location is blocked.
				}*/
				else if ((checkMulti && SpellHelper.CheckMulti(loc, map)))
				{
					Caster.SendLocalizedMessage(501942); // That location is blocked.
				}
				else if (CheckSequence())
				{
					BaseCreature.TeleportPets(Caster, loc, map, true);

					Caster.PlaySound(0x1FC);
					Caster.MoveToWorld(loc, map);
					Caster.PlaySound(0x1FC);
				}

				FinishSequence();
			}
		}
	}
}