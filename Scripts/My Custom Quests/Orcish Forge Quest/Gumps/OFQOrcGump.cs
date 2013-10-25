using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class OFQOrcGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "OFQOrcGump", AccessLevel.GameMaster, new CommandEventHandler( OFQOrcGump_OnCommand ) ); 
      } 

      private static void OFQOrcGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new OFQOrcGump( e.Mobile ) ); 
      } 

      public OFQOrcGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Orcish Forge Quest" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=White><I>* The engaged orc blacksmith looks at you in anger. *</I><br><br>" +
"<BASEFONT Color=White>What do you want! I am in no mood to deal with a human such as yourself!<br><br>" + 
"<BASEFONT COLOR=White><I>* Understanding his anger, you prepare yourself for battle. *</I><br><br>" +
"<BASEFONT COLOR=White>I do not wish to fight you. I only want my wedding ring back. I am to be married soon. Can you help me?<br><br>" +
"<BASEFONT COLOR=White>You see, there is a bully orc brute that has taken the ring I am to give my wife to be, at our wedding. He is much larger than me. I cannot defeat him.<br><br>" +
"<BASEFONT COLOR=White>If you could convince him to give me back the wedding ring, I will be more than happy to reward your efforts.<br><br>" +
"<BASEFONT COLOR=White><I>* You make a decision on how to go about convincing this orc brute to return the ring *</I><br>" + 
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
               from.SendMessage( "Engaged Orc Blacksmith Says: I hope you are stronger than the last human that tried to defeat him!" );
               break; 
            } 

         }
      }
   }
}