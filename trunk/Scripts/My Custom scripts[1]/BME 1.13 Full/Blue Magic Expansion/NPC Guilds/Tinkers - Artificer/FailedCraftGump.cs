using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class FailedCraftGump : Gump
	{
		public FailedCraftGump( string message ) : base( 0, 0 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddImage( 0, 0, 2080 );
			AddImage( 17, 37, 2081 );
			AddImage( 17, 106, 2082 );
			AddImage( 17, 176, 2083 );
			AddLabel( 100, 37, 1191, "Failed Craft" );
			AddHtml( 25, 60, 245, 110, message, true, true );
		}
	}
}