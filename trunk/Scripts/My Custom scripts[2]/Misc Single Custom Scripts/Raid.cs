using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class Raid : Item
	{
		[Constructable]
		public Raid() : base( 0xE25 )
		{
			Weight = 1.0;
			Name = "A can of Raid cockroach spray";
            Hue = 6208;
		}

		public Raid( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); 
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}
}


