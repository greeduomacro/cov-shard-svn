// Created by Peoharen
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 1<br>Duration: Combat<br>Target: Combat<br>You copy the wild swings of the goblins and aim at your opponent's vitals adding a random multiplier to your damage." )]
	public class GoblinPunchMove : BlueMove
	{
		public override int BaseMana{ get{ return 10; } }
		public override double RequiredSkill{ get{ return 50.0; } }

		public GoblinPunchMove()
		{
		}

		public override bool ValidatesDuringHit { get { return true; } }

		public override int GetAccuracyBonus( Mobile attacker )
		{
			return 20;
		}

		public override double GetDamageScalar( Mobile attacker, Mobile defender )
		{
			if ( GetContext( attacker, typeof( BlueMagic.GoblinPunchMove ) ) )
			{
				// Returns 0.5~2.5
				double punchbonus = 0.5;
				punchbonus += Utility.RandomDouble(); // +0.0~1.0
				punchbonus += Utility.RandomDouble(); // +0.0~1.0

				return punchbonus;
			}

			return 1.0;
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			ClearCurrentMove( attacker );

			BlueMageControl.CheckKnown( defender, this, CanTeach( attacker ) );
			CheckGain( attacker );

			attacker.SendMessage("You make a wild swing and hit your foe with it.");
			defender.SendMessage("You were hit by a wild swing.");
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			ClearCurrentMove( attacker );
			SetContext( attacker );
		}
	}
}