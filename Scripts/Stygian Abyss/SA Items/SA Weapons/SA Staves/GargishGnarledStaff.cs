using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x48B8, 0x48B9 )]
	public class GargishGnarledStaff : BaseStaff
	{
        public override int LabelNumber { get { return 1097488; } } ///gargish gnarled staff

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 33; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.25f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 30; } }
		public override int OldSpeed{ get{ return 33; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 50; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public GargishGnarledStaff() : base( 0x48B8 )
		{
			Weight = 3.0;
		}

		public GargishGnarledStaff( Serial serial ) : base( serial )
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