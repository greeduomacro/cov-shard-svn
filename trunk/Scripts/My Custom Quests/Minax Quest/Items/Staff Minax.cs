//Written by Lord Dalamar
using System;
using Server.Items;

namespace Server.Items
{
	public class StaffMinax : BlackStaff
	{
		public override int LabelNumber{ get{ return 1070692; } }
		
		public override int InitMinHits{ get{ return 500; } }
		public override int InitMaxHits{ get{ return 500; } }

		[Constructable]
		public StaffMinax()
		{
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 75;
			Attributes.WeaponDamage = 50;
			Attributes.AttackChance = 100;
			Hue = 1172;
			Name = "Staff of Lady Minax";

			LootType = LootType.Blessed;

		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = cold = pois = chaos = direct = 0;
            fire = 50;
            nrgy = 50;
        }
        #endregion

		public StaffMinax( Serial serial ) : base( serial )
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
