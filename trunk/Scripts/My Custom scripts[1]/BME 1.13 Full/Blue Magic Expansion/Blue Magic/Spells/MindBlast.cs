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
	[Description( "Level: 4<br>Duration: Instantaneous<br>Target: Enemy<br>Numbs the target's mind with a mental shockwave. Drains the target's intelligence & focus, the more spellcasting skills they have the greater the effect." )]
	public class MindBlastSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"MindBlast", "", 230 );

		public override int PowerLevel{ get{ return 4; } }

		public MindBlastSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				if ( target.GetStatMod( "MindBlast" ) == null )
				{
					int offset = (int)(target.Skills[SkillName.Magery].Value / 2);
					offset += (int)(target.Skills[SkillName.Necromancy].Value / 2);
					offset += (int)(target.Skills[SkillName.EvalInt].Value / 4);
					offset += (int)(target.Skills[SkillName.SpiritSpeak].Value / 4);

					if ( target is PlayerMobile )
						offset /= 2;

					offset -= ((int)ScaleBySkill( target, SkillName.MagicResist )) -5;

					if ( offset < 15 )
						offset = 15;

					int duration = (int)(Caster.Skills[CastSkill].Value * 2);

					target.AddStatMod( new StatMod( StatType.Int, "MindBlast", -offset, TimeSpan.FromSeconds( duration ) ) );
					target.AddSkillMod( new TimedSkillMod( SkillName.Meditation, true, -offset, TimeSpan.FromSeconds( duration ) ) );
					target.AddSkillMod( new TimedSkillMod( SkillName.Focus, true, -offset, TimeSpan.FromSeconds( duration ) ) );

					target.SendMessage("Your mind has been blown!");

					SpellHelper.Damage( this, target, offset * 2, 0, 0, 100, 0, 0 );
				}

				target.FixedParticles( 0x374A, 10, 15, 5038, 1181, 2, EffectLayer.Head );
				target.PlaySound( 0x213 );
				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}
	}
}