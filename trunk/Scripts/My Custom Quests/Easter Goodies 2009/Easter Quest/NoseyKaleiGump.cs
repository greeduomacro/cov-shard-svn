using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class NoseyKaleiGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "NoseyKaleiGump", AccessLevel.GameMaster, new CommandEventHandler( NoseyKaleiGump_OnCommand ) ); 
      } 

      private static void NoseyKaleiGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new NoseyKaleiGump( e.Mobile ) ); 
      }

      public NoseyKaleiGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "NoseyKalei");
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=White><I>Champions needs to Save Easter! Help Me! Help Me!</I><br><br>" +
"<BASEFONT Color=White><br>Hey you, come over here please! I really need your help, to save<br>" + 
"<BASEFONT COLOR=White><br>Easter! You need to go and find the Evil hermit, who is hiding under<br>" +
"<BASEFONT COLOR=White><br>Buc's Den in the caverns below. Find your way into the caves and kill<br>" +
"<BASEFONT COLOR=White><br>him so you can save the bunnies! He's capturing them and turning them<br>" +
"<BASEFONT COLOR=White>Evil, in doing so, there will be no Easter! So please kind stranger help me!<br><br>" +
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
                     from.SendMessage("I'm glad you accepted this task to kill that nasty Hermit!");
                     from.CloseGump(typeof(NoseyKaleiGump));
                     from.AddToBackpack(new EasterGoalMarker());

                     break;
                 }
             case 0:
                 {
                     from.SendMessage("Such a pity, Hopefully someone will help me! COV needs to have Easter!");
                     from.CloseGump(typeof(NoseyKaleiGump));
                     break;
                 }
         }
      }
   }
}
