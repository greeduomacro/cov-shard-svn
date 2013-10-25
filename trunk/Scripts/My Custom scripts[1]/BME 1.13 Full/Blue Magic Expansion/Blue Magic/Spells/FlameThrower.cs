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
	[Description( "Level: 5<br>Duration: Instantaneous<br>Target: Line<br>The caster shoots a wide line of fire burning everything in it's path." )]
	public class FlameThrowerSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"FlameThrower", "", 230 );

		public override int PowerLevel{ get{ return 5; } }
		public override int Range{ get{ return GetRange(); } }
		public override SpellType BlueSpellType{ get{ return SpellType.WideLine; } }

		public FlameThrowerSpell( Mobile from ) : base( from, m_Info )
		{
		}

		private int GetRange()
		{
			if ( Caster != null )
				return (int)Caster.Skills[CastSkill].Value / 20;
			else
				return 5;
		}

		public override void SpellEffect( Mobile target )
		{
			SpellHelper.Damage( this, target, GetDamage( Caster, target, DamageSkill, 2.3 ), 0, 100, 0, 0, 0 );
			BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
		}

		public override void VisualEffects( Point3D point )
		{
			Effects.SendLocationParticles( EffectItem.Create( point, Caster.Map, EffectItem.DefaultDuration ), 
				0x36BD/*ItemID*/, 1/*Speed*/, 20/*Duration*/, 0/*Hue*/, 0/*RenderMode*/, 0/*Effect*/, 0/*Unknown*/ );
		}
	}
}