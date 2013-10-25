using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class MissMuffetGump : Gump
   {
      public static void Initialize() 
      { 
		 CommandSystem.Register( "MissMuffetGump", AccessLevel.GameMaster, new CommandEventHandler( MissMuffetGump_OnCommand ) );
	  }

	  private static void MissMuffetGump_OnCommand( CommandEventArgs e )
      { 
		 e.Mobile.SendGump( new MissMuffetGump( e.Mobile ) );
      }

       public MissMuffetGump(Mobile owner)
           : base(50, 50)
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Miss Muffet" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW><I>As you approach the child you can see tears flowing down her cheeks.</I><BR><BR><I>You kindly ask her what is wrong.</I><BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I was sitting in the field eating my curds and whey when all of a sudden spiders came down beside me.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I was so frightened that I dropped my bowl of curds and whey. It is the only meal I have today, but more could be made if only I were not so frightened of the spiders and their queen.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“You can find the spiders around the spider cave in Illshenar. A wizard, named Merlin, was kind enough to open me a portal to the land of Illshenar and the spiders, but alas I am to frightened to go retrieve my curds and whey.”<BR><BR> <I>She hands you two bowls for making curds and whey. She then asks a favor of you...</I><BR><BR>“If you could collect 10 whey from the spiders you could use the plain bowl to make a curd and then with the second bowl and the curd you could make me my curds and whey.”<BR><BR>The spiders are crystaline and very aggresive so be careful. I can not thank you enough for undertaking this task for me.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“If you succeed in bringing me a bowl of curds and whey then I will reward you with my special ring and scroll that will allow you the chance to kill the Spider Queen. God's speed stranger.” <BR><BR>" +

											  "</BODY>", false, true);


			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 );

//--------------------------------------------------------------------------------------------------------------
	  }

	  public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
	  {
		 Mobile from = state.Mobile;

		 switch ( info.ButtonID )
		 {
			case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
			{
			   //Cancel
			   from.SendMessage( "Make the bowl of curds and whey and return it to Little Miss Muffet." );
			   break;
			}

		 }
	  }
   }
}