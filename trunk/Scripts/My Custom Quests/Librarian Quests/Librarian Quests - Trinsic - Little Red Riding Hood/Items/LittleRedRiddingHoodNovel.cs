using System;
using Server;

namespace Server.Items
{
	public class LittleRedRiddingHoodNovel : BlueBook
	{
		[Constructable]
		public LittleRedRiddingHoodNovel() : base( "Red Riding Hood", "Keja Mimi", 14, false )
		{
		Hue = 32;
			Pages[0].Lines = new string[]

				 {

				"Once Upon a Time",
				"there was a little",
				"girl. Her Grandmother",
				"loved her very much",
				"and made her a cape",
				"and hood of bright red",
				"to wear. The hooded",
				"cape looked lovely, and",

						  };

			Pages[1].Lines = new string[]
				 {
			  "the villagers began",
			  "to call her Little",
			  "Red Riding Hood, and",
			  "eventually, people",
			  "forgot that she even",
			  "had another name. One",
			  "day Little Red Riding",
			  "Hood's Grandmother was",
						  };


			Pages[2].Lines = new string[]
				 {
				"sick, and so Little",
				"Red Riding Hood took",
				"a basket her mother",
				"had given her, and",
				"filled it full of",
				"delicious things for",
				"her Grandmother to eat",
				"to help her get well.",

						  };


			Pages[3].Lines = new string[]
			 {
				  "As Little Red Riding",
				  "Hood Walked through",
				  "the forest, a dark",
				  "shadow slinking",
				  "through the brush",
				  "noticed her. When",
				  "Little Red Riding Hood",
				  "stopped to pick some",

						 };

			Pages[4].Lines = new string[]
				{
					"flowers, the wolf",
					"thought to eat her",
					"but he heard her say,",
					"Yes Grandmother will",
					"like these flowers",
					"very much. The wolf,",
					"decided to visit",
					"Grandmother and so eat",

						 };

			Pages[5].Lines = new string[]
			{
				"them both. The wolf",
				"raced ahead to",
				"Grandmothers house",
				"and knocked on the",
				"door. When Grandmother",
				"said Who is there? the",
				"wolf answered It's",
				"Little Red Riding Hood.",

						 };


			Pages[6].Lines = new string[]
				 {
				"I have brought you a",
				"basket full of good",
				"things to eat. When",
				"Grandmother opened the",
				"door, the wolf quickly",
				"gobbled her up.  Then",
				"he put on Grandmothers",
				"nightgown and nightcap",

						 };

			Pages[7].Lines = new string[]
				 {
				"and laid in her bed",
				"waiting for Little",
				"Red Riding Hood to",
				"show up. When Little",
				"Red Riding Hood",
				"arrived at",
				"Grandmother's house,",
				"she went inside, set",

						 };


			Pages[8].Lines = new string[]
				 {
			  "the basket down on",
			  "the table and walked",
			  "to the bed to check",
			  "on her Grandmother.",
			  "In the dim light,",
			  "Little Red Riding Hood",
			  "thought she didn’t",
			  "look quite right...",
						 };

			Pages[9].Lines = new string[]
				 {
			  "Grandmother, what big",
			  "eyes you have...",
			  "Little Red Riding Hood",
			  "said. The better to",
			  "see you with, The",
			  "crafty wolf answered",
			  "in high sweet tones.",
			  "And Grandmother, what",
						 };

			Pages[10].Lines = new string[]
			 {
			  "big hands you have...",
			  "The better to hold",
			  "you with, was the",
			  "wolf's reply.",
			  "Little Red Riding Hood",
			  "peered closer,",
			  "And Grandmother, what",
			  "big teeth you have...",
						 };

			 Pages[11].Lines = new string[]
			 {
			  "The better to eat you",
			  "with! the wolf cried",
			  "and leaped out of bed",
			  "and gobbled up",
			  "Little Red Riding Hood",
			  "as well. Not long",
			  "after a woodsman was",
			  "passing, when he saw",
						 };

			Pages[12].Lines = new string[]
			 {

			  "the wolf leaving",
			  "Grandmothers house,",
			  "fat and happy from",
			  "eating Grandmother and",
			  "Little Red Riding Hood.",
			  "The woodsman shot an",
			  "arrow and killed the",
			  "wolf. He cut open the",
						 };

			 Pages[13].Lines = new string[]
			 {

			  "wolf and there inside",
			  "were Grandmother and",
			  "Little Red Riding Hood.",
			  "",
			  "",
			  
			  "      The End       ",


						 };

		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( "Little Red Riding Hood" );
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, "Little Red Riding Hood" );
		}

		public LittleRedRiddingHoodNovel( Serial serial ) : base( serial )
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