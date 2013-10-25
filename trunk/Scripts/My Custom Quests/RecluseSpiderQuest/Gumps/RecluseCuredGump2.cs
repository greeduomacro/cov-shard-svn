using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class RecluseCuredGump2 : Gump
	{
        public RecluseCuredGump2()
			: base( 200, 200 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 357, 122, 9270);
			this.AddAlphaRegion( 2, 2, 353, 118 );
//			this.AddItem(297, 38, 4168);
			this.AddLabel(48, 23, 255, @"You are not infected with the");
			this.AddLabel(48, 39, 255, @"Recluse Venom, why are you back?");
			this.AddLabel(48, 55, 255, @"I have no need of those things now!");
			this.AddLabel(48, 71, 255, @"You need to go and leave us alone!");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
