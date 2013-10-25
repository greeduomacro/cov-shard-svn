using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[Furniture]
	[FlipableAttribute( 0x4910, 0x4911 )] 
	public class GothicChest : LockableContainer 
	{ 		
		public override int DefaultGumpID{ get{ return 0x49; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		[Constructable] 
		public GothicChest() : base( 0x4910 ) 
		{
            Name = "Gothic Chest";
			Weight = 1.0;
		} 

		public GothicChest( Serial serial ) : base( serial ) 
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

