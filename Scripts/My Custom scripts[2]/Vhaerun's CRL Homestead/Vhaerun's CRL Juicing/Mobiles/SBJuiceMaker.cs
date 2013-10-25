using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBJuiceMaker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBJuiceMaker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( JuicersTools ), 500, 20, 0xE4F, 0 ) );
				Add( new GenericBuyInfo( typeof( Lemon ), 5, 20, 0x1728, 0 ) );
				Add( new GenericBuyInfo( typeof( Lime ), 5, 20, 0x172A, 0 ) );
				Add( new GenericBuyInfo( typeof( Apple ), 5, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Dates ), 5, 20, 0x1727, 0 ) );
				Add( new GenericBuyInfo( typeof( Orange ), 5, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Peach ), 5, 20, 0x9D2, 0 ) );
				Add( new GenericBuyInfo( typeof( Pear ), 5, 20, 0x994, 0 ) );
				Add( new GenericBuyInfo( typeof( Pumpkin ), 5, 20, 0xC6A, 0 ) );
				Add( new GenericBuyInfo( typeof( Tomato ), 5, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Watermelon ), 5, 20, 0xC5C, 0 ) );
				Add( new GenericBuyInfo( typeof( Banana ), 5, 20, 0x171F, 0 ) );
				Add( new GenericBuyInfo( typeof( Apricot ), 5, 20, 0x9D2, 0 ) );
				Add( new GenericBuyInfo( typeof( Blackberries ), 5, 20, 0x9D1, 0 ) );
				Add( new GenericBuyInfo( typeof( Blueberries ), 5, 20, 0x9D1, 0 ) );
				Add( new GenericBuyInfo( typeof( Cherries ), 5, 20, 0x9D1, 0 ) );
				Add( new GenericBuyInfo( typeof( Grapefruit ), 5, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Kiwi ), 5, 20, 0xF8B, 0 ) );
				Add( new GenericBuyInfo( typeof( Mango ), 5, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Pineapple ), 5, 20, 0xFC4, 0 ) );
				Add( new GenericBuyInfo( typeof( Pomegranate ), 5, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Strawberry ), 5, 20, 0xF2A, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyJuiceBottle ), 5, 20, 0x99B, 0 ) );
				Add( new GenericBuyInfo( typeof( FarmLabelMaker ), 500, 20, 0xFC0, 0 ) );
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