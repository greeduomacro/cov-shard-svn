// Original Author Unknown
// Updated to be halloween 2007 by GreyWolf

using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class Halloween2011 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new Halloween2011() );
		}

		public override DateTime Start{ get{ return new DateTime( 2011, 10, 28 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2011, 11, 1 ); } }

		public override void GiveGift( Mobile mob )
		{
			HalloweenBagAllGifts2011 bag = new HalloweenBagAllGifts2011();

			if ( 0.1 > Utility.RandomDouble() )
			{
				bag.DropItem( new HalloweenOuiJaBoard2011() );
			}

			switch ( GiveGift( mob, bag ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy Halloween from the COV Staff!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "Happy Halloween from the COV Staff!  Gift items have been placed in your bank box." );
					break;
			}
		}
	}
}
