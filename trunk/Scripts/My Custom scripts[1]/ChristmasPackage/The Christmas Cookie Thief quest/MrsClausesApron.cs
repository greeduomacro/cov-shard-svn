using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MrsClausesApron : HalfApron
	{
		//public override int LabelNumber{ get{ return 1075043; } } // Crimson Cincture
	
		[Constructable]
		public MrsClausesApron() : base()
		{
			Hue = 64;
            Name = "Mrs. Clause's Apron";

            SkillBonuses.SetValues(0, SkillName.Cooking, 10.0);
            SkillBonuses.SetValues(1, SkillName.TasteID, 10.0);
            LootType = LootType.Blessed;
			
		}

        public MrsClausesApron(Serial serial)
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

