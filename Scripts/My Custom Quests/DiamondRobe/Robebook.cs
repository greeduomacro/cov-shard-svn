using System;
using Server;

namespace Server.Items
{
	// books: Brown 0xFEF, Tan 0xFF0, Red 0xFF1, Blue 0xFF2, 
	// OpenSmall 0xFF3, Open 0xFF4, OpenOld 0xFBD, 0xFBE

	public class RobeBook : BaseBook
	{
		private const string TITLE = "Diamond Mastery Robe";
		private const string AUTHOR = "Melbore";
		private const int PAGES = 7;
		private const bool WRITABLE = false;
		
		[Constructable]
		public RobeBook() : base( Utility.RandomList( 0xFEF, 0xFF0, 0xFF1, 0xFF2 ), TITLE, AUTHOR, PAGES, WRITABLE )
		{
			// NOTE: There are 8 lines per page and
			// approx 22 to 24 characters per line.
			//  0----+----1----+----2----+
			int cnt = 0;
			string[] lines;

			lines = new string[]
			{
				"I have begun my work on", 
				"my new Robe. I call it",
				"a Mastery Robe. Strong",
				"and powerful. Also it has",
				"very little weight, good",
				"for a mage. I am finding",
				"that the materials I need",
				"are hard to collect.",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"The only item I found",
				"that I can make work",
				"is a Diamond Shard.",
				"This is a VERY hard",
				"material to work with.",
				"AT LAST! I have a ",
				"finished robe. I find",
				"that 35 shards is",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"going to be what it",
				"takes. this is bad",
				"news. Diamond Golems",
				"are the only source",
				"of these shards. They",
				"are very powerful and",
				"Rare creatures.",
				"",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"I know they spawn in",
				"Wrong. But they are",
				"very very rare. I",
				"will craft these robes",
				"for all who can bring",
				"me these items. for if",
				"they can then they are",
				"truly worthy of a Robe.",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"Do to the rare nature",
				"of these beasts, The",
				"adventurer will not",
				"be flagged as being",
				"on a quest. They can",
				"just gather them over",
				"time and when they ",
				"have enough I will",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"make them there Robe.",
				"",
				"",
				"Plated Diamond Armor",
				"should they want to",
				"wait. I know my ",
				"brother is working",
				"Plate Armor in the",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"way I have been",
				"working on my Robes.",
				"I know it is better",
				"then my robe but much",
				"more costly. His name",
				"is Belmore.",
				"",
				"",
			};
			Pages[cnt++].Lines = lines;

		}

		public RobeBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); 
		}
	}
}