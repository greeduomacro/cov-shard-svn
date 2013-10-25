using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
namespace Server.Gumps
{
    public class BritainLibrarianQuestGump : Gump 
    { 
public static void Initialize() 
{ 
CommandSystem.Register( "BritainLibrarianQuestGump", AccessLevel.GameMaster,
    new CommandEventHandler(BritainLibrarianQuestGump_OnCommand)); 
}
private static void BritainLibrarianQuestGump_OnCommand( CommandEventArgs e ) 
{
    e.Mobile.SendGump(new BritainLibrarianQuestGump(e.Mobile));
} 
public BritainLibrarianQuestGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Britain Librarian" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW><I>Shara looks up at you from behind her glasses.</I><BR><BR>“Hello there stranger!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I hope you have not traveled all this way for the Fairy Tale books?”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Why you ask? Well it’s because one of them has been stolen from this very library!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I know of a way to obtain a copy of the book, but alas, I can not leave my post here.”<BR><BR><I>She looks at you with pleading eyes.</I><BR><BR>“You are brave and an adventurer though, aren't you?”" +

"<BASEFONT COLOR=YELLOW> “If you would go to <I>The farms West of here</I> and speak with Fifer the first of the three little pigs. perhaps you have heard of him? He and his brothers must recall their story with the wolf.”" +

"<BASEFONT COLOR=YELLOW> “It is their story that was stolen from me. Please help me to obtain it and I shall reward you for your efforts.”" +

"<BASEFONT COLOR=YELLOW> “Just combine the pieces of the story into one.”" +

"<BASEFONT COLOR=YELLOW> “Be swift brave adventurers and return to me with the story. My thanks for your efforts in this endeavor.”" +

"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; 
    switch ( info.ButtonID ) 
    {
        case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            {
                //Cancel
                from.SendMessage("Get the story of The Three Little Pigs and return it to the librarian.");
                break;
            }
    }
}
    }
}
