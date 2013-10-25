using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
public class FameGump : Gump
{
public static void Initialize()
{
CommandSystem.Register( "FameGump", AccessLevel.Player, new CommandEventHandler( FameGump_OnCommand ) );
}

private static void FameGump_OnCommand( CommandEventArgs e )
{
e.Mobile.SendGump( new FameGump( e.Mobile ) );
}

public FameGump( Mobile owner ) : base( 0, 0 )
{
AddBackground( 100, 40, 200, 125, 5054 );


AddPage( 0 );


AddHtml( 120, 45, 160, 57, "In this Gump you can see your Fame/Karma level", false, false );

AddButton( 120, 135, 0xFB7, 0xFB9, 0, GumpButtonType.Reply, 0 );
AddLabel( 155, 138, 0, "Close" );

AddPage( 1 );

AddLabel( 120, 85, 0, string.Format("Your Fame: {0}", owner.Fame) );
AddButton( 120, 110, 0xFA5, 0xFA7, 0, GumpButtonType.Page, 2 );
AddLabel( 155, 113, 0, "Switch to Karma" );

AddPage( 2 );

AddLabel( 120, 85, 0, string.Format("Your Karma: {0}", owner.Karma) );
AddButton( 120, 110, 0xFA5, 0xFA7, 0, GumpButtonType.Page, 1 );
AddLabel( 155, 113, 0, "Switch to Fame" );
}

public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
{
Mobile from = state.Mobile;

switch ( info.ButtonID )
{
case 0:
{
from.SendMessage( "Closed !!" );

break;
}
}
}
}
}