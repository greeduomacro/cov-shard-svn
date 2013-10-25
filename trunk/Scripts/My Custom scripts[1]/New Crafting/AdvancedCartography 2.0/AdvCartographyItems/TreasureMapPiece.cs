//////////////////////////////////////////////////////////////////////////////////////////////////
//												//
//				Advanced Cartography and Treasure Maps				//
//					version Beta 1.0					//
//												//
//				author: Vhaerun @ Endara					//
//												//
//				thanks: Joeku, Storm33229, Irial				//
//												//
//////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace Server.Items
{
	public class TreasureMapPiece : Item
	{
		[Constructable]
		public TreasureMapPiece() : base( 0xE34 )
		{
		      	Weight = 0.5;
			Stackable = true;
			Hue = 0x4A7;
			Name = "Treasure Map Piece";
		}

		public TreasureMapPiece( Serial serial ) : base( serial )
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