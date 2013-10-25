using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class OldSmithquestGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "OldSmithquestGump", AccessLevel.GameMaster, new CommandEventHandler( OldSmithquestGump_OnCommand ) ); 
      } 

      private static void OldSmithquestGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new OldSmithquestGump( e.Mobile ) ); 
      } 

      public OldSmithquestGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Thieving Peg Leg" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=RED>Eirnin looks deeply into your eyes. I feel a strength in you young child also a strong presence of greed, If you are willing to help me<BR><BR>Muahaha. *Eirnin Smiles*.<BR>" +
"<BASEFONT COLOR=RED>Are you still interested?<BR><BR>I need you to travel to the City Of Wind and find the Loch Ness Monster. Bring Me Back the Loch Ness Scales and I Will craft you a Shield." +
"<BASEFONT COLOR=RED>So all you have to do is, kill Loch Ness and bring me back 5 scales.<BR><BR>If you decide to go through with this, The Shield Is Of Great Fortune." +
						     "</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

//			AddLabel( 113, 135, 0x34, "" );
//			AddLabel( 113, 150, 0x34, "" );
//			AddLabel( 113, 165, 0x34, "" );
//			AddLabel( 113, 180, 0x34, "" );
//			AddLabel( 113, 195, 0x34, "" );
//			AddLabel( 113, 210, 0x34, "" );
//			AddLabel( 113, 235, 0x34, "" );
//			AddLabel( 113, 250, 0x34, "" );
//			AddLabel( 113, 265, 0x34, "" );
//			AddLabel( 113, 280, 0x34, "" );
//			AddLabel( 113, 295, 0x34, "" );
//			AddLabel( 113, 310, 0x34, "" );
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
               from.SendMessage( "Eirnin points you in the direction of wind." );
               break; 
            } 

         }
      }
   }
}