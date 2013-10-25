using System;

namespace Server.Items
{
	public class EasterApron : HalfApron
	{
	
		[Constructable]
		public EasterApron() : base()
		{
			Hue = 2117;
			Name = "I completed the 2010 Easter Quest";

            SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            //SelfRepair = 3;
            Attributes.Luck = 100;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 2;
		}

		public EasterApron( Serial serial ) : base( serial )
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

