using System; 
using System.Collections.Generic;
using System.Collections; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBGargishTinker: SBInfo 
	{
       private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGargishTinker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo() 
			{


                Add(new CustomGenericBuy3Info(typeof(BasketWeavingBook), 21, 20, 0xFF4, 0));

			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				/*Add( typeof( Drums ), 10 );
				Add( typeof( Tambourine ), 10 );
				Add( typeof( LapHarp ), 10 );
				Add( typeof( Lute ), 10 );

				Add( typeof( Shovel ), 6 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Scissors ), 6 );
				Add( typeof( Tongs ), 7 );
				Add( typeof( Key ), 1 );

				Add( typeof( DovetailSaw ), 6 );
				Add( typeof( MouldingPlane ), 6 );
				Add( typeof( Nails ), 1 );
				Add( typeof( JointingPlane ), 6 );
				Add( typeof( SmoothingPlane ), 6 );
				Add( typeof( Saw ), 7 );

				Add( typeof( Clock ), 11 );
				Add( typeof( ClockParts ), 1 );
				Add( typeof( AxleGears ), 1 );
				Add( typeof( Gears ), 1 );
				Add( typeof( Hinge ), 1 );
				Add( typeof( Sextant ), 6 );
				Add( typeof( SextantParts ), 2 );
				Add( typeof( Axle ), 1 );
				Add( typeof( Springs ), 1 );

				Add( typeof( DrawKnife ), 5 );
				Add( typeof( Froe ), 5 );
				Add( typeof( Inshave ), 5 );
				Add( typeof( Scorp ), 5 );

				Add( typeof( Lockpick ), 6 );
				Add( typeof( TinkerTools ), 3 );

				Add( typeof( Board ), 1 );
				Add( typeof( Log ), 1 );

				Add( typeof( Pickaxe ), 16 );
				Add( typeof( Hammer ), 3 );
				Add( typeof( SmithHammer ), 11 );
				Add( typeof( ButcherKnife ), 6 );*/
			} 
		} 
	} 
}