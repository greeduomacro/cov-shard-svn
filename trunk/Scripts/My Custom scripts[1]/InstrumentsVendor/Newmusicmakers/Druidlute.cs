using System;

namespace Server.Items
{
	public class Druidlute : BaseInstrument
	{
		[Constructable]
		public Druidlute() : base( 0xEB3, 0x418, 0x4D )
		{
			
			Name = "a Druid's lute";
			Hue = 0x296;
			Weight = 5.0;
		}

		public Druidlute( Serial serial ) : base( serial )
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