using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class ChristmasKatana : Katana
  {
public override int ArtifactRarity{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int AosMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 4; } }
		public override int AosMaxDamage{ get{ return 4; } }

		public override int InitMinHits{ get{ return 2; } }
		public override int InitMaxHits{ get{ return 3; } }

      [Constructable]
		public ChristmasKatana()
		{
          Name = "ChristmasKatana";
          Hue = 38;

      Attributes.BonusDex = 5;
      Attributes.BonusHits = 5;
      Attributes.BonusInt = 5;
      //Attributes.BonusMana = 2;
      Attributes.SpellChanneling = 1;
      Attributes.WeaponDamage = 35;
      Attributes.WeaponSpeed = 25;
     Slayer = SlayerName.DragonSlaying ;
		}

		public ChristmasKatana( Serial serial ) : base( serial )
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
