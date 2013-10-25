using System;
using Server;

namespace Server.Items
{
	public class TheAncientBirdSlayer : BaseTalisman
	{

		//public override int ArtifactRarity{ get{ return 11; } } 

		[Constructable]
        public TheAncientBirdSlayer() : base( 0x2F5A )
		{
			Name = "The Ancient Bird Slayer Tailsman";
			Hue = 798;
            
            Attributes.NightSight = 1;
            SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            LootType = LootType.Blessed;
		}

		public TheAncientBirdSlayer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}