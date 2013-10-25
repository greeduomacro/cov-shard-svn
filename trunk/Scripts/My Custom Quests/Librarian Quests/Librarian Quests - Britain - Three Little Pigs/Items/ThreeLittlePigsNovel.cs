using System;
using Server;

namespace Server.Items
{
	public class ThreeLittlePigsNovel : BlueBook
	{
		[Constructable]
		public ThreeLittlePigsNovel() : base( "Three Little Pigs", "Keja Mimi", 15, false )
		{
		Hue = 30;
			Pages[0].Lines = new string[]

				 {

				"Once Upon a Time there",
				"were Three Little Pigs.",
				"When they grew up and",
				"left home, each Little Pig",
				"decided to build himself a",
				"house.",
				"The First Little Pig ",
				"looked and looked for",

						  };

			Pages[1].Lines = new string[]
				 {
			  "something to build his",
			  "house with. When he",
			  "saw a field full of straw",
			  "he thought that was just",
			  "the thing. Soon his",
			  "house was finished and",
			  "the Little Pig was ",
			  "celebrating. Along came",
						  };


			Pages[2].Lines = new string[]
				 {
				"the Big Bad Wolf and he",
				"saw the Little Pig enter",
				"the house of straw. The",
				"Big Bad Wolf knocked on",
				"the door and said, 'Little",
				"Pig, Little Pig, Let me",
				"in!' ",
				"The Little Pig said, 'Not",

						  };


			Pages[3].Lines = new string[]
			 {
				  "by the hair of my chinny",
				  "chin chin.' That made",
				  "the Big Bad Wolf mad so",
				  "he said, 'Then I'll huff",
				  "and I'll puff and I'll blow",
				  "your house down!",
				  "So the Big Bad Wolf",
				  "huffed and puffed and",

						 };

			Pages[4].Lines = new string[]
				{
					"the house of straw",
					"collapsed.Then the Big",
					"Bad Wolf ate up the",
					"Little Pig. ",
					"Down the road the Second",
					"Little Pig had searched to",
					"find something to build",
					"his house with.",

						 };

			Pages[5].Lines = new string[]
			{
				"In the forest he found",
				"some sticks and gathered",
				"them up. Soon the Little",
				"Pig had a house made out",
				"of sticks. The Little Pig",
				"was celebrating but soon",
				"along came the Big Bad",
				"Wolf.",

						 };


			Pages[6].Lines = new string[]
				 {
				"The Big Bad Wolf",
				"knocked on the door and",
				"said, 'Little Pig, Little",
				"Pig, Let me in!'",
				"'Not by the hair of my",
				"chinny chin chin,' said the",
				"Second Little Pig.",
				"'Then I'll huff and I'll",

						 };

			Pages[7].Lines = new string[]
				 {
				"puff and I'll blow your",
				"house in!' said the Big",
				"Bad Wolf.",
				"So he huffed and puffed",
				"and the house of sticks",
				"fell apart. Then the",
				"Big Bad Wolf ate up the",
				"Second Little Pig.",

						 };


			Pages[8].Lines = new string[]
				 {
			  "Down the road the Third",
			  "Little Pig had been busy",
			  "building his own house.",
			  "After looking around the",
			  "Little Pig had found a",
			  "man with a wagon full of",
			  "bricks. Soon the Little",
			  "Pig had built himself a",
						 };

			Pages[9].Lines = new string[]
				 {
			  "strong house of bricks.",
			  "The Third Little Pig was",
			  "celebrating when along",
			  "came the Big Bad Wolf.",
			  "The Big Bad Wolf said",
			  "'Little Pig, Little Pig,",
			  "Let me in!",
			  "But the Third Little Pig",
						 };

			Pages[10].Lines = new string[]
			 {
			  "said, 'Not by the hair of",
			  "my chinny chin chin!'",
			  "'Then I'll huff and I'll",
			  "puff and I'll blow your",
			  "house in!' said the Big",
			  "Bad Wolf.",
			  "So the Big Bad Wolf",
			  "huffed and the Big Bad",
						 };

			 Pages[11].Lines = new string[]
			 {
			  "Wolf puffed. But nothing",
			  "happened. So the Big Bad",
			  "Wolf huffed harder. And",
			  "the Big Bad Wolf puffed",
			  "harder. But still",
			  "nothing happened.",
			  "So the Big Bad Wolf",
			  "decided he would slide",
						 };

			Pages[12].Lines = new string[]
			 {

			  "down the chimney and get.",
			  "the Third Little Pig. But,",
			  "while he was climbing onto",
			  "the roof, the Little Pig",
			  "heard him and put a kettle",
			  "of boiling water over the",
			  "fire in the fireplace.",
			  "When the Big Bad Wolf",
						 };

            Pages[13].Lines = new string[]
             {

                 "slid down the chimney he",
                 "fell right into the big",
                 "pot of boiling water.",
                 "Then the Third Little Pig",
                 "got a sharp knife and",
                 "freed his brothers from",
                 "the stomach of the Big",
                 "Bad Wolf.",
                          };

			 Pages[14].Lines = new string[]
			 {

			  "And the Three Little",
			  "Pigs lived Happily Ever",
			  "After in the house of.",
			  "bricks.",
			  "",
			  "",
			  "      The End       ",


						 };

		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( "Three Little Pigs" );
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, "Three Little Pigs" );
		}

		public ThreeLittlePigsNovel( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
