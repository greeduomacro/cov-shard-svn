using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class SlothCrystal : Item
	{
		[Constructable]
		public SlothCrystal() : base( 0x1870 )
		{
			Weight = 1.0;
			Name = "The Crystal of Sloth";
            Hue = 98;
		}

		public SlothCrystal( Serial serial ) : base( serial )
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


