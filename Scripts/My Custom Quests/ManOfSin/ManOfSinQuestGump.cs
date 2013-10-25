/*
 * User: Masternightmage
 * Date: 10/16/2005
 * Time: 8:11 PM
 *
 * Please do not remove header or try and claim this script as your own!
 * This is a cutom quest and the first quest I have ever made so leave it as it is do not mod these files!
 *
 */
using System;
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class ManOfSinQuestGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ManOfSinQuestGump", AccessLevel.GameMaster, new CommandEventHandler( ManOfSinQuestGump_OnCommand ) ); 
      } 

      private static void ManOfSinQuestGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ManOfSinQuestGump( e.Mobile ) ); 
      } 

      public ManOfSinQuestGump( Mobile owner ) : base( 50,50 ) 
      { 

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Angel Head's" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +

"<BASEFONT COLOR=RED>You there come here i've got a Job for you that will be completed or you will die!<BR><BR>You will have to slay some angel's for me or i will have your soul forever, what the hell complete the task and you will have a seat at my throne.<BR><BR>But if do not bring me what i ask you shall burn!<BR>" +
"<BASEFONT COLOR=RED>I need exactly 10 Feathers Of An Angel, You will have to kill them fast there powers are strong and they could end your life in a matter of seconds! They can be found East of the Valor Shrine in Trammel. They are waiting to make their way in to destroy my kingdom! I shall reward you well! <BR><BR>You must get the Feathers soon so HURRY UP!" +
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


      } 

      public override void OnResponse( NetState state, RelayInfo info )  
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: 
            {  
               from.SendMessage( "Hurry up or lose your soul!" );
               break; 
            } 

         }
      }
   }
}
