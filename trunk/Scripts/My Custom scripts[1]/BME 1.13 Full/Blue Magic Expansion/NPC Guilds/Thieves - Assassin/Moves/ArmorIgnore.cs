using System;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class ArmorIgnoreMove : SpecialMove
	{
		public ArmorIgnoreMove()
		{
		}

		public override int BaseMana{ get{ return 30; } }
		public override double GetDamageScalar( Mobile attacker, Mobile defender )
		{
			return 0.9;
		}
		public override SkillName MoveSkill{ get{ return SkillName.Stealth; } }

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return;

			ClearCurrentMove( attacker );

			attacker.SendLocalizedMessage( 1060076 ); // Your attack penetrates their armor!
			defender.SendLocalizedMessage( 1060077 ); // The blow penetrated your armor!

			defender.PlaySound( 0x56 );
			defender.FixedParticles( 0x3728, 200, 25, 9942, EffectLayer.Waist );
		}
	}
}