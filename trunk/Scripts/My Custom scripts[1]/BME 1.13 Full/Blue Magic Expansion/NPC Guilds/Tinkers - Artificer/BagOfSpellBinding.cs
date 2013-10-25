// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class BagOfSpellBinding : Bag
	{
		[Constructable]
		public BagOfSpellBinding() : base()
		{
			#region Regents
			Pouch pouch = new Pouch();
			pouch.DropItem( new BlackPearl( 1000 ) );
			pouch.DropItem( new Bloodmoss( 1000 ) );
			pouch.DropItem( new Garlic( 1000 ) );
			pouch.DropItem( new Ginseng( 1000 ) );
			pouch.DropItem( new MandrakeRoot( 1000 ) );
			pouch.DropItem( new Nightshade( 1000 ) );
			pouch.DropItem( new SulfurousAsh( 1000 ) );
			pouch.DropItem( new SpidersSilk( 1000 ) );
			pouch.DropItem( new BatWing( 1000 ) );
			pouch.DropItem( new GraveDust( 1000 ) );
			pouch.DropItem( new DaemonBlood( 1000 ) );
			pouch.DropItem( new NoxCrystal( 1000 ) );
			pouch.DropItem( new PigIron( 1000 ) );
			DropItem( pouch );
			#endregion

			#region Clockwork
			pouch = new Pouch();

			ArcaneGem gem = new ArcaneGem();

			if ( Core.ML )
				gem.Amount = 1000;

			pouch.DropItem( gem );

			for ( int i = 0; i < 25; i++ )
				pouch.DropItem( new PowerCrystal() );

			DropItem( pouch );
			#endregion

			#region Weapons
			pouch = new Pouch();

			for ( int i = 0; i < 10; i++ )
				pouch.DropItem( new GnarledStaff() );

			for ( int i = 0; i < 10; i++ )
			{
				pouch.DropItem( new Mace() );
				pouch.DropItem( new WarMace() );
				pouch.DropItem( new HammerPick() );
				pouch.DropItem( new Scepter() );
				pouch.DropItem( new WarHammer() );
			}

			DropItem( pouch );
			#endregion

			#region Golems
			pouch = new Pouch();
			Pouch pouchtwo = new Pouch();
			// Blood Golem
			for ( int i = 0; i < 10; i++ )
			{
				pouchtwo.DropItem( new Head() );
				pouchtwo.DropItem( new LeftArm() );
				pouchtwo.DropItem( new RightArm() );
				pouchtwo.DropItem( new LeftLeg() );
				pouchtwo.DropItem( new RightLeg() );
			}

			pouch.DropItem( pouchtwo );

			// Clay Golem
			pouchtwo = new Pouch();
			pouchtwo.DropItem( new FertileDirt( 500 ) );

			for ( int i = 0; i < 40; i++ )
				pouchtwo.DropItem( new Pitcher( BeverageType.Water ) );

			pouch.DropItem( pouchtwo );
			DropItem( pouch );
			#endregion

			#region Runebow
			pouch = new Pouch();
			pouchtwo = new Pouch();

			for ( int i = 0; i < 10; i++ )
			{
				pouchtwo.DropItem( new Crossbow() );
				pouchtwo.DropItem( new HeavyCrossbow() );
				pouchtwo.DropItem( new RepeatingCrossbow() );
			}

			pouch.DropItem( pouchtwo );
			pouch.DropItem( new ClockParts( 10 ) );
			pouch.DropItem( new SextantParts( 10 ) );
			pouch.DropItem( new Gears( 50 ) );
			pouch.DropItem( new Springs( 50 ) );
			pouch.DropItem( new IronIngot( 100 ) );
			DropItem( pouch );
			#endregion

		}

		public BagOfSpellBinding( Serial serial ) : base( serial )
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
