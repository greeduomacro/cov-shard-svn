using System;
using Server;
using Server.Items;
 
namespace Server.Items
{
	public class SantasTimepiece : Clock
{
	
	
	[Constructable]
	
	public SantasTimepiece() : base( 0x1086 )
	{
		Name = "Santa's Timepiece";
		Hue = 1151;
        Layer = Layer.Bracelet;
        LootType = LootType.Blessed;
        
	}
 
 
	public SantasTimepiece( Serial serial ) : base( serial )
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
 
