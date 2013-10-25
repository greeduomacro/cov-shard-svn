using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
    public class FiferPigQuestGump2 : Gump { 

        public static void Initialize() { 
CommandSystem.Register( "FiferPigQuestGump", AccessLevel.GameMaster, 
    new CommandEventHandler( FiferPigQuestGump2_OnCommand ) ); 
}

        private static void FiferPigQuestGump2_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new FiferPigQuestGump2( e.Mobile ) ); } 

        public FiferPigQuestGump2( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Fifer Pig" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW><I>Fifer inspects the quality of the straw.</I><BR><BR>“Now let me see... Yes! That's perfect!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Thank you so much for your help! I can now rebuild my home. Here is my story as promised.”<BR><BR><I>He hands you a scroll.</I><BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I am so appreciative of your efforts I have made you a Golden Ring of Straw. May it serve you well in your travels.<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Now take it to my brother and he will surely add his part to mine.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“His house can be located <I>In a clearing North</I> of here.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW><I>He bids you good day.</I><BR><BR> “Fair well and safe journeys!”" +

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
