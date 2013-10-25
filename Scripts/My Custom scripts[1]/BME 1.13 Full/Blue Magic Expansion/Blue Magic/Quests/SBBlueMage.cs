// Created by Peoharen
using System;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	public class SBBlueMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBlueMage()
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

				Add( new GenericBuyInfo( typeof( BlueArms ), 100000, 5, 0x144E, 1365 ) );
				Add( new GenericBuyInfo( typeof( BlueBoots ), 100000, 5, 0x2FC4, 1365 ) );
				Add( new GenericBuyInfo( typeof( BlueCloak ), 100000, 5, 0x26AD, 1365 ) );
				Add( new GenericBuyInfo( typeof( BlueHat ), 100000, 5, 0x1718, 1365 ) );
				Add( new GenericBuyInfo( typeof( BluePants ), 100000, 5, 0x1539, 1365 ) );
				Add( new GenericBuyInfo( typeof( BlueSash ), 100000, 5, 0x1541, 1365 ) );
				Add( new GenericBuyInfo( typeof( BlueShirt ), 100000, 5, 0x1517, 1365 ) );
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

				Add( typeof( BlueArms ), 10000 );
				Add( typeof( BlueBoots ), 10000 );
				Add( typeof( BlueCloak ), 10000 );
				Add( typeof( BlueHat ), 10000 );
				Add( typeof( BluePants ), 10000 );
				Add( typeof( BlueSash ), 10000 );
				Add( typeof( BlueShirt ), 10000 );
			}
		}
	}
}