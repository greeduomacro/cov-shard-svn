// Created by Peoharen
using System;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 6<br>Duration: Base Spell Damage<br>Target: Enemy<br>Shoots several needles in rapid succession at a target, each one dealing one damage per hit." )]
	public class FiftyNeedlesSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Fifty Needles", "", 230 );

		public override int PowerLevel{ get{ return 6; } }

		public FiftyNeedlesSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				Timer timer = new InternalTimer( Caster, target, GetDamage( Caster, target, DamageSkill, 1.2 ), this );
				timer.Start();

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;
			private Mobile m_To;
			private int m_Count;
			private int m_MaxCount;
			private FiftyNeedlesSpell m_Spell;

			public InternalTimer( Mobile from, Mobile to, int count, FiftyNeedlesSpell spell ) : base( TimeSpan.FromMilliseconds( 50.0 ), TimeSpan.FromMilliseconds( 50.0 ) )
			{
				m_From = from;
				m_To = to;
				m_Spell = spell;

				//I'm claiming fifty, but its more like 35 in 1.75 secounds. ;)
				if ( count > 35 )
					count = 35;

				m_MaxCount = count;
			}

			protected override void OnTick()
			{
				m_Count++;

				if ( m_Count < m_MaxCount )
				{
					if ( m_From != null && m_To != null )
					{
						m_From.MovingEffect( m_To, 0x1BFE, 18, 1, false, false, 1437, 0 );
						SpellHelper.Damage( m_Spell, m_To, 1, 100, 0, 0, 0, 0 );
					}
					else
						Stop();
				}
				else
				{
					Stop();
				}
			}
		}
	}
}