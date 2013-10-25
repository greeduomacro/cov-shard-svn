// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines;
using Server.Engines.PartySystem;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server
{
	public partial class MonkCombos
	{

		// Healing Ki
		// Activate to heal all nearby allies for 1d4 (1 to 4), plus an additional 
		// 1d4 (1 to 4) for every two monk levels. (Does not harm undead)
		public static void LightCombo( Mobile from )
		{
			from.SendMessage( 2075, "You execute the maneuver: Healing Ki" );

			List<Mobile> mobiles = new List<Mobile>();

			foreach ( Mobile m in from.GetMobilesInRange( 4 ) )
			{
				if ( m != null )
					if ( NotorietyHandlers.Mobile_AllowBeneficial( from, m ) )
						mobiles.Add( m );
			}

			MonkFists mf = from.FindItemOnLayer( Layer.Gloves ) as MonkFists;
			int amount = 0;	

			if ( mf != null )
				amount = Utility.Dice( mf.Teir, 3, (3 * mf.Teir) );
			else
				amount = Utility.Dice( 2, 6, 0 );

			for ( int i = 0; i < mobiles.Count; i++ )
			{
				mobiles[i].FixedParticles( 0x3967, 10, 30, 5013, 36, 4, EffectLayer.CenterFeet, 0 );
				mobiles[i].Heal( amount, from );
			}

			if ( from.Female )
				from.PlaySound( 0x339 );
			else
				from.PlaySound( 0x44B );
		}

		// Dance of Clouds
		// Activate to grant all nearby allies 20% concealment for 60 seconds.
		public static void LightAirCombo( Mobile from )
		{
			from.SendMessage( 2075, "You execute the maneuver: Dance Of The Clouds" );

			Party p = Party.Get( from );

			object[] objs =
			{
				AosAttribute.DefendChance, 25
			};

			if ( p == null )
			{
				from.SendMessage( 2075, "Monk Boost: +25% defense" );
				from.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
				new EnhancementTimer( from, 15, "monk", objs ).Start();
				return;
			}

			for ( int i = 0; i < p.Members.Count; ++i )
			{
				if ( !(p.Members[i].Mobile.InRange( from, 10 )) )
					continue;

				p.Members[i].Mobile.SendMessage( 2075, "Monk Boost: +25% defense" );
				p.Members[i].Mobile.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
				new EnhancementTimer( p.Members[i].Mobile, 60, "monk", objs ).Start();
				p.Members[i].Mobile.PlaySound( 0x28F );
			}
		}


		// Grasp the Earth Dragon
		// Activate to grant all nearby allies become immunity to daze, 
		// stun, and sleep for 30 seconds.
		public static void LightEarthCombo( Mobile from )
		{
			from.SendMessage( 2075, "You execute the maneuver: Grasp Of The Dragon" );

			Party p = Party.Get( from );

			object[] objs =
			{
				AosWeaponAttribute.ResistPhysicalBonus, 5,
				AosWeaponAttribute.ResistFireBonus, 5,
				AosWeaponAttribute.ResistColdBonus, 5,
				AosWeaponAttribute.ResistPoisonBonus, 5,
				AosWeaponAttribute.ResistEnergyBonus, 5
			};

			if ( p == null )
			{
				from.SendMessage( 2075, "Monk Boost: Resist All +5" );
				from.FixedParticles( 0x374A, 10, 30, 5013, 1191, 2, EffectLayer.Waist );
				new EnhancementTimer( from, 60, "monk", objs ).Start();
				return;
			}

			for ( int i = 0; i < p.Members.Count; ++i )
			{
				if ( !(p.Members[i].Mobile.InRange( from, 10 )) )
					continue;

				p.Members[i].Mobile.SendMessage( 2075, "Monk Boost: Resist All +5" );
				p.Members[i].Mobile.FixedParticles( 0x374A, 10, 30, 5013, 1191, 2, EffectLayer.Waist );
				new EnhancementTimer( p.Members[i].Mobile, 60, "monk", objs ).Start();
				p.Members[i].Mobile.PlaySound( 0x457 );
			}
		}

		// Walk of the Sun
		// Activate to grant nearby allies gain a +2 morale bonus to attack, saves, 
		// and skills for 60 seconds.
		public static void LightFireCombo( Mobile from )
		{
			from.SendMessage( 2075, "You execute the maneuver: Walk Of The Sun" );

			Party p = Party.Get( from );

			object[] objs =
			{
				AosAttribute.BonusStr, 10,
				AosAttribute.BonusDex, 10,
				AosAttribute.BonusInt, 10
			};

			if ( p == null )
			{
				from.SendMessage( 2075, "Monk Boost: All Stats +10" );
				from.FixedParticles( 0x374A, 10, 30, 5013, 1160, 2, EffectLayer.Waist );
				new EnhancementTimer( from, 60, "monk", objs ).Start();
				return;
			}

			for ( int i = 0; i < p.Members.Count; ++i )
			{
				if ( !(p.Members[i].Mobile.InRange( from, 10 )) )
					continue;

				p.Members[i].Mobile.SendMessage( 2075, "Monk Boost: All Stats +10" );
				p.Members[i].Mobile.FixedParticles( 0x374A, 10, 30, 5013, 1160, 2, EffectLayer.Waist );
				new EnhancementTimer( p.Members[i].Mobile, 60, "monk", objs ).Start();
				p.Members[i].Mobile.PlaySound( 0x30A );
			}
		}

		// Aligning the Heavens
		// Activate to reduce the spell point costs of all nearby 
		// allies by a 25% for 60 Seconds.
		public static void LightWaterCombo( Mobile from )
		{
			from.SendMessage( 2075, "You execute the maneuver: Aligning the Heavens" );

			Party p = Party.Get( from );

			object[] objs =
			{
				AosAttribute.LowerManaCost, 25
			};

			if ( p == null )
			{
				from.SendMessage( 2075, "Monk Boost: Mana Cost -25%" );
				from.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
				new EnhancementTimer( from, 15, "monk", objs ).Start();
				return;
			}

			for ( int i = 0; i < p.Members.Count; ++i )
			{
				if ( !(p.Members[i].Mobile.InRange( from, 10 )) )
					continue;

				p.Members[i].Mobile.SendMessage( 2075, "Monk Boost: Mana Cost -25%" );
				p.Members[i].Mobile.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
				new EnhancementTimer( p.Members[i].Mobile, 60, "monk", objs ).Start();
				p.Members[i].Mobile.PlaySound( 0x4D2 );
			}
		}

	}
}