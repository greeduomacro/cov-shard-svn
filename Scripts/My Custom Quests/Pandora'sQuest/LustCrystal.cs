using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class LustCrystal : Item
	{
		[Constructable]
		public LustCrystal() : base( 0x1870 )
		{
			Weight = 1.0;
			Name = "The Crystal of Lust";
            Hue = 34;
		}

		public LustCrystal( Serial serial ) : base( serial )
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


