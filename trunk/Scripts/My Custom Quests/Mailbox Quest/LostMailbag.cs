using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
	public class LostMailBag : Item 
	{ 
		[Constructable] 
		public LostMailBag() : base(0xE76) 
		{
            Movable = true;
            Hue = Utility.RandomList(0x36, 0x17, 0x120, 0xD2, 0xC1, 0x2C);
            Name = "Karen's Lost Mailbag";
		} 

		public LostMailBag( Serial serial ) : base( serial ) 
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
