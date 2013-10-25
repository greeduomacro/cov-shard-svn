using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class Easter2010 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new Easter2010() );
		}

		public override DateTime Start{ get{ return new DateTime( 2010, 4, 3 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2010, 4, 5 ); } }

		public override void GiveGift( Mobile mob )
		{
			GiftBox box = new GiftBox();
			box.Hue = Utility.RandomList( 124, 1166 );

            box.DropItem(new EasterBonnet2010());
            box.DropItem(new ChocolateEasterBunny2010());
            box.DropItem(new EasterCard2010());
            box.DropItem(new EasterCarrot2010());
            box.DropItem(new BagOfJellyBeans());
            box.DropItem(new EasterLily2010());
            box.DropItem(new BubbleGumEasterGrass2010());
            box.DropItem(new MarshmallowPeep2010());

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
