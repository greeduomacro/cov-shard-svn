using System;

namespace Server.Items
{
	public class Savagedrum : BaseInstrument
	{
		[Constructable]
		public Savagedrum() : base( 0x03AA, 0x2EC, 0x39 )
		{
			Hue = 249;
			Name = "A Savage's Drum";
			Weight = 4.0;
		}

		public Savagedrum( Serial serial ) : base( serial )
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