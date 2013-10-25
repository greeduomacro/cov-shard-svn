using System;
using Server;

namespace Server.Items
{
	public class VampiricEssence : Cutlass
	{
		public override int LabelNumber{ get{ return 1113873; } }// Vampiric Essence

        public override int AosStrengthReq { get { return 25; } }
        public override int AosMinDamage { get { return 11; } }
        public override int AosMaxDamage { get { return 13; } }
        public override int AosSpeed { get { return 25; } }
        public override float MlSpeed { get { return 2.50f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

		[Constructable]
		public VampiricEssence()
		{
            Weight = 8.0;
            Layer = Layer.OneHanded;
			Hue = 1779;

            WeaponAttributes.HitHarm = 50;
            WeaponAttributes.HitLeechHits = 100;
			
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 50;

            Slayer = SlayerName.BloodDrinking;
			
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = pois = nrgy = chaos = direct = 0;
            cold = 100;
        }
        #endregion


		public VampiricEssence( Serial serial ) : base( serial )
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