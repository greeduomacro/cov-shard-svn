using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class AxeOfXmas : DoubleAxe
  {
public override int ArtifactRarity{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int AosMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 10; } }

		public override int InitMinHits{ get{ return 23; } }
		public override int InitMaxHits{ get{ return 3; } }

      [Constructable]
		public AxeOfXmas()
		{
          Name = "Axe Of Xmas";
          Hue = 64;

      //Attributes.CastSpeed = 2;
      //Attributes.LowerManaCost = 6;
      //Attributes.LowerRegCost = 5;
      //Attributes.SpellDamage = 4;
      Attributes.WeaponDamage = 35;
      Attributes.WeaponSpeed = 20;
     Slayer = SlayerName.DragonSlaying ;
		}

		public AxeOfXmas( Serial serial ) : base( serial )
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
