using System;
using Server.Items;

namespace Server.Items
{
	public class HeadofGwenno : Item
	{
		[Constructable]
		public HeadofGwenno() : base( 0x1DA0 )
		{
			Movable = true;
			Name = "Head of Gwenno";
		}

		public HeadofGwenno( Serial serial ) : base( serial )
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
