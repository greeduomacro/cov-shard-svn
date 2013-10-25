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
	public class Pith : Item
	{
		[Constructable]
		public Pith() : base( 0x101F )
		{
		      	Weight = 0.0;
			Stackable = true;
			Hue = 0x481;
			Name = "Mound of Pith";
		}

		public Pith( Serial serial ) : base( serial )
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