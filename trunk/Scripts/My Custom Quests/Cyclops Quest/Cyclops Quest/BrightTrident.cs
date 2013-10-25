using System;
using Server;

namespace Server.Items
{
	public class BrightTrident : WarFork
	{
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
		public override int ArtifactRarity{ get{ return 10; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public BrightTrident()
		{
            Name = "Bright Trident";
			Hue = 1159;
			WeaponAttributes.HitFireball = 50;
			Attributes.BonusDex = 5;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 50;
        }

		#region Mondain's Legacy
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}
		#endregion

		public BrightTrident( Serial serial ) : base( serial )
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