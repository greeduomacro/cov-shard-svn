/* Created by Hammerhand*/

using System;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class FirePick : BaseAxe
	{
        public override HarvestSystem HarvestSystem { get { return FireRockMining.System; } }


		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		[Constructable]
		public FirePick() : base( 0xE86 )
		{
            Name = "a Fire Pick";
			Weight = 11.0;
            Hue = 1358;
			UsesRemaining = 50;
			ShowUsesRemaining = true;
		}

        public FirePick(Serial serial)
            : base(serial)
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
			ShowUsesRemaining = true;
		}
	}
}