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
	[Description( "Level: 3<br>Duration: Instantaneous<br>Target: Enemy<br>Halves the HP total of a target (max 150hp loss), no damage rights given." )]
	public class DemiSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Demi", "", 230 );

		public override int PowerLevel{ get{ return 3; } }

		public DemiSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override TimeSpan GetCastDelay()
		{
			return TimeSpan.FromSeconds( 1.25 );
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				if ( target is BaseChampion || target is BasePeerless )
					return;

				int amount = target.Hits / 2;

				if ( amount >= 100 && Caster.AccessLevel == AccessLevel.Player )
					amount = 100;

				target.Hits -= amount;

				Caster.MovingEffect( target, 0xF62, 15, 1, false, false, 1, 0 );
				Caster.MovingEffect( target, 0x3660, 15, 1, false, false, 1, 0 );

				target.SendMessage("You feel your life force being pulled away.");
				target.PlaySound( 0x5C8 );

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}
	}
}