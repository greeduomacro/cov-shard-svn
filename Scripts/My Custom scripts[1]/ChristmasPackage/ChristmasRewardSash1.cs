using System;
using Server;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class ChristmasRewardSash1 : BodySash
	{
	
		[Constructable]
		public ChristmasRewardSash1() : base()
		{
			Hue = 1372;
			Name = "I Survived the Christmas Dungeon ";

            SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            //SelfRepair = 3;
            Attributes.Luck = 100;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 2;
		}

        public ChristmasRewardSash1(Serial serial)
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

