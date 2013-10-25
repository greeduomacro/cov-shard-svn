using System;
using Server;

namespace Server.Items
{
	public class OFQRing : GoldRing
	{
		
		[Constructable]
		public OFQRing()
		{
			Weight = 1.0;
			Name = "Orcish Wedding Ring";			
		}

		public OFQRing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}