using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class StPatricksDay2009 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new StPatricksDay2009() );
		}

		public override DateTime Start{ get{ return new DateTime( 2009, 3, 16 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2009, 3, 18 ); } }

		public override void GiveGift( Mobile mob )
		{
			GiftBox box = new StPatricksDay2009BL();
			
			switch ( GiveGift( mob, box ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy St. Patricks Day from the Staff!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "Happy St. Patricks Day from the Staff!  Gift items have been placed in your bank box." );
					break;
			}
		}
	}
}
