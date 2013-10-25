using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBMasterCook : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMasterCook()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( FoodPlate ), 5, 20, 0x9D7, 0 ) );
				Add( new GenericBuyInfo( typeof( BakersBoard ), 10, 20, 0x14EA, 0 ) );
				Add( new GenericBuyInfo( typeof( CooksCauldron ), 10, 20, 0x9ED, 0 ) );
				Add( new GenericBuyInfo( typeof( FryingPan ), 10, 20, 0x9E2, 0 ) );
                Add( new GenericBuyInfo( typeof( FoodDyes ), 500, 20, 0xFA9, 0 ) ); 
				Add( new GenericBuyInfo( typeof( CheeseForm ), 50, 20, 0x0E78, 0 ) );
				Add( new GenericBuyInfo( typeof( MilkBucket ), 500, 20, 0x0FFA, 0 ) );
                Add( new GenericBuyInfo( typeof( BottleCowMilk ), 15, 20, 0xF09, 0 ) );
                Add( new GenericBuyInfo( typeof( BottleSheepMilk ), 15, 20, 0xF09, 0) );
                Add( new GenericBuyInfo( typeof( BottleGoatMilk ), 15, 20, 0xF09, 0) );
				Add( new GenericBuyInfo( typeof( BasketOfHerbs ), 20, 20, 0x194F, 0 ) );
				Add( new GenericBuyInfo( typeof( MushroomGardenEastDeed ), 1000, 20, 0x14F0, 0 ) );
				Add( new GenericBuyInfo( typeof( MushroomGardenSouthDeed ), 1000, 20, 0x14F0, 0 ) );
       			Add( new GenericBuyInfo( typeof( GinsengUprooted ), 5, 20, 0x18E7, 0 ) );
				Add( new GenericBuyInfo( typeof( GinsengUprooted ), 5, 20, 0x18E8, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeUprooted ), 5, 20, 0x18DD, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeUprooted ), 5, 20, 0x18DE, 0 ) );
				Add( new GenericBuyInfo( typeof( BagOfCocoa ), 10, 20, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( BagOfCoffee ), 10, 20, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( BagOfCornmeal ), 10, 20, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( BagOfOats ), 10, 20, 0x1039, 0 ) );
                Add( new GenericBuyInfo( typeof( BagOfRicemeal ), 10, 20, 0x1039, 0 ) ); 
				Add( new GenericBuyInfo( typeof( BagOfSoy ), 10, 20, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( BagOfSugar ), 10, 20, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( CocoaNut ), 5, 20, 0x1726, 0 ) );
                Add( new GenericBuyInfo( typeof( HotBeverageMaker ), 1000, 20, 0x9D6, 0 ) );
                Add( new GenericBuyInfo( typeof( TeaPots ), 50, 20, 0x24E6, 0 ) );
                Add( new GenericBuyInfo( typeof( CoffeePot ), 50, 20, 0x24E6, 0 ) );
                Add( new GenericBuyInfo( typeof( WarmMug ), 25, 20, 0x996, 0 ) );
				Add( new GenericBuyInfo( typeof( FieldCorn ), 5, 20, 0xC81, 0 ) );
				Add( new GenericBuyInfo( typeof( Hay ), 5, 20, 0xF36, 0 ) );
       			Add( new GenericBuyInfo( typeof( OatSheath ), 5, 20, 0x1EBD, 0 ) );
				Add( new GenericBuyInfo( typeof( RiceSheath ), 5, 20, 0x1A9D, 0 ) );
				Add( new GenericBuyInfo( typeof( Sugarcane ), 5, 20, 0x1A9D, 0 ) );
				Add( new GenericBuyInfo( typeof( TeaLeaves ), 5, 20, 0x1AA2, 0 ) );
				Add( new GenericBuyInfo( typeof( Wheat ), 5, 20, 0x1EBD, 0 ) );
				Add( new GenericBuyInfo( typeof( Tortilla ), 5, 20, 0x973, 0 ) );
 				Add( new GenericBuyInfo( typeof( Eggs ), 5, 20, 0x9B5, 0 ) ); 
				Add( new GenericBuyInfo( typeof( RawBacon ), 5, 20, 0x979, 0 ) );
				Add( new GenericBuyInfo( typeof( RawBaconSlab ), 5, 20, 0x976, 0 ) );
				Add( new GenericBuyInfo( typeof( RawBird ), 5, 20, 0x9B9, 0 ) );
				Add( new GenericBuyInfo( typeof( RawChickenLeg ), 5, 20, 0x1607, 0 ) );
				Add( new GenericBuyInfo( typeof( RawFishSteak ), 5, 20, 0x097A, 0 ) );
       			Add( new GenericBuyInfo( typeof( RawHam ), 5, 20, 0x9C9, 0 ) );
				Add( new GenericBuyInfo( typeof( RawHamSlices ), 5, 20, 0x1E1F, 0 ) );
				Add( new GenericBuyInfo( typeof( RawHeadlessFish ), 5, 20, 0x1E17, 0 ) );
				Add( new GenericBuyInfo( typeof( RawLambLeg ), 5, 20, 0x1609, 0 ) );
				Add( new GenericBuyInfo( typeof( RawRibs ), 5, 20, 0x9F1, 0 ) );
				Add( new GenericBuyInfo( typeof( RawScaledFish ), 5, 20, 0x1E16, 0 ) );
                Add( new GenericBuyInfo( typeof( BaseGranery ), 500, 20, 0xE80, 0x1BB ) );

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}