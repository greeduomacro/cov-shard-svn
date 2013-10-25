using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[Flipable( 0x232A, 0x232B )]
	public class StPatricksDay2009BL : GiftBox
	{
		[Constructable]
		public StPatricksDay2009BL()
		{
		
		Name = "St. Patricks's Day GiftSet 09";
		Hue = 0x23D;
		        
			DropItem( new LeprechaunsMug() );
            DropItem( new LuckyCharmsCereal2009() );
            DropItem( new CladdaghRing2009() );
            DropItem( new IrishDrinkingMug2009() );
            DropItem( new BlarneyStone2009() );
            DropItem( new CloverPatch2009() );
            DropItem( new Rainbow2009() );
            DropItem( new PotOfGold2009() );
 
		}

		public StPatricksDay2009BL( Serial serial ) : base( serial )
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