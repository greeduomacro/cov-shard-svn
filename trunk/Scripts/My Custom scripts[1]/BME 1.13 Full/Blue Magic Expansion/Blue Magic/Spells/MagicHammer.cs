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
	[Description( "Level: 3<br>Duration: Instantaneous<br>Target: Enemy<br>Summons a hammer that strikes the target upside the head halving their mana (max loss is 50)." )]
	public class MagicHammerSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Magic Hammer", "", 230 );

		public override int PowerLevel{ get{ return 3; } }

		public MagicHammerSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				int drain = (target.Mana > 100) ? 50 : (target.Mana/2);
				target.Mana -= drain;

				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( target.X, target.Y, target.Z + 50 ), target.Map ), target, 0xFB4, 7, 0, false, true, 0/*hue?*/, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
				target.FixedParticles( 0x3779, 9, 32, 5030, EffectLayer.Head );
				target.PlaySound( 0x33 );

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}
	}
}