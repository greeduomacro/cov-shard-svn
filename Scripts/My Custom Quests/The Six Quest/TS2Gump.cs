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
   public class TS2Gump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "TS2Gump", AccessLevel.GameMaster, new CommandEventHandler( TS2Gump_OnCommand ) ); 
      } 

      public static void TS2Gump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new TS2Gump( e.Mobile ) ); 
      } 

      public TS2Gump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Return of the Control Globes" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>*Denton glances up with a worried look in his eyes*<BR><BR>Please kind Traveler, could you assist me?<BR>" +                                                                    
"<BASEFONT COLOR=WHITE>I am the keeper of the Globe that Imprisoned the Six! It has been shattered into six globes, and each one has it's own now!<BR>" +
"<BASEFONT COLOR=WHITE>They are very vicious and deadly creatures that once roamed this shard, and laid waste to everyone and thing they touched. Now they are loose and can travel anywhere on the shard at will!<BR>" +
"<BASEFONT COLOR=WHITE>I need you to find and kill all six, and bring me back all six pieces to create the Globe again to imprison them once again and keep COV safe!<BR> " +
"<BASEFONT COLOR=WHITE>If you succeed, I will reward you with a great gift!" +
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
                     from.SendMessage("I'm glad you accepted this task to get those pieces back!");
                     from.CloseGump(typeof(TS2Gump));
                     from.AddToBackpack(new TS2Marker());

                     break;
                 }
             case 0:
                 {
                     from.SendMessage("Such a pity, Hopefully someone will help me! COV will be lost without someone to help!.");
                     from.CloseGump(typeof(TS2Gump));
                     break;
                 }
         }
      }
   }
}
