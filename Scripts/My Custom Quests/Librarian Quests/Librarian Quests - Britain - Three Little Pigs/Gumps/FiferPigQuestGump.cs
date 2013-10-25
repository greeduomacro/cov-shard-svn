using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
    public class FiferPigQuestGump : Gump { 

        public static void Initialize() { 
CommandSystem.Register( "FiferPigQuestGump", AccessLevel.GameMaster, 
    new CommandEventHandler( FiferPigQuestGump_OnCommand ) ); 
}

        private static void FiferPigQuestGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new FiferPigQuestGump( e.Mobile ) ); } 

        public FiferPigQuestGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Fifer Pig" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW><I>Fifer the pig looks at you with a pleasant smile.</I><BR><BR>“Hi there!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I was just cleaning up after that mean old Wolf who blew down my straw house.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“So you need my story again aye? Tell you what! If you could help me gather some straw from the forest then I would gladly give you my story.”<BR><BR><I>He hands you an empty Box.</I><BR><BR>“Place the straw you collect in here, but beware this is no easy task.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“In <I>Trammel find the dungeon Shame. on the 2nd level</I> you will find the <I>Straw Elementals</I> that horde the straw I require. To claim it you will have to kill him. The Elemental is not easy prey, but you look worthy to take on the challenge.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Kill the Elemental and retrieve <I>five Bales of straw</I>. when you have all five double click the box and it will combine them for easy travel. Bring me the full box and I will write my story as I recall it on a scroll for you.” <BR><BR>" +

                                              "</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) 
{
    case 0:
{ 
    break; 
}
            }
        }
    }
}
