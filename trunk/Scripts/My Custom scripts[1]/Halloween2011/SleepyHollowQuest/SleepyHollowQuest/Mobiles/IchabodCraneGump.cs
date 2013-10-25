/* Created by Hammerhand*/
using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ public class IchabodCraneGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "IchabodCraneGump", AccessLevel.GameMaster, new CommandEventHandler( IchabodCraneGump_OnCommand ) ); 
}
private static void IchabodCraneGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new IchabodCraneGump( e.Mobile ) ); }
    public IchabodCraneGump(Mobile owner)
        : base(50, 50) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );
AddImageTiled(54, 33, 369, 400, 2624);
AddAlphaRegion(54, 33, 369, 400); 
AddImageTiled(416, 39, 44, 389, 203);
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );
AddImageTiled( 58, 39, 29, 390, 10460 );
AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "SleepyHollowQuest" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW>**You see before you a pale, skinny, nervous man** <BR>" +
"<BASEFONT COLOR=YELLOW>Can you please help me? I'm being <BR>" +
"<BASEFONT COLOR=YELLOW>haunted by the Headless Horseman.<BR>" +
"<BASEFONT COLOR=YELLOW>Every year at this time he appears<BR>" +
"<BASEFONT COLOR=YELLOW>riding through this area hunting me!<BR>" +
"<BASEFONT COLOR=YELLOW>So far I've escaped him, but this cant <BR>" +
"<BASEFONT COLOR=YELLOW>keep going on. He's terrorized<BR>" +
"<BASEFONT COLOR=YELLOW>Sleepy Hollow and me for years.<BR>" +
"<BASEFONT COLOR=YELLOW>Defeat him and bring me his arm<BR>" +
"<BASEFONT COLOR=YELLOW>and I will reward you. Beware, he <BR>" +
"<BASEFONT COLOR=YELLOW>is very hard to kill. I'll be hiding <BR>" +
"<BASEFONT COLOR=YELLOW>around here somewhere waiting your<BR>" +
"<BASEFONT COLOR=YELLOW>return. Good Luck!<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);
AddImageTiled( 40, 38, 17, 391, 9263 );
AddImage( 6, 25, 10421 );
AddImage( 34, 12, 10420 );
AddImageTiled( 94, 25, 342, 15, 10304 );
AddImageTiled( 40, 427, 415, 16, 10304 );
AddImage( -10, 314, 10402 );
AddImage( 56, 150, 10411 );
AddImage( 155, 120, 2103 );
AddImage( 136, 84, 96 );
AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
