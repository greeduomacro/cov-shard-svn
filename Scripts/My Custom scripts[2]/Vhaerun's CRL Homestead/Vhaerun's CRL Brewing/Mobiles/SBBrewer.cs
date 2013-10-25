using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBBrewer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBrewer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Keg ), 50, 20, 0xE7F, 0 ) );
				Add( new GenericBuyInfo( typeof( BrewersTools ), 500, 20, 0x1EBC, 0 ) );
                Add( new GenericBuyInfo( typeof( BreweryBox ), 1000, 20, 0xE80, 0 ) );
				Add( new GenericBuyInfo( typeof( BreweryLabelMaker ), 500, 20, 0xFBF, 0 ) );
				Add( new GenericBuyInfo( typeof( Malt ), 10, 20, 0x103D, 0 ) );
				Add( new GenericBuyInfo( typeof( Barley ), 20, 20, 0x103F, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyAleBottle ), 10, 20, 0x99B, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyMeadBottle ), 10, 20, 0x99B, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyJug ), 10, 20, 0x9C8, 0 ) );
				Add( new GenericBuyInfo( typeof( BitterHops ), 5, 20, 0x1AA2, 0 ) );
				Add( new GenericBuyInfo( typeof( SnowHops ), 5, 20, 0x1AA2, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenHops ), 5, 20, 0x1AA2, 0 ) );
				Add( new GenericBuyInfo( typeof( SweetHops ), 5, 20, 0x1AA2, 0 ) );
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