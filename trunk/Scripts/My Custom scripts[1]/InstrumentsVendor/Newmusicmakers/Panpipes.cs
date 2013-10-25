using System;

namespace Server.Items
{
	public class Panpipes : BaseInstrument
	{
		
		[Constructable]
		public Panpipes() : base( 0x2711, 0x58A, 0x58C )
		{
			Name = "Panpipes";
			Hue = 0x2E7;
			Weight = 2.0;
		}

		public Panpipes( Serial serial ) : base( serial )

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