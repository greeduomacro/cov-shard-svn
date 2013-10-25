//Scripted by Mimi & Kila Ventru
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class PorridgeHot : Item
	{
		[Constructable]
		public PorridgeHot() : base( 5630 )
		{
				  Name = "Too Hot Porridge";
				  Hue = 0;

		}

		public PorridgeHot( Serial serial ) : base( serial )
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