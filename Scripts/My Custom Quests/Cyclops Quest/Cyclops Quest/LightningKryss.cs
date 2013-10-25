using System;
using Server;

namespace Server.Items
{
	public class LightningKryss : Kryss
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public LightningKryss()
		{
            Name = "Lightning Kryss";
			ItemID = 0x1400;
			Hue = 1172;
			WeaponAttributes.HitEnergyArea = 100;
			WeaponAttributes.HitLightning = 20;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 50;
        }

		#region Mondain's Legacy
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = cold = pois = chaos = direct = 0;
			phys = 25;
			nrgy = 75;
		}
		#endregion

		public LightningKryss( Serial serial ) : base( serial )
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

			if ( ItemID == 0x1401 )
				ItemID = 0x1400;
		}
	}
}