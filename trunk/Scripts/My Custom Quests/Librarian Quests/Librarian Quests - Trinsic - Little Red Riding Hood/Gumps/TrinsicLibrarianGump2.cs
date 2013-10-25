using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class TrinsicLibrarianGump2 : Gump
   { 
      public static void Initialize() 
      { 
		 CommandSystem.Register( "TrinsicLibrarianGump2", AccessLevel.GameMaster, new CommandEventHandler( TrinsicLibrarianGump2_OnCommand ) );
	  }

	  private static void TrinsicLibrarianGump2_OnCommand( CommandEventArgs e )
      { 
		 e.Mobile.SendGump( new TrinsicLibrarianGump2( e.Mobile ) );
      } 

	  public TrinsicLibrarianGump2( Mobile owner ) : base( 50,50 )
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
			AddLabel( 140, 60, 0x34, "Trinsic Librarian Trinaree" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW><I>The librarian carefully inspects the story, </I><BR><BR>“Now let me see... Yes! This is it!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“You have done it brave adventurer. I grant to you this reward for all of your hard work.”<BR><BR><I>She places a reward in your backpack. </I><BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Blessed be to you for your swift completion of your task.”" +

"<BASEFONT COLOR=YELLOW> “You have the library’s eternal gratitude and thanks! You have mine as well.”" +

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
			   from.SendMessage( "Enjoy your rewards and may the blessings of the scholars be upon you!" );
               break; 
            } 

         }
      }
   }
}