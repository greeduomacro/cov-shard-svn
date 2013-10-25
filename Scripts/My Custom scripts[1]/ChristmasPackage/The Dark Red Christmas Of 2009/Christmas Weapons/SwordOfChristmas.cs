using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class SwordOfChristmas : VikingSword
  {
public override int ArtifactRarity{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 16; } }
		public override int AosMinDamage{ get{ return 16; } }
		public override int OldMaxDamage{ get{ return 28; } }
		public override int AosMaxDamage{ get{ return 28; } }

		public override int InitMinHits{ get{ return 32; } }
		public override int InitMaxHits{ get{ return 21; } }

      [Constructable]
		public SwordOfChristmas()
		{
			Weight = 24;
          Name = "Mystical Sword Of Christmas";
          Hue = 1157;
      WeaponAttributes.DurabilityBonus = 20;
      WeaponAttributes.HitColdArea = 10;
      //WeaponAttributes.HitDispel = 2;
      WeaponAttributes.HitEnergyArea = 10;
      WeaponAttributes.HitFireArea = 10;
      //WeaponAttributes.HitHarm = 3;
      Attributes.WeaponDamage = 25;
      Attributes.WeaponSpeed = 15;
      //Attributes.BonusMana = 3;
     Slayer = SlayerName.Silver ;
		}

		public SwordOfChristmas( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); 
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
