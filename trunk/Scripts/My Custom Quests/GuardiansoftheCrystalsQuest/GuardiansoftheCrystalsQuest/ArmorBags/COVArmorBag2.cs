using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class COVArmorBag2 : Bag 
	{ 
		[Constructable] 
		public COVArmorBag2() 
		{
            DropItem(new COVArms());
            DropItem(new COVFemaleBreastplate());
            DropItem(new COVGorget());
            DropItem(new COVLegs());
            DropItem(new COVGloves());
            DropItem(new COVCloseHelm());	
		}

        public COVArmorBag2 (Serial serial) : base(serial) 
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
