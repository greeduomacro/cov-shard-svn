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
    public class JanxTheDrunkenBlacksmithGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("JanxTheDrunkenBlacksmithGump", AccessLevel.GameMaster, new CommandEventHandler(JanxTheDrunkenBlacksmithGump_OnCommand));
        }
        private static void JanxTheDrunkenBlacksmithGump_OnCommand(CommandEventArgs e)
        {
        }
        public JanxTheDrunkenBlacksmithGump(Mobile owner): base(50, 50)
            
        {
            //----------------------------------------------------------------------------------------------------
            AddPage(0); AddImageTiled(54, 33, 369, 400, 2624); AddAlphaRegion(54, 33, 369, 400); AddImageTiled(416, 39, 44, 389, 203);
            //--------------------------------------Window size bar--------------------------------------------
            AddImage(97, 49, 9005); AddImageTiled(58, 39, 29, 390, 10460); AddImageTiled(412, 37, 31, 389, 10460);
            AddLabel(140, 60, 0x34, "Cyclops Quest");
            //----------------------/----------------------------------------------/
            AddHtml(107, 140, 300, 230, " < BODY > " +
            "<BASEFONT COLOR=YELLOW>'I've got myself in a pickle fair <BR>" +
            "<BASEFONT COLOR=YELLOW>traveler. It seems then when I was out<BR>" +
            "<BASEFONT COLOR=YELLOW>and about by this tavern here, when a<BR>" +
            "<BASEFONT COLOR=YELLOW>a few One-Eyed beasts stopped me and<BR>" +
            "<BASEFONT COLOR=YELLOW>robbed me blind! You see they are jealous<BR>" +
            "<BASEFONT COLOR=YELLOW>of me because I took over all of their<BR>" +
            "<BASEFONT COLOR=YELLOW>shady clientele by winning them in a friendly<BR>" +
            "<BASEFONT COLOR=YELLOW>game of cards in the tavern. By the way, I<BR>" +
            "<BASEFONT COLOR=YELLOW>would recommend never playing cards with<BR>" +
            "<BASEFONT COLOR=YELLOW>them, they are terrible sports! Anyway, I<BR>" +
            "<BASEFONT COLOR=YELLOW>really need your help now, and will tell you why.<BR>" +
            "<BASEFONT COLOR=YELLOW> <BR>" +
            "<BASEFONT COLOR=YELLOW>I was working on several prototype<BR>" +
            "<BASEFONT COLOR=YELLOW>blacksmith items for a certain client of<BR>" +
            "<BASEFONT COLOR=YELLOW>mine, and they stole them from me!<BR>" +
            "<BASEFONT COLOR=YELLOW>I am not strong enough to ge them back<BR>" +
            "<BASEFONT COLOR=YELLOW>If you would agree to hunt down the thieves<BR>" +
            "<BASEFONT COLOR=YELLOW>for me and retrieve these very valuable<BR>" +
            "<BASEFONT COLOR=YELLOW>prototypes I will make you exact copies<BR>" +
            "<BASEFONT COLOR=YELLOW>of the items stolen. But be very cautious<BR>" +
            "<BASEFONT COLOR=YELLOW>about these guys if you choose to help me.<BR>" +
            "<BASEFONT COLOR=YELLOW>The 3 thieves that robbed me are very<BR>" +
            "<BASEFONT COLOR=YELLOW>powerful leaders of their clan and by far<BR>" +
            "<BASEFONT COLOR=YELLOW>the strongest Cyclops I have ever seen! I do<BR>" +
            "<BASEFONT COLOR=YELLOW>know names of the 3. They are Brontes,<BR>" +
            "<BASEFONT COLOR=YELLOW>Steropes and Arges. They can be found in<BR>" +
            "<BASEFONT COLOR=YELLOW>Titan Valley.<BR>" +
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
                        from.CloseGump(typeof(JanxTheDrunkenBlacksmithGump));
                        from.AddToBackpack(new JanxMarker());
                        break;
                    }

                case 1:
                    {
                        from.SendMessage("Such a pity, my items will be lost forever! If you change your mind, I'll be here.");
                        from.CloseGump(typeof(JanxTheDrunkenBlacksmithGump));
                        break;
                    }
            }
        }
    }
}
            
        
       
        
    




