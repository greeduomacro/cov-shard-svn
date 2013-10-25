using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class SirKenGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "SirKenGump", AccessLevel.GameMaster, new CommandEventHandler( SirKenGump_OnCommand ) ); 
      } 

      private static void SirKenGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HallegGump( e.Mobile ) ); 
      } 

      public SirKenGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "That foul daemon..." );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>*Sir Kenshin stares at the ceiling...?*<BR><BR>I suspect Halleg sent you, am I correct?<BR>" +
"<BASEFONT COLOR=YELLOW>Haha, I thought so! So, you beat Rolph did ya? Not too shabby.<BR><BR>Now heres your next task, if you want my cloak that is.<BR>" +
"<BASEFONT COLOR=YELLOW>My cloak has gotten me through every battle I've ever faced (Well, besides this one...)<BR><BR>If you do wish to have this, then bring me the head of Gwenno.<BR>" +
"<BASEFONT COLOR=YELLOW>Haha, but don't be fooled. King Gwenno's ghost likes to hide his head sometimes: it's not always on his corpse.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>Good luck, hope Halleg told ya the password, cause I don't know it...<BR><BR>Don't be an idiot, be careful against Gwenno.<BR>His power's greater than you can comprehend..." +
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
               from.SendMessage( "Don't be a fool like Halleg!" );
               break; 
            } 

         }
      }
   }
}