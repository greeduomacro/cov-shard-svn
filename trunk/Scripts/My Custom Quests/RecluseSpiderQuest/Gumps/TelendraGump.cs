using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class TelendraGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("TelendraGump", AccessLevel.GameMaster, new CommandEventHandler(TelendraGump_OnCommand));
        }

        private static void TelendraGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new TelendraGump(e.Mobile));
        }

        public TelendraGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Seeking The Antidote");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White>Oh my my another sick mortal! Talantra look, they are coming in like flies. Better get the cauldron out! It's time to brew another batch of Recluse Sting Antidote. Oh no! we're" +
"<BASEFONT COLOR=White>out of the ingredients you say? well then, our sick stranger must go and find the four ingredients needed for us. You must hurry sick traveler because you will die within 24hrs." +
"<BASEFONT COLOR=White>The Recluse Sting has already began to eat your flesh! " +
"<BASEFONT COLOR=White<BR>" +
"<BASEFONT COLOR=RED> 1st)You will need to go to the Fan Dancer Dojo in Tokuno, and collect 3 Dried Flowers from the rare colored Fan Dancers. " +
"<BASEFONT COLOR=White<BR>" +
"<BASEFONT COLOR=Red> 2nd)You will need to go and get five Bacterial Mud from the Mud Elementals in Despise in the swampy area." +
"<BASEFONT COLOR=White<BR>" +
"<BASEFONT COLOR=Red> 3rd)You will need to go to Destard and find the Giant Evil serpents and collect five Serpent Eggs." +
"<BASEFONT COLOR=White<BR>" +
"<BASEFONT COLOR=Red> 4th) You will need to go to Destard and find the Evil Dragon babies and collect three Dragon Flesh." +
"<BASEFONT COLOR=White<BR>" +
"<BASEFONT COLOR=White>Last but not least, you will need to bring us six Herbal waters to brew it all in. Those can be found on the Evil Water Elementals in Destard, back by the pond." +
"<BASEFONT COLOR=White>As soon as you obtain all of these items, bring them to us, and we can make the antidote to save your life!" +

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
                        from.SendMessage("Oh Good! Now hurry, you don't have much time!");
                        from.CloseGump(typeof(TelendraGump));
                        from.AddToBackpack(new TelendraMarker());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("Such a pity, you having to die like this!");
                        from.CloseGump( typeof( TelendraGump ) );
                        break;
                    }
            }
        }
    }
}
        
