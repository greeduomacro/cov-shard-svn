using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class COVArmorBag1 : Bag 
	{ 
		[Constructable] 
		public COVArmorBag1() 
		{ 
			DropItem(new COVArms());
            DropItem(new COVBreastplate());
            DropItem(new COVGorget());
            DropItem(new COVLegs());
            DropItem(new COVGloves());
            DropItem(new COVCloseHelm());
		}

        public COVArmorBag1 (Serial serial) : base(serial) 
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
