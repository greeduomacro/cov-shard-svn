using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class GoldilocksGump : Gump
   {
      public static void Initialize() 
	  {
		 CommandSystem.Register( "GoldilocksGump", AccessLevel.GameMaster, new CommandEventHandler( GoldilocksGump_OnCommand ) );
	  }

	  private static void GoldilocksGump_OnCommand( CommandEventArgs e )
	  {
		 e.Mobile.SendGump( new GoldilocksGump( e.Mobile ) );
	  }

	  public GoldilocksGump( Mobile owner ) : base( 50,50 )
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
			AddLabel( 140, 60, 0x34, "Goldilocks" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW><I>Goldilocks looks at you with a puzzled expression.</I><BR><BR>“Hello!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“My Story has been lost how can this be?! I am sorry I can not recall that tramatic time.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Perhaps if you went to the three bears and collected for me three items, a <I>Just Right Chair</I>, a <I>Pillow Just Right</I>, and a <I>Bowl of Porridge Just Right</I> I might be able to remember how the story goes.”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Simply gather the items in your pack and double click the bag I have given you to add the items to it.” <BR><BR>" +

"<BASEFONT COLOR=YELLOW><I>She places a bag in your pack.</I><BR><BR>" +

"<BASEFONT COLOR=YELLOW>“You can find the three bears <I>South</I> of <I>Skara Brae</I>. Be warned the bears nearly killed me when last I visited their domain. They will not give up their possesions lightly. However, you seem like able adevtures; I doubt you will be scared off by them!”<BR><BR>" +

"<BASEFONT COLOR=YELLOW>“Do this for me and I may be able to recall the story for you.” <BR><BR>" +

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
			   from.SendMessage( "Bring me the three artifacts of the bears and you shall have your story!" );
			   break;
			}

		 }
	  }
   }
}