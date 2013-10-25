using System; 
using Server;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ShardRobeGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ShardRobeGump", AccessLevel.GameMaster, new CommandEventHandler( ShardRobeGump_OnCommand ) ); 
      } 

      private static void ShardRobeGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ShardRobeGump( e.Mobile ) ); 
      } 

      public ShardRobeGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Diamond Shard Mastery Robe" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Melbore looks up at you with a weary eye...<BR><BR>So you have heard of me have you. I am indeed the person you seek. Master in the art of crafting Robes, Rare and Powerful.<BR>" +
"<BASEFONT COLOR=YELLOW>So you wish one of these Mastery Robe for yourself do you?<BR><BR>Will you bring me the required items? This is a very dangerous yet rewarding endeavor." +
"<BASEFONT COLOR=YELLOW>The materials I require are called Diamond Shards, I require 35 of them, The shards can be found on Diamond Golems.<BR><BR>These are RARE and powerful beast not easily felled. Should you retreive these shards I require then I shall consider you truly worthy and I shall craft you your Robe." +
						     "</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

//			AddLabel( 113, 135, 0x34, "Melbore looks up at you with a weary eye..." );
//			AddLabel( 113, 150, 0x34, "So you have heard have you. I am indeed the" );
//			AddLabel( 113, 165, 0x34, "person you seek. Master in the art of crafting" );
//			AddLabel( 113, 180, 0x34, "Mastery Robes, Rare and Powerful. So you wish" );
//			AddLabel( 113, 195, 0x34, "a Mastery Robe for yourself do you? will you " );
//			AddLabel( 113, 210, 0x34, "bring me the required items?" );
//			AddLabel( 113, 235, 0x34, "This is a very dangerous yet rewarding endeavor." );
//			AddLabel( 113, 250, 0x34, "The materials I require are 35 Diamond Shards," );
//			AddLabel( 113, 265, 0x34, "The shards can be found on Diamond Golems." );
//			AddLabel( 113, 280, 0x34, "These are RARE and powerfull beast not easily" );
//			AddLabel( 113, 295, 0x34, "felled. Should you retreive these shards I shall" );
//			AddLabel( 113, 310, 0x34, "craft you your Robe." );
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
               from.SendMessage( "May whatever God you pray to follow your every move." );
               break; 
            } 

         }
      }
   }
}