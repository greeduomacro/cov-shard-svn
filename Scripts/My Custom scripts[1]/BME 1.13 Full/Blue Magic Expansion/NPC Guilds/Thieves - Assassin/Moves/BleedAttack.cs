using System;
using System.Collections;
using Server.Mobiles;
using Server.Spells.Necromancy;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class BleedAttackMove : SpecialMove
	{
		public BleedAttackMove()
		{
		}

		public override int BaseMana{ get{ return 30; } }
		public override SkillName MoveSkill{ get{ return SkillName.Stealth; } }

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return;

			ClearCurrentMove( attacker );

			// Necromancers under Lich or Wraith Form are immune to Bleed Attacks.
			TransformContext context = TransformationSpellHelper.GetContext( defender );

			if ( (context != null && ( context.Type == typeof( LichFormSpell ) || context.Type == typeof( WraithFormSpell ))) ||
				(defender is BaseCreature && ((BaseCreature)defender).BleedImmune) )
			{
				attacker.SendLocalizedMessage( 1062052 ); // Your target is not affected by the bleed attack!
				return;
			}

			attacker.SendLocalizedMessage( 1060159 ); // Your target is bleeding!
			defender.SendLocalizedMessage( 1060160 ); // You are bleeding!

			if ( defender is PlayerMobile )
			{
				defender.LocalOverheadMessage( MessageType.Regular, 0x21, 1060757 ); // You are bleeding profusely
				defender.NonlocalOverheadMessage( MessageType.Regular, 0x21, 1060758, defender.Name ); // ~1_NAME~ is bleeding profusely
			}

			defender.PlaySound( 0x133 );
			defender.FixedParticles( 0x377A, 244, 25, 9950, 31, 0, EffectLayer.Waist );

			BleedAttack.BeginBleed( defender, attacker, (AosWeaponAttributes.GetValue( attacker, AosWeaponAttribute.BloodDrinker ) != 0) );
		}
	}
}