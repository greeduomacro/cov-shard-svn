using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{
   public class LittleRedRiddingHoodGump2 : Gump
   { 
      public static void Initialize() 
      { 
		 CommandSystem.Register( "LittleRedRiddingHoodGump2", AccessLevel.GameMaster, new CommandEventHandler( LittleRedRiddingHoodGump2_OnCommand ) );
      } 

	  private static void LittleRedRiddingHoodGump2_OnCommand( CommandEventArgs e )
	  {
		 e.Mobile.SendGump( new LittleRedRiddingHoodGump2( e.Mobile ) );
      } 

	  public LittleRedRiddingHoodGump2( Mobile owner ) : base( 50,50 )
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
"<BASEFONT COLOR=YELLOW><I>Maisie carefully inspects the basket</I><BR><BR>“Now let me see... Yes! That's perfect!”<BR><BR>" +
"<BASEFONT COLOR=YELLOW>“Thank you so much for your help! I will take it to Grandma later. Here are the items I promised you.”<BR><BR><I>She hands you a scroll and a gift.</I><BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I hope they are useful to you. If it is not too much bother, can you please check on my grandmother for me? She is old and I am worried about her." +

"<BASEFONT COLOR=YELLOW>Besides, I think she is the best person to tell you about the wolf and his tale.”<BR><BR> “Oh! By the way, if you would please tell her I will be along shortly with her apples I would be most appreciative.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“My grandmother’s house can be located <I>North East</I> of <I>Empath Abbey</I>.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW><I>Her smile is pleasant as she bids you good day.</I><BR><BR> “Fair thee well and safe journeys!”" +

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
			   from.SendMessage( "Thank you so much for all your help!" );
               break; 
            } 

         }
      }
   }
}