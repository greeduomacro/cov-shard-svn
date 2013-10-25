using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class RecluseCuredGump1 : Gump
	{
        public RecluseCuredGump1()
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
			this.AddLabel(48, 23, 255, @"You are not infected with the");
			this.AddLabel(48, 39, 255, @"Recluse Venom, why are you here?");
			this.AddLabel(48, 55, 255, @"My sister and I are very busy! Now Go!");
			//this.AddLabel(48, 71, 255, @"");
//			this.AddItem(12, 38, 4171);

		}
		

	}
}
