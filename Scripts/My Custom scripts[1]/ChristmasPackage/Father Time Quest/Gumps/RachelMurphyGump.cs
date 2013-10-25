/* Created by Hammerhand*/

using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

      namespace Server.Gumps
    {
       public class RachelMurphyGump : Gump 
       { 
       public static void Initialize()
       {
           CommandSystem.Register("RachelMurphyGump", AccessLevel.GameMaster, new CommandEventHandler(RachelMurphyGump_OnCommand)); 
    }
           private static void RachelMurphyGump_OnCommand(CommandEventArgs e) 
    {
        e.Mobile.SendGump(new RachelMurphyGump(e.Mobile));
    }
           public RachelMurphyGump(Mobile owner)
               : base(50, 50) 
    {
//----------------------------------------------------------------------------------------------------
          AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );
          AddAlphaRegion( 54, 33, 369, 400 );
          AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
          AddImage( 97, 49, 9005 );
          AddImageTiled( 58, 39, 29, 390, 10460 );
          AddImageTiled( 412, 37, 31, 389, 10460 );
          AddLabel(140, 60, 0x34, "The Botanist");
//----------------------/----------------------------------------------/
          AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=RED>A young woman looks up from her notes at your approach<BR>" +
"<BASEFONT COLOR=YELLOW>Hello there! Are you a botanist as well? No? Oh.. OH!<BR>" +
"<BASEFONT COLOR=YELLOW>Donovan sent you here, didnt he? Sorry, this white tree is so exciting to study.<BR>" +
"<BASEFONT COLOR=YELLOW>Its a one of a kind tr.... Oops... *sigh* <BR>" +
"<BASEFONT COLOR=YELLOW>The baby thief, yes. Apparently it was seen near here, but is gone now. <BR>" +
"<BASEFONT COLOR=YELLOW>I think Kristobal had an idea where it went.<BR>" +
"<BASEFONT COLOR=YELLOW>He went to see if it was there or at least had been.<BR>" +
"<BASEFONT COLOR=YELLOW>He was looking near the Mushroom caves in Ilshenar, he may still be there. <BR>" +
"<BASEFONT COLOR=YELLOW>Are you sure you dont want to learn of this magnificant tree?<BR>" +
"<BASEFONT COLOR=YELLOW>*Rachel goes back to her notes* <BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
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
          AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
      public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile;
          switch ( info.ButtonID ) { case 0:{ break; 
          }
        }
      }
    }
 }
