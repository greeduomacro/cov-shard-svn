// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Necromancy;
using Server.Spells.Fourth;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 6<br>Duration: Instantaneous<br>Target: Party<br>Consumes a Healing, Curing, and Refresh Potions per party member in range of the caster to heal several aliments and a minor amount of HP." )]
	public class AngelsSnackSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"AngelsSnack", "", 230 );

		public override bool IsHarmful{ get{ return false; } }
		public override int PowerLevel{ get{ return 6; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Party; } }

		public AngelsSnackSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void SpellEffect( Mobile target )
		{
			if ( Caster.Backpack == null || !(Caster.Backpack is Container) )
			{
				Caster.SendMessage( "You need a backpack to use this spell." );
				return;
			}

			if ( AosAttributes.GetValue( Caster, AosAttribute.LowerRegCost ) < 100 ) // Nothing less than 100% will do
			{
				Item item = Caster.Backpack.FindItemByType( typeof( RefreshPotion ) );

				if ( item == null )
				{
					Caster.SendMessage( "You do not have enough Refresh Potions" );
					return;
				}

				item = Caster.Backpack.FindItemByType( typeof( LesserHealPotion ) );

				if ( item == null )
				{
					Caster.SendMessage( "You do not have enough Heal Potions" );
					return;
				}

				item = Caster.Backpack.FindItemByType( typeof( LesserCurePotion ) );

				if ( item == null )
				{
					Caster.SendMessage( "You do not have enough Cure Potions" );
					return;
				}

				// We just checked for the items.
				Caster.Backpack.ConsumeTotal( typeof( RefreshPotion ), 1 );
				Caster.Backpack.ConsumeTotal( typeof( LesserHealPotion ), 1 );
				Caster.Backpack.ConsumeTotal( typeof( LesserCurePotion ), 1 );
			}

			StatMod mod;

			mod = target.GetStatMod( "[Magic] Str Offset" );
			if ( mod != null && mod.Offset < 0 )
				target.RemoveStatMod( "[Magic] Str Offset" );

			mod = target.GetStatMod( "[Magic] Dex Offset" );
			if ( mod != null && mod.Offset < 0 )
				target.RemoveStatMod( "[Magic] Dex Offset" );

			mod = target.GetStatMod( "[Magic] Int Offset" );
			if ( mod != null && mod.Offset < 0 )
				target.RemoveStatMod( "[Magic] Int Offset" );

			BuffInfo.RemoveBuff( target, BuffIcon.Clumsy );
			BuffInfo.RemoveBuff( target, BuffIcon.FeebleMind );
			BuffInfo.RemoveBuff( target, BuffIcon.Weaken );
			BuffInfo.RemoveBuff( target, BuffIcon.MassCurse );

			target.Paralyzed = false;

			 // Don't cure others of Lethal Poison
			if ( target.Poison != Poison.Lethal || target == Caster )
				target.CurePoison( Caster );

			EvilOmenSpell.TryEndEffect( target );
			StrangleSpell.RemoveCurse( target );
			CorpseSkinSpell.RemoveCurse( target );
			CurseSpell.RemoveEffect( target );

			// Cure Status aliments (is the system being used?)
			BlindSpell.EndBlind( target );
			SilenceSpell.EndSilence( target );
			SlowSpell.EndSlow( target );
			StillSpell.EndStill( target );

			Effects.SendLocationParticles(
				EffectItem.Create( new Point3D( target.X, target.Y, target.Z ), target.Map, EffectItem.DefaultDuration ),
				0x376A, 9, 32, 5020 );

			// Play a random eating sound
			target.PlaySound( Utility.Random( 0x3A, 3 ) );

			int bonus = AosAttributes.GetValue( Caster, AosAttribute.EnhancePotions ) / 2;

			if ( bonus > 20 )
				bonus = 20;

			target.Hits += bonus;
			target.Stam += bonus;

			target.SendMessage( "You have been cured of all ailments" );
			Caster.SendMessage( "You have cured " + target.Name + " of all alignments." );

			// It is a party effect, no way to ever get hit by it.
			// BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
		}
	}
}