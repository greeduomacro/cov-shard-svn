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
       public class DonovanMacKennzieGump : Gump 
       { 
       public static void Initialize()
       {
           CommandSystem.Register("DonovanMacKennzieGump", AccessLevel.GameMaster, new CommandEventHandler(DonovanMacKennzieGump_OnCommand)); 
    }
           private static void DonovanMacKennzieGump_OnCommand(CommandEventArgs e) 
    {
        e.Mobile.SendGump(new DonovanMacKennzieGump(e.Mobile));
    }
           public DonovanMacKennzieGump(Mobile owner)
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
          AddLabel(140, 60, 0x34, "The Historian");
//----------------------/----------------------------------------------/
          AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW>Greetings, I am Donovan MacKennzie, a Historian by trade.<BR>" +
"<BASEFONT COLOR=YELLOW>I was sent by Father Time on a most important mission.<BR>" +
"<BASEFONT COLOR=YELLOW>As you know, the Baby Time was taken away and needs to be returned.<BR>" +
"<BASEFONT COLOR=YELLOW>I have been asking many people in the lands if they have seen <BR>" +
"<BASEFONT COLOR=YELLOW>this baby thief.<BR>" +
"<BASEFONT COLOR=YELLOW>Along the way I heard some of the most fasinating tales of past times.<BR>" +
"<BASEFONT COLOR=YELLOW>Did you know that 100 years ago, there was a grea....... <BR>" +
"<BASEFONT COLOR=YELLOW>Oh.. so sorry. Forgive me, I tend to ramble where history is concerned.<BR>" +
"<BASEFONT COLOR=YELLOW>Now, what I have been able to find out isnt much. The creature was seen near <BR>" +
"<BASEFONT COLOR=YELLOW>a white tree west of the bridge from Luna.<BR>" +
"<BASEFONT COLOR=YELLOW>Maybe you can find it there. <BR>" +
"<BASEFONT COLOR=YELLOW>Donovan begins to mumble about something that happened many, many years ago as you walk away.<BR>" +

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
