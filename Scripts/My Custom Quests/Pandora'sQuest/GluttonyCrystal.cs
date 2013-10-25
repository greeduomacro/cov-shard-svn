using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class GluttonyCrystal : Item
	{
		[Constructable]
		public GluttonyCrystal() : base( 0x1870 )
		{
			Weight = 1.0;
			Name = "The Crystal of Gluttony";
            Hue = 643;
		}

		public GluttonyCrystal( Serial serial ) : base( serial )
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


