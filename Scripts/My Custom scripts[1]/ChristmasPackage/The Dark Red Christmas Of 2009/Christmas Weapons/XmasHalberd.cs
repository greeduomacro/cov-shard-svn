using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class XmasHalberd : Halberd
  {
public override int ArtifactRarity{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 10; } }


      [Constructable]
		public XmasHalberd()
		{
          Name = "XmasHalberd";
          Hue = 34;

      Attributes.LowerManaCost = 5;
      Attributes.LowerRegCost = 15;
      Attributes.Luck = 75;
      //Attributes.NightSight = 1;
      //Attributes.RegenMana = 5;
      //Attributes.SpellDamage = 2;
      Attributes.WeaponSpeed = 25;
      //Attributes.BonusMana = 4;
      Attributes.WeaponDamage = 15;
     Slayer = SlayerName.Silver ;
		}

		public XmasHalberd( Serial serial ) : base( serial )
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
