using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class ChestOfWinter : StuddedChest
  {
public override int ArtifactRarity{ get{ return 10; } }

		public override int InitMinHits{ get{ return 10; } }
		public override int InitMaxHits{ get{ return 18; } }

		public override int BaseColdResistance{ get{ return 15; } } 
		public override int BaseEnergyResistance{ get{ return 12; } } 

      
      [Constructable]
		public ChestOfWinter()
		{
          Name = "Chest Of Winter";
          Hue = 1153;

          Attributes.Luck = 100;
		}

		public ChestOfWinter( Serial serial ) : base( serial )
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
