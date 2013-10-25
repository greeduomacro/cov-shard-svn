// Original Ingot Box Author Unknown
// Scripted by Karmageddon
using System;
using System.Collections;
using Server;
using Server.Prompts;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Multis;
using Server.Regions;
using Server.Engines.Craft;

namespace Server.Items
{	
	public class BreweryBox : Item 
	{
		private int m_BitterHops;
		private int m_SnowHops;
		private int m_ElvenHops;
		private int m_SweetHops;
		private int m_Malt;
		private int m_Barley;
        private int m_BreweryLabelMaker;
		private int m_BrewersTools;
		private int m_WithdrawIncrement;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int BitterHops{ get{ return m_BitterHops; } set{ m_BitterHops = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int SnowHops{ get{ return m_SnowHops; } set{ m_SnowHops = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int ElvenHops{ get{ return m_ElvenHops; } set{ m_ElvenHops = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int SweetHops{ get{ return m_SweetHops; } set{ m_SweetHops = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Malt{ get{ return m_Malt; } set{ m_Malt = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Barley{ get{ return m_Barley; } set{ m_Barley = value; InvalidateProperties(); } }
        		
		[CommandProperty( AccessLevel.GameMaster )]
		public int BreweryLabelMaker{ get{ return m_BreweryLabelMaker; } set{ m_BreweryLabelMaker = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int BrewersTools{ get{ return m_BrewersTools; } set{ m_BrewersTools = value; InvalidateProperties(); } }

		[Constructable]
		public BreweryBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 1109;
			Name = "Brewery Box";
			WithdrawIncrement = 1;
		}
		
		[Constructable]
		public BreweryBox( int withdrawincrement ) : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 1109;
			Name = "Brewery Box";
			WithdrawIncrement = withdrawincrement;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( from is PlayerMobile )
			from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
		}

		public void BeginCombine( Mobile from )
		{
			from.Target = new BreweryBoxTarget( this );
		}

		public void EndCombine( Mobile from, object o )
		{
			if ( o is Item && ((Item)o).IsChildOf( from.Backpack ) )
			{
				if (!(o is BaseHops || o is BaseTool || o is BreweryLabelMaker || o is ICommodity))
				{
					from.SendMessage( "That is not an item you can put in here." );
				}
				if ( o is BitterHops )
				{

					if ( BitterHops >= 5000 )
					from.SendMessage( "That hop is too full to add more." );
					else
					{
						Item curItem = o as Item;
						BitterHops += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is SnowHops )
				{

					if ( SnowHops >= 5000 )
					from.SendMessage( "That hop is too full to add more." );
					else
					{
						Item curItem = o as Item;
						SnowHops += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is ElvenHops )
				{

					if ( ElvenHops >= 5000 )
					from.SendMessage( "That hop is too full to add more." );
					else
					{
						Item curItem = o as Item;
						ElvenHops += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is SweetHops )
				{

					if ( SweetHops >= 5000 )
					from.SendMessage( "That hop is too full to add more." );
					else
					{
						Item curItem = o as Item;
						SweetHops += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is Malt )
				{

					if ( Malt >= 5000 )
					from.SendMessage( "That ingrediant is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Malt += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is Barley )
				{

					if ( Barley >= 5000 )
					from.SendMessage( "That ingrediant is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Barley += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is BreweryLabelMaker )
				{

					if ( BreweryLabelMaker >= 5000 )
					from.SendMessage( "That tool is too full to add more." );
					else
					{
						Item curItem = o as Item;
						BreweryLabelMaker += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is BrewersTools )
				{

					if ( BrewersTools >= 5000 )
					from.SendMessage( "That tool is too full to add more." );
					else
					{
						Item curItem = o as Item;
						BrewersTools += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BreweryBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
			}
			else
			{
				from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
			}
		}

		public BreweryBox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) m_BitterHops);
			writer.Write( (int) m_SnowHops);
			writer.Write( (int) m_ElvenHops);
			writer.Write( (int) m_SweetHops);
			writer.Write( (int) m_Malt);
			writer.Write( (int) m_Barley);
            writer.Write( (int) m_BreweryLabelMaker);
			writer.Write( (int) m_BrewersTools);
			writer.Write( (int) m_WithdrawIncrement);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_BitterHops = reader.ReadInt();
			m_SnowHops = reader.ReadInt();
			m_ElvenHops = reader.ReadInt();
			m_SweetHops = reader.ReadInt();
			m_Malt = reader.ReadInt();	
			m_Barley = reader.ReadInt();
            m_BreweryLabelMaker = reader.ReadInt();
			m_BrewersTools = reader.ReadInt();
			m_WithdrawIncrement = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class BreweryBoxGump : Gump
	{
		private PlayerMobile m_From;
		private BreweryBox m_Box;

		public BreweryBoxGump( PlayerMobile from, BreweryBox box ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;

			m_From.CloseGump( typeof( BreweryBoxGump ) );

			AddPage( 0 );

			AddBackground( 12, 19, 486, 195, 9250);
			AddLabel( 200, 30, 32, @"Hops Box");
			
			AddLabel( 60, 50, 32, @"Add Item");
			AddButton( 25, 50, 4005, 4007, 1, GumpButtonType.Reply, 0);

			AddLabel( 60, 75, 32, @"Close");
			AddButton( 25, 75, 4005, 4007, 0, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 115, 0, @"Bitter Hops");
			AddLabel( 150, 115, 0x480, box.BitterHops.ToString() );
			AddButton( 25, 115, 4005, 4007, 3, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 135, 0, @"Snow Hops");
			AddLabel( 150, 135, 0x480, box.SnowHops.ToString() );
			AddButton( 25, 135, 4005, 4007, 4, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 155, 0, @"Elven Hops");
			AddLabel( 150, 155, 0x480, box.ElvenHops.ToString() );
			AddButton( 25, 155, 4005, 4007, 5, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 175, 0, @"Sweet Hops");
			AddLabel( 150, 175, 0x480, box.SweetHops.ToString() );
			AddButton( 25, 175, 4005, 4007, 6, GumpButtonType.Reply, 0);
            /*********** New Column *******************/
			AddLabel( 320, 115, 0, @"Malt");
			AddLabel( 410, 115, 0x480, box.Malt.ToString() );
			AddButton( 285, 115, 4005, 4007, 7, GumpButtonType.Reply, 0 );

			AddLabel( 320, 135, 0, @"Barley");
			AddLabel( 410, 135, 0x480, box.Barley.ToString() );
			AddButton( 285, 135, 4005, 4007, 8, GumpButtonType.Reply, 0);
			
			AddLabel( 320, 155, 0, @"B.Label Maker");
			AddLabel( 410, 155, 0x480, box.BreweryLabelMaker.ToString() );
			AddButton( 285, 155, 4005, 4007, 9, GumpButtonType.Reply, 0);
			
			AddLabel( 320, 175, 0, @"Brewers Tools");
			AddLabel( 410, 175, 0x480, box.BrewersTools.ToString() );
			AddButton( 285, 175, 4005, 4007, 10, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Box.Deleted )
			return;
			
			if ( info.ButtonID == 1)
			{
				m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
				m_Box.BeginCombine( m_From );
			}
			
			if ( info.ButtonID == 3 )
			{
				if ( m_Box.BitterHops > 0 )
				{
					if ( m_Box.BitterHops > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new BitterHops(m_Box.WithdrawIncrement) );
						m_Box.BitterHops = m_Box.BitterHops - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.BitterHops > 0)
                				{
						m_From.AddToBackpack( new BitterHops(m_Box.BitterHops) );
						m_Box.BitterHops = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that hop!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			
			if ( info.ButtonID == 4 )
			{
				if ( m_Box.SnowHops > 0 )
				{
					if ( m_Box.SnowHops > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new SnowHops(m_Box.WithdrawIncrement) );
						m_Box.SnowHops = m_Box.SnowHops - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.SnowHops> 0)
                				{
						m_From.AddToBackpack( new SnowHops(m_Box.SnowHops) );
						m_Box.SnowHops = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that hop!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 5 )
			{
				if ( m_Box.ElvenHops > 0 )
				{
					if ( m_Box.ElvenHops > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new ElvenHops(m_Box.WithdrawIncrement) );
						m_Box.ElvenHops = m_Box.ElvenHops - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.ElvenHops> 0)
                				{
						m_From.AddToBackpack( new ElvenHops(m_Box.ElvenHops) );
						m_Box.ElvenHops = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that hop!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 6 )
			{
				if ( m_Box.SweetHops > 0 )
				{
					if ( m_Box.SweetHops > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new SweetHops(m_Box.WithdrawIncrement) );
						m_Box.SweetHops = m_Box.SweetHops - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.SweetHops> 0)
                				{
						m_From.AddToBackpack( new SweetHops(m_Box.SweetHops) );
						m_Box.SweetHops = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that hop!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 7 )
			{
				if ( m_Box.Malt > 0 )
				{
					if ( m_Box.Malt > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new Malt(m_Box.WithdrawIncrement) );
						m_Box.Malt = m_Box.Malt - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Malt > 0)
                				{
						m_From.AddToBackpack( new Malt(m_Box.Malt) );
						m_Box.Malt = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that ingrediant!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 8 )
			{
				if ( m_Box.Barley > 0 )
				{
					if ( m_Box.Barley > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new Barley(m_Box.WithdrawIncrement) );
						m_Box.Barley = m_Box.Barley - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Barley > 0)
                				{
						m_From.AddToBackpack( new Barley(m_Box.Barley) );
						m_Box.Barley = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that ingrediant!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 9 )
			{
				if ( m_Box.BreweryLabelMaker > 0 )
				{
					if ( m_Box.BreweryLabelMaker > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new BreweryLabelMaker(m_Box.WithdrawIncrement) );
						m_Box.BreweryLabelMaker = m_Box.BreweryLabelMaker - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.BreweryLabelMaker > 0)
                				{
						m_From.AddToBackpack( new BreweryLabelMaker(m_Box.BreweryLabelMaker) );
						m_Box.BreweryLabelMaker = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that tool!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			
			if ( info.ButtonID == 10 )
			{
				if ( m_Box.BrewersTools > 0 )
				{
					if ( m_Box.BrewersTools > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new BrewersTools(m_Box.WithdrawIncrement) );
						m_Box.BrewersTools = m_Box.BrewersTools - m_Box.WithdrawIncrement;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.BrewersTools> 0)
                				{
						m_From.AddToBackpack( new BrewersTools(m_Box.BrewersTools) );
						m_Box.BrewersTools = 0;
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that tool!" );
						m_From.SendGump( new BreweryBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
		}
	}

}

namespace Server.Items
{
	public class BreweryBoxTarget : Target
	{
		private BreweryBox m_Box;

		public BreweryBoxTarget( BreweryBox box ) : base( 18, false, TargetFlags.None )
		{
			m_Box = box;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( m_Box.Deleted )
			return;

			m_Box.EndCombine( from, targeted );
		}
	}
}
