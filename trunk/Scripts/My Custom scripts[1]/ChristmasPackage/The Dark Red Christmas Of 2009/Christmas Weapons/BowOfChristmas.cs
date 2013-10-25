using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class BowOfChristmas : Bow
  {
public override int ArtifactRarity{ get{ return 89; } }

		public override int InitMinHits{ get{ return 3; } }
		public override int InitMaxHits{ get{ return 4; } }

      [Constructable]
		public BowOfChristmas()
		{
			Weight = 23;
          Name = "BowOfChristmas";
          Hue = 1157;

      Attributes.BonusInt = 5;
      Attributes.BonusMana = 5;
      Attributes.LowerRegCost = 10;
      Attributes.WeaponDamage = 35;
      Attributes.WeaponSpeed = 20;
      Attributes.WeaponDamage = 45;
		}

		public BowOfChristmas( Serial serial ) : base( serial )
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
