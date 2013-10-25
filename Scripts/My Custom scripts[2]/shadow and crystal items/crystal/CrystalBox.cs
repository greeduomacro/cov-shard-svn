using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CrystalBox : WoodenBox
	{
		[Constructable]
		public CrystalBox() : this( 1 )
		{
			Movable = true;
			Hue = 88;
            Name = " 9th Anniversary Crystal Gift Box";
		}

		[Constructable]
		public CrystalBox( int amount )
		{
			DropItem( new CrystalBeggarStatueDeed() );
			DropItem( new CrystalBrazierDeed() );
			DropItem( new CrystalRunnerStatueDeed() );
			DropItem( new CrystalPillarDeed() );
			DropItem( new CrystalSupplicantStatueDeed() );
			DropItem( new CrystalThroneDeed() );

			
			switch ( Utility.Random( 2 ))
			{
			case 0:
                        DropItem( new CrystalBullSouthAddonDeed() );
			break;

			case 1:
                        DropItem( new CrystalBullEastAddonDeed() );
			break;
                        }
                        
                        switch ( Utility.Random( 2 ))
			{
			case 0:
                        DropItem( new CrystalTableEastAddonDeed() );
			break;

			case 1:
                        DropItem( new CrystalTableSouthAddonDeed() );
			break;
                        }

		}
		
		public CrystalBox( Serial serial ) : base( serial )
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
