// Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level 4 Holy<br>Level: 4<br>Duration: Instantaneous<br>Target: Enemy<br>If the target's skill total can evenly be divided by 4 it deals a massive amount of damage." ) ]
	public class Level4HolySpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Level 4 Holy", "", 269 );

		public override int PowerLevel{ get{ return 4; } }

		public Level4HolySpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				double total = 0.0;
				int skills = 0;

				// Does TotalSkills count temp mods?
				for ( int i = 0; i < target.Skills.Length; ++i )
				{
					if ( target.Skills[i].Value > 0.0 )
					{
						total += target.Skills[i].Value;
						skills++;
					}
				}

				total /= skills;

				if ( (int)total % 4 == 0 )
				{
					int damage = GetDamage( Caster, target, CastSkill, 1.0 ) + GetDamage( Caster, target, DamageSkill, 1.0 );
					SpellHelper.Damage( this, target, damage * 2, 0, 0, 0, 0, 100 );
					BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
				}
				else
				{
					target.FixedParticles( 0x3779, 9, 32, 5030, EffectLayer.Head );
					Caster.PlaySound( 0x5C );
				}
			}

			FinishSequence();
		}
	}
}