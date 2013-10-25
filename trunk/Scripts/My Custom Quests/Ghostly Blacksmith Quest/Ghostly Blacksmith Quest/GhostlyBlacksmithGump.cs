/* Created by Hammerhand */
using System;
using Server;
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
namespace Server.Gumps
{
    public class GhostlyBlacksmithGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("GhostlyBlacksmithGump", AccessLevel.GameMaster, new CommandEventHandler(GhostlyBlacksmithGump_OnCommand));
        }
        private static void GhostlyBlacksmithGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new GhostlyBlacksmithGump(e.Mobile));
        }
        public GhostlyBlacksmithGump(Mobile owner)
            : base(50, 50)
        {
            //----------------------------------------------------------------------------------------------------
            AddPage(0); AddImageTiled(54, 33, 369, 400, 2624); AddAlphaRegion(54, 33, 369, 400); AddImageTiled(416, 39, 44, 389, 203);
            //--------------------------------------Window size bar--------------------------------------------
            AddImage(97, 49, 9005); AddImageTiled(58, 39, 29, 390, 10460); AddImageTiled(412, 37, 31, 389, 10460);
            AddLabel(140, 60, 0x34, "Ghostly Blacksmith Quest");
            //----------------------/----------------------------------------------/
            AddHtml(107, 140, 300, 230, " < BODY > " +
            "<BASEFONT COLOR=YELLOW>'Greetings Warrior' says the spirit. <BR>" +
            "<BASEFONT COLOR=YELLOW>'Once, long ago I crafted a special<BR>" +
            "<BASEFONT COLOR=YELLOW>sword for the battles against evil.<BR>" +
            "<BASEFONT COLOR=YELLOW>The sword was victorious, but now is <BR>" +
            "<BASEFONT COLOR=YELLOW>broken. I feel its presence may be<BR>" +
            "<BASEFONT COLOR=YELLOW>needed yet again. I need you to go<BR>" +
            "<BASEFONT COLOR=YELLOW>and find the items needed to craft a new one. <BR>" +
            "<BASEFONT COLOR=YELLOW> <BR>" +
            "<BASEFONT COLOR=YELLOW>'The items I require are, Star Metal Fragments,<BR>" +
            "<BASEFONT COLOR=YELLOW>Special Charcoal, Sosarian Ore and an<BR>" +
            "<BASEFONT COLOR=YELLOW>Energizer Crystal.'<BR>" +
            "<BASEFONT COLOR=YELLOW> <BR>" +
            "<BASEFONT COLOR=YELLOW> 'The Fragments and Crystal can be found at Exodus Dungeon in Ilshenar.<BR>" +
            "<BASEFONT COLOR=YELLOW>The Charcoal can be found somewhere by Umbra in the corrupted forest, on an Ancient Reaper.<BR>" +
            "<BASEFONT COLOR=YELLOW>And the Sosarian Ore can be found in one of the Malas mines, on a special elmental. <BR>" +
            "<BASEFONT COLOR=YELLOW> <BR>" +
            "<BASEFONT COLOR=YELLOW>If you choose to accept this quest I will give you a Ghostly Smelting box<BR>" +
            "<BASEFONT COLOR=YELLOW>that you will need to combine the three items into Energized Sosarian Ingots.<BR>" +
            "<BASEFONT COLOR=YELLOW>Once you obtain the three items, put them in the box and return to me.<BR>" +
            "<BASEFONT COLOR=YELLOW>When you return, double click the box to make the special ingots, and <BR>" +
            "<BASEFONT COLOR=YELLOW>drop them on me. I will then recreate the sword for you.<BR>" +
            "<BASEFONT COLOR=YELLOW>Please hurry, for I fear we haven't much time!<BR>" +
            "</BODY>", false, true);
            //----------------------/----------------------------------------------/
            AddImage(430, 9, 10441); AddImageTiled(40, 38, 17, 391, 9263); AddImage(6, 25, 10421); AddImage(34, 12, 10420); AddImageTiled(94, 25, 342, 15, 10304); AddImageTiled(40, 427, 415, 16, 10304); AddImage(-10, 314, 10402); AddImage(56, 150, 10411); AddImage(155, 120, 2103); AddImage(136, 84, 96); AddButton(270, 390, 241, 242, 1, GumpButtonType.Reply, 1);
            AddButton(180, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);
        }
        //----------------------/----------------------------------------------/
        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        from.SendMessage("Excellent! Hopefully you'll return in one piece with the items!");
                        from.CloseGump(typeof(GhostlyBlacksmithGump));
                        from.AddToBackpack(new AncientSmeltingBox());
                        from.AddToBackpack(new BlacksmithMarker());
                        break;
                    }

                case 1:
                    {
                        from.SendMessage("Such a pity, the sword will be broken forever! If you change your mind, I'll be here.");
                        from.CloseGump(typeof(GhostlyBlacksmithGump));
                        break;
                    }
            }
        }
    }
}
            
        
       
        
    




