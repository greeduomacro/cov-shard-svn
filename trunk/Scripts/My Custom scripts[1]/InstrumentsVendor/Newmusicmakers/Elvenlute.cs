using System;

namespace Server.Items
{
	public class Elvenlute : BaseInstrument
	{
		[Constructable]
		public Elvenlute() : base( 0xEB4, 0x40B, 0x4D )
		{
			
			Name = "an Elven lute";
			Hue = 0xFE;
			Weight = 5.0;
		}

		public Elvenlute( Serial serial ) : base( serial )
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