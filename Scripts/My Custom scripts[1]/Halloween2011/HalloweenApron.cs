using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class HalloweenApron : HalfApron
	{
	
		[Constructable]
		public HalloweenApron() : base()
		{
			Hue = 2117;
			Name = "Halloween 2011";

            SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            //SelfRepair = 3;
            Attributes.Luck = 100;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 2;
		}

		public HalloweenApron( Serial serial ) : base( serial )
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

