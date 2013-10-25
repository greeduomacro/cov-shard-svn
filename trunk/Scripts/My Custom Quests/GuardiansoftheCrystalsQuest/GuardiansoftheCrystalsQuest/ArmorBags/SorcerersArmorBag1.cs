using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class SorcerersArmorBag1 : Bag 
	{ 
		[Constructable] 
		public SorcerersArmorBag1() 
		{ 
			DropItem(new SorcerersSleeves());
            DropItem(new SorcerersTunic());
            DropItem(new SorcerersGorget());
            DropItem(new SorcerersLeggings());
            DropItem(new SorcerersGloves());
            DropItem(new SorcerersHat());
		}

        public SorcerersArmorBag1 (Serial serial) : base(serial) 
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
