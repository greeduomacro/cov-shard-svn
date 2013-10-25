using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class RecluseAntidoteGump : Gump
	{
        public RecluseAntidoteGump()
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
			this.AddLabel(48, 23, 255, @"You are longer infected with the");
			this.AddLabel(48, 39, 255, @"Recluse Venom, as you drink down");
			this.AddLabel(48, 55, 255, @"the antidote.");
			//this.AddLabel(48, 71, 255, @"");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
