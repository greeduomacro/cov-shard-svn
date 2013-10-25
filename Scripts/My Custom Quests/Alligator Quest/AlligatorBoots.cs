using System;

namespace Server.Items
{
	public class AlligatorBoots : Boots
	{
		//public override int LabelNumber{ get{ return 1075043; } } // Crimson Cincture
	
		[Constructable]
		public AlligatorBoots() : base()
		{
			Hue = 2967;
            Name = "Alligator hide boots";

            SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            SkillBonuses.SetValues(1, SkillName.Chivalry, 10.0);
            LootType = LootType.Blessed;
			
		}

        public AlligatorBoots(Serial serial)
            : base(serial)
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

