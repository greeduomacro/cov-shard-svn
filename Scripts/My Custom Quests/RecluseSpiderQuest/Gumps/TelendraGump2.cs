using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class TelendraGump2 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("TelendraGump2", AccessLevel.GameMaster, new CommandEventHandler(TelendraGump2_OnCommand));
        }

        private static void TelendraGump2_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new TelendraGump2(e.Mobile));
        }

        public TelendraGump2(Mobile owner)
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
            AddLabel(140, 60, 0x34, "One last thing...");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> Good job young one! Now that we saved your life, there is one small thing to do for us to collect your reward. We need you to do this, as we are too old and feeble to do it ourselves." +
"<BASEFONT COLOR=White> We will reward you greatly for all that you have been through if you go to Despise, by a pool of acid, and kill the Recluse spider's creator. After killing him, bring us his head." +
"<BASEFONT COLOR=White> The hard part is over, now go and avenge all of us so no one else has to suffer! " +
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
                        from.SendMessage("Lets finish this up and destroy that madman!");
                        from.CloseGump(typeof(TelendraGump));
                        from.AddToBackpack(new TelendraMarker2());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("Such a pity, you don't want a reward for all your efforts!");
                        from.CloseGump( typeof( TelendraGump ) );
                        break;
                    }
            }
        }
    }
}
        
