using System;
using Server;

namespace Server.Items
{
	public class ClueBook : BlueBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"ClueBook", "The Land Plot Quest",
				new BookPageInfo
				(
					"The next clue",
					"for the second",
					"riddle you seek",
					"is located in",
					"the Shame dungeon,",
					"near the bridge,"
                ), 
                new BookPageInfo
                (
                    "where a lone Elder",
                    "Gazer resides...",
                    "You are looking",
                    "for the Fire Lord!!!",
                    "Beware! He is a very",
                    "tough opponent!"
                ),
				new BookPageInfo
				(
					"The Third and final",
					"clue can be found",
					"a few passages down",
					"from the Fire Lord.",
					"in the pack of a",
                    "Dirt Elemental"
				)
				
			);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ClueBook() : base( false )
		{
		}

		public ClueBook( Serial serial ) : base( serial )
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