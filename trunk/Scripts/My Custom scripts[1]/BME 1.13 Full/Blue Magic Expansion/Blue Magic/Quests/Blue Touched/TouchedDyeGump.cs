using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
	public class TouchedDyeGump : Gump
	{
		public TouchedDyeGump() : base( 25, 25 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 342, 275, 9270 );

			AddImage( 15, 15, 113, 1365 );
			AddLabel( 104, 17, 1365, "Touched Recolorer" );
			AddLabel( 126, 35, 1365, "Choose A Color" );
			AddImage( 295, 15, 113, 1365 );
			AddImage( 15, 55, 2054, 1365 );
			AddImage( 219, 55, 2054, 1365 );

			// Row 1
			AddImage( 15, 75, 113, 1156 );
			AddButton( 23, 115, 2117, 2118, 1157/*ButtonID*/, GumpButtonType.Reply, 0 );
			AddImage( 55, 76, 113, 1254 );
			AddButton( 63, 115, 2117, 2118, 1255, GumpButtonType.Reply, 0 );
			AddImage( 95, 75, 113, 2217 );
			AddButton( 103, 115, 2117, 2118, 2218, GumpButtonType.Reply, 0 );
			AddImage( 135, 75, 113, 1154 );
			AddButton( 142, 115, 2117, 2118, 1155, GumpButtonType.Reply, 0 );
			AddImage( 175, 75, 113, 1155 );
			AddButton( 183, 115, 2117, 2118, 1156, GumpButtonType.Reply, 0 );
			AddImage( 215, 75, 113, 1157 );
			AddButton( 223, 115, 2117, 2118, 1158, GumpButtonType.Reply, 0 );
			AddImage( 255, 75, 113, 1174 );
			AddButton( 263, 115, 2117, 2118, 1175, GumpButtonType.Reply, 0 );
			AddImage( 295, 75, 113, 1149 );
			AddButton( 303, 115, 2117, 2118, 1150, GumpButtonType.Reply, 0 );

			// Row 2
			AddImage( 15, 140, 113, 1193 );
			AddButton( 23, 180, 2117, 2118, 1194/*ButtonID*/, GumpButtonType.Reply, 0 );
			AddImage( 55, 140, 113, 2113 );
			AddButton( 63, 180, 2117, 2118, 2114, GumpButtonType.Reply, 0 );
			AddImage( 95, 140, 113, 1158 );
			AddButton( 103, 180, 2117, 2118, 1159, GumpButtonType.Reply, 0 );
			AddImage( 135, 140, 113, 1163 );
			AddButton( 142, 180, 2117, 2118, 1164, GumpButtonType.Reply, 0 );
			AddImage( 175, 140, 113, 1365 );
			AddButton( 183, 180, 2117, 2118, 1365, GumpButtonType.Reply, 0 );
			AddImage( 214, 140, 113, 1167 );
			AddButton( 223, 180, 2117, 2118, 1168, GumpButtonType.Reply, 0 );
			AddImage( 255, 140, 113, 0 );
			AddButton( 263, 180, 2117, 2118, 1, GumpButtonType.Reply, 0 );
			AddImage( 295, 140, 113, 1164 );
			AddButton( 303, 180, 2117, 2118, 1165, GumpButtonType.Reply, 0 );

			// Row 3
			AddImage( 14, 205, 113, 1165 );
			AddButton( 23, 245, 2117, 2118, 1166, GumpButtonType.Reply, 0 );
			AddImage( 55, 205, 113, 1160 );
			AddButton( 63, 245, 2117, 2118, 1161, GumpButtonType.Reply, 0 );
			AddImage( 95, 205, 113, 1168 );
			AddButton( 103, 245, 2117, 2118, 1169, GumpButtonType.Reply, 0 );
			AddImage( 135, 205, 113, 1166 );
			AddButton( 142, 245, 2117, 2118, 1167, GumpButtonType.Reply, 0 );
			AddImage( 175, 205, 113, 1172 );
			AddButton( 183, 245, 2117, 2118, 1173, GumpButtonType.Reply, 0 );
			
			AddImage( 215, 205, 113, 1169 );
			AddButton( 223, 245, 2117, 2118, 1170, GumpButtonType.Reply, 0 );
			AddImage( 255, 205, 113, 2101 );
			AddButton( 263, 245, 2117, 2118, 2101, GumpButtonType.Reply, 0 );
			AddImage( 295, 205, 113, 1150 );
			AddButton( 303, 245, 2117, 2118, 1151, GumpButtonType.Reply, 0 );
		}
		
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( sender.Mobile != null && info.ButtonID > 0 )
				sender.Mobile.Target = new TouchedDyeTarget( info.ButtonID );
		}

		public class TouchedDyeTarget : Target
		{
			private int m_Hue;

			public TouchedDyeTarget( int hue ) : base( 1, false, TargetFlags.None )
			{
				m_Hue = hue;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( !(o is BlueClothing) )
				{
					from.SendMessage( "That isn't a piece of touched clothing." );
					return;
				}

				BlueClothing cloth = (BlueClothing)o;

				if ( from.Backpack == null )
					from.SendMessage( "You need a backpack." );
				else if ( cloth.Parent != from.Backpack )
					from.SendMessage( "The clothing must be in your backpack to dye it." );
				else
				{
					if ( m_Hue == 1 )
						cloth.Hue = 0;
					else
						cloth.Hue = m_Hue;

					from.SendLocalizedMessage( 1062623 ); // You dye the item.
				}
			}
		}
	}
}