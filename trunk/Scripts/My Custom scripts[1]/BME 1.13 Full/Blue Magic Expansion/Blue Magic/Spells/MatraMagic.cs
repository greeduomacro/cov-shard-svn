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
	[Description( "Level: 8<br>Duration: Instantaneous<br>Target: Any<br>Creates a strange reversal in the target swaping their mana. Anything that can have more than 500HP is immune.<br><br>Secondary Effect<br>Level: 0<br>Duration: Instantaneous<br>Target: Self<br>The caster can try to sacrifice some of his hit points to enter a meditative trance." )]
	public class MatraMagicSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"MatraMagic", "", 230 );

		public override int PowerLevel{ get{ return 8; } }

		public MatraMagicSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				if ( !(target is BaseChampion || target.HitsMax >= 500) )
				{
					int oldmana = target.Mana;
					int oldhits = target.Hits;

					target.Hits = oldmana;
					target.Mana = oldhits;
				}

				//0xF62 = spear, 0x37B9 = glow, 0x13A7 = pillow
				target.FixedParticles( 0x37B9, 10, 19, 0, 0x501, 0, EffectLayer.LeftFoot );
				target.FixedParticles( 0x37B9, 10, 19, 0, 0x501, 0, EffectLayer.Head );
				target.BoltEffect( 0x35 );
				target.PlaySound( 0x5AA );

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}
	}
}