using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class RTWGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("RTW", AccessLevel.GameMaster, new CommandEventHandler(RTWGump_OnCommand));
        }

        private static void RTWGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new RTWGump(e.Mobile));
        }

        public RTWGump(Mobile owner)
            : base(50, 50)
        {
            //----------------------------------------------------------------------------------------------------

            AddPage(0);
            AddImageTiled(54, 33, 369, 400, 2624);
            AddAlphaRegion(54, 33, 369, 400);

            AddImageTiled(416, 39, 44, 389, 203);
            //--------------------------------------Window size bar--------------------------------------------

             AddImage(97, 49, 9005);
            AddImageTiled(58, 39, 29, 390, 10460);
            AddImageTiled(412, 37, 31, 389, 10460);
            AddLabel(140, 60, 0x34, "The Tourist Trap");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> I sho' need yer help. There's a gator down yonder that's been attackin and eatin' all the tourists! Well, word got out, and the tourists stopped coming round here. He's a biggun" +
"<BASEFONT COLOR=White> he is, and a bad one! If'n you could go down yonder to that crick and find that there gator, and kill it for me, I'd sho be grateful. Bring me back his hide, and I'll get Mimi here" +
"<BASEFONT COLOR=White> to stitch you up a gator gift fer yer trouble and all. Good luck stranger!" +
                             "</BODY>", false, true);

            AddImage(430, 9, 10441);
            AddImageTiled(40, 38, 17, 391, 9263);
            AddImage(6, 25, 10421);
            AddImage(34, 12, 10420);
            AddImageTiled(94, 25, 342, 15, 10304);
            AddImageTiled(40, 427, 415, 16, 10304);
            AddImage(-10, 314, 10402);
            AddImage(56, 150, 10411);
            AddImage(155, 120, 2103);
            AddImage(136, 84, 96);
            AddButton(270, 390, 241, 242, 1, GumpButtonType.Reply, 1);
            AddButton(180, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);

            //--------------------------------------------------------------------------------------------------------------
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        from.SendMessage("I hope you accept my offer stranger.");
                        from.CloseGump(typeof(RTWGump));
                        from.AddToBackpack(new RTWMarker());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("Such a pity, if you change your mind, I'll be here.");
                        from.CloseGump( typeof( RTWGump ) );
                        break;
                    }
            }
        }
    }
}
        
