using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBLootMap : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBLootMap()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				// GenericBuyInfo( string name, Type type, int price, int amount, int itemID, int hue )
				Add( new GenericBuyInfo( "Britain", typeof( BritainLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Buccaneer's Den", typeof( BuccaneersDenLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Jhelom", typeof( JhelomLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Magincia", typeof( MaginciaLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Minoc", typeof( MinocLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Moonglow", typeof( MoonglowLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Nu Jelm", typeof( NujelmLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Serpent's Hold", typeof( SerpentsHoldLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Skara Brae", typeof( SkaraBraeLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Trinsic", typeof( TrinsicLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Vesper", typeof( VesperLootMap ), 3000, 5, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( "Yew", typeof( YewLootMap ), 3000, 5, 0x14EC, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BritainLootMap ), 1500 );
				Add( typeof( BuccaneersDenLootMap ), 1500 );
				Add( typeof( JhelomLootMap ), 1500 );
				Add( typeof( MaginciaLootMap ), 1500 );
				Add( typeof( MinocLootMap ), 1500 );
				Add( typeof( MoonglowLootMap ), 1500 );
				Add( typeof( NujelmLootMap ), 1500 );
				Add( typeof( SerpentsHoldLootMap ), 1500 );
				Add( typeof( SkaraBraeLootMap ), 1500 );
				Add( typeof( TrinsicLootMap ), 1500 );
				Add( typeof( VesperLootMap ), 1500 );
				Add( typeof( YewLootMap ), 1500 );
			}
		}
	}
}