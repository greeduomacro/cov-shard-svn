// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server
{
	public partial class MonkCombos
	{
		// Touch of Despair
		// This strike causes and enemy to take half healing from positive energy, reduces 
		// fortification by 25%, and causes the opponent to take 25% more damage from 
		// negative energy for 60 seconds. A successful Fortitude save negates this effect.
		public static void DarkCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: Touch Of Despair" );
			// Doesn't work :p
			target.SendMessage( 2075, "You are hit with overwhelming despair." );
			target.PlaySound( 0x654 );
		}

		// Falling Star Strike
		// Target is blinded for 60 seconds. Periodic fortitude saves to negate.
		public static void DarkAirCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: Falling Star Strike" );

			object[] objs =
			{
				AosAttribute.DefendChance, -25
			};

			new EnhancementTimer( target, 10, "monk", objs ).Start();
			target.SendMessage( 2075, "Your opponent's punch makes you see stars: Defend -25%." );
			target.PlaySound( 0x591 );
		}

		// Pain Touch
		// Target is nauseated for 60 seconds. Periodic fortitude saves to negate.
		public static void DarkEarthCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: Pain Touch" );

			object[] objs =
			{
				AosAttribute.BonusStr, -10,
				AosAttribute.BonusDex, -10,
				AosAttribute.BonusInt, -10
			};

			new EnhancementTimer( target, 60, "monk", objs ).Start();
			target.SendMessage( 2075, "Your body is wracked with pain: All Stats -10." );
		}

		// Karmic Strike
		// The attack is automatically a critical threat, but then next strike on you 
		// for 3 seconds will also be a critical. Unknown if Fortification applies. 
		public static void DarkFireCombo( Mobile from, Mobile target, ref int damage )
		{
			from.SendMessage( 2075, "You execute the maneuver: Karmic Strike" );
			damage = (int)(damage * 1.5 );

			object[] objs =
			{
				AosWeaponAttribute.ResistPhysicalBonus, -100,
				AosWeaponAttribute.ResistFireBonus, -100,
				AosWeaponAttribute.ResistColdBonus, -100,
				AosWeaponAttribute.ResistPoisonBonus, -100,
				AosWeaponAttribute.ResistEnergyBonus, -100
			};

			new EnhancementTimer( from, 5, "monk", objs ).Start();
			from.AddSkillMod( new TimedSkillMod( SkillName.MagicResist, true, -100, TimeSpan.FromSeconds( 5 ) ) );
			target.SendMessage( 2075, "Your opponent's blow hits a vital area maximizing their damage but leaves them wide open." );
			target.PlaySound( 0x234 );
		}

		// Freezing The Lifeblood
		// Your attack paralyzes a humanoid and making them helpless for 60 seconds.
		// A successful fortitude save negates this effect. This target periodically 
		// makes a save to attempt to break free of this effect.
		public static void DarkWaterCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: Freezing The Lifeblood" );
			target.Paralyze( TimeSpan.FromSeconds( 15 ) );
			target.SendMessage( 2075, "Your opponent's blow cuts you with a chilling blow." );
			target.PlaySound( 0x21A );
		}

	}
}