using System;
using Server;

namespace Server.Items
{
	public class ThunderDagger : Dagger
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ThunderDagger()
		{
            Name = "Thunder Dagger";
			ItemID = 0xF51;
			Hue = 1276;
			WeaponAttributes.HitHarm = 40;
			Slayer = SlayerName.Repond;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 35;
		}

		public ThunderDagger( Serial serial ) : base( serial )
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