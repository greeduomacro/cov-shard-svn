using System;

namespace Server.Items
{
	public class Drowflute : BaseInstrument
	{
		[Constructable]
		public Drowflute() : base( 0x2807, 0x58B, 0x503 )
		{
			Hue = 0x398;
			Name = "A Drow's flute";
			Weight = 2.0;
		}

		public Drowflute( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 3.0 )
				Weight = 2.0;
		}
	}
}