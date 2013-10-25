using System;
using Server;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Targeting;
using System.Collections;
using Server.Gumps;


namespace Server.Items
{
	#region Book
	public class PetPSBook : Item
	{
		private ArrayList m_Entries;
		public ArrayList Entries{get{ return m_Entries; }}

		[Constructable]
		public PetPSBook() : base(8793)
		{
			Weight = 1.0;
			LootType = LootType.Cursed;
			m_Entries = new ArrayList();

			Hue = 100;
			Name = "Pet PowerScroll Book";
		}

		public PetPSBook(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 1);

			writer.WriteEncodedInt( (int) m_Entries.Count );

			for ( int i = 0; i < m_Entries.Count; ++i )
			{
				PetPowerScroll scroll = m_Entries[i] as PetPowerScroll;
				int skill = (int)scroll.Skill;
				writer.WriteEncodedInt(skill);
				double amount = scroll.Value;
				writer.Write(amount);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			int count = reader.ReadEncodedInt();

			m_Entries = new ArrayList( count );

			for ( int i = 0; i < count; ++i )
			{
				SkillName skill = (SkillName)reader.ReadEncodedInt();
				double amount = reader.ReadDouble();
				PetPowerScroll scroll = new PetPowerScroll(skill,amount);
				m_Entries.Add(scroll);
			}
		}
		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			list.Add(1053099 ,"{0}\t{1}","Scrolls in book: ", m_Entries.Count.ToString());
		}
		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "Book must be in your backpack to use it." );
			}
			else if ( m_Entries.Count == 0 )
			{
				from.SendLocalizedMessage( 1062381 );
			}
			else if ( from is PlayerMobile )
			{
				from.CloseGump( typeof( PetPSBookGump ) );
				from.SendGump( new PetPSBookGump( from, this ) );
			}
		}
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is PetPowerScroll )
			{
				if ( !IsChildOf( from.Backpack ) )
				{
					from.SendMessage( "Book must be in your backpack to use it." );
					return false;
				}
				else if ( m_Entries.Count < 20 )//will hold 20
				{
					PetPowerScroll scroll = (PetPowerScroll)dropped;
					this.Entries.Add(scroll);

					InvalidateProperties();

					from.SendMessage( " Pet Scroll added to book." );

					if ( from is PlayerMobile )
					{
						from.CloseGump( typeof( PetPSBookGump ) );
						from.SendGump( new PetPSBookGump( from, this ) );
					}

					dropped.Delete();
					return true;
				}
				else
				{
					from.SendMessage( "The book is full." ); 
					return false;
				}
			}

			from.SendMessage( "That is not a pet powerscroll." ); 
			return false;
		}
	}
	#endregion
	#region Gump
	public class PetPSBookGump : Gump
	{
		private int y;
		public Mobile m_From;
		public PetPSBook m_Book;

		public PetPSBookGump(Mobile from, PetPSBook book)	: base( 0, 0 )
		{
			m_From = from;
			m_Book = book;

			y = (m_Book.Entries.Count -1)*20;

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage(0);
			AddBackground(10, 50, 230, 113+y, 9250);
			AddImageTiled( 24, 65, 200, 85+y, 2053);			
			AddAlphaRegion(24, 65, 200, 85+y);
			AddImageTiled(24, 87, 200, 10, 9264);
			AddImageTiled(24, 120, 200, 10, 9264);
			AddImageTiled(105, 95, 3, 55+y, 9264);
			AddImageTiled(179, 95, 3, 55+y, 9264);

			AddLabel(65, 65, 190, "Pet PowerScroll Book");
			AddLabel(30, 100, 199, "Skill");
			AddLabel(110, 100, 199, "Value");
			AddLabel(185, 100, 199, "Drop");
			
			int y2 = 0;
			int butNumb = 1;
			for(int i = 0; i < m_Book.Entries.Count; i++)
			{
				PetPowerScroll scroll = m_Book.Entries[i] as PetPowerScroll;
				AddLabel(25, 130+y2, 195, scroll.Skill.ToString());
				AddLabel(110, 130+y2, 195, scroll.Value.ToString());
				AddButton(195, 133+y2, 1209, 1210, butNumb, GumpButtonType.Reply, 0);
				y2+=20;
				butNumb++;
			}
		}		
		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			int bp;//button pushed
			switch(info.ButtonID)
			{
				case 1:bp = 0;break;
				case 2:bp = 1;break;
				case 3:bp = 2;break;
				case 4:bp = 3;break;
				case 5:bp = 4;break;
				case 6:bp = 5;break;
				case 7:bp = 6;break;
				case 8:bp = 7;break;
				case 9:bp = 8;break;
				case 10:bp = 9;break;
				case 11:bp = 10;break;
				case 12:bp = 11;break;
				case 13:bp = 12;break;
				case 14:bp = 13;break;
				case 15:bp = 14;break;
				case 16:bp = 15;break;
				case 17:bp = 16;break;
				case 18:bp = 17;break;
				case 19:bp = 18;break;
				case 20:bp = 19;break;
				default: return;
			}

			PetPowerScroll scroll = m_Book.Entries[bp] as PetPowerScroll;
			SkillName sklnm = scroll.Skill;
			double sklval = scroll.Value;
			PetPowerScroll newScroll = new PetPowerScroll(sklnm, sklval);
			m_From.AddToBackpack(newScroll);
			m_Book.Entries.RemoveAt(bp);
			m_Book.InvalidateProperties();
		}
	}
	#endregion
}
