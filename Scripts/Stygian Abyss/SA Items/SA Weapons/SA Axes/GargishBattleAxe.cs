using System;
using Server.Items;
using Server.Network;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0x48B0, 0x48B1 )]
	public class GargishBattleAxe : BaseAxe
	{
        public override int LabelNumber { get { return 1097480; } } ///gargish battle axe

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 31; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.50f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 38; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

         public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public GargishBattleAxe() : base( 0x48B0 )
		{
			Weight = 4.0;
			Layer = Layer.TwoHanded;
		}

		public GargishBattleAxe( Serial serial ) : base( serial )
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