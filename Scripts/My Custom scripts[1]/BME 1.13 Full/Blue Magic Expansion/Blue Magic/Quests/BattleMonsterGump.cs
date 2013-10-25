// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class BattleMonsterGump : Gump
	{
		public Mobile From;
		public Point3D MoveToLocation;
		public Map MoveToMap;

		public BattleMonsterGump( Mobile from, string name, Point3D point, Map map ) : base( 100, 100 )
		{
			From = from;
			MoveToLocation = point;
			MoveToMap = map;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddImage( 0, 0, 2080 );
			AddImage( 17, 37, 2081 );
			AddImage( 17, 107, 2082 );
			AddImage( 17, 177, 2083 );

			AddLabel( 35, 35, 1371, from.Name );
			AddLabel( 35, 55, 1365, "Requests that you help him to defeat" );
			AddLabel( 35, 75, 1365, "the champion" );
			AddLabel( 120, 75, 1371, name );
			AddLabel( 35, 95, 1365, "It is said to hold powerful artifacts" );
			AddLabel( 35, 115, 1365, "that you, if you are lucky, can obtain." );

			AddLabel( 35, 155, 1365, "Accept?" );
			AddLabel( 170, 155, 1365, "Yes:" );
			AddButton( 200, 155, 1896, 1895, 1, GumpButtonType.Reply, 0 );

			AddLabel( 225, 155, 1365, "No:" );
			AddButton( 250, 155, 1896, 1895, 0, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				sender.Mobile.MoveToWorld( MoveToLocation, MoveToMap );
			else
			{
				sender.Mobile.SendMessage( "You decline their offer." );

				if ( From != null )
					From.SendMessage( sender.Mobile.Name + " has declined your offer" );
			}
		}
	}
}