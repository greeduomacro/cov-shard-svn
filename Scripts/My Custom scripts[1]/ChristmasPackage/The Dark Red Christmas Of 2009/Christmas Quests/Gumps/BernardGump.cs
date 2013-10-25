using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class BernardGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "BernardGump", AccessLevel.GameMaster, new CommandEventHandler( BernardGump_OnCommand ) ); 
}
private static void BernardGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new BernardGump( e.Mobile ) ); } 
public BernardGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Bernard the Elf Archerer" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Hello There! I'm sure you've heard all<BR>" +
"<BASEFONT COLOR=YELLOW>about the Horrible Christmas were havin<BR>" +
"<BASEFONT COLOR=YELLOW>this year. Well anyway, My problem is, <BR>" +
"<BASEFONT COLOR=YELLOW>I would helped fight, but Santas Helper<BR>" +
"<BASEFONT COLOR=YELLOW>got my Bow. I need it to fight! Please <BR>" +
"<BASEFONT COLOR=YELLOW>go out and find my bow for me, and I <BR>" +
"<BASEFONT COLOR=YELLOW>reward you with a Gift. Thanks<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
