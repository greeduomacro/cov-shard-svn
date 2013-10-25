using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ErikSullivanGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ErikSullivanGump", AccessLevel.GameMaster, new CommandEventHandler( ErikSullivanGump_OnCommand ) ); 
      } 

      private static void ErikSullivanGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ErikSullivanGump( e.Mobile ) ); 
      } 

      public ErikSullivanGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "The Fair Elain" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>What? I'm not going to start courting<BR>Elain for some weakling that<BR>hasn't ever picked up a sword!<BR><BR>" +
"<BASEFONT COLOR=YELLOW>Tell you what. If you can get the famous<BR>sword Gorgon Blade from Andora the<BR>Ranger, I'll give up chasing Elain.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>That sounds like a good deal, hm? You<BR>can find her in the forest she<BR>protects east of the city." +

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
               from.SendMessage( "Remember... strength is the measure of a man." );
               break; 
            } 

         }
      }
   }
}
