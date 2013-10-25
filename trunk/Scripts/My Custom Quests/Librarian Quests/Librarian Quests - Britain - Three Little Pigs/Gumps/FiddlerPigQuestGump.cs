using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
    public class FiddlerPigQuestGump : Gump { 

        public static void Initialize() { 
CommandSystem.Register( "FiddlerPigQuestGump", AccessLevel.GameMaster, 
    new CommandEventHandler( FiddlerPigQuestGump_OnCommand ) ); 
}

        private static void FiddlerPigQuestGump_OnCommand(CommandEventArgs e) 
{
    e.Mobile.SendGump(new FiddlerPigQuestGump(e.Mobile));
}

        public FiddlerPigQuestGump(Mobile owner)
            : base(50, 50) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "Fiddler Pig" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW><I>Fiddler Pig looks at you with a pleasant smile.</I><BR><BR>“Hi there!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I was just cleaning up after that blow hard of a Wolf blew down my wooden house.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Ah my brother Fifer has sent you has he, well I suppose I can help you , but first I require your help.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“If you could help me gather some wood from the greedy reapers in the forest then I would gladly give you my story.”<BR><BR><I>He hands you an empty Box.</I><BR><BR>“Place the Reaper Wood you collect in here, but beware if it were so easy to collect I would have it already.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“In the deep forest you can find a waterfall where the reapers dwell they are made of the wood I require. To claim it you will have to kill the <I>Reapers</I> . They are not easy prey, but you look worthy to take on the challenge. You can find them located north of Justice shrine by the Great Waterfall. <I></I>”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Kill the <I>Scorched Reapers</I> and retrieve <I>five Boards</I> that should be all I need to finish my house. When you have all five double click the box and it will combine them for easy travel. Bring me the full box and I will write my story as I recall it on a scroll for you.” <BR><BR>" +

                                              "</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) 
{
    case 0:
{ 
    break; 
}
            }
        }
    }
}
