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
   public class SamuelGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "SamuelGump", AccessLevel.GameMaster, new CommandEventHandler( SamuelGump_OnCommand ) ); 
      } 

      public static void SamuelGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new SamuelGump( e.Mobile ) ); 
      } 

      public SamuelGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Samuel's Slingshot Quest" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>*Samuel glances up with a worried look in his eyes*<BR><BR>Please kind Traveler,  could you help me?<BR>" +
"<BASEFONT COLOR=WHITE>I went out hunting with my father's special Family Heirloom Slingshot and a Giant earth elemental attacked me and knocked me unconcious and when I awoke, the Slingshot was gone!!<BR>" +
"<BASEFONT COLOR=WHITE>You can find him in the dungeon Shame on the first level. Please hurry if you can, my father went to Vesper overnight<BR>"+
"<BASEFONT COLOR=WHITE>on business and will be back soon! If it's missing when he gets back I'll be in so much trouble!<BR>" +
"<BASEFONT COLOR=WHITE>If you will retrieve this heirloom for me, I will make you an exact replica, so you may hand yours down to your family as well.<BR>"+
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

			AddButton( 180, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 );
            AddButton( 270, 390, 241, 242, 1, GumpButtonType.Reply, 1);

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
               from.SendMessage( "Thank you most kindly stranger!" );
               from.AddToBackpack(new SlingShotMarker());
               break; 
            }
        case 1:
            {
                from.SendMessage("Oh No! My dad is gonna punish me for sure! If you change your mind, I'll be here.");
                from.CloseGump(typeof(SamuelGump));
                break;
            }
         }
      }
   }
}
