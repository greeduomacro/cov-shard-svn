using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class AthenaGump2 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("AthenaGump2", AccessLevel.GameMaster, new CommandEventHandler(AthenaGump2_OnCommand));
        }

        private static void AthenaGump2_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new AthenaGump2(e.Mobile));
        }

        public AthenaGump2(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Oh My, you have done it!");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------" +
"<BASEFONT COLOR=White> Now here is your Invasion reward! The shard of COV thanks you!" +
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

            AddButton(225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);

            //--------------------------------------------------------------------------------------------------------------
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        from.SendMessage("Be well and safe travels.");
                        from.CloseGump(typeof(AthenaGump2));
                        
                        break;
                    }       
            }
        }
    }
}