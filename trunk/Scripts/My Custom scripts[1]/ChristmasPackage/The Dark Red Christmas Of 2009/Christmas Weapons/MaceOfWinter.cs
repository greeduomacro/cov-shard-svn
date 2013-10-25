using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class MaceOfWinter : WarMace
  {
public override int ArtifactRarity{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 3; } }
		public override int AosMinDamage{ get{ return 3; } }
		public override int OldMaxDamage{ get{ return 3; } }
		public override int AosMaxDamage{ get{ return 3; } }

		public override int InitMinHits{ get{ return 24; } }
		public override int InitMaxHits{ get{ return 4; } }

      [Constructable]
		public MaceOfWinter()
		{
			Weight = 23;
          Name = "MaceOfWinter";
          Hue = 1153;
      WeaponAttributes.HitColdArea = 20;
      //Attributes.CastSpeed = 3;
      Attributes.DefendChance = 5;
      Attributes.LowerManaCost = 5;
      Attributes.LowerRegCost = 5;
      Attributes.WeaponDamage = 30;
      Attributes.WeaponSpeed = 15;
      //Attributes.BonusMana = 1;
     Slayer = SlayerName.SnakesBane ;
		}

		public MaceOfWinter( Serial serial ) : base( serial )
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
