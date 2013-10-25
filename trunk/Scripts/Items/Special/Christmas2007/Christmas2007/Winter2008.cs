using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class WinterGiftGiver2008 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new WinterGiftGiver2008() );
		}

		public override DateTime Start{ get{ return new DateTime( 2010, 12, 26 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2010, 12, 31 ); } }

		public override void GiveGift( Mobile mob )
		{
			GiftBox box = new GiftBox();

			box.DropItem( new MistletoeDeed2008() );
			box.DropItem( new PileOfGlacialSnow2008() );
			box.DropItem( new SnowPile2008() );
			box.DropItem( new LightOfTheWinterSolstice2008() );
			box.DropItem( new DecorativeTopiary2008() );
			box.DropItem( new FestiveCactus2008() );
			box.DropItem( new SnowyTree2008() );
			box.DropItem( new RedStockin() );
			box.DropItem( new SantasSleighDeed() );
			box.DropItem( new CandyCane() );
			box.DropItem( new HolidayBell2008() );
			box.DropItem( new SnowGlobe2008() );
			box.DropItem( new HolidayBell2008() );
			box.DropItem( new Snowman2008() );
			box.DropItem( new RedPoinsettia() );
			box.DropItem( new WhitePoinsettia() );
			box.DropItem( new HolidayTreeDeed() );
			box.DropItem( new CandyCane() );
			box.DropItem( new GingerBreadCookie() );
			box.DropItem( new GingerbreadHouseAddonDeed() );


			switch ( GiveGift( mob, box ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy Holidays from the staff!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "Happy Holidays from the staff!  Gift items have been placed in your bank box." );
					break;
			}
		}
	}
}