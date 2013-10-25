using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26CE, 0x26CF )]
	public class TheRedeemer : BaseSword
	{
		public override int LabelNumber{ get{ return 1077442; } } // The Redeemer
		public override int ArtifactRarity{ get{ return 7; } }
		
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }
		

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 20; } }
		public override int AosMaxDamage{ get{ return 24; } }
		public override int AosSpeed{ get{ return 40; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public TheRedeemer() : base( 0x26CE )
		{
			Weight = 6.0;
            Hue = 1151;
            Slayer = SlayerName.DaemonDismissal;
			Slayer2 = SlayerName.Silver;
			Attributes.WeaponDamage = 55;
			LootType = LootType.Blessed;
			Layer = Layer.TwoHanded;

			StrRequirement = 85;
		}
		

		public TheRedeemer( Serial serial ) : base( serial )
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
