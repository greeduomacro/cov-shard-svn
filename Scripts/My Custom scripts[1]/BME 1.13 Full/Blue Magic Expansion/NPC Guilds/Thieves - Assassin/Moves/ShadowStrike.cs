using System;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class ShadowStrikeMove : SpecialMove
	{
		public ShadowStrikeMove()
		{
		}

		public override int BaseMana{ get{ return 20; } }
		public override double GetDamageScalar( Mobile attacker, Mobile defender )
		{
			return 1.25;
		}
		public override SkillName MoveSkill{ get{ return SkillName.Stealth; } }

		public override bool CheckSkills( Mobile from )
		{
			if ( !base.CheckSkills( from ) )
				return false;

			Skill skill = from.Skills[SkillName.Stealth];

			if ( skill != null && skill.Value >= 80.0 )
				return true;

			from.SendLocalizedMessage( 1060183 ); // You lack the required stealth to perform that attack

			return false;
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return;

			ClearCurrentMove( attacker );

			attacker.SendLocalizedMessage( 1060078 ); // You strike and hide in the shadows!
			defender.SendLocalizedMessage( 1060079 ); // You are dazed by the attack and your attacker vanishes!

			Effects.SendLocationParticles( EffectItem.Create( attacker.Location, attacker.Map, EffectItem.DefaultDuration ), 0x376A, 8, 12, 9943 );
			attacker.PlaySound( 0x482 );

			defender.FixedEffect( 0x37BE, 20, 25 );

			attacker.Combatant = null;
			attacker.Warmode = false;
			attacker.Hidden = true;
		}
	}
}