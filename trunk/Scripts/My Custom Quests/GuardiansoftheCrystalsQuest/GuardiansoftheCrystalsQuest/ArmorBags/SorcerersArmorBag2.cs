using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class SorcerersArmorBag2 : Bag 
	{ 
		[Constructable] 
		public SorcerersArmorBag2() 
		{
            DropItem(new SorcerersSleeves());
            DropItem(new SorcerersFemaleArmor());
            DropItem(new SorcerersGorget());
            DropItem(new SorcerersSkirt());
            DropItem(new SorcerersGloves());
            DropItem(new SorcerersHat());	
		}

        public SorcerersArmorBag2 (Serial serial) : base(serial) 
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
