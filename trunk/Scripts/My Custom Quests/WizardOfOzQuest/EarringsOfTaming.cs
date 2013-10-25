using System;
using Server;

namespace Server.Items
{
	public class EarringsOfTaming : GoldEarrings
	{

		//public override int ArtifactRarity{ get{ return 11; } } 

		[Constructable]
		public EarringsOfTaming()
		{
			Name = "Earrings Of Taming";
			Hue = 1282;
            Attributes.CastSpeed += 1;
            Attributes.CastRecovery += 2;
            Attributes.NightSight = 1;
            SkillBonuses.SetValues(0, SkillName.AnimalTaming, 10.0);
            SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            LootType = LootType.Blessed;
		}

		public EarringsOfTaming( Serial serial ) : base( serial )
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