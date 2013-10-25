using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class SlingShott : BaseRanged
	{
		public override int EffectID{ get{ return 3699; } }
		public override Type AmmoType{ get{ return typeof( SlingShotAmmo ); } }
		public override Item Ammo{ get{ return new SlingShotAmmo(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 18; } }
		public override int AosMaxDamage{ get{ return 20; } }
		public override int AosSpeed{ get{ return 44; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 43; } }
		public override int OldSpeed{ get{ return 38; } }

		public override int DefMaxRange{ get{ return 12; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public SlingShott() : base( 0xF50 )
		{
            Name = " SlingShot (Family Heirloom ";
            Hue = 2424;
			Weight = 7.0;
			Layer = Layer.TwoHanded;

            //WeaponAttributes.DurabilityBonus = 45;
            //WeaponAttributes.HitColdArea = 25;
            //WeaponAttributes.HitEnergyArea = 45;
            //WeaponAttributes.HitFireArea = 45;
            //WeaponAttributes.HitHarm = 45;
            //WeaponAttributes.HitLeechHits = 25;
            //WeaponAttributes.HitLeechMana = 25;
            //WeaponAttributes.HitLeechStam = 25;
            //WeaponAttributes.HitLightning = 25;
            //WeaponAttributes.HitMagicArrow = 25;
            //WeaponAttributes.HitPhysicalArea = 25;
            //WeaponAttributes.HitPoisonArea = 25;
            //WeaponAttributes.LowerStatReq = 25;
            //WeaponAttributes.ResistColdBonus = 25;
            //WeaponAttributes.ResistEnergyBonus = 25;
            //WeaponAttributes.ResistPhysicalBonus = 25;
            //WeaponAttributes.ResistPoisonBonus = 25;
            //WeaponAttributes.ResistFireBonus = 25;
            //WeaponAttributes.SelfRepair = 3;
            //WeaponAttributes.UseBestSkill = 1;

            //Attributes.AttackChance = 32;
            //Attributes.BonusDex = 33;
            //Attributes.BonusHits = 10;
            //Attributes.BonusInt = 39;
            //Attributes.BonusMana = 30;
            //Attributes.BonusStam = 37;

            //Attributes.DefendChance = 10;
            //Attributes.EnhancePotions = 30;
            //Attributes.LowerManaCost = 46;
            //Attributes.Luck = 122;
            //Attributes.NightSight = 1;
            //Attributes.ReflectPhysical = 25;
            //Attributes.RegenHits = 25;
            //Attributes.RegenMana = 26;
            //Attributes.RegenStam = 26;
            //Attributes.SpellChanneling = 1;
            //Attributes.WeaponDamage = 45;
            //Attributes.WeaponSpeed = 25;
                                        
		}

		public SlingShott( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}