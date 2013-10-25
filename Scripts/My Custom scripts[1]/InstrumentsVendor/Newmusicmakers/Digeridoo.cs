using System;

namespace Server.Items
{
	public class Digeridoo : BaseInstrument
	{
		[Constructable]
		public Digeridoo() : base( 0x27F5, 0x1F6, 0x546 )
		{
			
			Name = "Digeridoo";
			Hue = 0x21;
			Weight = 20.0;
		}

		public Digeridoo( Serial serial ) : base( serial )
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