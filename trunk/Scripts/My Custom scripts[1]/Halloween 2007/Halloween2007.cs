// Original Author Unknown
// Updated to be halloween 2007 by GreyWolf

using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class Halloween2007 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new Halloween2007() );
		}

		public override DateTime Start{ get{ return new DateTime( 2007, 10, 21 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2007, 10, 31 ); } }

		public override void GiveGift( Mobile mob )
		{
			HalloweenBag2007 bag = new HalloweenBag2007();

			bag.DropItem( new HalloweenLantern2007() );

			switch ( Utility.Random( 4 ) )
			{      	
				case 0: bag.DropItem(new HalloweenCloak2007()); break;
				case 1: bag.DropItem(new HalloweenTunic2007()); break;
				case 2: bag.DropItem(new HalloweenDoublet2007()); break;
				case 3: bag.DropItem(new HalloweenBoots2007()); break;
			}

			if ( 0.1 > Utility.RandomDouble() )
			{
				bag.DropItem( new HalloweenOuiJaBoard2007() );
			}

			switch ( GiveGift( mob, bag ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy Halloween from Tannis and Victoria!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "Happy Halloween ffrom Tannis and Victoria!  Gift items have been placed in your bank box." );
					break;
			}
		}
	}
}
