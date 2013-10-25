using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26C2, 0x26CC )]
	public class PhoenixBow : BasePhoenix
	{
	  public override int ArtifactRarity{ get{ return 11; } }
		public override int EffectID{ get{ return 0x36D4; } }
		public override Type AmmoType{ get{ return typeof( SulfurousAsh ); } }
		public override Item Ammo{ get{ return new SulfurousAsh(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 25; } }

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 15; } }
		public override int OldMaxDamage{ get{ return 17; } }
		public override int OldSpeed{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }
       
		[Constructable]
		public PhoenixBow() : base( 0x26C2 )
		{
		  Name = " Bow Of The Phoenix";
			Hue = 1358;
			Weight = 5.0;
			Attributes.WeaponDamage = 30;
			WeaponAttributes.HitFireball = 20;
			Attributes.WeaponSpeed = 20;
			WeaponAttributes.ResistFireBonus = 20;
		}
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = cold = pois = nrgy = chaos = direct = 0;
            fire = 100;
        }

		public PhoenixBow( Serial serial ) : base( serial )
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