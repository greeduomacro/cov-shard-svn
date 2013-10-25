using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class EyeOfNavery : Item
	{	
		public override int LabelNumber{ get{ return 1095154; } } 
	
		[Constructable]
		public EyeOfNavery() : base( 0xF87 )
		{
            //Name = "Eye of Navery Nighteyes";
			Weight = 1;
			Hue = 33;
		}

		public EyeOfNavery( Serial serial ) : base( serial )
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

