using System;
using Server;

namespace Server.Items
{
	public class LochNessScales : Item
	{
		
		[Constructable]
		public LochNessScales() : base( 9908 )
		{
			Name = "Loch Ness Scales";
			Stackable = true;
		}

		public LochNessScales( Serial serial ) : base( serial )
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