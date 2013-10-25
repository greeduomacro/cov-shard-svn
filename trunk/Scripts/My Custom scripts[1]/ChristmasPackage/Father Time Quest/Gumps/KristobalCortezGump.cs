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
       public class KristobalCortezGump : Gump 
       { 
       public static void Initialize()
       {
           CommandSystem.Register("KristobalCortezGump", AccessLevel.GameMaster, new CommandEventHandler(KristobalCortezGump_OnCommand)); 
    }
           private static void KristobalCortezGump_OnCommand(CommandEventArgs e) 
    {
        e.Mobile.SendGump(new DonovanMacKennzieGump(e.Mobile));
    }
           public KristobalCortezGump(Mobile owner)
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
          AddLabel(140, 60, 0x34, "The Herbalist");
//----------------------/----------------------------------------------/
          AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=RED>You find a man examining a fallen tree trunk.<BR>" +
"<BASEFONT COLOR=YELLOW>Greetings, I am Kristobal Cortez, an Herbalist.<BR>" +
"<BASEFONT COLOR=YELLOW>I came here looking for a monstrous fiend.<BR>" +
"<BASEFONT COLOR=YELLOW>I know where it is! I found it early this morning and it hasnt left.<BR>" +
"<BASEFONT COLOR=YELLOW>Have you seen the kinds of mushrooms that grow in the cave here? Oh, the uses they have.... <BR>" +
"<BASEFONT COLOR=YELLOW>Oh, right, the fiend. My apologies, I get a little carried away sometimes.<BR>" +
"<BASEFONT COLOR=YELLOW>It calls itself the Time Thief and I guess it is in a way, <BR>" +
"<BASEFONT COLOR=YELLOW>since it stole the Baby Time. <BR>" +
"<BASEFONT COLOR=YELLOW>It certainly has no regard for other things, that is most certain!<BR>" +
"<BASEFONT COLOR=YELLOW>Why, it trampled a very rare type of mushro.... <BR>" +
"<BASEFONT COLOR=YELLOW>You will find it at an abandoned farm just a little ways West of here.<BR>" +
"<BASEFONT COLOR=YELLOW>Destroy that mushroom crushing fiend! And recover the Baby Time before it too late! <BR>" +
"<BASEFONT COLOR=RED>Kristobal goes back to examining the log.<BR>" +

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
