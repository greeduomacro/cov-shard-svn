using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class PolkaGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "PolkaGump", AccessLevel.GameMaster, new CommandEventHandler( PolkaGump_OnCommand ) ); 
      } 

      private static void PolkaGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new PolkaGump( e.Mobile ) ); 
      } 

      public PolkaGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Polka and Flowers" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Polka looks at you with hope in her eyes.<BR><BR>I'm in need of floral powder, but these days I can't seem to find any...<BR>" +
"<BASEFONT COLOR=YELLOW>Though I had already found some, but these bullies for monsters had stolen them from me!<BR><BR>" +
"<BASEFONT COLOR=YELLOW>I barely escaped with my life...<BR>" +
"<BASEFONT COLOR=YELLOW>Polka then frowns at you.<BR><BR>If it isn't too much to ask, I'd like you to collect back the floral powder for me.<BR>" +
"<BASEFONT COLOR=YELLOW>Will you be willing to do this for me? I would be so greatful to you if you could...<BR><BR>" +
"<BASEFONT COLOR=YELLOW>I'll give you my lucky flower box! Please do take care of it. It was my mothers.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>Though there is more to this than that...<BR><BR> Behind Britain graveyard is this dastardly lizardman whom stole my 'Teali Floral Powder'.<BR>There is also a nasty lich that has taken hold of my 'Aubry Floral Powder'.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>I'm sure he's still around the desert just north of Britain. I almost forgot the last one! 'Ragnal Floral Powder' was taken from me by this filthy ratman. he darted off towards Skara Brea.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>By the way.. Once you recieve all three, please combine them together in the box...<BR><BR>" +
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
            case 0:
            {
		from.AddToBackpack( new PolkaFlowerBox() );
               from.SendMessage( "Please be careful!" );
               break; 
            } 

         }
      }
   }
}