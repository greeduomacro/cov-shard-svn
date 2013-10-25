/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class StoneHarpyClueGump : Gump
	{
		public StoneHarpyClueGump () : base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddImage(142, 115, 2081);
			this.AddImage(142, 183, 2082);
			this.AddImage(125, 78, 2080);
			this.AddHtml( 162, 112, 229, 140, "Khashina is on the Island of Tokuno that has the Volcano. You will find her in a house but beware, she is well guarded!", false, false);
			this.AddImage(143, 253, 2083);

		}
		

	}
}