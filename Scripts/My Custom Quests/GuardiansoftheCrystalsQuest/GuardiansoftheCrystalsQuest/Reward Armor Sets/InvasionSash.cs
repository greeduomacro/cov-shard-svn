using System;

namespace Server.Items
{
	public class InvasionSash : BodySash
	{
	
		[Constructable]
		public InvasionSash() : base()
		{
			Hue = 33;
			Name = "I Survived the Moonglow Invasion!";

            SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            //SelfRepair = 3;
            Attributes.Luck = 100;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 2;
		}

		public InvasionSash( Serial serial ) : base( serial )
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

