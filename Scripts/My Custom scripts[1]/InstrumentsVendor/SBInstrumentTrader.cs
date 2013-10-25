//////////////////////////////////////////
//    *+ MW Admin Naturescorpse +*    ////  
// Script Name : InstrumentTrader.cs  ////
//For BaronVallyr,Additional Instruments///
//  Thanks to Talrol,Kamuflaro.WeEzL    //
//////////////////////////////////////////

using System;
using Server; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBInstrumentTrader: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBInstrumentTrader() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( "InstrumentTuningBox", typeof( InstrumentTuningBox ), 5000, 20, 0x2AF9, 0 ) ); 
				Add( new GenericBuyInfo( "Beltherlute", typeof( Beltherlute ), 500, 20, 0xEB4, 0xF9 ) );
				Add( new GenericBuyInfo( "Digeridoo", typeof( Digeridoo ), 600, 20, 0x27F5, 0x21 ) );
				Add( new GenericBuyInfo( "Drowflute", typeof( Drowflute ), 700, 20, 0x2807, 0x398 ) );
				Add( new GenericBuyInfo( "Druidlute", typeof( Druidlute ), 800, 20, 0xEB3, 0x296 ) );
				Add( new GenericBuyInfo( "Dryadharp", typeof( Dryadharp ), 575, 20, 0xEB2, 0x296 ) );
				Add( new GenericBuyInfo( "DwarvenDrum", typeof( DwarvenDrum ), 675, 20, 0xE9C, 543 ) );
				Add( new GenericBuyInfo( "Elvenlute", typeof( Elvenlute ), 775, 20, 0xEB4, 0xFE ) );
				Add( new GenericBuyInfo( "fiddle", typeof( fiddle ), 875, 20, 0x1E29, 0xF9 ) );
				Add( new GenericBuyInfo( "Gnomenoisemaker", typeof( Gnomenoisemaker ), 530, 20, 0xE9E, 0x28b ) );
				Add( new GenericBuyInfo( "LizardT", typeof( LizardT ), 630, 20, 0xE9E, 0xF9 ) );
				Add( new GenericBuyInfo( "Orcdrum", typeof( Orcdrum ), 730, 20, 0x03AA, 0x166 ) );
				Add( new GenericBuyInfo( "Panpipes", typeof( Panpipes ), 830, 20, 0x2711, 0x2E7 ) );
				Add( new GenericBuyInfo( "Satyrpipe", typeof( Satyrpipe ), 525, 20, 0x1421, 0x234 ) );
				Add( new GenericBuyInfo( "Savagedrum", typeof( Savagedrum ), 625, 20, 0x03AA, 249 ) );
				Add( new GenericBuyInfo( "Savagetambourine", typeof( Savagetambourine ), 725, 20, 0xE9D, 0x21 ) );
				Add( new GenericBuyInfo( "Spriteharp", typeof( Spriteharp ), 825, 20, 0xEB2, 0x29 ) );
				Add( new GenericBuyInfo( "Trumpet", typeof( Trumpet ), 632, 20, 0x2D30, 0x35 ) );
				Add( new GenericBuyInfo( "Vahallansaxe", typeof( Vahallansaxe ), 732, 20, 0x2D34, 253 ) );
				Add( new GenericBuyInfo( "Woodharp", typeof( Woodharp ), 832, 20, 0xEB2, 0xF9 ) );
                Add( new GenericBuyInfo( typeof( BardsStand ), 500, 20, 0xE80, 0x481 ) );
				
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof ( InstrumentTuningBox ), 500 );
				Add( typeof( Beltherlute ), 20 ); 
                                Add( typeof( Digeridoo ), 20); 
				Add( typeof( Drowflute ), 20 ); 
				Add( typeof( Druidlute ), 20 ); 
                                Add( typeof( Dryadharp ), 20 ); 
                                Add( typeof( DwarvenDrum ), 20 ); 
                                Add( typeof( Elvenlute ), 20 ); 
				Add( typeof( fiddle ), 20 );
				Add( typeof( Gnomenoisemaker ), 20 );
				Add( typeof( LizardT ), 20 );
				Add( typeof( Orcdrum ), 20 );
				Add( typeof( Panpipes ), 20 );
				Add( typeof( Satyrpipe ), 20 );
				Add( typeof( Savagedrum ), 20 );
                                Add( typeof( Savagetambourine ), 20 );
                                Add( typeof( Spriteharp ), 20 );
                                Add( typeof( Trumpet ), 20 );
                                Add( typeof( Vahallansaxe ), 20 );
                                Add( typeof( Woodharp ), 20 );
			} 
		} 
	} 
}
