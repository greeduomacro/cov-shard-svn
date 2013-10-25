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
   public class Ranni1Gump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "Ranni1Gump", AccessLevel.GameMaster, new CommandEventHandler( Ranni1Gump_OnCommand ) ); 
      } 

      public static void Ranni1Gump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new Ranni1Gump( e.Mobile ) ); 
      } 

      public Ranni1Gump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Gathering Reagents Quest" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/                                                                   
"<BASEFONT COLOR=WHITE>I see your new to Magery since your talking to me, so I might be able to help you out.<BR>" +
"<BASEFONT COLOR=WHITE>If you would go and gather 20 Spider Silk, 20 Ginseng, 20 Nightshade, and 20 Black Pearls, <BR>" +
"<BASEFONT COLOR=WHITE> and bring them back to me, I'll reward you with a full Magery spellbook.<BR>" +

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
                     from.SendMessage("I'm glad you accepted this task, now go get my reagents!");
                     from.CloseGump(typeof(Ranni1Gump));
                     from.AddToBackpack(new Ranni1Marker());

                     break;
                 }
             case 0:
                 {
                     from.SendMessage("Such a pity, Hopefully someone will help me get my reagents");
                     from.CloseGump(typeof(Ranni1Gump));
                     break;
                 }
         }
      }
   }
}
