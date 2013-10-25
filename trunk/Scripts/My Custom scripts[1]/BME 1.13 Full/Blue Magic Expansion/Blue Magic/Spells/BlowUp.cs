// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 2<br>Duration: Instantaneous<br>Target: Self & Area 2<br>The caster charges up and then detonates him self dealing twice his HP in damage to the surrounding area." )]
	public class BlowUpSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"BlowUp", "", 260 );

		public override int PowerLevel{ get{ return 2; } }
		public override int Range{ get{ return 2; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Burst; } }

		private int m_Count;

		public BlowUpSpell( Mobile from ) : base( from, m_Info )
		{
			m_Count = 1109;
		}

		public override void OnCast()
		{
			// Caster.Freeze( TimeSpan.FromSeconds( 2 ) );
			Caster.FixedParticles( 0x37C4, 1, 8, 9916, 1150, 3, EffectLayer.Head );
			Caster.FixedParticles( 0x37C4, 1, 8, 9502, 998, 4, EffectLayer.Head );
			Caster.SolidHueOverride = 1175;
			Timer.DelayCall( TimeSpan.FromMilliseconds( 250.0 ), new TimerCallback( Count ) );
		}

		private void Count()
		{
			if ( Caster != null )
			{
				if ( Caster.Alive )
				{
					Caster.SolidHueOverride = m_Count;
					m_Count--;

					if ( m_Count >= 1102 )
						Timer.DelayCall( TimeSpan.FromMilliseconds( 250.0 ), new TimerCallback( Count ) );
					else
					{
						Caster.SolidHueOverride = -1;

						DoBurstEffect( this, Caster.Location );

						if ( Caster.AccessLevel == AccessLevel.Player )
							Caster.Hits = Caster.Stam = 0; // No longer kills.
					}
				}
			}
		}

		public override void VisualEffects( Point3D point )
		{
			Effects.SendLocationParticles( EffectItem.Create( point, Caster.Map, EffectItem.DefaultDuration ), 
				0x36BD/*ItemID*/, 1/*Speed*/, 20/*Duration*/, 0/*Hue*/, 0/*RenderMode*/, 0/*Effect*/, 0/*Unknown*/ );
		}

		public override void SpellEffect( Mobile target )
		{
			SpellHelper.Damage( this, target, (Caster.Hits * 2), 0, 100, 0, 0, 0 );
			BlueMageControl.CheckKnown( target, this, CanTeach( target ) );

		}
	}
}