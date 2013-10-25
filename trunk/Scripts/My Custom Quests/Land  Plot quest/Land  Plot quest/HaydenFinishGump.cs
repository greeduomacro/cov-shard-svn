using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class HaydenFinishGump : Gump
	{
		public HaydenFinishGump()
			: base( 200, 200 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 368, 132, 9270);
			this.AddAlphaRegion( 2, 2, 364, 128 );
//			this.AddItem(297, 38, 4168);
			this.AddLabel(118, 15, 1149, @"The Land Plot Quest");
			this.AddLabel(48, 39, 255, @"So you have returned with the items that answer");
			this.AddLabel(48, 55, 255, @"our three riddles. Now my daughter can wed the");
			this.AddLabel(48, 71, 255, @"King, and I will recieve the majority of the");
            this.AddLabel(48, 87, 255, @"land my brother and I were competing for.");
            this.AddLabel(48, 103, 255, @"Thank You, here is your reward!");
//			this.AddItem(12, 38, 4171);

		}	
	}
}
