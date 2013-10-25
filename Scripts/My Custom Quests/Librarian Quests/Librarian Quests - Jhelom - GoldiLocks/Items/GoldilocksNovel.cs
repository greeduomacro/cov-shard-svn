using System;
using Server;

namespace Server.Items
{
	public class GoldilocksNovel : BlueBook
	{
		[Constructable]
		public GoldilocksNovel() : base( "Goldilocks & 3 Bears", "Keja Mimi",12, false )
		{
		Hue = 1281;
			Pages[0].Lines = new string[]

				 {
			  //“123456789012345678901”
				"Once Upon a Time",
				"A girl came upon a ",
				"tiny cottage when she ",
				"went for a walk in the ",
				"woods. After getting ",
				"no answer to her ",
				"knocking she went ",
				"inside. There was a ",

						  };

			Pages[1].Lines = new string[]
				 {
			  //“123456789012345678901”
				"table all laid out for",
				"breakfast. She was ",
				"hungry so she pulled ",
				"herself up into the ",
				"first chair. It was too ",
				"hard.  She moved to the",
				"chair next to it. It ",
				"was too soft. She moved ",
						  };


			Pages[2].Lines = new string[]
				 {
			  //“123456789012345678901”
				"to the smallest chair. ",
				"It was just right. She ",
				"made herself ",
				"comfortable and took a ",
				"spoon and pulled a bowl ",
				"to her. The porridge ",
				"in the bowl was too hot. ",
				"She burned her mouth. ",

						  };


			Pages[3].Lines = new string[]
			 {
				//“123456789012345678901”
				  "The next bowl she ",
				  "tried had porridge ",
				  "that was clumping. This ",
				  "porridge was too cold. ",
				  "She tried the very last ",
				  "bowl and that porridge ",
				  "was sweet and warm  ",
				  "and creamy. It was just ",

						 };

			 Pages[4].Lines = new string[]
			 {
		   //“123456789012345678901”
			 "right. So Goldilocks",
			 "ate all of the porridge",
			 "and as she finished the",
			 "chair she had been",
			 "sitting on broke! She",
			 "was quite unhurt but",
			 "she was feeling sleepy",
			 "after the warm meal,",
			  };

			Pages[5].Lines = new string[]
				{

				  //“123456789012345678901”
					" so she found three",
					"beds. The first bed ",
					"was too hard. The ",
					"second bed was too ",
					"soft. The third bed ",
					"was just right and it ",
					"was only a moment ",
					"before she fell asleep.",

						 };

			Pages[6].Lines = new string[]
			{

			  //“123456789012345678901”
				"A few minutes later",
				"the owners of the",
				"house came home. It",
				"was the three bears,",
				"Papa Bear, Mama Bear,",
				"and Baby Bear. They",
				"were just returning",
				"for breakfast. Papa ",


						 };


			Pages[7].Lines = new string[]
				 {
			  //“123456789012345678901”
				"Bear noticed his",
				"place and growled",
				"“Someone has been",
				"sitting in my chair",
				"eating my porridge.”",
				"Mama Bear said",
				"“Someone has been",
				"sitting in my chair",


						 };

			Pages[8].Lines = new string[]
				 {
			  //“123456789012345678901”
				"and eating my",
				"porridge.” Baby Bear ",
				"began to cry when he",
				"saw his little chair",
				"broken on the floor, ",
				"“Someone broke my",
				"chair and they ate up",
				"all my porridge! Soon",

				 };


			Pages[9].Lines = new string[]
				 {
			  //“123456789012345678901”
				"the three bears ",
				"noticed their beds.",
				"Papa Bear was angry",
				"when he saw his",
				"blankets on the floor.",
				"Mama Bear was angry",
				"when she saw her ",
				"pillows all tossed off",


						 };

			Pages[10].Lines = new string[]
				 {
		   //“123456789012345678901”
			 "the bed. Baby Bear",
			 "stopped crying and ",
			 "said Someone is",
			 "asleep in my bed!",
			 "Goldilocks woke up ",
			 "and saw the bears,",
			 "she ran screaming",
			 "from the house. The",


						 };

			 Pages[11].Lines = new string[]
				{
             "bears chased her far",
			 "away from their home",
			 "and she never again",
			 "went into a strange",
			 "house.",
			  "",
			  "",

			  "     The End",
			   };

		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( "Goldilocks and the three Bears" );
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, "Goldilocks and the three Bears" );
		}

		public GoldilocksNovel( Serial serial ) : base( serial )
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