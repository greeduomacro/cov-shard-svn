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
   public class SCSMGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "SCSMGump", AccessLevel.GameMaster, new CommandEventHandler( SCSMGump_OnCommand ) ); 
      } 

      public static void SCSMGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new SCSMGump( e.Mobile ) ); 
      } 

      public SCSMGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Santa's Stolen Boots" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>*Larry glances up with a worried look in his eyes*<BR><BR>Please kind Traveler,  could you assist me?<BR>" +
"<BASEFONT COLOR=WHITE>I am the official boot maker for Mr.Clause, and we seem to be missing his most favorite pair that he wears every Christmas. These are<BR>" +
"<BASEFONT COLOR=WHITE>the very magical boots he wears on Christmas Eve. The only 2 clues I have are some brownish green fur caught in the workshop door, and some very peculiar deer footprints<BR>" +
"<BASEFONT COLOR=WHITE>in the snow headed east. It has to be that nasty Evil reindeer Marty again! If you would find him, kill him, and bring me back Santa's boots<BR> " +
"<BASEFONT COLOR=WHITE>I will reward you with a magical pair for yourself!" +
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
                     from.SendMessage("I'm glad you accepted this task and get those boots back!");
                     from.CloseGump(typeof(SCSMGump));
                     from.AddToBackpack(new SCMMarker());

                     break;
                 }
             case 0:
                 {
                     from.SendMessage("Such a pity, Hopefully someone will help me! If you change your mind, I'll be here.");
                     from.CloseGump(typeof(SCSMGump));
                     break;
                 }
         }
      }
   }
}
