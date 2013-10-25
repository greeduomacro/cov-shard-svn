// Created by Peoharen
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 2<br>Duration: Combat<br>Target: Combat<br>You break your brain's limits on muscle control using your endangered state, the closer to death you are the more power your attack becomes." )]
	public class LimitGloveMove : BlueMove
	{
		public override int BaseMana{ get{ return 5; } }
		public override double RequiredSkill{ get{ return 50.0; } }

		public LimitGloveMove()
		{
		}

		public override int GetAccuracyBonus( Mobile attacker )
		{
			return 20;
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			ClearCurrentMove( attacker );

			double diff = (attacker.Hits / attacker.HitsMax);
			diff = 100 - (diff * 100.0);
			int glove = (int)diff;

			switch( Utility.Random( 5 ) )
			{
				case 1: AOS.Damage( defender, attacker, glove, 0, 100, 0, 0, 0 ); break;
				case 2: AOS.Damage( defender, attacker, glove, 0, 0, 100, 0, 0 ); break;
				case 3: AOS.Damage( defender, attacker, glove, 0, 0, 0, 100, 0 ); break;
				case 4: AOS.Damage( defender, attacker, glove, 0, 0, 0, 0, 100 ); break;
				default: AOS.Damage( defender, attacker, glove, 100, 0, 0, 0, 0 ); break;
			}

			BlueMageControl.CheckKnown( defender, this, CanTeach( attacker ) );
			CheckGain( attacker );
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			ClearCurrentMove( attacker );
			SetContext( attacker );
		}
	}
}