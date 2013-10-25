using System;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x143D, 0x143C )]
	public class TheImpalersPick : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 28; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.75f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public TheImpalersPick() : base( 0x143D )
		{
			Weight = 9.0;
			Layer = Layer.OneHanded;
            Hue = 2304;

            WeaponAttributes.HitLowerDefend = 40;
            WeaponAttributes.HitLightning = 40;
            WeaponAttributes.HitManaDrain = 10;

            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 45;

            Slayer = SlayerName.Repond;
            
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            fire = cold = pois = nrgy = chaos = direct = 0;
            phys = 100;
        }
        #endregion

		public TheImpalersPick( Serial serial ) : base( serial )
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