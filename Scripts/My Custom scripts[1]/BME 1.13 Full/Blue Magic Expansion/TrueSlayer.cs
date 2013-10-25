//Created by Peoharen
using System;
using Server.Mobiles;

namespace Server
{
	public class TrueSlayer
	{
		#region Dragon
		private static int[] DragonBodies = new int[]
		{
			60, 61, // Drake
			46, // Ancient Wyrm
			197, // Crimson Dragon
			447, // SeaSerpent/DeepSeaSerpent
			12, 59, // Dragon
			77, // Kraken/Leviathan
			106, // Shadow Dragon
			104, // Skeletal Dragon
			180, 49, // White Wyrm
			172, // Rikktor
			197, // Order Dragon
			198, // Chaos Dragon
			718, // Fairy Dragon
			719, // Wolf Dragon?
			826 // Stygian Dragon
		};

		public static bool IsDragon( Mobile m )
		{
			for ( int i = 0; i < DragonBodies.Length; i++ )
			{
				if ( m.Body == DragonBodies[i] )
					return true;
			}

			return false;
		}
		#endregion

		#region Undead
		private static int[] UndeadBodies = new int[]
		{
			3, // Zombie
			24, // Lich
			26, // Ghost
			50, // Skeleton
			56, // Skeleton has an axe
			57, // Skeleton has a sword & sheild
			78, // Lich
			79, // Anicent Lich
			82, // Lich Lord
			147, // Skeleton Knight
			148, // Skeleton Mage
			153, // Ghoul
			154, // Mummy
			155, // Rotting Corpse
			304, // Flesh Golem
			308, // Bone Demon
			309, // Patch Skeleton
			310, // Wailing Banshee
			318, // Demon Knight
			747, // Banshe
			748, // Ghost
			793 // Skeletal Mount
		};

		public static bool IsUndead( Mobile m )
		{
			for ( int i = 0; i < UndeadBodies.Length; i++ )
			{
				if ( m.Body == UndeadBodies[i] )
					return true;
			}

			return false;
		}
		#endregion
	}
}


