using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class SantasStaff : GnarledStaff
  {

		public override int InitMinHits{ get{ return 3; } }

      [Constructable]
		public SantasStaff()
		{
			Weight = 50;
          Name = "SantasStaff";
          Hue = 38;

      Attributes.BonusInt = 5;
      
      Attributes.BonusStam = 5;
      Attributes.Luck = 120;
      //Attributes.NightSight = 1;
      Attributes.ReflectPhysical = 10;
      Attributes.RegenHits = 5;
      //Attributes.RegenMana = 3;
      Attributes.SpellChanneling = 1;
      Attributes.SpellDamage = 10;
      Attributes.WeaponDamage = 15;
      //Attributes.BonusMana = 5;
      LootType = LootType.Cursed;
     Slayer = SlayerName.Exorcism ;
		}

		public SantasStaff( Serial serial ) : base( serial )
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
