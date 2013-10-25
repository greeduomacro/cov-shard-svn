using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class EricGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "EricGump", AccessLevel.GameMaster, new CommandEventHandler( EricGump_OnCommand ) ); 
      } 

      private static void EricGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new EricGump( e.Mobile ) ); 
      } 

      public EricGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "The Lost Toy" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>*Eric glances up with a worried look in his eye.*<BR><BR>Please, stranger - could you assist me?<BR>" +
"<BASEFONT COLOR=YELLOW>I'm nothing but a old farmer, but a few weeks ago a monster came here and stole my daughter Casandras favorite toy - she never stops crying..<BR>" +
"<BASEFONT COLOR=YELLOW>Please, will you find the monster and slaughter him, and then bring the toy back to me?<BR><BR> I will reward you as best I can.<BR>" +
"<BASEFONT COLOR=YELLOW>Help: The monster was last seen at an old ruin ..." +						     
                                              "</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

//			AddLabel( 113, 135, 0x34, "Eric looks at you in disbelief..." );
//			AddLabel( 113, 150, 0x34, "Eric looks at you in disbelief..." );
//			AddLabel( 113, 165, 0x34, "Eh?" );
//			AddLabel( 113, 180, 0x34, "Bah!" );
//			AddLabel( 113, 195, 0x34, "Aha?" );
//			AddLabel( 113, 210, 0x34, "Bring me the required items?" );
//			AddLabel( 113, 235, 0x34, "Bleh!" );
//			AddLabel( 113, 250, 0x34, "The materials I require are the toy," );
//			AddLabel( 113, 265, 0x34, "The monster was last seen at a ruin." );
//			AddLabel( 113, 280, 0x34, "Not a easy kill--" );
//			AddLabel( 113, 295, 0x34, "felled. Should you retreive the toy I shall" );
//			AddLabel( 113, 310, 0x34, "give you a nice reward" );
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
               from.SendMessage( "Thank you most kindly stranger!" );
               break; 
            } 

         }
      }
   }
}