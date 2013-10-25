// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Spells
{
	public class BlueMove : SpecialMove
	{
		public virtual string Description{ get{ return ""; } }

		public override SkillName MoveSkill{ get{ return SkillName.Forensics; } }

		public override bool ValidatesDuringHit { get { return false; } }

		public override bool OnBeforeSwing( Mobile attacker, Mobile defender )
		{
			if ( CheckMana( attacker, true ) )
			{
				Item righthand = attacker.FindItemOnLayer( Layer.OneHanded );
				Item lefthand = attacker.FindItemOnLayer( Layer.TwoHanded );

				if ( lefthand is BaseWeapon )
					righthand = lefthand;

				if ( righthand is IBlueWeapon )
					return true;

				if ( righthand != null )
					attacker.SendMessage( "You must be fighting unarmed to use this attack." );
				else
					return true;
			}

			return false;
		}

		public static bool CanTeach( Mobile m )
		{
			return m.AccessLevel == AccessLevel.Player & m.Player == false; //& ( m.Skills[SkillName.Forensics].Value - RequiredSkill > 10.0 );
		}

		public static double ScaleBySkill( Mobile from, SkillName skill )
		{
			if ( from == null )
				return 0.0;

			double bonus = (from.Skills[skill].Value > 100.0) ? 0.5 : 0.0;

			return ((from.Skills[skill].Value * 0.2) + bonus);
		}

	}
}
		/*
		public override bool IgnoreArmor( Mobile attacker )
		{
			double mr = attacker.Skills[SkillName.MagicResist].Value;

			double criticalChance = (mr * mr) / 72000.0;

			return ( criticalChance >= Utility.RandomDouble() );
		}
		*/