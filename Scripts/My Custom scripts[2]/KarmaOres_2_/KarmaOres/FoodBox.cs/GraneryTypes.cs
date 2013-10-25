/***************************************************************************/

// Modified by Ankhesentapemkah

// Credits :														
// Based on ResourceBox	by A_Li_N
// Original Gump Layout - Lysdexic
// Hashtable help - UOT and daat99

/***************************************************************************/

using System;

namespace Server.Items
{
	public class GraneryTypes
	{
		private static Type[] m_Bread = new Type[]
		{
			typeof( BreadLoaf ),
			typeof( FrenchBread ),
		};
		public static Type[] Bread{ get{ return m_Bread; } }

		private static Type[] m_Fish = new Type[]
		{
			typeof( Fish ),
			typeof( FishSteak ),
            typeof( RawFishSteak )
		};
		public static Type[] Fish{ get{ return m_Fish; } }

		private static Type[] m_Meat = new Type[]
		{
			typeof( ChickenLeg ),
            typeof( RawChickenLeg ),
			typeof( CookedBird ),
            typeof( RawBird ),
			typeof( LambLeg ),
            typeof( RawLambLeg ),
			typeof( Ribs ),
            typeof( RawRibs ),
			typeof( Ham ),typeof( PorkHock ),
			typeof( Sausage ),
			typeof( Bacon ),typeof( RawBaconSlab ),typeof( BaconSlab ),
            typeof( BeefHock ),typeof( TurkeyHock )
		};
		public static Type[] Meat{ get{ return m_Meat; } }

		private static Type[] m_Vegetables = new Type[]
		{
			typeof( Squash ),typeof( YellowGourd ),typeof( SmallPumpkin ),typeof( Pumpkin ),typeof( GreenSquash ),
			typeof( Turnip ),typeof( Onion ),typeof( Carrot ),typeof( Lettuce ),typeof( Cabbage ),typeof( GreenGourd ),
            typeof( ChiliPepper),typeof( Mushrooms ),typeof( SnowPeas ),typeof( SweetPotato ),typeof( Tomato ),typeof( Spinach ),
            typeof( GreenBean ),typeof( Radish ),typeof( Beet ),typeof( Cauliflower ),typeof( Broccoli ),typeof( Eggplant ),typeof( Cucumber ),
            typeof( Potato ),typeof( OrangePepper ),typeof( GreenPepper ),typeof( RedPepper ),typeof( Celery ),typeof( Asparagus ),typeof( Peas ),  
		};
		public static Type[] Vegetables{ get{ return m_Vegetables; } }

		private static Type[] m_Fruit = new Type[]
		{		
			typeof( Watermelon ),typeof( Cantaloupe ),typeof( SmallWatermelon ),typeof( HoneydewMelon ),typeof( Kiwi ),typeof(Grapefruit),typeof(Mango),
			typeof( Coconut ),typeof( RedRaspberry ),typeof( Grapes ),typeof( Dates ),typeof( Apple ),typeof( Peach ),typeof(Apricot),typeof(Plum),
            typeof( Strawberry ),typeof( Cherries ),typeof( Orange ),typeof( Pomegranate ),typeof( Blackberries ),typeof( Cranberries ),
            typeof( Blueberries ),typeof( Pineapple ), typeof( Lime ),typeof( Lemon ),typeof( Pear ),typeof( Banana ), 
		};
		public static Type[] Fruit{ get{ return m_Fruit; } }

		private static Type[] m_Grain = new Type[]
		{
            typeof( Hay ),typeof( EarOfCorn ),typeof( Wheat ),
            typeof( OatSheath ),typeof( Soybean ),typeof( RiceSheath ),
            typeof( FieldCorn ),typeof( Corn ),typeof( Sugarcane ),
		};
		public static Type[] Grain{ get{ return m_Grain; } }

		private static Type[] m_Misc = new Type[]
		{
			typeof( SackFlour ),typeof( Eggs ),
            typeof( BagOfSoy ),typeof( BagOfSugar ),typeof( CocoaNut ),typeof( BagOfRicemeal ),typeof( BagOfOats ),typeof( BagOfCoffee ),
            typeof( Peanut ),typeof( CoffeeBean ),typeof( CocoaBean ),typeof( Almonds ),typeof( GingerRoot ),typeof( TeaLeaves ),
		};
		public static Type[] Misc{ get{ return m_Misc; } }
	}
}
