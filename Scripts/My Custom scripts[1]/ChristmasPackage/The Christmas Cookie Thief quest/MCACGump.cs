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
   public class MCACGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "MCACGump", AccessLevel.GameMaster, new CommandEventHandler( MCACGump_OnCommand ) ); 
      } 

      public static void MCACGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new MCACGump( e.Mobile ) ); 
      } 

      public MCACGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "The Christmas Cookie Thief!" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>*Lorin glances up with a worried look in his eyes*<BR><BR>Please kind Traveler,  could you assist me?<BR>" +
"<BASEFONT COLOR=WHITE>I am an assistant cook for Mrs. Clause, and we seem to be missing all of our Christmas cookies that were baked yesterday. These were<BR>" +
"<BASEFONT COLOR=WHITE>for Christmas for our players here on the shard. The only 2 clues I have are some white fur caught in the kitchen door, and some very<BR>" +
"<BASEFONT COLOR=WHITE>large footprints in the snow headed north. It has to be that pesky Abominable Snowman again! If you would find him, kill him, and bring<BR> " +
"<BASEFONT COLOR=WHITE>me back his fur, I will reward you." +
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

            AddButton(270, 390, 241, 242, 1, GumpButtonType.Reply, 1);
            AddButton(180, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);

          //--------------------------------------------------------------------------------------------------------------
      }

      public override void OnResponse(NetState state, RelayInfo info)
      {
          Mobile from = state.Mobile;

          switch (info.ButtonID)
          {
              case 0:
                  {
                      from.SendMessage("I'm so glad you decided to help me!");
                      from.CloseGump(typeof(MCACGump));
                      from.AddToBackpack(new CookMarker());

                      break;
                  }
              case 1:
                  {
                      from.SendMessage("Such a pity, If you change your mind, I'll be here.");
                      from.CloseGump(typeof(MCACGump));
                      break;
                  }
          }
      }
   }
}