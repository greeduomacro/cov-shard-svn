// Created by Peoharen
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 4<br>Duration: Combat<br>Target: Combat<br>With a very forceful attack you shove your opponent away from you." )]
	public class ThrustKickMove : BlueMove
	{
		public override int BaseMana{ get{ return 10; } }
		public override double RequiredSkill{ get{ return 50.0; } }

		public ThrustKickMove()
		{
		}

		public override int GetAccuracyBonus( Mobile attacker )
		{
			return 10;
		}

		public override double GetDamageScalar( Mobile attacker, Mobile defender )
		{
			return 1.0;
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			attacker.SendMessage("You hit your opponent with a powerful kick.");
			defender.SendMessage("You have been knocked back by your opponent's kick.");

			int dist = (int)(ScaleBySkill( attacker, SkillName.Forensics ) / 4);
			Ability.SlideAway( defender, attacker.Location, (dist > 6) ? 6 : dist );

			BlueMageControl.CheckKnown( defender, this, CanTeach( attacker ) );

			ClearCurrentMove( attacker );
			CheckGain( attacker );
		}
	}
}