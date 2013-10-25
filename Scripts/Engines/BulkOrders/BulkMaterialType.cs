using System;
using Server;
using Server.Items;

namespace Server.Engines.BulkOrders
{
	public enum BulkMaterialType
	{
		None,
		DullCopper,
		ShadowIron,
		Copper,
		Bronze,
		Gold,
		Agapite,
		Verite,
		Valorite,
		Silver,
		//Platinum,
		//Mythril,
		//Obsidian,
		Jade,
		Moonstone,
		Sunstone,
		//Bloodstone,
		Spined,
		Horned,
		Barbed,
		DragonL,
		Daemon,
		Pine,
		Ash,
		Mahogany,
		Yew,
		Oak
	}

	public enum BulkGenericType
	{
		Iron,
		Cloth,
		Leather,
		Wood
	}

	public class BGTClassifier
	{
		public static BulkGenericType Classify( BODType deedType, Type itemType )
		{
			if ( deedType == BODType.Tailor )
			{
				if ( itemType == null || itemType.IsSubclassOf( typeof( BaseArmor ) ) || itemType.IsSubclassOf( typeof( BaseShoes ) ) )
					return BulkGenericType.Leather;

				return BulkGenericType.Cloth;
			}
			//else if ( deedType == BODType.Fletcher )
//////////////////////////////////
//  Cap & Fletch BOD Addon 2/2  //
//////////////////////////////////
            else if ( deedType == BODType.Fletcher )
			{
				if ( itemType == null || itemType.IsSubclassOf( typeof( BaseRanged ) ) )
					return BulkGenericType.Wood;

				return BulkGenericType.Wood;
			}
            else if ( deedType == BODType.Carpenter )
			{
				if ( itemType == null || itemType.IsSubclassOf( typeof( BaseStaff ) ) || itemType.IsSubclassOf( typeof( BaseShield ) ) )
					return BulkGenericType.Wood;

				return BulkGenericType.Wood;
			}
//////////////////////////////////
//  End of Edit            2/2  //
//////////////////////////////////
				//return BulkGenericType.Wood;

			return BulkGenericType.Iron;
		}
	}
}