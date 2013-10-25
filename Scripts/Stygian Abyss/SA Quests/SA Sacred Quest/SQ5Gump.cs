
using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class SQ5Gump : Gump
    {

        public static void Initialize()
        {
            CommandSystem.Register("SQ5Gump", AccessLevel.GameMaster, new CommandEventHandler(SQ5Gump_OnCommand));
        }

        private static void SQ5Gump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new SQ5Gump(e.Mobile));
        }

        public SQ5Gump(Mobile owner)
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
            AddLabel(140, 60, 1153, "Quest Offer");

            AddHtml(107, 155, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>Answering the last question correctly, you feel a strange energy wash over you.<br><br>You don't understand how you know, but you are absolutely certain that the guardians will no longer bar you from entering the Stygian Abyss.<br><br>It seems you have proven yourself worthy of La Insep Om.<br>" +

                 "</BODY>", false, true);

            AddImage(430, 9, 10441);
            AddImageTiled(40, 38, 17, 391, 9263);
            AddImage(6, 25, 10421);
            AddImage(34, 12, 10420);
            AddImageTiled(94, 25, 342, 15, 10304);
            AddImageTiled(40, 427, 415, 16, 10304);
            AddImage(-10, 314, 10402);
            AddImage(56, 150, 10411);
            AddImage(136, 84, 96);

            AddButton(114, 380, 12009, 12010, 0, GumpButtonType.Reply, 0);


        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        
                        from.CloseGump(typeof(SQ5Gump));
                        from.PlaySound(0x1E0);
                        from.FixedParticles(0x3709, 1, 30, 1153, 13, 3, EffectLayer.Head);
                        from.AddToBackpack(new AbyssMarker());

                        break;
                    }
                }  
            }
        }
    }
