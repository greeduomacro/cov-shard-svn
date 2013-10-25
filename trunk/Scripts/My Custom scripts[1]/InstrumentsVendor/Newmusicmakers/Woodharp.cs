using System;

namespace Server.Items
{
	public class Woodharp : BaseInstrument
	{
		[Constructable]
		public Woodharp() : base( 0xEB2, 0x391, 0x45 )
		{
			Name = "A Wood Elf's Harp";
			Hue = 0xF9;
			Weight = 10.0;
		}

		public Woodharp( Serial serial ) : base( serial )
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
				Weight = 10.0;
		}
	}
}