// Created by Peoharen
using System;

namespace Server
{
	public class UWater
	{
		private static int[] Hues =
		{
			// cold enhanced armor
			1361, 1362, 1363, 1364, 1365, 1366, // 1365 is the "standard" blue mage hue.

			// bird blues
			2119, 2120, 2121, 2122, 2123, 2124,

			// slime blues
			2219, 2220, 2221, 2222, 2223, 2224,

			// The light blueish rainbow hues
			2566, 2567, 2568, 

			// The blueish rainbow hues
			2578, 2579, 2580,

			// The dark blueish rainbow hues
			2590, 2591, 2592,

			2714
		};

		public static int RandomHue()
		{
			return Hues[Utility.Random( Hues.Length )];
		}
	}
}