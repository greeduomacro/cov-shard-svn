using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class HallegGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "HallegGump", AccessLevel.GameMaster, new CommandEventHandler( HallegGump_OnCommand ) ); 
      } 

      private static void HallegGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HallegGump( e.Mobile ) ); 
      } 

      public HallegGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "I want my arm back!" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>*Halleg looks at you with a glass eye...*<BR><BR>I see you're looking for my arm? Haha, your not gonna find it here, sonny.<BR>" +
"<BASEFONT COLOR=YELLOW>A monster named Rolph, bodyguard of Gwenno, took it many moons ago.<BR><BR>But I got one thing from the battle: the knowledge of where the ghost of Gwenno resides.<BR>" +
"<BASEFONT COLOR=YELLOW>And don't be fooled, the items that both carry are very powerfull, indeed.<BR><BR>You wish to have these? HA! You couldn't last a minute against Rolph, let alone King Gwenno the Scourge!<BR>" +
"<BASEFONT COLOR=YELLOW>But tell ya what: I'll give you the information of where Gwenno is if you get back my arm from Rolph.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>Rolph resides within malas, i believe he likes to hang around Grimswind ruins.<BR><BR>Good luck, and don't be a fool.<BR>Tell Rolph I said hi! Huckhuckhuck..." +
						     "</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

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
               from.SendMessage( "Beat that idiot and get me my arm back!" );
               break; 
            } 

         }
      }
   }
}