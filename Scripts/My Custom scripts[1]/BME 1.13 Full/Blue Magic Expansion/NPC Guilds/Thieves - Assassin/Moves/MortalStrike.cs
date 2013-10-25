using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class MortalStrikeMove : SpecialMove
	{
		public MortalStrikeMove()
		{
		}

		public override int BaseMana{ get{ return 30; } }
		public override SkillName MoveSkill{ get{ return SkillName.Stealth; } }

		public static readonly TimeSpan PlayerDuration = TimeSpan.FromSeconds( 6.0 );
		public static readonly TimeSpan NPCDuration = TimeSpan.FromSeconds( 12.0 );

		public override void OnHit(Mobile attacker, Mobile defender, int damage)
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return;

			ClearCurrentMove( attacker );

			attacker.SendLocalizedMessage( 1060086 ); // You deliver a mortal wound!
			defender.SendLocalizedMessage( 1060087 ); // You have been mortally wounded!

			defender.PlaySound( 0x1E1 );
			defender.FixedParticles( 0x37B9, 244, 25, 9944, 31, 0, EffectLayer.Waist );

			// Do not reset timer if one is already in place.
			if ( !MortalStrike.IsWounded( defender ) )
				MortalStrike.BeginWound( defender, defender.Player ? PlayerDuration : NPCDuration );
		}
	}
}