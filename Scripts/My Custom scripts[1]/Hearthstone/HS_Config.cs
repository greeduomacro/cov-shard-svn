using System;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		/***STONE CONFIG***/

		/// <summary>
		/// The default Cool-Down period applied to Hearthstones when created.
		/// </summary>
		public static TimeSpan DefStoneCoolDown = TimeSpan.FromMinutes(360.0);

		/// <summary>
		/// The default Name applied to Hearthstones when created.
		/// </summary>
		public static string DefStoneName = "a  COV Hearthstone";

		/// <summary>
		/// The default ItemID for the Hearthstone when created.
		/// </summary>
		public static int DefStoneItemID = 0x23B;

		/// <summary>
		/// The default Hue of the Hearthstone when created.
		/// </summary>
		public static int DefStoneHue = 33;

		/***SPELL CONFIG***/

		/// <summary>
		/// The default amount of Time it takes to cast the HearthSpell.
		/// </summary>
		public static TimeSpan DefSpellCastDelay = TimeSpan.FromSeconds(5.0);

		/// <summary>
		/// The default amount of mana to consume when casting the HearthSpell.
		/// </summary>
		public static int DefSpellManaCost = 0;

		/// <summary>
		/// The default SpellInfo used when using the HearthSpell.
		/// </summary>
		private static SpellInfo DefSpellInfo = new SpellInfo("Hearth", "Capio Mihi Domus", 239, 9031, true);

		/***VENDOR CONFIG***/

		/// <summary>
		/// The List of Strings that Innkeepers should listen for when being asked to mark a Player's Hearthstone.
		/// </summary>
		public static string[] DefVendorKeyPhrases = new string[]
		{ 
			"enchant my hearthstone",
			"make this place my home",		
		};

		/// <summary>
		/// The default Price of a Hearthstone when sold by Innkeepers.
		/// </summary>
		public static int DefVendorPrice = 0;
	}
}