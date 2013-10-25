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
	[Description( "Level: 7<br>Duration: (Bonus) Seconds<br>Target: Area 10<br>Darkens the area and puts everyone nearby (including the caster and his allies) to sleep." )]
	public class NightSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Night", "", 230 );

		public override int PowerLevel{ get{ return 7; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Area; } }
		public override int Range{ get{ return 10; } }

		public NightSpell( Mobile from ) : base( from, m_Info )
		{
			//SpellEffect( Caster );
		}

		public override void SpellEffect( Mobile m )
		{
			m.Paralyze( TimeSpan.FromSeconds( ScaleBySkill( Caster, DamageSkill ) ) );

			NetState ns = m.NetState;

			if ( ns != null )
			{
				if ( m.Race == Race.Elf )
					ns.Send( new PersonalLightLevel( m, -66 ) );
				else
					ns.Send( new PersonalLightLevel( m, -56 ) );
			}

			Timer timer = new InternalTimer( m, (int)ScaleBySkill( Caster, DamageSkill ) );
			timer.Start();

			BlueMageControl.CheckKnown( m, this, CanTeach( m ) );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private int m_Count;
			private int m_MaxCount;

			public InternalTimer( Mobile m, int maxcount ) : base( TimeSpan.FromSeconds( 6.0 ), TimeSpan.FromSeconds( 6.0 ) )
			{
				m_Mobile = m;
				m_MaxCount = maxcount / 6;
			}

			protected override void OnTick()
			{
				m_Count++;

				if ( m_Count < m_MaxCount )
				{
					if ( m_Mobile != null )
					{
						if ( m_Mobile.Paralyzed )
						{
							m_Mobile.PlaySound( m_Mobile.Female ? 819 : 1093 );

							m_Mobile.Say( TheZs[Utility.RandomMinMax( 0, 1 )] +
								TheZs[Utility.RandomMinMax( 0, 1 )] +
								TheZs[Utility.RandomMinMax( 0, 1 )] +
								TheZs[Utility.RandomMinMax( 0, 1 )] +
								TheZs[Utility.RandomMinMax( 0, 1 )] );
						}
						else
							DoStop();
					}
					else
						DoStop();
				}
				else
				{
					DoStop();
				}
			}

			protected void DoStop()
			{
				m_Mobile.LightLevel = 0;
				m_Mobile.CheckLightLevels( false );
				Stop();
			}

			private string[] TheZs = { "z", "Z" };
		}
	}
}