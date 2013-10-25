using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{
   public class MissMuffetGump2 : Gump
   { 
      public static void Initialize() 
      { 
		 CommandSystem.Register( "MissMuffetGump2", AccessLevel.GameMaster, new CommandEventHandler( MissMuffetGump2_OnCommand ) );
      } 

	  private static void MissMuffetGump2_OnCommand( CommandEventArgs e )
	  {
		 e.Mobile.SendGump( new MissMuffetGump2( e.Mobile ) );
      }

       public MissMuffetGump2(Mobile owner)
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
"<BASEFONT COLOR=YELLOW><I>Miss Muffet takes the bowl from you and tastes the curds and whey.</I><BR><BR>“Oh my this is the best I have ever eaten thank you so much!”<BR><BR>" +
"<BASEFONT COLOR=YELLOW>“Here are the items I promised you.”<BR><BR><I>She hands you a scroll and a ring she takes from her very finger.</I><BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I hope they are useful to you." +

"<BASEFONT COLOR=YELLOW>“If you decide to fight the Spider Queen be warned she is no small task and many have perished fighting her. She can be found just inside the entrance of the cave. There you will find a stone that with the scroll will allow you to summon her.”<BR><BR>" +


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