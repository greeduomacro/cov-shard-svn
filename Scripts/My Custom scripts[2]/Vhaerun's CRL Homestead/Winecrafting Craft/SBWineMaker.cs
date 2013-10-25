using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBWineMaker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWineMaker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
                Add(new GenericBuyInfo( typeof( VinyardGroundAddonDeed ), 5000, 20, 0xE4F, 0));
                Add(new GenericBuyInfo( typeof( bottlerackAddonDeed ), 500, 20, 0x1728, 0));
                Add(new GenericBuyInfo( typeof( kegstorageAddonDeed ), 500, 20, 0x172A, 0));
                Add(new GenericBuyInfo( typeof( GrapevinePlacementTool ), 5000, 20, 0xD1A, 0));
                Add(new GenericBuyInfo( typeof( EmptyWineBottle ), 5, 20, 3854, 0));
                Add(new GenericBuyInfo( typeof( WinecrafterYeast ), 5, 20, 4165, 0));
                Add(new GenericBuyInfo( typeof( WinecrafterSugar ), 5, 20, 4165, 0));
                Add(new GenericBuyInfo( typeof( VinyardLabelMaker ), 500, 20, 0xFC0, 0));
                Add(new GenericBuyInfo(typeof(WinecraftersTools), 500, 20, 0xF00, 0));
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