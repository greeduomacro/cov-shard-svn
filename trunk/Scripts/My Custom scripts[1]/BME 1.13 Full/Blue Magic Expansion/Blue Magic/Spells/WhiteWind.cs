// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 6<br>Duration: Instantaneous<br>Target: Ally, Area 3<br>Heals all friendly creatures in range, amount is based off the caster's current HP." )]
	public class WhiteWindSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"WhiteWind Spell", "", 230 );

		public override int PowerLevel{ get{ return 6; } }
		public override bool IsHarmful{ get{ return false; } }
		public override int Range{ get{ return 3; } }

		public WhiteWindSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			DoAreaEffect( this, target.Location );
		}

		public override void SpellEffect( Mobile m )
		{
			int toheal = 0;
			
			if ( Caster.Hits < 30 )
				toheal = 15;
			else if ( Caster.Hits < 90 )
				toheal = Caster.Hits / 2;
			else
				toheal = 45 + ( Caster.Hits / 10 );

			if ( !( m.Poisoned && !(m == Caster) ) )
			{
				SpellHelper.Heal( toheal, m, Caster );
				m.FixedParticles( 0x376A, 1, 15, 9923, 1153, 3, EffectLayer.Waist );
				m.PlaySound( 0x5C8 );
				BlueMageControl.CheckKnown( m, this, CanTeach( m ) );
			}
		}
	}
}