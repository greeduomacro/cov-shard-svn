using System;

namespace Server.Items
{
	public class Beltherlute : BaseInstrument
	{
		[Constructable]
		public Beltherlute() : base( 0xEB4, 0x403, 0x4D )
		{
			
			Name = "a belther's lute";
			Hue = 0xF9;
			Weight = 5.0;
		}

		public Beltherlute( Serial serial ) : base( serial )
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
				Weight = 5.0;
		}
	}
}