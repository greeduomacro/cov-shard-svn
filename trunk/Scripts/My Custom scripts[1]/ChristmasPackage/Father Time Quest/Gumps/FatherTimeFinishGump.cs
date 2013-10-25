/* Created by Hammerhand*/

using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
	public class FatherTimeFinishGump : Gump
	{
		public FatherTimeFinishGump()
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(76, 77, 298, 108, 9200);
			this.AddBackground(146, 38, 160, 49, 9200);
			this.AddLabel(163, 52, 4, @"Happy New Year!");
			this.AddLabel(82, 112, 352, @"Oh thankyou! You've saved more than you'll ever know!");
			this.AddLabel(82, 135, 262, @"Take this as my reward to you.");
			this.AddLabel(83, 90, 0, @"Father Time Says:");

		}
		

	}
}