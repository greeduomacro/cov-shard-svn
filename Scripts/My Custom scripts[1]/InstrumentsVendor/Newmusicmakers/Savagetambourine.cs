using System;

namespace Server.Items
{
	public class Savagetambourine : BaseInstrument
	{
		[Constructable]
		public Savagetambourine() : base( 0xE9D, 0x4B7, 0x53 )
		{
			
			Name = "Savage Ankle Bells";
			Hue = 0x21;
			Weight = 1.0;
		}

		public Savagetambourine( Serial serial ) : base( serial )
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

			if ( Weight == 2.0 )
				Weight = 1.0;
		}
	}
}