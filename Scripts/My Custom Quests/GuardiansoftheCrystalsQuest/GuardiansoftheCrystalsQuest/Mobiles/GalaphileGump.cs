using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GalaphileGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("GalaphileGump", AccessLevel.GameMaster, new CommandEventHandler(GalaphileGump_OnCommand));
        }

        private static void GalaphileGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new GalaphileGump(e.Mobile));
        }

        public GalaphileGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Welcome brave stranger!");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=White> I welcome your bravery in coming here! In order to save COV from future destruction, you must seek out and destroy the six, *Guardians of the Crystals!* These terrible beasts are Ancient Dragons, " +
"<BASEFONT COLOR=White> that long ago, appeared on the shard and stole the very crystalline fragments that hold all of the elements of nature together! If these beasts are not sought out and killed soon, this shard will " +
"<BASEFONT COLOR=White> slowly fade out into oblivion! These fragments need to be recaptured and brought back to me, so I may combine them and restore the elements of the Shard itself! This will not be an easy quest to" + 
"<BASEFONT COLOR=White> complete, as you will need the aid of others I'm sure. If you agree to this task, I can only give you one clue to find these beasts. They are hidden in secret places in the land of Ilshenar! " + 
"<BASEFONT COLOR=White> So, are you up to the challenge to seek all six out, slay them, retrieve all the fragments that they guard, and return them to me? If you agree and return, I will reward you with a great treasure!" + 
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
                        from.SendMessage("I hope you accept this quest and succeed! COV depends on your bravery!");
                        from.CloseGump(typeof(GalaphileGump));
                        from.AddToBackpack(new GalaphileMarker());

                        break;
                    }
                case 1:
                    {
                        from.SendMessage("I had hoped you would attempt to save the shard! If you change your mind, I'll be here.");
                        from.CloseGump( typeof( GalaphileGump ) );
                        break;
                    }
            }
        }
    }
}
        
