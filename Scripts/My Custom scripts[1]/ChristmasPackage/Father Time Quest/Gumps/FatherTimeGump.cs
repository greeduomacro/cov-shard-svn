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
       public class FatherTimeGump : Gump 
       { 
       public static void Initialize()
       {
           CommandSystem.Register("FatherTimeGump", AccessLevel.GameMaster, new CommandEventHandler(FatherTimeGump_OnCommand)); 
    }
           private static void FatherTimeGump_OnCommand(CommandEventArgs e) 
    {
        e.Mobile.SendGump(new FatherTimeGump(e.Mobile));
    }
           public FatherTimeGump(Mobile owner)
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
          AddLabel(140, 60, 0x34, "FatherTime");
//----------------------/----------------------------------------------/
          AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=RED>You see a wizened old man in front of you. <BR>" +
"<BASEFONT COLOR=YELLOW>Greetings Traveler, I find myself in need of assistance, can you help?<BR>" +
"<BASEFONT COLOR=YELLOW>I am Father Time, Keeper of the Ages<BR>" +
"<BASEFONT COLOR=YELLOW>Every year as I grow old, I am replaced by a new Keeper in the form of a baby.<BR>" +
"<BASEFONT COLOR=YELLOW>My problem is this. The Baby Time has been taken away!<BR>" +
"<BASEFONT COLOR=YELLOW>The fiend that took the baby wants time to end, thus ending the entire world.<BR>" +
"<BASEFONT COLOR=YELLOW>This cannot be allowed to happen!<BR>" +
"<BASEFONT COLOR=YELLOW>I need you to find this fiend, defeat it and recover the Baby Time.<BR>" +
"<BASEFONT COLOR=YELLOW>I warn you, the fiend wont die easily.<BR>" +
"<BASEFONT COLOR=YELLOW>I have a few others searching now. Check with them to see if they know its location.<BR>" +
"<BASEFONT COLOR=YELLOW>They are just to search, but not try to kill the fiend.<BR>" +
"<BASEFONT COLOR=YELLOW>Follow any clues they may have and destroy that fiendish creature once and for all!<BR>" +
"<BASEFONT COLOR=YELLOW>I believe you'll find Donovan near Grimswind ruins in Malas.<BR>" +
"<BASEFONT COLOR=YELLOW>Bring the Baby Time back to me before time runs out!<BR>" +

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
