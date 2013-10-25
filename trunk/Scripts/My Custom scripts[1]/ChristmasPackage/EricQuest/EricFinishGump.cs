using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
	public class EricFinishGump : Gump
	{
		public EricFinishGump()
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(76, 77, 298, 108, 9200);
			this.AddBackground(146, 38, 160, 49, 9200);
			this.AddLabel(163, 52, 4, @"Quest Complete!");
			this.AddImage(143, -143, 50422);
			this.AddLabel(82, 112, 352, @"Oh thanks, this is most kindly of you!");
			this.AddLabel(82, 135, 262, @"Take this as a reward, all I really got.");
			this.AddLabel(83, 90, 0, @"Eric Says:");

		}
		

	}
}