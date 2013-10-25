using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class DraconisWrath : Katana
	{
		public override int LabelNumber{ get{ return 1114789; } } // Draconi's Wrath
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public DraconisWrath()
		{
			Hue = 2217;
            WeaponAttributes.HitFireball = 60;
            WeaponAttributes.UseBestSkill = 1;
			Attributes.WeaponDamage = 50;
            Attributes.AttackChance = 15;
            AbsorptionAttributes.EaterFire = 20;
		}

		public DraconisWrath( Serial serial ) : base( serial )
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            fire = cold = pois = nrgy = chaos = direct = 0;
            phys = 100;
        }
        #endregion

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Hue == 0x44F )
				Hue = 0x76D;
		}
	}
}