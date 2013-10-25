using System;
using Server;

namespace Server.Items
{
	public class ACreedAntoinesDeed : Item
	{
		[Constructable]
		public ACreedAntoinesDeed() : base( 0x1C11 )
		{
		}

		public ACreedAntoinesDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}