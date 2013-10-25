using System;
using Server;

namespace Server.Items
{
	public class HallegsAdvice : BrownBook
	{
		[Constructable]
		public HallegsAdvice() : base( "My Advice", "Halleg ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Wow kid ya surprised me.", 
				"I didn't think ya had it", 
				"in ya. Ah well, we learn", 
				"Something new everyday I", 
				"suppose. You see where", 
				"you are now? Or are you",
				"just wondering how I",
				"transported you? Haha,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Well a magician never", 
				"Reveals his secrets.", 
				"", 
				"Anyways, you are in", 
				"the passage leading to", 
				"King Gwenno's burial", 
				"chamber. That's right,", 
				"you finally made it.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Head to the end and", 
				"you'll be transported to", 
				"the chamber. But that's", 
				"not all, there's a", 
				"password you must say", 
				"to get in. What's the", 
				"password you ask? Well,", 
				"it's this right here:", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"JoJack", 
				"", 
				"The password's after his", 
				"husband (???). Say that", 
				"on the marked sqaure and", 
				"prepare to die kid. Hahah", 
				"", 
				"By the way, if you happen", 
			}; 
			Pages[cnt++].Lines = lines;
			lines = new string[] 
			{ 
				"ta see Sir Kenshin,", 
				"give him the head of", 
				"Gwenno. He'll give ya", 
				"sometin nice. Now, go on", 
				"kid, and good luck.", 
				"",
				"Huckhuck,",
				"You'll need it.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
		}

		public HallegsAdvice( Serial serial ) : base( serial )
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

			writer.Write( (int)0 ); // version
		}
	}
}