using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class DeathsHead : DiamondMace
	{
		public override int LabelNumber{ get{ return 1113526; } } //Deaths Head 

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public DeathsHead()
		{
			ItemID = 0x2D30;
			Hue = 1304;

            WeaponAttributes.HitLowerDefend = 30;
            WeaponAttributes.HitLightning = 45;
            WeaponAttributes.HitFatigue = 45;
            Attributes.WeaponSpeed = 20;
            Attributes.WeaponDamage = 45;
			
		}

		public DeathsHead( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}