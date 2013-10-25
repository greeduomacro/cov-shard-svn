using System;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute( 0x900, 0x4071)]
	public class AbyssalBlade : BaseSword
	{
        public override int LabelNumber { get { return 1113520; } }///AbyssalBlade

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 43; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 4; } }
		public override int OldMaxDamage{ get{ return 32; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x236; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public AbyssalBlade() : base( 0x900 )
		{
            Weight = 6.0;
            Hue = 2022;
           
            AbsorptionAttributes.SoulChargeKinetic = 50;
            WeaponAttributes.HitLeechMana = 60;
            WeaponAttributes.HitLeechStam = 60;
            Attributes.WeaponSpeed = 20;
            Attributes.WeaponDamage = 60;
            
		}

		public AbyssalBlade( Serial serial ) : base( serial )
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = pois = nrgy = direct = 0;
            chaos = 100;
        }
        #endregion

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