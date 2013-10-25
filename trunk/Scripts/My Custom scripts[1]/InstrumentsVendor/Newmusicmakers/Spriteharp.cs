using System;

namespace Server.Items
{
	public class Spriteharp : BaseInstrument
	{
		[Constructable]
		public Spriteharp() : base( 0xEB2, 0x393, 0x45 )
		{
			Name = "A Sprite's Harp" ;
			Hue = 0x29;
			Weight = 10.0;
		}

		public Spriteharp( Serial serial ) : base( serial )
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