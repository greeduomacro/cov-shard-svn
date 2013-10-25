// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class DivineAvengerGump : Gump
	{
		public DivineAvengerGump( Mobile from ): base( 0, 0 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 50, 0, 107, 405, 9250 );
			AddImage( 50, 0, 10462 ); // Left Dragon
			AddImage( 105, 0, 10462 ); // Right Dragon
			AddImage( 0, 0, 10440 ); // Top Left Border
			AddImage( 125, 0, 10441 ); // Top Right Border
			AddLabel( 77, 30, 1153, "Divine" );
			AddLabel( 72, 49, 1153, "Avenger" );

			int number = DivineAvengerControl.GetHolyPoints( from );

			if ( number == 0 || number == 2 || number == 3 || number > 4 )
				AddImage( 90, 80, 10001 ); // Top: 0, 2, 3, 5, 6, 7, 8, 9.

			if ( number == 0 || number == 4 || number == 5 || number == 6 || number > 7 )
				AddImage( 85, 85, 10004 ); // Top Left: 0, 4, 5, 6, 8, 9.

			if ( number == 0 || number == 2 || number == 3 || number == 4 || number > 6 )
				AddImage( 118, 85, 10004 ); // Top Right: 0, 2, 3, 4, 7, 8, 9.

			if ( number != 0 && number != 1 && number != 7 )
				AddImage( 90, 115, 10001 ); // Middle: 2, 3, 4, 5, 6, 8, 9.

			if ( number == 0 || number == 2 || number == 6 || number > 7 )
				AddImage( 85, 120, 10004 ); // Bottom Left: 0, 2, 6, 8, 9.

			if ( number != 2 )
				AddImage( 118, 120, 10004 ); // Bottom Right: 0, 3, 4, 5, 6, 7, 8, 9.

			if ( number != 1 && number != 4 && number != 7 )
				AddImage( 90, 150, 10001 ); // Bottom: 0, 2, 3, 5, 6, 8, 9.

			AddLabel( 63, 160, 0, "Lay On Hands" );
			AddButton( 95, 185, 10154, 101545, 1, GumpButtonType.Reply, 0 );
			AddLabel( 71, 208, 0, "Smite Evil" );
			AddButton( 95, 232, 10154, 101545, 2, GumpButtonType.Reply, 0 );
			AddLabel( 72, 255, 0, "Sacrifice" );
			AddButton( 95, 279, 10154, 101545, 3, GumpButtonType.Reply, 0 );
			AddLabel( 66, 302, 0, "Divine Might" );
			AddButton( 95, 328, 10154, 101545, 4, GumpButtonType.Reply, 0 );
			AddLabel( 65, 351, 0, "Turn Undead" );
			AddButton( 95, 375, 10154, 101545, 5, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 0 )
			{
				// Stop Recovery Timer
				return;
			}

			switch( info.ButtonID )
			{
				case 1: // Lay On Hands
				{
					break;
				}
				case 2: // Smite Evil
				{
					break;
				}
				case 3: // Sacrifice
				{
					break;
				}
				case 4: // Might
				{
					break;
				}
				case 5: // Turn Undead
				{
					break;
				}
			}

			sender.Mobile.CloseGump( typeof( DivineAvengerGump ) );
			sender.Mobile.SendGump( new DivineAvengerGump( sender.Mobile ) );
		}
	}
}