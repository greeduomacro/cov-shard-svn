using System;
using Server;

namespace Server.Items
{
	public class GibberlingHead : Item
	{
		[Constructable]
		public GibberlingHead() : this( null )
		{
		}

		[Constructable]
		public GibberlingHead( string name ) : base( 0x1DA0 )
		{
			Name = name;
			Weight = 1.0;
            Hue = 1150;
		}

		public GibberlingHead( Serial serial ) : base( serial )
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
		}
	}
}