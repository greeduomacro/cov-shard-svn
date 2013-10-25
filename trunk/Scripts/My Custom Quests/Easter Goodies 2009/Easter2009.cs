using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class Easter2009 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new Easter2009() );
		}

		public override DateTime Start{ get{ return new DateTime( 2009, 4, 11 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2009, 4, 13 ); } }

		public override void GiveGift( Mobile mob )
		{
			GiftBox box = new GiftBox();
			box.Hue = Utility.RandomList( 124, 1166 );

            box.DropItem(new EasterBonnet2009());
            box.DropItem(new ChocolateEasterBunny2009());
            box.DropItem(new EasterCard2009());
            box.DropItem(new EasterCarrot2009());
            box.DropItem(new BagOfJellyBeans());
            box.DropItem(new EasterLily2009());
            box.DropItem(new BubbleGumEasterGrass2009());
            box.DropItem(new MarshmallowPeep2009());

			switch ( GiveGift( mob, box ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy Easter! from the Staff of COV!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
                    mob.SendMessage( 0x482, "Happy Easter! from the Staff of COV!  Gift items have been placed in your bank box.");
					break;
			}
		}
	}
}
