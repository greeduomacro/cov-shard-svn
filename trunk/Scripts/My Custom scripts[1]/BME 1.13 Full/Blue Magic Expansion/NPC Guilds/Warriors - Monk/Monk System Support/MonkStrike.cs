// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class MonkStrike : SpecialMove
	{
		public override int BaseMana{ get{ return 5; } }
		public override SkillName MoveSkill{ get{ return SkillName.Wrestling; } }
		public override double RequiredSkill{ get{ return 100.0; } }

		public MonkElement m_Element;

		public MonkStrike( MonkElement element )
		{
			m_Element = element;
		}

		public override void OnUse( Mobile from )
		{
			if ( from.HasGump( typeof( MonkStrikeGump ) ) )
				from.CloseGump( typeof( MonkStrikeGump ) );

			from.SendGump( new MonkStrikeGump( from ) );
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if ( !MonkSystem.IsMonk( attacker ) )
			{
				attacker.SendMessage( "Only monks can use this strike." );
				return;
			}

			MonkFists mf = attacker.FindItemOnLayer( Layer.Gloves ) as MonkFists;
			int amount = 0;	

			if ( mf != null )
				amount = Utility.Dice( mf.Teir, 3, (3 * mf.Teir) );
			else
				amount = Utility.Dice( 2, 6, 0 );

			switch( m_Element )
			{
				case MonkElement.Air:
				{
					defender.FixedParticles( 0x374A, 10, 20, 5013, 1176, 0, EffectLayer.Waist );
					AOS.Damage( defender, attacker, amount, 0, 0, 0, 0, 100 );
					PlayPunchSound( attacker );
					break;
				}
				case MonkElement.Earth:
				{
					defender.FixedParticles( 0x374A, 10, 20, 5013, 1191, 0, EffectLayer.Waist );
					AOS.Damage( defender, attacker, amount, 100, 0, 0, 0, 0 );
					PlayPunchSound( attacker );
					break;
				}
				case MonkElement.Fire:
				{
					defender.FixedParticles( 0x374A, 10, 20, 5013, 1160, 0, EffectLayer.Waist );
					AOS.Damage( defender, attacker, amount, 0, 100, 0, 0, 0 );
					PlayPunchSound( attacker );
					break;
				}
				case MonkElement.Water:
				{
					defender.FixedParticles( 0x374A, 10, 20, 5013, 1364, 0, EffectLayer.Waist );
					AOS.Damage( defender, attacker, amount, 0, 0, 0, 100, 0 );
					PlayPunchSound( attacker );
					break;
				}
				case MonkElement.Light:
				{
					defender.FixedParticles( 0x374A, 10, 20, 5013, 1149, 0, EffectLayer.Waist );
					AOS.Damage( defender, attacker, amount / 2, false, 0, 0, 0, 0, 0, 0, 100 /*direct*/, false, false, false );
					PlayPunchSound( attacker );
					mf.LightEnergy += 5;
					break;
				}
				case MonkElement.Dark:
				{
					defender.FixedParticles( 0x374A, 10, 20, 5013, 1108, 0, EffectLayer.Waist );
					AOS.Damage( defender, attacker, amount, false, 0, 0, 0, 0, 0, 100 /*chaos*/, 0, false, false, false );
					PlayPunchSound( attacker );
					mf.DarkEnergy += 5;
					break;
				}

				case MonkElement.AirCombo: { MonkCombos.AirCombo( attacker, defender ); break; }
				case MonkElement.EarthCombo: { MonkCombos.EarthCombo( attacker, defender ); break; }
				case MonkElement.FireCombo:
				{
					// Handled in MonkStrikeGump
					break;
				}
				case MonkElement.WaterCombo: { MonkCombos.WaterCombo( attacker, defender ); break; }
				case MonkElement.DarkCombo: { MonkCombos.DarkCombo( attacker, defender ); break; }
				case MonkElement.DarkAirCombo: { MonkCombos.DarkAirCombo( attacker, defender ); break; }
				case MonkElement.DarkEarthCombo: { MonkCombos.DarkEarthCombo( attacker, defender ); break; }
				case MonkElement.DarkFireCombo:
				{
					MonkCombos.DarkFireCombo( attacker, defender, ref damage );
					break;
				}
				case MonkElement.DarkWaterCombo: { MonkCombos.DarkWaterCombo( attacker, defender ); break; }
			}

			if ( (int)m_Element < 11 )
				attacker.SendMessage( "You hit your opponent with an elemental attack." );

			ClearCurrentMove( attacker );

			MonkSystem.AddHit( attacker, m_Element );

			if ( attacker.HasGump( typeof( MonkStrikeGump ) ) )
				attacker.CloseGump( typeof( MonkStrikeGump ) );

			attacker.SendGump( new MonkStrikeGump( attacker ) );
		}

		private void PlayPunchSound( Mobile m )
		{
			if ( Utility.RandomBool() )
				m.PlaySound( Utility.RandomList( 0x136, 0x138, 0x139, 0x13B, 0x13C, 0x13D, 0x13E, 0x142, 0x145, 0x14B ) );
			else
				m.PlaySound( 0x3A3 + Utility.Random( 21 ) );
		}

		//public override void OnMiss( Mobile attacker, Mobile defender )
		//{
			//ClearCurrentAbility( attacker );
			//SetCurrentAbility( attacker, new MonkElementalStrike( m_Element ) );
		//}
	}
}