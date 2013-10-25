using System;
using Server;
using System.Collections.Generic;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class WakitaGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "WakitaGump", AccessLevel.GameMaster, new CommandEventHandler( WakitaGump_OnCommand ) ); 
      } 

      public static void WakitaGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new WakitaGump( e.Mobile ) ); 
      } 

      public WakitaGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "New Neighbors Quest" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/                                                                   
"<BASEFONT COLOR=WHITE>I see your new to COV, and could use a place to live. I might be able to help you out with a new house.<BR>" +
"<BASEFONT COLOR=WHITE> If you would go and get me 100 boards, so I can finish this last house I'm building, I'll reward you with the Deed to it.<BR>" +

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

            AddButton( 135, 390, 0xF7, 0xF8, 1, GumpButtonType.Reply, 1);
            AddButton( 250, 390, 241, 242, 0, GumpButtonType.Reply, 0 );


//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile;

         switch (info.ButtonID)
         {
             case 1:
                 {
                     from.SendMessage("I'm glad you accepted this task, now go get me my boards!");
                     from.CloseGump(typeof(WakitaGump));
                     from.AddToBackpack(new WakitaMarker());

                     break;
                 }
             case 0:
                 {
                     from.SendMessage("Such a pity, Hopefully someone will help me finish this house.");
                     from.CloseGump(typeof(WakitaGump));
                     break;
                 }
         }
      }
   }
}
