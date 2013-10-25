// Created by Peoharen
using System;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Spells;
using Server.Items;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 1<br>Duration: Instantaneous<br>Target: Enemy<br>The caster swap places with the targeted creature." )]
	public class SwitchSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
			"Switch", "", 215 );

		public override int PowerLevel{ get{ return 1; } }

		public SwitchSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( Caster is BaseCreature )
				Caster.Target = new BlueSpellTarget( this, TargetFlags.Harmful );
			else
				Caster.Target = new BlueSpellTarget( this, TargetFlags.Beneficial );
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;
			else if ( Factions.Sigil.ExistsOn( Caster ) )
			{
				Caster.SendLocalizedMessage( 1061632 ); // You can't do that while carrying the sigil.
				return false;
			}

			return SpellHelper.CheckTravel( Caster, TravelCheckType.TeleportFrom );
		}

		public override void OnTarget( Mobile target )
		{
			Point3D from = Caster.Location;
			Point3D to = target.Location;

			if ( Factions.Sigil.ExistsOn( Caster ) )
			{
				Caster.SendLocalizedMessage( 1061632 ); // You can't do that while carrying the sigil.
			}
			else if ( !SpellHelper.CheckTravel( Caster, TravelCheckType.TeleportFrom ) )
			{
			}
			else if ( !SpellHelper.CheckTravel( Caster, Caster.Map, new Point3D( target ), TravelCheckType.TeleportTo ) )
			{
			}
			else if ( target is BaseVendor )
			{
				Caster.SendMessage( "You cannot switch with that." );
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, target );
				Caster.Location = to;
				target.Location = from;
				SpellHelper.Turn( Caster, target );

				Caster.ProcessDelta();

				Effects.SendLocationParticles( EffectItem.Create( from, Caster.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
				Effects.SendLocationParticles( EffectItem.Create(   to, Caster.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );
				//m.FixedParticles( 0x376A, 9, 32, 0x13AF, EffectLayer.Waist );
				Caster.PlaySound( 0x1FE );

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}

	}
}