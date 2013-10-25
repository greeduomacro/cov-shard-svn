using System;
using Server;

namespace Server.Items
{
	public class GoldilocksDagger : Dagger
	{


		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public GoldilocksDagger()
		{

		Weight = 1.0;
					Name = "Goldilocks' Dagger";
			Hue = 1281;
			WeaponAttributes.HitLeechHits = 50;
			Slayer = SlayerName.Repond;
			Attributes.WeaponSpeed = 40;
			Attributes.WeaponDamage = 40;
		}

		public GoldilocksDagger( Serial serial ) : base( serial )
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