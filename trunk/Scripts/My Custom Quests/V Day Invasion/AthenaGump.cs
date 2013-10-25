using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class AthenaGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("AthenaGump", AccessLevel.GameMaster, new CommandEventHandler(AthenaGump_OnCommand));
        }

        private static void AthenaGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new AthenaGump(e.Mobile));
        }

        public AthenaGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "We have been Invaded on Valentines Day!!!");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> Rumor has it, that Sirens have taken over the city of Buc's Den in Trammel. They have kidnapped all of the men of COV and are holding them hostage. Will you take up the fight " +
"<BASEFONT COLOR=White> and help bring our men home? If you decide to help out, I will need you to bring me back 30 of the Siren's Bloody Hearts! I will reward you for your efforts on your return." +

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
                        from.SendMessage("I hope you accept my offer, and rid Buc's of these nasty creatures");
                        from.CloseGump(typeof(AthenaGump));
                        from.AddToBackpack(new BloodyHeartMarker());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("Such a pity, if you change your mind, I'll be here.");
                        from.CloseGump( typeof( AthenaGump ) );
                        break;
                    }
            }
        }
    }
}
        
