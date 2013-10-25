// Created by Peoharen
using System;
using Server;
using Server.Spells.Chivalry;

namespace Server.Items
{
	public class CleanseByFireMace : BaseChivMace
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 14; } }
		public override int AosSpeed{ get{ return 40; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 32; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public CleanseByFireMace() : base( 20 )
		{
			Name = "Mace of Cleanse By Fire";
			ItemID = 0xF5C;
			Weight = 14.0;
			Layer = Layer.TwoHanded;
		}

		public override void OnWandUse( Mobile from )
		{
			Cast( new CleanseByFireSpell( from, this ) );
		}

		public CleanseByFireMace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}