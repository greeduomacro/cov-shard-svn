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
	public class PressedPapyrus : Item
	{
		[Constructable]
		public PressedPapyrus() : base( 0xA6C )
		{
		      	Weight = 2.0;
			Stackable = true;
			Hue = 0x33;
			Name = "Pressed Papyrus";
		}

		public PressedPapyrus( Serial serial ) : base( serial )
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