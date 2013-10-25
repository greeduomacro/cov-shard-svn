using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
    public class PracticalPigQuestGump : Gump { 

        public static void Initialize() { 
CommandSystem.Register( "PracticalPigQuestGump", AccessLevel.GameMaster, 
    new CommandEventHandler( PracticalPigQuestGump_OnCommand ) ); 
}

        private static void PracticalPigQuestGump_OnCommand(CommandEventArgs e) 
{
    e.Mobile.SendGump(new PracticalPigQuestGump(e.Mobile));
}

        public PracticalPigQuestGump(Mobile owner)
            : base(50, 50) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel(140, 60, 0x34, "Practical Pig");
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " +
"<BASEFONT COLOR=YELLOW><I>Practical Pig looks at you with vague intrest.</I><BR><BR>“Hi there!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“I was just cleaning up the fur from the Wolf's failed attempt to pierce my stone home.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Ah my brothers have sent you, well I suppose I can help you , but first I need your help.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“If you could help me dispose of the Wolf once and for all, then I would gladly give you my story.”<BR><BR><I>He hands you an empty Box.</I><BR><BR>“Place the Wolf's head you collect in here, but beware if it were an easy task I would done it myself.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“In the <I>Mountians North of my home</I> the Wolf dwells. To claim my part of the story you will have to kill the <I>Wolf</I> and bring his head to me! You look worthy to take on the challenge.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Kill the Wolf, cut his head off with the knife I have provided you, and return it to me and I will write my story as I recall it on a scroll for you.” <BR><BR>" +

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
