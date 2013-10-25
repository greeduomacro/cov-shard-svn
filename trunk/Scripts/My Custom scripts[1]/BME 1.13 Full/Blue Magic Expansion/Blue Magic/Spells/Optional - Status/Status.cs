// Created by Peoharen.
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server
{
	public class Status
	{
		// Before setting this to true you need to edit disto files.
		public static bool Enabled = false;

		// amount = the damage the mobile will take after all other factors
		public static int PlayerOnDamage( Mobile taker, Mobile damager, int amount )
		{
			if ( ShieldSpell.IsShielded( taker ) )
			{
				if ( taker.Mana <= 10 )
				{
					taker.Mana = 0;
					ShieldSpell.EndShield( taker );
				}
				else if ( amount > 10 )
				{
					taker.Mana -= 10;
					amount -= 10;
					taker.SendMessage( "Your shield prevented some of the damage." );
				}
			}

			if ( TempHP.Has( taker ) > 0 )
				amount = TempHP.Damage( taker, amount );

			return amount;
		}

		// amount = the damage the mobile will take after all other factors
		public static int CreatureOnDamage( Mobile taker, Mobile damager, int amount )
		{
			if ( ShieldSpell.IsShielded( taker ) )
			{
				if ( taker.Mana <= 10 )
				{
					taker.Mana = 0;
					ShieldSpell.EndShield( taker );
				}
				else if ( amount > 10 )
				{
					taker.Mana -= 10;
					amount -= 10;
					taker.SendMessage( "Your shield prevented some of the damage." );
				}
			}

			if ( TempHP.Has( taker ) > 0 )
				amount = TempHP.Damage( taker, amount );

			return amount;
		}




//<**Magic**>
		// damage = amount before BaseCreature's AlterSpellDamage To/From alterations
		public static double SpellDamage( Mobile from, Mobile target, double damage )
		{
			if ( ShellSpell.IsShelled( target ) )
			{
				damage *= 0.5;
				target.FixedEffect( 0x3660 /*itemid*/, 1 /*speed*/, 15 /*duration*/, 1167 /*hue*/, 4 /*renderMode*/ );
			}
				
			return damage;
		}

		// true means check the rest of OnCast, false means they fail to cast.
		public static bool OnCast( Mobile m, Type spell )
		{
			if ( SilenceSpell.IsSilenceed( m ) )
			{
				if ( m is PlayerMobile )
					m.Say("...");

				return false;
			}
			else if ( DragonForceSpell.DragonList.ContainsKey( m ) && spell != typeof( DragonForceSpell ) )
			{
				m.SendMessage( "You cannot cast spells while under the effects of Dragon Force" );
				return false;
			}
			else
				return true; //true means go ahead and cast.
		}

		// works with the final delay value, which is then / CastRecoveryPerSecond(4) and used as the seconds to delay by
		public static double CastRecovery( Mobile from, double total )
		{
			if ( HasteSpell.IsHasteed( from ) )
				total *= 0.5;

			if ( SlowSpell.IsSlowed( from ) )
				total *= 1.5;

			return total;
		}

		// as FC points
		public static int CastDelay( Mobile from, int fc )
		{
			if ( HasteSpell.IsHasteed( from ) )
				fc += 2;

			if ( SlowSpell.IsSlowed( from ) )
				fc -= 2;

			return fc;
		}




//<**Melee**>
		// works like HCI, etc.
		public static int Hit( Mobile attacker )
		{
			int total = 0;

			if ( HasteSpell.IsHasteed( attacker ) )
				total += 20;

			if ( SlowSpell.IsSlowed( attacker ) )
				total -= 20;

			if ( BlindSpell.IsBlinded( attacker ) )
				total -= 50;
				
			return total;
		}

		// works like DCI, etc.
		public static int Dodge( Mobile defender )
		{
			int total = 0;

			if ( HasteSpell.IsHasteed( defender ) )
				total += 20;

			if ( SlowSpell.IsSlowed( defender ) )
				total -= 20;

			if ( BlindSpell.IsBlinded( defender ) )
				total -= 50;
				
			return total;
		}

		// works like SSI, uncapped
		public static int SwingDelay( Mobile m )
		{
			int total = 0;
			//DivineFurySpell gives +10.

			if ( HasteSpell.IsHasteed( m ) )
				total += 12;

			if ( SlowSpell.IsSlowed( m ) )
				total -= 12;

			return total;
		}

		// work as DI, uncapped
		public static int WeaponDamage( Mobile attacker, Mobile defender, int damage )
		{
			if ( ProtectSpell.IsProtected( defender ) )
			{
				damage /= 2;
				defender.FixedEffect( 0x3660 /*itemid*/, 1 /*speed*/, 15 /*duration*/, 1166 /*hue*/, 4 /*renderMode*/ );
			}

			return damage;
		}

		// ML install alters how this works. Instead of Slayer giving *2.0 and enemy of one giving *1.5
		// it instead increases an integer by; slayer +100, eoo +100.
		// works with percentage bonus, this called after the +300 cap
		public static int WeaponDamageBonus( Mobile attacker, Mobile defender )
		{
			int total = 0;

			return total;
		}




//<**Regen**>
		// works like HP regen, ignores cap
		public static int HitsRegen( Mobile m )
		{
			int total = 0;

			return total;
		}

		// works like stam regen, ignores cap
		public static int StamRegen( Mobile m )
		{
			int total = 0;

			return total;
		}

		// works like mana regen, ignores cap
		public static int ManaRegen( Mobile m )
		{
			int total = 0;

			return total;
		}
	}
}
// target.FixedEffect( int itemID, int speed, int duration, int hue, int renderMode )