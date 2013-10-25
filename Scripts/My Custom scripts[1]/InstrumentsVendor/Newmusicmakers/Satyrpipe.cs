using System;

namespace Server.Items
{
	public class Satyrpipe : BaseInstrument
	{
		
		[Constructable]
		public Satyrpipe() : base( 0x1421, 0x5B8, 0x5B7 )
		{
			Name = "a satyr's panpipes";
			Hue = 0x234;
			Weight = 2.0;
		}

		public Satyrpipe( Serial serial ) : base( serial )

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