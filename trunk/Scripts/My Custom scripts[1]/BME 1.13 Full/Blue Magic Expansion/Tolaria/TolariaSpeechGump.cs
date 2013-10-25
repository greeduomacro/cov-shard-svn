using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class TolariaSpeechGump : Gump
	{
		public TolariaSpeechGump( string speech ) : base( 100, 100 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddImage( 0, 0, 2080 );
			AddImage( 17, 37, 2081 );
			AddImage( 17, 107, 2082 );
			AddImage( 17, 177, 2083 );
			AddHtml( 30, 40, 235, 130, speech, true, true );
		}
	}
}