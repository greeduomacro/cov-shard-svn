//Scripted by Mimi & Kila Ventru
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class FullBag : Item
	{
		[Constructable]
		public FullBag() : base( 0xE76 )
		{
				  Name = "Full Bag";
				  Hue = 1150;

		}

		public FullBag( Serial serial ) : base( serial )
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