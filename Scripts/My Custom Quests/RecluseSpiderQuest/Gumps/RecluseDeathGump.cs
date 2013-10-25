using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class RecluseDeathGump : Gump
	{
        public RecluseDeathGump()
			: base( 200, 200 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 360, 118, 9270);
			this.AddAlphaRegion( 2, 2, 356, 114 );
//			this.AddItem(297, 38, 4168);
			this.AddLabel(118, 10, 1149, @"Times UP! You Were Warned!");
			this.AddLabel(48, 39, 255, @"    You have failed to complete the quest");
			this.AddLabel(48, 55, 255, @"    within 1 hr. and get the antidote.");
			this.AddLabel(48, 71, 255, @"    You have suffered a 10% loss in all skills!");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
