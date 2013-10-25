using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class DorothyGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("Dorothy'sGump", AccessLevel.GameMaster, new CommandEventHandler(DorothyGump_OnCommand));
        }

        private static void DorothyGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new DorothyGump(e.Mobile));
        }

        public DorothyGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Welcome kind stranger!");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> As you can see my friends are in a state of lifelessness, and we need your help! My friend the Lion lost his courage when an Evil Paladin came and stole it from him, while he was wandering" +
"<BASEFONT COLOR=White> the jungles of Trinsic near the moongate. My friend the Tin Man lost his heart when an Evil Tinker stole it from him while he was in Minoc getting oiled. The Tinker is said to be hiding out" +
"<BASEFONT COLOR=White> in the mining cabins there. My friend the Scarecrow was working in Yew at a farm when a large black crow flew on top of his head and plucked his brain out! He could still be there wreaking havoc on others." +
"<BASEFONT COLOR=White> When I found each of them lifeless like this, I went to a witch at the Vesper Cemetary to ask for help. When I asked, she knocked me down and stole my Ruby Red Slippers! Please, I am begging" +
"<BASEFONT COLOR=White> you to go out and find these Evil creatures and get our items back for us. We will be forever grateful. If you do happen to retrieve all 4 of these items for us, bring them back here and give" +
"<BASEFONT COLOR=White> them to the Wizard, and he will reward you with a strongbox full of goodies that might help you on other quests in the future." +
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
                        from.SendMessage("Thank you for helping us, and please hurry back!");
                        from.CloseGump(typeof(DorothyGump));
                        from.AddToBackpack(new DorothyMarker());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("Such a pity, we will be stuck here forever! But, if you change your mind, I'll be here.");
                        from.CloseGump( typeof( DorothyGump ) );
                        break;
                    }
            }
        }
    }
}
        
