using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class KenFinishGump : Gump
	{
		public KenFinishGump()
			: base( 200, 200 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 353, 118, 9270);
			this.AddAlphaRegion( 2, 2, 349, 114 );
//			this.AddItem(297, 38, 4168);
			this.AddLabel(118, 15, 1149, @"Quest Complete");
			this.AddLabel(48, 39, 255, @"Oh wonderful. Thank you so much!.");
			this.AddLabel(48, 55, 255, @"Please, take this as a sign of my gratitude.");
			this.AddLabel(48, 71, 255, @"Thank you again!");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
