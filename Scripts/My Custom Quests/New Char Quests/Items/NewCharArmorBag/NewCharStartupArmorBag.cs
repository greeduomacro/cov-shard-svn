using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class NewCharStartupArmorBag : Bag 
	{ 
		[Constructable] 
		public NewCharStartupArmorBag() 
		{ 
			DropItem(new NewCharLeatherLegs());
            DropItem(new NewCharLeatherChest());
            DropItem(new NewCharLeatherGorget());
            DropItem(new NewCharLeatherArms());
            DropItem(new NewCharLeatherGloves());		
		}

        public NewCharStartupArmorBag (Serial serial) : base(serial) 
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
