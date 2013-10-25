using System;
using Server;

namespace Server.Items
{
	public class JadeWarAxe : DoubleAxe
	{
		public override int LabelNumber{ get{ return 1115445; } } // Jade War Axe
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public JadeWarAxe()
		{
            Weight = 8.0;
			Hue = 1268;

            AbsorptionAttributes.EaterFire = 10;

			WeaponAttributes.HitFireball = 30;
            WeaponAttributes.HitLowerDefend = 60;
            Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 50;

            Slayer = SlayerName.DragonSlaying;
		}

		public JadeWarAxe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}