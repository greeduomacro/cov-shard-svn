using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF62, 0xF63 )]
	public class DemonHuntersStandard : BaseSpear
	{
        public override int LabelNumber { get { return 1113864; } } //Demon Hunter's Standard

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 42; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 2.75f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 36; } }
		public override int OldSpeed{ get{ return 46; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int VirtualDamageBonus{ get{ return 25; } }

		[Constructable]
		public DemonHuntersStandard() : base( 0xF62 )
		{
			Weight = 7.0;
			Hue = 1274;
            Slayer = SlayerName.Exorcism;
            Attributes.WeaponDamage = 50;
            Attributes.WeaponSpeed = 25;
            WeaponAttributes.HitLowerDefend = 30;
            WeaponAttributes.HitLightning = 40;
            WeaponAttributes.HitLeechStam = 50;
            Attributes.CastSpeed = 1;
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = pois = nrgy = direct = 0;
            chaos = 100;
        }
        #endregion

		public DemonHuntersStandard( Serial serial ) : base( serial )
		{
		}

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