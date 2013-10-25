// Created by Peoharen
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 7<br>Duration: Combat<br>Target: Combat<br>You make a melee attack that is empowered with negative energy. The effect steals your opponent's life force healing you and leaving them weaker than they were." )]
	public class DrainTouchMove : BlueMove
	{
		public override int BaseMana{ get{ return 10; } }
		public override double RequiredSkill{ get{ return 50.0; } }

		public DrainTouchMove()
		{
		}

		public override int GetAccuracyBonus( Mobile attacker )
		{
			return 10;
		}

		public override double GetDamageScalar( Mobile attacker, Mobile defender )
		{
			if ( GetContext( attacker, typeof( BlueMagic.DrainTouchMove ) ) )
				return (ScaleBySkill( attacker, SkillName.MagicResist ) / 6.0 ); // Fists: 1~4. +300% = 12 damage.
			else
				return 1.0;
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			attacker.SendMessage("You drain part of your opponent's life energy");
			defender.SendMessage("You feel part of your life force being stolen away.");

			// Energy Drain it's self heals the user 10 points per negative level as well.
			// attacker.Heal( damage - (damage / 4) ); //75% leech like effect since it deals very little damage.

			if ( attacker is PlayerMobile )
			{
				if ( defender is PlayerMobile )
					Ability.EnergyDrain( attacker, defender, 1, 3, true ); // 1 to stats & skills per hit for 3 minutes.
				else
					Ability.EnergyDrain( attacker, defender, 2, 3, true ); // 2 to stats & skills per hit for 3 minutes.
			}
			else
				Ability.EnergyDrain( attacker, defender, 3, 6, true ); // 3 to stats & skills per hit for 6 minutes.

			BlueMageControl.CheckKnown( defender, this, CanTeach( attacker ) );

			ClearCurrentMove( attacker );
			CheckGain( attacker );
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			ClearCurrentMove( attacker );
			SetContext( attacker );
		}
	}
}