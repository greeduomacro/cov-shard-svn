using System; 
using System.Collections.Generic; 
using Server.Items; 
using Server.Items.Crops;

namespace Server.Mobiles 
{ 
	public class SBGardener : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGardener()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( "1060834", typeof( Engines.Plants.PlantBowl ), 2, 20, 0x15FD, 0 ) );
                Add( new GenericBuyInfo( "SeedContainer", typeof( SeedContainer ), 1000, 20, 0x2D4A, 0 ) );
                Add( new GenericBuyInfo( "SeedBox", typeof( SeedBox), 1000, 20, 0xE80, 0 ) );
                Add( new GenericBuyInfo( "Sprinkler", typeof( Sprinkler ), 5000, 20, 0x14E7, 0 ) );
                Add( new GenericBuyInfo( "SprinklerContainer", typeof( SprinklerContainer), 5000, 20, 0x142B, 0 ) );
				Add( new GenericBuyInfo( "Cotton Seed", typeof( CottonSeed ), 250, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Flax Seed", typeof( FlaxSeed ), 250, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Wheat Seed", typeof( WheatSeed ), 150, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Planting Corn", typeof( CornSeed ), 150, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Carrot Seed", typeof( CarrotSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Onion Seed", typeof( OnionSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Garlic Seed", typeof( GarlicSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Lettuce Seed", typeof( LettuceSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cabbage Seed", typeof( CabbageSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Almond Tree Seed", typeof( AlmondTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Apple Tree Seed", typeof( AppleTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Apricot Tree Seed", typeof( ApricotTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Asparagus Seed", typeof( AsparagusSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Avocado Tree Seed", typeof( AvocadoTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Banana Tree Seed", typeof( BananaTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Beet Seed", typeof( BeetSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Bitter Hops Seed", typeof( BitterHopsSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Blackberry Tree Seed", typeof( BlackberryTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "BlackRaspberry Tree Seed", typeof( BlackRaspberryTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Blueberry Tree Seed", typeof( BlueberryTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Broccoli Seed", typeof( BroccoliSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cantaloupe Seed", typeof( CantaloupeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cauliflower Seed", typeof( CauliflowerSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Celery Seed", typeof( CelerySeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cherry Tree Seed", typeof( CherryTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "ChiliPepper Seed", typeof( ChiliPepperSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cocoa Tree Seed", typeof( CocoaTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Coconut Palm Seed", typeof( CoconutPalmSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Coffee Seed", typeof( CoffeeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cranberry tree Seed", typeof( CranberryTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Cucumber Seed", typeof( CucumberSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Date Palm Seed", typeof( DatePalmSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Eggplant Seed", typeof( EggplantSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Elven Hops Seed", typeof( ElvenHopsSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Field Corn Seed", typeof( FieldCornSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Ginger Seed", typeof( GingerSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "ginseng Seed", typeof( GinsengSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Grapefruit Tree Seed", typeof( GrapefruitTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "GreenBean Seed", typeof( GreenBeanSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Green Pepper Seed", typeof( GreenPepperSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Green Squash Seed", typeof( GreenSquashSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Hay Seed", typeof( HaySeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Honeydew melon Seed", typeof( HoneydewMelonSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Kiwi Seed", typeof( KiwiSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Lemon Tree Seed", typeof( LemonTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Lime Tree Seed", typeof( LimeTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Mandrake Seed", typeof( MandrakeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Mango Tree Seed", typeof( MangoTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Nightshade Seed", typeof( NightshadeSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Oats Seed", typeof( OatsSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Orange Pepper Seed", typeof( OrangePepperSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Orange Tree Seed", typeof( OrangeTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Peach Tree Seed", typeof( PeachTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Peanut Seed", typeof( PeanutSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Pear Tree Seed", typeof( PearTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Peas Seed", typeof( PeasSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Pineapple Tree Seed", typeof( PineappleTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Pistacio Tree Seed", typeof( PistacioTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Plum Tree Seed", typeof( PlumTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Pomegranate Tree Seed", typeof( PomegranateTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Potato Seed", typeof( PotatoSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Pumpkin Seed", typeof( PumpkinSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Radish Seed", typeof( RadishSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Red Pepper Seed", typeof( RedPepperSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Red Raspberry Tree Seed", typeof( RedRaspberryTreeSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Rice Seed", typeof( RiceSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Snow Hops Seed", typeof( SnowHopsSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Snow Peas Seed", typeof( SnowPeasSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Soy Seed", typeof( SoySeed ), 50, 20, 0xF27, 0x5E2 ) );
                        Add( new GenericBuyInfo( "Spinach Seed", typeof( SpinachSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Squash Seed", typeof( SquashSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Strawberry Seed", typeof( StrawberrySeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Sugar Seed", typeof( SugarSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Sun Flower Seed", typeof( SunFlowerSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Sweet Hops Seed", typeof( SweetHopsSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Sweet Potato Seed", typeof( SweetPotatoSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Tea Seed", typeof( TeaSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Tomato Seed", typeof( TomatoSeed ), 50, 20, 0xF27, 0x5E2 ) );
			      Add( new GenericBuyInfo( "Turnip Seed", typeof( TurnipSeed ), 50, 20, 0xF27, 0x5E2 ) );
				Add( new GenericBuyInfo( "Watermelon Seed", typeof( WatermelonSeed ), 50, 20, 0xF27, 0x5E2 ) );
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