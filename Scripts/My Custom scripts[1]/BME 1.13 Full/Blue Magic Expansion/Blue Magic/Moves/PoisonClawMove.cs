// Created by Peoharen
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 5<br>Duration: Combat<br>Target: Combat<br>Poison sweats out of your hands allowing you to infect the target with a deadly poison." )]
	public class PoisonClawMove : BlueMove
	{
		public override int BaseMana{ get{ return 17; } }
		public override double RequiredSkill{ get{ return 55.0; } }

		public PoisonClawMove()
		{
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			ClearCurrentMove( attacker );

			if ( Utility.RandomDouble() > 0.15 ) //15% fail chance
			{
				int level;
				int total = (int)attacker.Skills[MoveSkill].Value;
				total += (int)attacker.Skills[SkillName.MagicResist].Value / 2;
				total /= 2;

				if ( total > 82 ) // 105 Forensics & 120 MagicResist or better
					level = 4; // Lethal
				else if ( total > 74 ) // GM Forensics & MagicResist
					level = 3; // Deadly
				else if ( total > 60 ) // 80 in Forensics & MagicResist
					level = 2; // Greater
				else if ( total > 36 ) // 50.0 in Forensics & MagicResist
					level = 1; // Regular
				else
					level = 0; // Lesser

				defender.ApplyPoison( attacker, Poison.GetPoison( level ) );
			}
			else
			{
				ClearCurrentMove( attacker );
				SetContext( attacker );
				attacker.SendMessage("Your claw attack failed. You prepare to strike again...");
				return;
			}

			BlueMageControl.CheckKnown( defender, this, CanTeach( attacker ) );
			CheckGain( attacker );

			attacker.SendMessage("You poison your opponent with a deadly claw attack.");
			defender.SendMessage("You were poisoned by your opponent's claws");
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			ClearCurrentMove( attacker );
			SetContext( attacker );
		}
	}
}