using System;

namespace Server.Items
{
	public class Orcdrum : BaseInstrument
	{
		[Constructable]
		public Orcdrum() : base( 0x03AA, 0x2E9, 0x39 )
		{
			Name = "An Orcish Drum";
			Hue = 0x166;
			Weight = 4.0;
		}

		public Orcdrum( Serial serial ) : base( serial )
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
				Weight = 4.0;
		}
	}
}