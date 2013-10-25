using System;
using Server;

namespace Server.Items
{
	public class ACreedRamondosLetter : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"To Vincente", "Ramondo",

			new BookPageInfo
			(
				"Dear Vincente, I have",
				"received evidence to",
				"prove our worst",
				"suspicions: your",
				"daughter is marrying an",
				"impostor. Although",
				"Leone claims to be a",
				"Guelph, he is, in fact,"
			),
			new BookPageInfo
			(
				"Florentine. This is",
				"further proof that",
				"those liars and cheats",
				"are trying to invade",
				"our government, and",
				"further take away what",
				"little independence we",
				"have. If, upon reading"
			),
			new BookPageInfo
			(
				"this, your blood is",
				"boiling as much as",
				"mine, I say we drop him",
				"off the Torre Grossa,",
				"that will send a",
				"message to Florence.",
				"Yours, Ramondo P.S.",
				"Once you have disposed"
			),
			new BookPageInfo
			(
				"of this annoyance, my",
				"son is of eligible age,",
				"as you know. Perhaps",
				"your daughter's hand",
				"would be better suited",
				"for his."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ACreedRamondosLetter() : base( 0x1C11, false )
		{
		}

		public ACreedRamondosLetter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}