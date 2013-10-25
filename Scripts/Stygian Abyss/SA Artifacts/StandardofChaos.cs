using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26BF, 0x26C9 )]
	public class StandardofChaos : BaseSpear
	{
        public override int LabelNumber { get { return 1113522; } }// Standard of Chaos

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 13; } }
		public override int AosSpeed{ get{ return 49; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 2.25f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 50; } }
		public override int OldMinDamage{ get{ return 12; } }
		public override int OldMaxDamage{ get{ return 13; } }
		public override int OldSpeed{ get{ return 49; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public StandardofChaos() : base( 0x26BF )
		{
			Weight = 2.0;
            Hue = 1426;

            Attributes.WeaponDamage = -40;
            Attributes.WeaponSpeed = 30;
            Attributes.CastSpeed = 1;

            WeaponAttributes.HitLowerDefend = 40;
            WeaponAttributes.HitFireball = 20;
            WeaponAttributes.HitHarm = 30;
            WeaponAttributes.HitLightning = 10;

		}

		public StandardofChaos( Serial serial ) : base( serial )
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