using System;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B9, 0x13Ba )]
	public class AquaBlade : BaseSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 80; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 25; } }
		public override int AosSpeed{ get{ return 48; } }
        public override float MlSpeed { get { return 2.00f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		[Constructable]
		public AquaBlade() : base( 0x13B9 )
		{
			Weight = 5.0;
			Name = "Aqua's Blade";
			Attributes.SpellChanneling = 1;
			WeaponAttributes.UseBestSkill = 1;
			WeaponAttributes.HitPoisonArea = 100;
			WeaponAttributes.HitHarm = 50;
			WeaponAttributes.HitLeechHits = 50;
			Hue = 1266;
			Attributes.Luck = 150;

		}

		public AquaBlade( Serial serial ) : base( serial )
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