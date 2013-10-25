using System;

namespace Server.Items
{
	public class DwarvenDrum : BaseInstrument
	{
		[Constructable]
		public DwarvenDrum() : base( 0xE9C, 0x2E8, 0x39 )
		{
			Hue = 543;
			Name = "Dwarven War Drums";
			Weight = 4.0;
		}

		public DwarvenDrum( Serial serial ) : base( serial )
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