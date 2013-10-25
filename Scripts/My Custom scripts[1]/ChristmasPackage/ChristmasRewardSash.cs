using System;
using Server;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class ChristmasRewardSash : BodySash
	{
	
		[Constructable]
		public ChristmasRewardSash() : base()
		{
			Hue = 1372;
			Name = "I completed the 12 days of Christmas Quest";

            SkillBonuses.SetValues(0, SkillName.Inscribe, 10.0);
            SkillBonuses.SetValues(0, SkillName.Alchemy, 10.0);
            //SelfRepair = 3;
            Attributes.Luck = 100;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 2;
		}

        public ChristmasRewardSash(Serial serial)
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

