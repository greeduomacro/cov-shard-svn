// Based on the defCooking.cs. Defines the new craft - CarpetMaking. Establishes the crafting
// requirement of being near a CarpetLoom to craft carpets. This is done by replicating all
// NeedOven coding as NeedCarpetloom. 
// The carpet deeds made craftable here are made from Victor's RugAddOn.cs. They have
// been given more visually descriptive names. Modifications to CraftItem.cs and CraftSystem.cs
// are required to implement. Mods are listed in the text instructions page.
// Script mutilation provided by AndriaRose


using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefCarpetMaking : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Tailoring;	}
		}

		public override int GumpTitleNumber
		{
			get { return 0; } // <CENTER>CarpetMaking MENU</CENTER> --- Not made
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefCarpetMaking();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 0%(Changed from 0.0)
		}

		private DefCarpetMaking() : base( 1, 1, 1.125 )// base( 1, 1, 1.5 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if ( tool.Deleted || tool.UsesRemaining < 0 )
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

		public override void InitCraftList()
		{
			int index = -1;



			/* Begin Baking */
//			index = AddCraft( typeof( BreadLoaf ), 1044497, 1024156, 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
//			SetNeedOven( index, true );
			/* End Baking */

			/* BeginCarpet Making */


			index = AddCraft(typeof(RedRugDeed),"Plain Rugs","Red Rug",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(BrownRugDeed),"Plain Rugs","Brown Rug",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(BlueRugDeed),"Plain Rugs","Blue Rug",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(GreenRugDeed),"Plain Rugs","Green Rug",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			
			index = AddCraft(typeof(RedCarpetDeed),"Carpets","Red Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(RedPrintCarpetDeed),"Carpets","Red Print Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(BlueCarpetDeed),"Carpets","Blue Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(BluePrintCarpetDeed),"Carpets","Blue Print Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			
			index = AddCraft(typeof(RedBlueCarpetDeed),"Tapestry Carpets","Red/Blue Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(RedGoldCarpetDeed),"Tapestry Carpets","Red/Gold Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(RedPatternedCarpetDeed),"Tapestry Carpets","Red Patterned Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(RedXweaveCarpetDeed),"Tapestry Carpets","Red Xweave Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(RedFloralCarpetDeed),"Tapestry Carpets","Red Floral Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			
			index = AddCraft(typeof(BlueXweaveCarpetDeed),"Re-Hued Carpets","Blue Xweave Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(GreenFloralCarpetDeed),"Re-Hued Carpets","Green Floral Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(GoldPrintCarpetDeed),"Re-Hued Carpets","Gold Print Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(GreenPrintCarpetDeed),"Re-Hued Carpets","Green Print Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			index = AddCraft(typeof(BrownPrintCarpetDeed),"Re-Hued Carpets","Brown Print Carpet",100.00,130.0,typeof( Cloth ), 1044286, 300, 1044287 );
			SetNeedCarpetloom( index,true );
			
			
			
		}
	}
}