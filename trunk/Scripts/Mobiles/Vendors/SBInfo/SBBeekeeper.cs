using System;
using System.Collections.Generic;
using Server.Items;
using Server.Engines.Apiculture;

namespace Server.Mobiles
{
	public class SBBeekeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBeekeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( JarHoney ), 3, 20, 0x9EC, 0 ) );
				Add( new GenericBuyInfo( typeof( Beeswax ), 1, 20, 0x1422, 0 ) );
				Add( new GenericBuyInfo( typeof( apiBeeHiveDeed ), 10000, 10, 2330, 0 ) );
                Add( new GenericBuyInfo( typeof( HoneycombProcessingKettle ), 1000, 20, 0x9ED, 0) );
				Add( new GenericBuyInfo( typeof( HiveTool ), 100, 20, 2549, 0 ) );
                Add( new GenericBuyInfo( typeof( CandleWick ), 25, 20, 0x979, 0));
				Add( new GenericBuyInfo( typeof( apiWaxProcessingPot ), 250, 20, 2532, 0 ) );
				Add( new GenericBuyInfo( typeof( WaxCraftingPot ), 1000, 20, 0x142A, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( JarHoney ), 1 );
				Add( typeof( Beeswax ), 1 );
				Add( typeof( apiBeeHiveDeed ), 1000 );
				Add( typeof( HiveTool ), 50 );
				Add( typeof( apiWaxProcessingPot ), 125 );
				Add( typeof( apiLargeWaxPot ), 200 );
                Add( typeof( HoneycombProcessingKettle ), 250 );
                Add( typeof( CandleWick ), 5 );
			}
		}
	}
}