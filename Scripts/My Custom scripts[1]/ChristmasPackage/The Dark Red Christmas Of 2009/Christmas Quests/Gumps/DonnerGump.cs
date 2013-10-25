using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class DonnerGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "DonnerGump", AccessLevel.GameMaster, new CommandEventHandler( DonnerGump_OnCommand ) ); 
}
private static void DonnerGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new DonnerGump( e.Mobile ) ); } 
public DonnerGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Donner of the 8 Reindeer" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Hello there I'm Donner. I like to help <BR>" +
"<BASEFONT COLOR=YELLOW>pull Santa's Sleigh to deliver the <BR>" +
"<BASEFONT COLOR=YELLOW>presents of christmas. But I was gonna <BR>" +
"<BASEFONT COLOR=YELLOW>ask you if you could do a job for me?<BR>" +
"<BASEFONT COLOR=YELLOW>Since Santa has Gone evil and he's doin<BR>" +
"<BASEFONT COLOR=YELLOW>very naughty things, I would like for <BR>" +
"<BASEFONT COLOR=YELLOW>you to fetch his hat for me. With his <BR>" +
"<BASEFONT COLOR=YELLOW>hat, I can use it's magic to stop this <BR>" +
"<BASEFONT COLOR=YELLOW>evil christmas of terror. I heard Santa<BR>" +
"<BASEFONT COLOR=YELLOW>was located in Ice. Thanks for helping.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
