using System;
using Server.Items;

namespace Server.Engines.Craft
{
    #region Recipes
    public enum CookRecipes
    {
        // magical
        RotWormStew = 500
        
    }
    #endregion
	public class DefCooking : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Cooking;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044003; } // <CENTER>COOKING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefCooking();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefCooking() : base( 1, 1, 1.25 )// base( 1, 1, 1.5 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if ( quality == 0 )
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if ( makersMark && quality == 2 )
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if ( quality == 2 )
					return 1044155; // You create an exceptional quality item.
				else				
					return 1044154; // You create the item.
			}
		}


// format of AddCraft: AddCraft( typeof( ThingToMake ), Category (text or ##),
//			ThingToMake (text or ##), minskill, maxskill, typeof( FirstThingToConsume),
//			FirstThingToConsume (text or ##), Qty,
//			ErrorMessageForNotHavingFirstThingToConsume (text or ##) );
// format of AddRes:   AddRes( index, typeof( SecondThingToConsume ),
//			SecondThingToConsume (text or ##), Qty,
//			ErrorMessageForNotHavingSecondThingToConsume (text or ##) );

// index = AddCraft( typeof( Make ), Category, Make, minskill, maxskill, typeof( Consume1 ), Consume1, qty, Error );
// AddRes( index, typeof( Consume2 ), Consume2, qty, Error );

		public override void InitCraftList()
		{
			int index = -1;

			/* Begin Ingredients */
			index = AddCraft( typeof( SackFlour ), 1044495, 1024153, 0.0, 100.0, typeof( WheatPlant ), 1044489, 2, 1044490 );
			SetNeedMill( index, true );

			index = AddCraft( typeof( Dough ), 1044495, 1024157, 0.0, 100.0, typeof( SackFlour ), 1044468, 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );

			index = AddCraft( typeof( SweetDough ), 1044495, 1041340, 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( JarHoney ), 1044472, 1, 1044253 );

			index = AddCraft( typeof( Batter ), 1044495, "Batter", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( Eggs ), "Eggs", 1, 1044253 );

			index = AddCraft( typeof( Butter ), 1044495, "Butter", 0.0, 100.0, typeof( Cream ), "Cream", 1, 1044253 );

			index = AddCraft( typeof( Cream ), 1044495, "Cream", 0.0, 100.0, typeof( BottleCowMilk ), "Milk", 1, 1044253 );

			index = AddCraft( typeof( CookingOil ), 1044495, "Cooking Oil", 0.0, 100.0, typeof( Peanut ), "Peanut", 10, 1044253 );

			index = AddCraft( typeof( Vinegar ), 1044495, "Vinegar", 0.0, 100.0, typeof( Apple ), "Apple", 5, 1044253 );
			AddRes( index, typeof( BottleOfWine ), "BottleOfWine", 1, 1044253 );

			/* Preparations */

			index = AddCraft( typeof( GroundBeef ), "Preparations", "Ground Beef", 0.0, 100.0, typeof( BeefHock ), "Beef Hock", 1, 1044253 );

			index = AddCraft( typeof( GroundPork ), "Preparations", "Ground Pork", 0.0, 100.0, typeof( PorkHock ), "Pork Hock", 1, 1044253 );

			index = AddCraft( typeof( SlicedTurkey ), "Preparations", "Sliced Turkey", 0.0, 100.0, typeof( TurkeyHock ), "Turkey Hock", 1, 1044253 );

			index = AddCraft( typeof( PastaNoodles ), "Preparations", "Pasta Noodles", 0.0, 100.0, typeof( SackFlour ), "Sack of Flour", 1, 1044253 );
			AddRes( index, typeof( Eggs ), "Eggs", 5, 1044253 );

			index = AddCraft( typeof( PeanutButter ), "Preparations", "Peanut Butter", 0.0, 100.0, typeof( Peanut ), "Peanuts", 30, 1044253 );

			index = AddCraft( typeof( Tortilla ), "Preparations", "Tortilla", 0.0, 100.0, typeof( BagOfCornmeal ), "Bag of Cornmeal", 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
			SetNeedOven( index, true );

			index = AddCraft( typeof( UncookedPizza ), "Preparations", "Uncooked Pizza", 0.0, 100.0, typeof( PizzaCrust ), "Pizza Crust", 1, 1044253 );
			AddRes( index, typeof( TomatoSauce ), "Tomato Sauce", 1, 1044253 );
			AddRes( index, typeof( CheeseWheel ), "Cheese Wheel", 1, 1044253 );

			index = AddCraft( typeof( DriedOnions ), "Preparations", "Dried Onions", 0.0, 100.0, typeof( Onion ), "Onions", 5, 1044253 );

			index = AddCraft( typeof( DriedHerbs ), "Preparations", "Dried Herbs", 0.0, 100.0, typeof( Garlic ), "Garlic", 2, 1044253 );
			AddRes( index, typeof( Ginseng ), "Ginseng", 2, 1044253 );
			AddRes( index, typeof( GingerRoot ), "Ginger Root", 2, 1044253 );

			index = AddCraft( typeof( BasketOfHerbs ), "Preparations", "Basket of Herbs", 0.0, 100.0, typeof( DriedHerbs ), "Dried Herbs", 1, 1044253 );
			AddRes( index, typeof( DriedOnions ), "Dried Onions", 1, 1044253 );

			/* Sauces */

			index = AddCraft( typeof( BarbecueSauce ), "Sauces", "Barbecue Sauce", 0.0, 100.0, typeof( Tomato ), "Tomato", 1, 1044253 );
			AddRes( index, typeof( JarHoney ), "Honey", 1, 1044253 );
			AddRes( index, typeof( BasketOfHerbs ), "Basket Of Herbs", 1, 1044253 );

			index = AddCraft( typeof( CheeseSauce ), "Sauces", "Cheese Sauce", 0.0, 100.0, typeof( Butter ), "Butter", 1, 1044253 );
			AddRes( index, typeof( BottleCowMilk ), "Milk", 1, 1044253 );
			AddRes( index, typeof( CheeseWheel ), "Cheese Wheel", 1, 1044253 );

			index = AddCraft( typeof( EnchiladaSauce ), "Sauces", "Enchilada Sauce", 0.0, 100.0, typeof( Tomato ), "Tomato", 1, 1044253 );
			AddRes( index, typeof( ChiliPepper ), "Chili Pepper", 1, 1044253 );
			AddRes( index, typeof( BasketOfHerbs ), "Basket Of Herbs", 1, 1044253 );

			index = AddCraft( typeof( Gravy ), "Sauces", "Gravy", 0.0, 100.0, typeof( Dough ), 1044469, 2, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
			AddRes( index, typeof( BasketOfHerbs ), "Basket Of Herbs", 1, 1044253 );

			index = AddCraft( typeof( HotSauce ), "Sauces", "Hot Sauce", 0.0, 100.0, typeof( Tomato ), "Tomato", 2, 1044253 );
			AddRes( index, typeof( ChiliPepper ), "Chili Pepper", 3, 1044253 );
			AddRes( index, typeof( BasketOfHerbs ), "Basket Of Herbs", 1, 1044253 );

			index = AddCraft( typeof( SoySauce ), "Sauces", "Soy Sauce", 0.0, 100.0, typeof( BagOfSoy ), "Bag of Soy", 1, 1044253 );
			AddRes( index, typeof( BagOfSugar ), "Bag of Sugar", 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );

			index = AddCraft( typeof( Teriyaki ), "Sauces", "Teriyaki", 0.0, 100.0, typeof( SoySauce ), "Soy Sauce", 1, 1044253 );
			AddRes( index, typeof( BottleOfWine ), "Bottle of Wine", 1, 1044253 );
			AddRes( index, typeof( JarHoney ), "Honey", 1, 1044253 );

			index = AddCraft( typeof( TomatoSauce ), "Sauces", "Tomato Sauce", 0.0, 100.0, typeof( Tomato ), "Tomato", 3, 1044253 );
			AddRes( index, typeof( BasketOfHerbs ), "Basket Of Herbs", 1, 1044253 );

            /*Soups*/

            if (Core.SE)
            {
                index = AddCraft(typeof(MisoSoup), 1044497, 1030317, 60.0, 110.0, typeof(RawFishSteak), 1044476, 1, 1044253);
                AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                SetNeededExpansion(index, Expansion.SE);
                SetNeedOven(index, true);

                index = AddCraft(typeof(WhiteMisoSoup), 1044497, 1030318, 60.0, 110.0, typeof(RawFishSteak), 1044476, 1, 1044253);
                AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                SetNeededExpansion(index, Expansion.SE);
                SetNeedOven(index, true);

                index = AddCraft(typeof(RedMisoSoup), 1044497, 1030319, 60.0, 110.0, typeof(RawFishSteak), 1044476, 1, 1044253);
                AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                SetNeededExpansion(index, Expansion.SE);
                SetNeedOven(index, true);

                index = AddCraft(typeof(AwaseMisoSoup), 1044497, 1030320, 60.0, 110.0, typeof(RawFishSteak), 1044476, 1, 1044253);
                AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                SetNeededExpansion(index, Expansion.SE);
                SetNeedOven(index, true);

                index = AddCraft( typeof( GreenTea ), 1044496, 1030315, 80.0, 130.0, typeof( GreenTeaBasket ), 1030316, 1, 1044253 );
				AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
				SetNeededExpansion( index, Expansion.SE );
				SetNeedOven( index, true );

				index = AddCraft( typeof( WasabiClumps ), 1044496, 1029451, 70.0, 120.0, typeof( BaseBeverage ), 1046458, 1, 1044253 );
				AddRes( index, typeof( WoodenBowlOfPeas ), 1025633, 3, 1044253 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( SushiRolls ), 1044496, 1030303, 90.0, 120.0, typeof( BaseBeverage ), 1046458, 1, 1044253 );
				AddRes( index, typeof( RawFishSteak ), 1044476, 10, 1044253 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( SushiPlatter ), 1044496, 1030305, 90.0, 120.0, typeof( BaseBeverage ), 1046458, 1, 1044253 );
				AddRes( index, typeof( RawFishSteak ), 1044476, 10, 1044253 );
				SetNeededExpansion( index, Expansion.SE );
            }

			index = AddCraft( typeof( TribalPaint ), 1044496, 1040000, 80.0, 80.0, typeof( SackFlour ), 1044468, 1, 1044253 );
			AddRes( index, typeof( TribalBerry ), 1046460, 1, 1044253 );

            if (Core.SE)
            {
		    index = AddCraft( typeof( EggBomb ), 1044496, 1030249, 90.0, 120.0, typeof( Eggs ), 1044477, 1, 1044253 );
			AddRes( index, typeof( SackFlour ), 1044468, 3, 1044253 );
			SetNeededExpansion( index, Expansion.SE );
            }

            #region Mondain's Legacy
            if (Core.ML)
            {
                index = AddCraft(typeof(ParrotWafer), 1044496, 1032246, 37.5, 87.5, typeof(Dough), 1044469, 1, 1044253);
                AddRes(index, typeof(JarHoney), 1044472, 1, 1044253);
                AddRes(index, typeof(RawFishSteak), 1044476, 10, 1044253);
                SetNeededExpansion(index, Expansion.ML);
            }
            #endregion
            /* End Soups/SE/ML */

			/* Mixes */

			index = AddCraft( typeof( CakeMix ), "Mixes", "Cake Mix", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( CookingOil ), "Cooking Oil", 1, 1044253 );
			AddRes( index, typeof( BagOfSugar ), "Bag of Sugar", 1, 1044253 );

			index = AddCraft( typeof( CookieMix ), "Mixes", "Cookie Mix", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( Butter ), "Butter", 1, 1044253 );
			AddRes( index, typeof( JarHoney ), "Honey", 1, 1044253 );

			index = AddCraft( typeof( AsianVegMix ), "Mixes", "Asian Vegetable Mix", 0.0, 100.0, typeof( Cabbage ), "Cabbage", 1, 1044253 );
			AddRes( index, typeof( Onion ), "Onion", 1, 1044253 );
			AddRes( index, typeof( Mushrooms ), "Mushroom", 1, 1044253 );
			AddRes( index, typeof( Carrot ), "Carrot", 1, 1044253 );

			index = AddCraft( typeof( ChocolateMix ), "Mixes", "Chocolate Mix", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( BagOfCocoa ), "Bag of Cocoa", 1, 1044253 );
			AddRes( index, typeof( BagOfSugar ), "Bag of Sugar", 1, 1044253 );

			index = AddCraft( typeof( MixedVegetables ), "Mixes", "Mixed Vegetables", 0.0, 100.0, typeof( Potato ), "Potato", 2, 1044253 );
			AddRes( index, typeof( Carrot ), "Carrot", 1, 1044253 );
			AddRes( index, typeof( Celery ), "Celery", 1, 1044253 );
			AddRes( index, typeof( Onion ), "Onion", 1, 1044253 );

			index = AddCraft( typeof( PieMix ), "Mixes", "Pie Mix", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( Butter ), "Butter", 1, 1044253 );

			index = AddCraft( typeof( PizzaCrust ), "Mixes", "Pizza Crust", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );

			index = AddCraft( typeof( WaffleMix ), "Mixes", "Waffle Mix", 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( Eggs ), "Eggs", 2, 1044253 );
			AddRes( index, typeof( CookingOil ), "Cooking Oil", 1, 1044253 );

			/* Food */

			index = AddCraft( typeof( BowlCornFlakes ), "Food", "Bowl of Corn Flakes", 0.0, 100.0, typeof( BagOfCornmeal ), "Bag of Cornmeal", 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );

			index = AddCraft( typeof( BowlRiceKrisps ), "Food", "Bowl of Rice Krisps", 0.0, 100.0, typeof( BagOfRicemeal ), "Bag of Ricemeal", 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );

			index = AddCraft( typeof( FruitBasket ), "Food", "Fruit Basket", 0.0, 100.0, typeof( Apple ), "Apple", 5, 1044253 );
			AddRes( index, typeof( Peach ), "Peach", 5, 1044253 );
			AddRes( index, typeof( Pear ), "Pear", 5, 1044253 );
			AddRes( index, typeof( Cherries ), "Cherries", 5, 1044253 );

			index = AddCraft( typeof( Tofu ), "Food", "Tofu", 0.0, 100.0, typeof( BagOfSoy ), "Bag of Soy", 1, 1044253 );

			/* Other */
			index = AddCraft( typeof( Pith ), "Other", "Pith", 50.0, 100.0, typeof( Log ), "Log or Board", 5, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
			SetNeedOven( index, true );

            #region Mondain's Legacy
            /* Begin Enchanted */
            if (Core.ML)
            {
                index = AddCraft(typeof(FoodEngraver), 1073108, 1072951, 75.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
                AddRes(index, typeof(JarHoney), 1044472, 1, 1044253);
                SetNeededExpansion(index, Expansion.ML);

                index = AddCraft(typeof(EnchantedApple), 1073108, 1072952, 60.0, 110.0, typeof(Apple), 1044479, 1, 1044253);
                AddRes(index, typeof(GreaterHealPotion), 1073467, 1, 1044253);
                SetNeededExpansion(index, Expansion.ML);

                index = AddCraft(typeof(WrathGrapes), 1073108, 1072953, 95.0, 145.0, typeof(Grapes), 1073468, 1, 1044253);
                AddRes(index, typeof(GreaterStrengthPotion), 1073466, 1, 1044253);
                SetNeededExpansion(index, Expansion.ML);

                /*index = AddCraft(typeof(FruitBowl), 1073108, 1072950, 55.0, 105.0, typeof(EmptyWoodenBowl), 1073472, 1, 1044253);
                AddRes(index, typeof(Pear), 1044481, 3, 1044253);
                AddRes(index, typeof(Apple), 1044479, 3, 1044253);
                AddRes(index, typeof(Banana), 1073470, 3, 1044253);
                SetNeededExpansion(index, Expansion.ML);*/
            }
            /* End Enchanted */
            #endregion
		}
	}
}