// Created by Peoharen for Lady Vic
using System;
using Server;
using Server.Items;
using Server.Engines.Craft;

namespace Server.Engines.Craft
{
	public class DefPottery : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Cooking; }
		}

		public override int GumpTitleNumber
		{
			get { return 0; } // Use String
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Pottery Menu</CENTER></basefont>"; } 
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefPottery();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefPottery() : base( 1, 1, 1.25 ) // MinCraftEffect, MaxCraftEffect, Delay
		{
		}

		public override bool RetainsColorFrom( CraftItem item, Type type )
		{
			return true;
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x104 );
		}

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (failed)
            {
                if (lostMaterial)
                    return 1044043; // You failed to create the item, and some of your materials are lost.
                else
                    return 1044157; // You failed to create the item, but no materials were lost.
            }
            else
            {
                if (quality == 0)
                    return 502785; // You were barely able to make this item.  It's quality is below average.
                else if (makersMark && quality == 2)
                    return 1044156; // You create an exceptional quality item and affix your maker's mark.
                else if (quality == 2)
                    return 1044155; // You create an exceptional quality item.
                else
                    return 1044154; // You create the item.
            }
        }


		public override void InitCraftList()
		{
			int index = -1;

// public int AddCraft( Type typeItem, TextDefinition group, TextDefinition name, SkillName skillToMake, double minSkill, double maxSkill, Type typeRes, TextDefinition nameRes, int amount, TextDefinition message )
// public void AddRes( int index, Type type, TextDefinition name, int amount, TextDefinition message )
// public void AddSkill( int index, SkillName skillToMake, double minSkill, double maxSkill )

			        //AddCraft( Type, TextDefinition, TextDefinition, SkillName, double, double, Type, TextDefinition nameRes, int amount, TextDefinition message )
			index = AddCraft( typeof( Clay ), "Materials", "Clay", SkillName.Cooking, 65.0, 85.0, typeof( FertileDirt ), "Fertile Dirt", 5, "You need more fertile dirt." );
			AddRes( index, typeof ( SpringWater ), "Spring Water", 10, "You need more spring water." );
			AddSkill( index, SkillName.ItemID, 65.0, 85.0 );
            SetNeedPotteryWheel(index, true);

			// Unbaked
			index = AddCraft( typeof( PotteryVaseOneUnbaked ), "Unbaked Vases", "Vase One", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 5, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);	
            index = AddCraft( typeof( PotteryVaseTwoUnbaked ), "Unbaked Vases", "Vase Two", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 5, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseOneUnbaked ), "Unbaked Vases", "Large Vase One", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 10, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseTwoUnbaked ), "Unbaked Vases", "Large Vase Two", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 10, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseThreeUnbaked ), "Unbaked Vases", "Large Vase Three", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 10, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseFourUnbaked ), "Unbaked Vases", "Large Vase Four", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 10, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotterySmallUrnOneUnbaked ), "Unbaked Vases", "Small Urn One", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 5, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryUrnOneUnbaked ), "Unbaked Vases", "Urn One", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 7, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryUrnTwoUnbaked ), "Unbaked Vases", "Urn Two", SkillName.Cooking, 65.0, 85.0, typeof( Clay ), "Clay", 7, "You need more clay." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);

            index = AddCraft(typeof(GargishVaseOneUnbaked), "Unbaked Gargish Vases", "Gargish Vase One", SkillName.Cooking, 65.0, 85.0, typeof(Clay), "Clay", 10, "You need more clay.");
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);

            index = AddCraft(typeof(GargishVaseTwoUnbaked), "Unbaked Gargish Vases", "Gargish Vase Two", SkillName.Cooking, 65.0, 85.0, typeof(Clay), "Clay", 10, "You need more clay.");
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);

			// Baked
			index = AddCraft( typeof( PotteryVaseOne ), "Vases", "Vase One", SkillName.Cooking, 65.0, 85.0, typeof( PotteryVaseOneUnbaked ), "Unbaked Vase One", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryVaseTwo ), "Vases", "Vase Two", SkillName.Cooking, 65.0, 85.0, typeof( PotteryVaseTwoUnbaked ), "Unbaked Vase Two", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseOne ), "Vases", "Large Vase One", SkillName.Cooking, 65.0, 85.0, typeof( PotteryLargeVaseOneUnbaked ), "Unbaked Large Vase One", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseTwo ), "Vases", "Large Vase Two", SkillName.Cooking, 65.0, 85.0, typeof( PotteryLargeVaseTwoUnbaked ), "Unbaked Large Vase Two", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseThree ), "Vases", "Large Vase Three", SkillName.Cooking, 65.0, 85.0, typeof( PotteryLargeVaseThreeUnbaked ), "Unbaked Large Vase Three", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryLargeVaseFour ), "Vases", "Large Vase Four", SkillName.Cooking, 65.0, 85.0, typeof( PotteryLargeVaseFourUnbaked ), "Unbaked Large Vase Four", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotterySmallUrnOne ), "Vases", "Small Urn One", SkillName.Cooking, 65.0, 85.0, typeof( PotterySmallUrnOneUnbaked ), "Unbaked Small Urn", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryUrnOne ), "Vases", "Urn One", SkillName.Cooking, 65.0, 85.0, typeof( PotteryUrnOneUnbaked ), "Unbaked Urn One", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
			index = AddCraft( typeof( PotteryUrnTwo ), "Vases", "Urn Two", SkillName.Cooking, 65.0, 85.0, typeof( PotteryUrnTwoUnbaked ), "Unbaked Urn Two", 1, "You do not have the proper unbaked product." );
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);

            index = AddCraft(typeof(GargishVaseOne), "Vases", "Gargish Vase One", SkillName.Cooking, 65.0, 85.0, typeof(GargishVaseOneUnbaked), "Unbaked Gargish Vase One", 1, "You do not have the proper unbaked product.");
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);
            index = AddCraft(typeof(GargishVaseTwo), "Vases", "Gargish Vase Two", SkillName.Cooking, 65.0, 85.0, typeof(GargishVaseTwoUnbaked), "Unbaked Gargish Vase Two", 1, "You do not have the proper unbaked product.");
            AddSkill(index, SkillName.ItemID, 65.0, 85.0);
            SetNeedPotteryWheel(index, true);

			MarkOption = true;
		}
	}
}