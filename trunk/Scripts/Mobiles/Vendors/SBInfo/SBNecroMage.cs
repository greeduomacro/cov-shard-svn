using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBNecroMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBNecroMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 10, 0x2253, 0 ) );
                Add( new GenericBuyInfo( typeof( SpellCastersBox ), 500, 20, 0xE80, 0x206 ) );
				Add( new GenericBuyInfo( typeof( ScribesPen ), 8, 10, 0xFBF, 0 ) );
				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 20, 0x0E34, 0 ) );
				Add( new GenericBuyInfo( typeof( RecallRune ), 15, 10, 0x1F14, 0 ) );
			    Add( new GenericBuyInfo( typeof( BatWing ), 3, 999, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, 999, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, 999, 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, 999, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, 999, 0xF8F, 0 ) );

				}
        }

				/*Type[] types = Loot.RegularScrollTypes;

				int circles = 3;

				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), 20, itemID, 0 ) );
				}
			}*/
		

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
                Add( typeof( BatWing ), 3); 
				Add( typeof( DaemonBlood ),4 ); 
				Add( typeof( PigIron ), 2 ); 
				Add( typeof( NoxCrystal ), 2 ); 
				Add( typeof( GraveDust ), 2 ); 
				Add( typeof( NecromancerSpellbook ), 20 ); 
				
				/*Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add( types[i], ((i / 8) + 2) * 5 );*/
			}
		}
	}
}