using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class RecluseInfectedGump : Gump
	{
        public RecluseInfectedGump()
			: base( 200, 200 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 365, 134, 9270);
			this.AddAlphaRegion( 2, 2, 361, 130 );
            this.AddLabel(118, 10, 1149, @"Warning-Warning-Warning!");
            this.AddLabel(48, 33, 255, @"    You have been infected with deadly");
            this.AddLabel(48, 49, 255, @"    Recluse Venom! You have 3 hrs. to");
            this.AddLabel(48, 65, 255, @"    seek out Telandra in Witch's Haven");
            this.AddLabel(48, 81, 255, @"    for the antidote before your DEATH!");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
