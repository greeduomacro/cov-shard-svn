/***************************************************************************/

// Modified by Ankhesentapemkah

// Credits :														
// Based on ResourceBox	by A_Li_N
// Original Gump Layout - Lysdexic
// Hashtable help - UOT and daat99

/***************************************************************************/

using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Targeting;
using Server.Prompts;

namespace Server.Items
{
	public class GraneryGump : Gump
	{
		private Mobile m_From;
		private BaseGranery m_Box;
		private Pages m_Page;
		private Type[] m_Types;

		public enum Pages
		{
			Start,
			Bread,
			Fish,
			Meat,
			Vegetables,
			Fruit,
			Grain,
			Misc,

			MoreBread,
			MoreFish,
			MoreMeat,
			MoreVegetables,
			MoreFruit,
			MoreGrain,
			MoreMisc,
		}

		public GraneryGump( Mobile from, BaseGranery box, Pages page ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;
			m_Page = page;

			AddPage( 0 );

			AddBackground( 50, 10, 455, 280, 83 );
			AddImageTiled( 58, 20, 438, 262, 2624 );
			AddAlphaRegion( 58, 20, 438, 262 );

			AddButton( 75, 25, 4026, 4027, 1, GumpButtonType.Reply, 0 );
			AddLabel( 110, 25, 0x8AB, "Add Resource" );

			AddPage( 1 );

			if( m_Page == Pages.Start )
			{
				AddLabel( 225, 25, 0x480, "Choose Resource" );

				AddLabel( 110, 75, 1152, "Bread" );
				AddButton( 75, 75, 4005, 4007, 10, GumpButtonType.Reply, 0 );
				AddLabel( 110, 100, 1152, "Fish" );
				AddButton( 75, 100, 4005, 4007, 11, GumpButtonType.Reply, 0 );
				AddLabel( 110, 125, 1152, "Meat" );
				AddButton( 75, 125, 4005, 4007, 12, GumpButtonType.Reply, 0 );
				AddLabel( 110, 150, 1152, "Vegetables" );
				AddButton( 75, 150, 4005, 4007, 13, GumpButtonType.Reply, 0 );
				AddLabel( 110, 175, 1152, "Fruit" );
				AddButton( 75, 175, 4005, 4007, 14, GumpButtonType.Reply, 0 );
				AddLabel( 110, 200, 1152, "Grain" );
				AddButton( 75, 200, 4005, 4007, 15, GumpButtonType.Reply, 0 );
				AddLabel( 110, 225, 1152, "Misc" );
				AddButton( 75, 225, 4005, 4007, 16, GumpButtonType.Reply, 0 );
				//AddLabel( 110, 250, 1152, "Reagents" );
				//AddButton( 75, 250, 4005, 4007, 17, GumpButtonType.Reply, 0 );

				if( GraneryTypes.Bread.Length > 16 )
				{
					AddLabel( 310, 75, 1152, "More Bread" );
					AddButton( 275, 75, 4005, 4007, 17, GumpButtonType.Reply, 0 );
				}
				if( GraneryTypes.Fish.Length > 16 )
				{
					AddLabel( 310, 100, 1152, "More Fish" );
					AddButton( 275, 100, 4005, 4007, 18, GumpButtonType.Reply, 0 );
				}
				if( GraneryTypes.Meat.Length > 16 )
				{
					AddLabel( 310, 125, 1152, "More Meat" );
					AddButton( 275, 125, 4005, 4007, 19, GumpButtonType.Reply, 0 );
				}
				
				if( GraneryTypes.Vegetables.Length > 16 )
				{
					AddLabel( 310, 150, 1152, "More Vegetables" );
					AddButton( 275, 150, 4005, 4007, 20, GumpButtonType.Reply, 0 );
				}
				if( GraneryTypes.Fruit.Length > 16 )
				{
					AddLabel( 310, 175, 1152, "More Fruit" );
					AddButton( 275, 175, 4005, 4007, 21, GumpButtonType.Reply, 0 );
				}
				if( GraneryTypes.Grain.Length > 16 )
				{
					AddLabel( 310, 200, 1152, "More Grain" );
					AddButton( 275, 200, 4005, 4007, 22, GumpButtonType.Reply, 0 );
				}
				if( GraneryTypes.Misc.Length > 16 )
				{
					AddLabel( 310, 225, 1152, "More Misc" );
					AddButton( 275, 225, 4005, 4007, 23, GumpButtonType.Reply, 0 );
				}
				//if( StorageTypes.Reagents.Length > 16 )
				//{
				//	AddLabel( 310, 250, 1152, "More Reagents" );
				//	AddButton( 275, 250, 4005, 4007, 25, GumpButtonType.Reply, 0 );
				//}
			}

			else
			{
				AddLabel( 225, 25, 0x480, AddLabelsButtonsAmounts() );
				AddButton( 425, 25, 4014, 4015, 2, GumpButtonType.Reply, 0 );
				AddLabel( 460, 25, 0x8AB, "Back" );
			}
		}


		private string AddLabelsButtonsAmounts()
		{
			string Label = "";
			int Offset = 0;
			switch( (int)m_Page )
			{
				case (int)Pages.Bread:		{m_Types = GraneryTypes.Bread;		Label = "Bread";		Offset = 0;	break;}
				case (int)Pages.Fish:		{m_Types = GraneryTypes.Fish;		Label = "Fish";		Offset = 0;	break;}
				case (int)Pages.Meat:		{m_Types = GraneryTypes.Meat;		Label = "Meat";		Offset = 0;	break;}
				case (int)Pages.Vegetables:	{m_Types = GraneryTypes.Vegetables;	Label = "Vegetables";		Offset = 0;	break;}
				case (int)Pages.Fruit:		{m_Types = GraneryTypes.Fruit;		Label = "Fruit";		Offset = 0;	break;}
				case (int)Pages.Grain: 		{m_Types = GraneryTypes.Grain;		Label = "Grain";		Offset = 0;	break;}
				case (int)Pages.Misc: 		{m_Types = GraneryTypes.Misc;		Label = "Misc";		Offset = 0;	break;}


/*
				case (int)Pages.Reagents: 	{m_Types = StorageTypes.Reagents;	Label = "Reagents";	Offset = 0;		break;}

*/
				case (int)Pages.MoreBread: 	{m_Types = GraneryTypes.Bread;		Label = "More Bread";		Offset = 16;	break;}
				case (int)Pages.MoreFish: 	{m_Types = GraneryTypes.Fish;		Label = "More Fish";		Offset = 16;	break;}
				case (int)Pages.MoreMeat:	{m_Types = GraneryTypes.Meat;		Label = "More Meat";		Offset = 16;	break;}
				case (int)Pages.MoreVegetables:	{m_Types = GraneryTypes.Vegetables;	Label = "More Vegetables";	Offset = 16;	break;}
				case (int)Pages.MoreFruit:	{m_Types = GraneryTypes.Fruit;		Label = "More Fruit";		Offset = 16;	break;}
				case (int)Pages.MoreGrain:	{m_Types = GraneryTypes.Grain;		Label = "More Grain";		Offset = 16;	break;}
				case (int)Pages.MoreMisc:	{m_Types = GraneryTypes.Misc;		Label = "More Misc";		Offset = 16;	break;}

/*
				case (int)Pages.MoreReagents:	{m_Types = StorageTypes.Reagents;	Label = "More Reagents";Offset = 16;	break;}

*/

			}

			for( int i = Offset; i < m_Types.Length && i < 16 + Offset; i++ )
			{
				Type type = m_Types[i];

				if( !m_Box.Resources.ContainsKey( type ) )
					continue;

				if( (i - Offset) <= 7 )
				{
					AddLabel( 110, 75+((i-Offset)*25), 1152, type.Name );
					if( (int)m_Box.Resources[type] >= 100000 )
						AddLabel( 225, 75+((i-Offset)*25), 1152, "99999" );
					else
						AddLabel( 225, 75+((i-Offset)*25), 1152, ((int)m_Box.Resources[type]).ToString() );
					AddButton( 75, 75+((i-Offset)*25), 4029, 4030, i+100, GumpButtonType.Reply, 0 );
				}

				else
				{
					AddLabel( 310, 75+((i-8-Offset)*25), 1152, type.Name );
					if( (int)m_Box.Resources[type] >= 100000 )
						AddLabel( 225, 75+((i-8-Offset)*25), 1152, "99999" );
					else
						AddLabel( 425, 75+((i-8-Offset)*25), 1152, ((int)m_Box.Resources[type]).ToString() );
					AddButton( 275, 75+((i-8-Offset)*25), 4029, 4030, i+100, GumpButtonType.Reply, 0 );
				}
			}
			return Label;
		}

      private class GraneryTarget : Target
      {
			private BaseGranery m_Box;
			private Pages m_Page;

			public GraneryTarget( BaseGranery box, Pages page ) : base( 18, false, TargetFlags.None )
			{
					m_Box = box;
					m_Page = page;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Box.Deleted )
					return;
				if( targeted is Item )
				{
					if( m_Box.TryAdd( targeted as Item ) )
						from.SendMessage( "Resource added, please choose another." );
					else
						from.SendMessage( "Resource could not be added, please try another." );

					from.Target = new GraneryTarget( m_Box, m_Page );
				}
			}

			protected override void OnTargetCancel( Mobile from, TargetCancelType cancelType )
			{
				from.SendGump( new GraneryGump( from, m_Box, m_Page ) );
			}
      }

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			int BID = info.ButtonID;

			if( BID == 1 )
			{
				if ( from.InRange( m_Box.GetWorldLocation(), 3 ) )
				{
					from.SendMessage( "Target a resource to add" );
					from.Target = new GraneryTarget( m_Box, m_Page );
				}
				else
				{
					from.SendMessage( "You are not in range of your Resource Box!" );
					from.CloseGump( typeof (GraneryGump) );
				}
			}

			else if( BID == 2 )
			{
				from.SendGump( new GraneryGump( from, m_Box, Pages.Start ) );
			}

			else if( BID >= 10 && BID < 26 )
			{
				from.SendGump( new GraneryGump( from, m_Box, (Pages)(BID-9) ) );
			}

			else if( BID >= 100 && BID < 132 )
			{
				Type type = m_Types[BID-100];
				if ( from.InRange( m_Box.GetWorldLocation(), 3 ) )
				{
					from.SendMessage( "Enter Amount, you may only take out 1 unit of hay/flour at a time." );
					from.Prompt = new ExtractPrompt( type, m_Box, m_Page );
				}
				    
				 else
				{
					from.SendMessage( "You are not in range of the granery storage!" );
					from.CloseGump( typeof (GraneryGump) );
				}   
			}
		
		}
		
		private class ExtractPrompt : Prompt
		{
			private Type m_type;
			private BaseGranery m_Box;
			private Pages m_Page;
			
			public ExtractPrompt( Type type, BaseGranery box, Pages page  )
			{
				m_type = type;
				m_Box = box;
				m_Page = page;
			}
			
			public override void OnResponse( Mobile typer, string text )
			{
				
				int amount = Utility.ToInt32( text );
				if ( amount < 10000 )
					m_Box.ExtractResource( typer, m_type, amount );
				else
					typer.SendMessage( "You may only take a max of 10,000 items at once." );
			
				typer.SendGump( new GraneryGump( typer, m_Box, m_Page ) );
				
					
				
				
			}
		}
	}
}
