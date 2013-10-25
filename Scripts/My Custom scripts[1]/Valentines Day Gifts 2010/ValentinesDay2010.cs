using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class ValentinesDay2009 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new ValentinesDay2009() );
		}

		public override DateTime Start{ get{ return new DateTime( 2010, 2, 13 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2010, 2, 15 ); } }

		public override void GiveGift( Mobile mob )
		{
			GiftBox box = new GiftBox();
			box.Hue = Utility.RandomList( 38, 1166 );

			box.DropItem( new PinkChampagne() );
			box.DropItem( new ChampagneFlute() );
			box.DropItem( new CandleOfLove1() );
			box.DropItem( new ValCandy() );
			box.DropItem( new ValCandy() );
			box.DropItem( new ValCandy() );
			box.DropItem( new ValCandy() );
			box.DropItem( new ValCandy() );

			LongStemRose rose = new LongStemRose();
			rose.Name = "a whispering rose from " + mob.Name;
			box.DropItem( rose );
			
			ValCandy candy = new ValCandy();
			candy.Name = "Valentine's Candy from " + mob.Name;
			box.DropItem( candy );

            ValCandy candy1 = new ValCandy();
            candy1.Name = "Valentine's Candy from " + mob.Name;
            box.DropItem(candy1);

            ValCandy candy2 = new ValCandy();
            candy2.Name = "Valentine's Candy from " + mob.Name;
            box.DropItem(candy2);

            ValCandy candy3 = new ValCandy();
            candy3.Name = "Valentine's Candy from " + mob.Name;
            box.DropItem(candy3);

            ValCandy candy4 = new ValCandy();
            candy4.Name = "Valentine's Candy from " + mob.Name;
            box.DropItem(candy4);
			
			

			int random = Utility.Random( 100 );

			if ( random < 30 )
				box.DropItem( new CupidsBow() );
			else
				box.DropItem( new CupidsHarp() );


			switch ( GiveGift( mob, box ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy Valentines Day from the Staff!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "Happy Valentines Day from the Staff!  Gift items have been placed in your bank box." );
					break;
			}
		}
	}
}
