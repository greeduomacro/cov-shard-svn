using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class PandoraGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("PandoraGump", AccessLevel.GameMaster, new CommandEventHandler(PandoraGump_OnCommand));
        }

        private static void PandoraGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new PandoraGump(e.Mobile));
        }

        public PandoraGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Welcome to my Eternal Prison!");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> I welcome your bravery in entering here! In order to save me and COV from future destruction, you must first bring me a few things, and I will give you a great treasure!." +
"<BASEFONT COLOR=White> As you will see there are 6 gated rooms, that make up my Eternal Prison. What I ask is that you enter each room, kill the Master of each sin inside and search their corpse for" +
"<BASEFONT COLOR=White> a Crystal Of Sin, from the body of their corpse. Once you have slain all seven, and retrieve the 7 crystals, bring them back to me and I will give you a great treasure for your efforts." +
"<BASEFONT COLOR=White> The items I ask for are the actual Seven Deadly Sins trapped inside the crystals. Each one of the Masters has one of these in their possesion. The mini prisons are where I finally" +
"<BASEFONT COLOR=White> was able to trap them after the Evil Mages overran the temple above and opened my box. Pandora's Box is where the sins were trapped for all eternity, until the Evil Mages came and unleashed them." +
"<BASEFONT COLOR=White> I only have the power now to keep them imprisoned here inside this prison, unless you help me kill them. Then you must bring me the seven crystals to put back in my Box to recieve your gift " +
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
                        from.SendMessage("I hope you accept my offer and right what has been wronged");
                        from.CloseGump(typeof(PandoraGump));
                        from.AddToBackpack(new PandoraMarker());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("Such a pity, I shall be imprisoned forever! But, if you change your mind, I'll be here.");
                        from.CloseGump( typeof( PandoraGump ) );
                        break;
                    }
            }
        }
    }
}
        
