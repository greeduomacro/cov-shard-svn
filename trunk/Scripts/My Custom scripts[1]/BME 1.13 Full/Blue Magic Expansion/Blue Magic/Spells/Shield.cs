// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 3<br>Duration: (Bonus * 8) Seconds<br>Target: Self<br>While under it's effects damage taken drains your mana instead. the spell ends when you run out of mana." )]
	public class ShieldSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "Shield Spell", "", 230 );

		public override int PowerLevel{ get{ return 3; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Self; } }

		public ShieldSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void SpellEffect( Mobile target )
		{
			if ( Status.Enabled )
			{
				target.FixedParticles( 0x374A, 10, 15, 5038, EffectLayer.Head );
				target.PlaySound( 0x213 );
				BeginShield( target, (int)(ScaleBySkill( Caster, DamageSkill ) * 8) );
				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}
			else
			{
				target.SendMessage( "This spell is nonfunctional." );
			}
		}

		private static Dictionary<Serial, Timer> m_Table = new Dictionary<Serial, Timer>();

		public static bool IsShielded( Mobile m )
		{
			return m_Table.ContainsKey( m.Serial );
		}

		public static void BeginShield( Mobile m, double duration )
		{
			if ( Status.Enabled )
			{
				if ( m_Table.ContainsKey( m.Serial ) )
				{
					Timer timer = m_Table[m.Serial];
					timer.Stop();
					m_Table.Remove( m.Serial );
				}

				InternalTimer timertostart = new InternalTimer( m, duration );
				timertostart.Start();
				m_Table.Add( m.Serial, timertostart );

				m.SendMessage( "You are now under a shield of magic." );
			}
			else
			{
				m.SendMessage( "This spell is nonfunctional." );
			}
		}

		public static void EndShield( Mobile m )
		{
			if ( m_Table.ContainsKey( m.Serial ) )
			{
				Timer t = m_Table[m.Serial];

				if ( t != null )
					t.Stop();

				m_Table.Remove( m.Serial );

				m.SendMessage( "You are no longer under the shield." );
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile m, double duration ) : base( TimeSpan.FromSeconds( duration ), TimeSpan.FromSeconds( duration ) )
			{
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				EndShield( m_Mobile );
			}
		}

	}
}