using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ShadowBox : WoodenBox
	{
		[Constructable]
		public ShadowBox() : this( 1 )
		{
			Movable = true;
			Hue = 1109;
            Name = "9th Anniversary Shadow Gift Box";
		}

		[Constructable]
		public ShadowBox( int amount )
		{
			DropItem( new FireDemonStatueDeed() );
			DropItem( new GlobeOfSosariaAddonDeed() );
			DropItem( new ObsidianPillarDeed() );
			DropItem( new ShadowFirePitAddonDeed() );
			DropItem( new ShadowPillarDeed() );
			DropItem( new SpikeColumnDeed() );
			DropItem( new SpikePostDeed() );
			
			switch ( Utility.Random( 2 ))
			{
			case 0:
                        DropItem( new ShadowAltarSouthAddonDeed() );
			break;

			case 1:
                        DropItem( new ShadowAltarEastAddonDeed() );
			break;
                        }
                        
                        switch ( Utility.Random( 2 ))
			{
			case 0:
                        DropItem( new ShadowBannerEastAddonDeed() );
			break;

			case 1:
                        DropItem( new ShadowBannerSouthAddonDeed() );
			break;
                        }

		}
		
		public ShadowBox( Serial serial ) : base( serial )
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
