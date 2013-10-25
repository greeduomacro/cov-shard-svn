using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class TelendraFinishGump : Gump
	{
        public TelendraFinishGump()
			: base( 200, 200 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 360, 125, 9270);
			this.AddAlphaRegion( 2, 2, 356, 121 );
//			this.AddItem(297, 38, 4168);
			this.AddLabel(48, 23, 255, @"My, My! You have done it! We are");
			this.AddLabel(48, 39, 255, @"so proud of you for ridding us of");
			this.AddLabel(48, 55, 255, @"vile spider creator. Here is your");
			this.AddLabel(48, 71, 255, @"reward for all you have been through!");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
