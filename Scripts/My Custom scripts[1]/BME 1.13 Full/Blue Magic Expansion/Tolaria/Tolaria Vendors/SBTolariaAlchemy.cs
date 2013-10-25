// Created by Peoharen
using System;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	public class SBTolariaAlchemy : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTolariaAlchemy()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, 10, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, 10, 0xF08, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, 10, 0xF09, 0 ) );
				Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, 10, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( HealPotion ), 30, 10, 0xF0C, 0 ) );
 				Add( new GenericBuyInfo( typeof( CurePotion ), 30, 10, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( Bottle ), 5, 100, 0xF0E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 8, 10, 0xE9B, 0 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 200, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 200, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, 200, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 200, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 200, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, 200, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 200, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 200, 0xF8C, 0 ) );
				Add( new GenericBuyInfo( typeof( BatWing ), 3, 200, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, 200, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, 200, 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, 200, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, 200, 0xF8F, 0 ) );

				Add( new GenericBuyInfo( "Crafting Glass With Glassblowing", typeof( GlassblowingBook ), 10637, 10, 0xFF4, 0 ) );
				Add( new GenericBuyInfo( "Finding Glass-Quality Sand", typeof( SandMiningBook ), 10637, 10, 0xFF4, 0 ) );
				Add( new GenericBuyInfo( "1044608", typeof( Blowpipe ), 21, 100, 0xE8A, 0x3B9 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( HealPotion ), 14 );
				Add( typeof( CurePotion ), 14 );
				Add( typeof( Bottle ), 3 );
				Add( typeof( MortarPestle ), 4 );

				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 2 );
				Add( typeof( BatWing ), 1 );
				Add( typeof( DaemonBlood ), 3 );
				Add( typeof( PigIron ), 2 );
				Add( typeof( NoxCrystal ), 3 );
				Add( typeof( GraveDust ), 1 );

				Add( typeof( GlassblowingBook ), 5000 );
				Add( typeof( SandMiningBook ), 5000 );
				Add( typeof( Blowpipe ), 10 );
			}
		}
	}
}