// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class BagOfAssassinGear : Bag
	{
		[Constructable]
		public BagOfAssassinGear() : base()
		{
			DropItem( new ACreedBelt() );
			DropItem( new ACreedBoneArms() );
			DropItem( new ACreedChainCoif() );
			DropItem( new ACreedJinBori() );
			DropItem( new ACreedKilt() );
			DropItem( new ACreedMempo() );
			DropItem( new ACreedShirt() );
			DropItem( new ACreedSkirt() );
			DropItem( new ACreedStuddedChest() );
			DropItem( new ACreedThighBoots() );
			DropItem( new ACreedLeafGloves() );
			DropItem( new ACreedSword() );

			Bag bag = new Bag();

			for ( int i = 0; i < 16; i++ )
			{
				bag.DropItem( new Dagger() );
			}

			SmokeBomb smoke = new SmokeBomb();
			smoke.Amount = 15;
			bag.DropItem( smoke );
			bag.DropItem( new GreaterHealPotion( 15 ) );
			DropItem( bag );


			bag = new Bag();

			for ( int i = 0; i < 34; i++ )
			{
				bag.DropItem( new UpgradeACreedGarbDeed() );
			}

			DropItem( bag );
		}

		public BagOfAssassinGear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
