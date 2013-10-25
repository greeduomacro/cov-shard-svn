using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x48E1, 0x48E0 )]
	public class VT : Item
	{
		[Constructable]
		public VT() : base( 0x48E1 )
		{
			Weight = 1.0;
            Name = "Pohkie Panda";
		}
        		
		public VT( Serial serial ) : base( serial )
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