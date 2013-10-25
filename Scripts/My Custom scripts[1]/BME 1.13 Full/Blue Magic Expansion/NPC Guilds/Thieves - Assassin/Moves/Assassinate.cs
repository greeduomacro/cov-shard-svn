// Created by Peoharen
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;

namespace Server
{
	public class AssassinateMove : SpecialMove
	{
		public override int BaseMana{ get{ return 10; } }
		public override double RequiredSkill{ get{ return 50.0; } }
		public override SkillName MoveSkill{ get{ return SkillName.Stealth; } }

		public AssassinateMove()
		{
		}

		public override bool ValidatesDuringHit { get { return false; } }

		public override bool IgnoreArmor( Mobile attacker )
		{
			if ( (attacker.Luck / 200) > Utility.Random( 11 ) )
			{
				attacker.SendMessage( "Your attack penetrates their armor." );
				return true;
			}

			return false;
		}

		public override int GetAccuracyBonus( Mobile attacker )
		{
			return 50;
		}

		public override double GetDamageScalar( Mobile attacker, Mobile defender )
		{
			if ( defender.Hits == defender.HitsMax && defender.Warmode == false )
				return 4.0;
			else
				return 1.0;
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			ClearCurrentMove( attacker );

			if ( defender.Hits < damage )
			{
				attacker.SendMessage( "You successfully assassinated your target." );

				if ( defender != null )
					defender.SendMessage( "You were assassinated." );
			}
			//else
			//{
			//	attacker.SendMessage( "You hit your target with a deadly strike." );
			//	defender.SendMessage( "You were hit with a deadly strike." );
			//}

			defender.FixedParticles( 0x3818, 1, 11, 0x13A8, 0, 0, EffectLayer.Waist );
			defender.PlaySound( 0x51D );
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			//ClearCurrentMove( attacker );
			//SetContext( attacker );
		}
	}
}