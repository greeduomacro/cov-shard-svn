/* Created by Mitty */
using System;
using Server;
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
namespace Server.Gumps
{
    public class HaydenGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("HaydenGump", AccessLevel.GameMaster, new CommandEventHandler(HaydenGump_OnCommand));
        }
        private static void HaydenGump_OnCommand(CommandEventArgs e)
        {
        }
        public HaydenGump(Mobile owner): base(50, 50)
            
        {
            //----------------------------------------------------------------------------------------------------
            AddPage(0); AddImageTiled(54, 33, 369, 400, 2624); AddAlphaRegion(54, 33, 369, 400); AddImageTiled(416, 39, 44, 389, 203);
            //--------------------------------------Window size bar--------------------------------------------
            AddImage(97, 49, 9005); AddImageTiled(58, 39, 29, 390, 10460); AddImageTiled(412, 37, 31, 389, 10460);
            AddLabel(140, 60, 0x34, "The Land Plot Quest");
            //----------------------/----------------------------------------------/
            AddHtml(107, 140, 300, 230, " < BODY > " +
            "<BASEFONT COLOR=YELLOW>Please can you help us dear warrior? <BR>" +
            "<BASEFONT COLOR=YELLOW>My brother and I are trying to divide<BR>" +
            "<BASEFONT COLOR=YELLOW>our land. The King has given us three<BR>" +
            "<BASEFONT COLOR=YELLOW>riddles to solve, to see who gets the<BR>" +
            "<BASEFONT COLOR=YELLOW>bigger share of the land. <BR>" +
            "<BASEFONT COLOR=YELLOW><BR>" +
            "<BASEFONT COLOR=WHITE>Here are the riddles...<BR>" +
            "<BASEFONT COLOR=YELLOW><BR>" +
            "<BASEFONT COLOR=RED>(1) What is the fastest thing in the world?<BR>" +
            "<BASEFONT COLOR=YELLOW><BR>" +
            "<BASEFONT COLOR=RED>(2) What is the heaviest thing in the world?<BR>" +
            "<BASEFONT COLOR=YELLOW><BR>" +
            "<BASEFONT COLOR=RED>(3) What is the most important thing in the<BR>" +
            "<BASEFONT COLOR=RED>world? <BR>" +
            "<BASEFONT COLOR=YELLOW><BR>" +
            "<BASEFONT COLOR=YELLOW>My daughter and I would appreciate your<BR>" +
            "<BASEFONT COLOR=YELLOW>help in solving these riddles. If we can<BR>" +
            "<BASEFONT COLOR=YELLOW>beat my brother, I will get the bigger <BR>" +
            "<BASEFONT COLOR=YELLOW>share of the land, and my daughter will<BR>" +
            "<BASEFONT COLOR=YELLOW>be able to wed the King. The only clue<BR>" +
            "<BASEFONT COLOR=YELLOW>that the King gave us, was the name of <BR>" +
            "<BASEFONT COLOR=YELLOW>an Evil librarian, his name is Ashton. He<BR>" +
            "<BASEFONT COLOR=YELLOW>can be found in Compassion in the Ancient<BR>" +
            "<BASEFONT COLOR=YELLOW>Citadel. <BR>" +
            "<BASEFONT COLOR=YELLOW><BR>" +
            "<BASEFONT COLOR=WHITE>Please bring us the items that will answer<BR>" +
            "<BASEFONT COLOR=WHITE>each riddle.<BR>" +
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
                        from.SendMessage("Excellent! Please hurry so we may beat my brother!");
                        from.CloseGump(typeof(HaydenGump));
                        from.AddToBackpack(new HaydenMarker());
                        break;
                    }

                case 1:
                    {
                        from.SendMessage("Such a pity, the riddles will remain unanswered forever! If you change your mind, We will be here.");
                        from.CloseGump(typeof(HaydenGump));
                        break;
                    }
            }
        }
    }
}
            
        
       
        
    




