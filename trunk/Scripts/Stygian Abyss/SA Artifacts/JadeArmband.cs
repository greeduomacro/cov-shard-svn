using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class JadeArmband : GoldBracelet
	{

        public override int LabelNumber { get { return 1112407; } } // Jade Armband 
        public override int ArtifactRarity { get { return 11; } }
               
        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }

		[Constructable]
		public JadeArmband()
		{
			Name = "Jade Armband";
			Hue = 1164;

            Attributes.AttackChance = 10;
            Attributes.WeaponSpeed = 20;
            Attributes.DefendChance = 10;
            Resistances.Poison = 20;
		
		}

		public JadeArmband( Serial serial ) : base( serial )
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