using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class PandoraGump2 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("PandoraGump2", AccessLevel.GameMaster, new CommandEventHandler(PandoraGump2_OnCommand));
        }

        private static void PandoraGump2_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new PandoraGump2(e.Mobile));
        }

        public PandoraGump2(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Oh My, you have done it! So many before you have tried and failed! ");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> I welcome your bravery in helping all of COV and myself. Now COV should be safe! *For an Eternity I hope*" +
"<BASEFONT COLOR=White> Now here is your great reward, and a gate to return to the outside world! Good luck and be safe on your journey's." +
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
                        from.SendMessage("Be safe and have a good life on the outside, and Thank You!");
                        from.CloseGump(typeof(PandoraGump2));
                        PandoraGate g = new PandoraGate();
                        g.MoveToWorld(new Point3D(1982, 1022, -28), Map.Ilshenar);

                        break;
                    }

                  
            }
        }
    }
}