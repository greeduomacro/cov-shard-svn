// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 4<br>Duration: Instantaneous<br>Target: Personal<br>Creates a division that can hide the caster, the caster may then sneak away for a few steps as if they were using stealth." )]
	public class VanishSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Vanish", "", 230 );

		public override int PowerLevel{ get{ return 4; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Self; } }

		public VanishSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void SpellEffect( Mobile target )
		{
			if ( target.Skills[SkillName.Hiding].Value < Utility.Random( 120 ) )
			{
				target.SendMessage( "The spell failed to hide you." );
				return;
			}
			
			for ( int i = -1; i < 2; i++ )
			{
				for ( int j = -1; j < 2; j++ )
				{
					Effects.SendLocationParticles( 
						EffectItem.Create( new Point3D( 
							target.X+i, 
							target.Y+j, 
							target.Z
						), target.Map, EffectItem.DefaultDuration ), 
						0x36BD/*ItemID*/, 1/*Speed*/, 20/*Duration*/, 0/*Hue*/, 0/*RenderMode*/, 0/*Effect*/, 0/*Unknown*/
					);
				}
			}

			target.Warmode = false;
			target.Hidden = true;

			target.AllowedStealthSteps = (int)((Caster.Skills[DamageSkill].Value / 5) / 4); // 6 steps at 120.0
			BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
		}
	}
}