using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class ScoutArmorBag2 : Bag 
	{ 
		[Constructable] 
		public ScoutArmorBag2() 
		{
            DropItem(new ScoutStuddedSleeves());
            DropItem(new ScoutFemaleStuddedArmor());
            DropItem(new ScoutStuddedGorget());
            DropItem(new ScoutStuddedLeggings());
            DropItem(new ScoutStuddedGloves());
            DropItem(new ScoutCirclet());	
		}

        public ScoutArmorBag2 (Serial serial) : base(serial) 
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
