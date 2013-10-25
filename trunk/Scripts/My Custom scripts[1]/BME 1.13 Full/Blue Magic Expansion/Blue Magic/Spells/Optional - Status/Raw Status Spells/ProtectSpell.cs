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
	public class ProtectSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "Protect Spell", "", 230 );

		public override int PowerLevel{ get{ return 5; } }

		private Mobile m_Caster;

		public ProtectSpell( Mobile from ) : base( from, m_Info )
		{
			m_Caster = from;
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}
	
		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				m_Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				Mobile from = m_Caster, target = m;

				SpellHelper.Turn( from, target );

				from.FixedParticles( 0x374A, 10, 15, 2038, EffectLayer.Head );

				m.FixedParticles( 0x374A, 10, 15, 5038, EffectLayer.Head );
				m.PlaySound( 0x213 );

				BeginProtect( m, 50 );
			}
			FinishSequence();
		}

		private static Dictionary<Serial, Timer> m_Table = new Dictionary<Serial, Timer>();

		public static bool IsProtected( Mobile m )
		{
			return m_Table.ContainsKey( m.Serial );
		}

		public static void BeginProtect( Mobile m, double duration )
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

			m.SendMessage( "You are now under protection." );
		}

		public static void EndProtect( Mobile m )
		{
			if ( m_Table.ContainsKey( m.Serial ) )
			{
				Timer t = m_Table[m.Serial];

				if ( t != null )
					t.Stop();

				m_Table.Remove( m.Serial );
			}

			m.SendMessage( "You are no longer under protection." );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile m, double duration ) : base( TimeSpan.FromSeconds( duration ) )
			{
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				EndProtect( m_Mobile );
			}
		}

		private class InternalTarget : Target
		{
			private ProtectSpell m_Owner;

			public InternalTarget( ProtectSpell owner ) : base( 12, false, TargetFlags.Beneficial )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}