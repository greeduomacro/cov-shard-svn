using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class BSWGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "BSWGump", AccessLevel.GameMaster, new CommandEventHandler( BSWGump_OnCommand ) ); 
      } 

      private static void BSWGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new BSWGump( e.Mobile ) ); 
      }

      public BSWGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Contamination Quest!");
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=White><I>Please help COV, our water is being Contaminated!</I><br><br>" +
"<BASEFONT Color=White>Our water is being contaminated by these pesky Bully Wugs! They have been<br>" + 
"<BASEFONT COLOR=White>coming into our cities and jumping into our lakes and ponds, where we<br>" +
"<BASEFONT COLOR=White>draw our water from. Many of our townsfolk are getting very sick from this.<br>" +
"<BASEFONT COLOR=White>Please go find each of them, kill them, and bring me back each of their Lily<br>" +
"<BASEFONT COLOR=White>Pads. It is rumored that they can be found in the Brit Sewers, and the passageway<br>" +
"<BASEFONT COLOR=White> beyond that. They use these to hatch their eggs to contaminate the water. I will<br>" +
"<BASEFONT COLOR=White>reward you with a special gift, when you bring me all 4 Lily Pads!<br>" +

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

            AddButton(135, 390, 0xF7, 0xF8, 1, GumpButtonType.Reply, 1);
            AddButton(250, 390, 241, 242, 0, GumpButtonType.Reply, 0);

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile;

         switch (info.ButtonID)
         {
             case 1:
                 {
                     from.SendMessage("I'm glad you accepted this task to kill those nasty Frogs!");
                     from.CloseGump(typeof(BSWGump));
                     from.AddToBackpack(new CMarker());

                     break;
                 }
             case 0:
                 {
                     from.SendMessage("Such a pity, Hopefully someone will help me!");
                     from.CloseGump(typeof(BSWGump));
                     break;
                 }
         }
      }
   }
}
