using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ChandlerGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ChandlerGump", AccessLevel.GameMaster, new CommandEventHandler( ChandlerGump_OnCommand ) ); 
      } 

      private static void ChandlerGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ChandlerGump( e.Mobile ) ); 
      } 

      public ChandlerGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Chandler the old artifact seeker" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=White><I>Hello fair traveler, I am sure you have better things to do than listen to an old man.</I><br><br>" +
"<BASEFONT Color=White>However, if you sit a spell, I will share an old myth with you. It was said long ago, there was a favored beauty of Zues's called Lamia. <br><br>" +
"<BASEFONT COLOR=White>She bore several of his children, and Hara was so jealous; she killed them all in a fit of rage! In Lamia's massive grief, she sought out to kill all the children of the world. It is said that she steals their essence and holds them captive. They can be used in making Candles of Love. She has since joined forces with the succubi of this world. They hold the skulls of many lost ancestors.<br><br>" +
"<BASEFONT COLOR=White>So fair traveler, are you brave enough to seek out and destroy Lamia and her Concubines? If so, she is said to be found deep in the rooms of Hythloth!<br><br>" +
//"<BASEFONT COLOR=White>Also if you like visit us at our website, there are yellow web stones in most major cities. Just double-click to use the stones. Also, if you would, go to our website and follow the link to our forums and register on our new player forum.<br><br>" +
//"<BASEFONT COLOR=White>Thank You For Joining Our Family And We Hope You Enjoy Your Stay With Us. If You Need Help at any time feel free to page a GM, or contact Admin via E-mail, or on our Shard fourms website. Thank you.<br><br>" +
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
               from.SendMessage( "Thank you for listening to an old man's tale and safe journeys to you." );
               break; 
            } 

         }
      }
   }
}
