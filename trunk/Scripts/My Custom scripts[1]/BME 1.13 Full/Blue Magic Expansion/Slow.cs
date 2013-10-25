// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server
{
	public class Slow
	{
		public static void SlowWalk( Mobile m, int duration )
		{
			if ( m.NetState != null )
			{
				m.Send( SpeedControl.WalkSpeed );
				new EndSlowWalkTimer( m, DateTime.Now + TimeSpan.FromSeconds( duration ) ).Start();
			}
			else if ( m is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)m;
				bc.ActiveSpeed += 0.4;
				bc.PassiveSpeed += 0.4;
				new EndSlowWalkTimer( m, DateTime.Now + TimeSpan.FromSeconds( duration ) ).Start();

				//m.SendMessage( m.GetType().ToString() );
			}
		}

		public class EndSlowWalkTimer : Timer
		{
			private DateTime m_When;
			private Mobile m_Mobile;

			public EndSlowWalkTimer( Mobile m, DateTime when ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_When = when;
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				if ( DateTime.Now > m_When )
				{
					if ( m_Mobile != null )
					{
						if ( m_Mobile.NetState != null )
							m_Mobile.Send( SpeedControl.Disable );
						else if ( m_Mobile is BaseCreature )
						{
							BaseCreature bc = (BaseCreature)m_Mobile;
							bc.ActiveSpeed -= 0.4;
							bc.PassiveSpeed -= 0.4;
						}
					}

					Stop();
				}
			}
		}
	}
}