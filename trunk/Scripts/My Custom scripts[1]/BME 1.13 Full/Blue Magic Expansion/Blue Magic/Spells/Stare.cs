// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 7<br>Duration: (Bonus + 5) Seconds.<br>Target: Enemy<br>A piercing gaze confuses the target. Confused creatures may attack their allies." )]
	public class StareSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Stare", "", 230 );

		public override int PowerLevel{ get{ return 7; } }

		public StareSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				Timer timer = new ConfuseTimer( target, (int)(ScaleBySkill( Caster, DamageSkill ) + 5) );
				timer.Start();
				target.SendMessage("You are confused!");

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}

		public class ConfuseTimer : Timer
		{
			private Mobile m_Mobile;
			private int m_MaxCount;
			private int m_Count;

			public ConfuseTimer( Mobile m, int maxcount ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_MaxCount = maxcount;
				m_Count = 0;
			}

			protected override void OnTick()
			{
				if ( m_Count > m_MaxCount )
				{
					m_Mobile.SendMessage("Your confusion subsides.");
					Stop();
					return;
				}

				Target targ = m_Mobile.Target;

				if ( targ != null )
				{
					List<Mobile> targets = new List<Mobile>();

					foreach ( Mobile m in m_Mobile.GetMobilesInRange( 8 ) )
					{
						if ( m != null )
							targets.Add( m );
					}

					if ( targets.Count > 1 ) //two or more targets
					{
						int number = Utility.RandomMinMax( 0, targets.Count-1 );
						Mobile mobile = targets[number];
						targ.Invoke( m_Mobile, mobile );

						Target.Cancel( m_Mobile );

						m_Mobile.SendMessage("You aim at what appears to be a threat!");
					}

					targets.Clear();
				}

				m_Count++;
			}
		}

	}
}

