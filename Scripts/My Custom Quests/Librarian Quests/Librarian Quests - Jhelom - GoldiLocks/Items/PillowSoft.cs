//Scripted by Mimi & Kila Ventru
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class PillowSoft : Item
	{
		[Constructable]
		public PillowSoft() : base( 5691 )
		{
				  Name = "Too Soft Pillow";
				  Hue = Utility.RandomList ( 1, 1150, 1260, 3, 1266, 1045, 1845, 1643, 23, 22, 1372, 1357, 33, 53, 932, 22, 529, 1010, 818, 1196, 1367, 502, 16, 43, 57 );

		}

		public PillowSoft( Serial serial ) : base( serial )
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