using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class HelmOfChristmas : CloseHelm
  {
public override int ArtifactRarity{ get{ return 10; } }

		public override int InitMinHits{ get{ return 3; } }
		public override int InitMaxHits{ get{ return 6; } }

		public override int BaseColdResistance{ get{ return 20; } } 
		public override int BaseEnergyResistance{ get{ return 10; } } 
		public override int BasePhysicalResistance{ get{ return 13; } } 
		public override int BasePoisonResistance{ get{ return 2; } } 
		public override int BaseFireResistance{ get{ return 5; } } 
      
      [Constructable]
		public HelmOfChristmas()
      {
          Name = "Helm Of Christmas";
          Hue = 38;

          Attributes.Luck = 100;
		}

		public HelmOfChristmas( Serial serial ) : base( serial )
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
