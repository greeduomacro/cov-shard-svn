using System;

namespace Server.Items
{
	public class Dryadharp : BaseInstrument
	{
		[Constructable]
		public Dryadharp() : base( 0xEB2, 0x392, 0x46 )
		{
			Name = "A Dryad's Harp";
			Hue = 0x296;
			Weight = 10.0;
		}

		public Dryadharp( Serial serial ) : base( serial )
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