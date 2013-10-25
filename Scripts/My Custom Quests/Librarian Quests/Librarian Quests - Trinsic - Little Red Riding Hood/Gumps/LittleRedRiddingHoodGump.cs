using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class LittleRedRiddingHoodGump : Gump
   {
      public static void Initialize() 
      { 
		 CommandSystem.Register( "LittleRedRiddingHoodGump", AccessLevel.GameMaster, new CommandEventHandler( LittleRedRiddingHoodGump_OnCommand ) );
	  }

	  private static void LittleRedRiddingHoodGump_OnCommand( CommandEventArgs e )
      { 
		 e.Mobile.SendGump( new LittleRedRiddingHoodGump( e.Mobile ) );
      } 

	  public LittleRedRiddingHoodGump( Mobile owner ) : base( 50,50 )
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
			AddLabel( 140, 60, 0x34, "Red Riding Hood" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW><I>Little Red Riding Hood looks at you with a pleasant smile.</I><BR><BR>“Hi there!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I was just on my way to fill my basket for my dear sweet Grandmother, but alas I cannot.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“My parents need me here to help around the house. Could you by chance help me?”<BR><BR><I>She hands you an empty basket.</I><BR><BR>“If you would be so kind as to fill it with fresh green apples, I will reward you for your kindness.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“You can find the apple tree <I>North</I> of  the <I>Yew gate</I>. Be warned the tree folk that guard the tree do not take kindly to those who take their apples. However, these are the only apples my grandmother will eat.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Oh it’s my story you would like? Then I will write the story as I recall it on a scroll for you.” <BR><BR>" +

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
			   from.SendMessage( "Get enough green apples to fill the basket and return it to Little Red Ridding Hood." );
			   break;
			}

		 }
	  }
   }
}