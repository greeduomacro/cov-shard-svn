using System;
using Server;

namespace Server.Items
{
	public class FemaleStoneChest: FemalePlateChest
	{
		public override int ArtifactRarity{ get{ return 10; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public FemaleStoneChest()
		{
			Hue = 1154;
            Weight = 10.0;
						Name = "Female Stone Chest";

						Attributes.Luck = 150;
						Attributes.DefendChance = 20;
						Attributes.BonusHits = 10;
						ArmorAttributes.MageArmor = 1;
						
						FireBonus = 20;
						PhysicalBonus = 20;
					
		}

        public FemaleStoneChest(Serial serial)
            : base(serial)
	{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
    
		
	}
}
