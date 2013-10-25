using System;

namespace Server.Items
{
	public class SCFB : Boots
	{
		//public override int LabelNumber{ get{ return 1075043; } } // Crimson Cincture
	
		[Constructable]
		public SCFB() : base()
		{
			Hue = 1;
            Name = "Santa Clause's Favorite Boots";

            SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            LootType = LootType.Blessed;
			
		}

        public SCFB(Serial serial)
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

