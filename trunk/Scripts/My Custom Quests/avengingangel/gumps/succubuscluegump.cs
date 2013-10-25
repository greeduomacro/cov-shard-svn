/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class SuccubusClueGump : Gump
	{
		public SuccubusClueGump () : base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddImage(142, 115, 2081);
			this.AddImage(142, 183, 2082);
			this.AddImage(125, 78, 2080);
			this.AddHtml( 162, 112, 229, 140, "Go West of Luna, in the moutains, there are gypsies. It is said they are hiding someone.", false, false);
			this.AddImage(143, 253, 2083);

		}
		

	}
}