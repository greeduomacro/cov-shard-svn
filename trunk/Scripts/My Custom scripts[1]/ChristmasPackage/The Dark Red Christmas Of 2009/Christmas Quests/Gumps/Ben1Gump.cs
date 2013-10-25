using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class Ben1Gump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "Ben1Gump", AccessLevel.GameMaster, new CommandEventHandler( Ben1Gump_OnCommand ) ); 
}
private static void Ben1Gump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new Ben1Gump( e.Mobile ) ); } 
public Ben1Gump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Benny The Xmas Elf" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Merry Christmas to you sir! May I ask <BR>" +
"<BASEFONT COLOR=YELLOW>if you are having a good christmas so <BR>" +
"<BASEFONT COLOR=YELLOW>far? Well good. But I'm not doing too <BR>" +
"<BASEFONT COLOR=YELLOW>well myself. Santa has been taken over <BR>" +
"<BASEFONT COLOR=YELLOW>by an evil force and he has turned on <BR>" +
"<BASEFONT COLOR=YELLOW>us. Even Ms's Claus has turned evil!<BR>" +
"<BASEFONT COLOR=YELLOW>Also, one of our Helpers has turned on<BR>" +
"<BASEFONT COLOR=YELLOW>us too! Now Listen. Santa has sent many<BR>" +
"<BASEFONT COLOR=YELLOW>sets of presents in red blue and white<BR>" +
"<BASEFONT COLOR=YELLOW>and they explode! We cant let these get<BR>" +
"<BASEFONT COLOR=YELLOW>into the Childrens Hands! Please go out<BR>" +
"<BASEFONT COLOR=YELLOW>and Collect me 30 white Xmas Presents &<BR>" +
"<BASEFONT COLOR=YELLOW>I will gladly award you! Thank you for <BR>" +
"<BASEFONT COLOR=YELLOW>helping save Christmas!<BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
