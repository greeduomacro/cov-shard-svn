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
	public class ScrollofAlacrityBook: Item
	{
		private ArrayList m_Entries;
		public ArrayList Entries{get{ return m_Entries; }}

		[Constructable]
		public ScrollofAlacrityBook() : base(8793)
		{
			Weight = 1.0;
			LootType = LootType.Cursed;
			m_Entries = new ArrayList();

			Hue = 415;
			Name = "ScrollofAlacrityBook";
		}

        public ScrollofAlacrityBook(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 1);

			writer.WriteEncodedInt( (int) m_Entries.Count );

			for ( int i = 0; i < m_Entries.Count; ++i )
			{
                ScrollofAlacrity scroll = m_Entries[i] as ScrollofAlacrity;
				int skill = (int)scroll.Skill;
				writer.WriteEncodedInt(skill);
				//double amount = scroll.Value;
				//writer.Write(amount);
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
				//double amount = reader.ReadDouble();
                ScrollofAlacrity scroll = new ScrollofAlacrity(skill);
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
                from.CloseGump(typeof(ScrollofAlacrityBookGump));
                from.SendGump(new ScrollofAlacrityBookGump(from, this));
			}
		}
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
            if (dropped is ScrollofAlacrity)
			{
				if ( !IsChildOf( from.Backpack ) )
				{
					from.SendMessage( "Book must be in your backpack to use it." );
					return false;
				}
				else if ( m_Entries.Count < 20 )//will hold 20
				{
                    ScrollofAlacrity scroll = (ScrollofAlacrity)dropped;
					this.Entries.Add(scroll);

					InvalidateProperties();

					from.SendMessage( " Scroll was added to the book." );

					if ( from is PlayerMobile )
					{
                        from.CloseGump(typeof(ScrollofAlacrityBookGump));
                        from.SendGump(new ScrollofAlacrityBookGump(from, this));
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

            from.SendMessage("That is not a Scroll of Alacrity Book."); 
			return false;
		}
	}
	#endregion
	#region Gump
	public class ScrollofAlacrityBookGump : Gump
	{
		private int y;
		public Mobile m_From;
        public ScrollofAlacrityBook m_Book;

        public ScrollofAlacrityBookGump(Mobile from, ScrollofAlacrityBook book)
            : base(0, 0)
		{
			m_From = from;
			m_Book = book;

			y = (m_Book.Entries.Count -1)*50;

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

            AddLabel(65, 65, 190, "Scroll of Alacrity Book");
			AddLabel(30, 100, 199, "Skill");
			//AddLabel(110, 100, 199, "Value");
			AddLabel(185, 100, 199, "Drop");
			
			int y2 = 0;
			int butNumb = 1;
			for(int i = 0; i < m_Book.Entries.Count; i++)
			{
                ScrollofAlacrity scroll = m_Book.Entries[i] as ScrollofAlacrity;
				AddLabel(25, 130+y2, 195, scroll.Skill.ToString());
				//AddLabel(110, 130+y2, 195, scroll.Value.ToString());
				AddButton(195, 133+y2, 1209, 1210, butNumb, GumpButtonType.Reply, 0);
				y2+=50;
				butNumb++;
			}
		}		
		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			int bp;//button pushed
			switch(info.ButtonID)
			{
                case 1: bp = 0; break;
                case 2: bp = 1; break;
                case 3: bp = 2; break;
                case 4: bp = 3; break;
                case 5: bp = 4; break;
                case 6: bp = 5; break;
                case 7: bp = 6; break;
                case 8: bp = 7; break;
                case 9: bp = 8; break;
                case 10: bp = 9; break;
                case 11: bp = 10; break;
                case 12: bp = 11; break;
                case 13: bp = 12; break;
                case 14: bp = 13; break;
                case 15: bp = 14; break;
                case 16: bp = 15; break;
                case 17: bp = 16; break;
                case 18: bp = 17; break;
                case 19: bp = 18; break;
                case 20: bp = 19; break;
                case 21: bp = 20; break;
                case 22: bp = 21; break;
                case 23: bp = 22; break;
                case 24: bp = 23; break;
                case 25: bp = 24; break;
                case 26: bp = 25; break;
                case 27: bp = 26; break;
                case 28: bp = 27; break;
                case 29: bp = 28; break;
                case 30: bp = 29; break;
                case 31: bp = 30; break;
                case 32: bp = 31; break;
                case 33: bp = 32; break;
                case 34: bp = 33; break;
                case 35: bp = 34; break;
                case 36: bp = 35; break;
                case 37: bp = 36; break;
                case 38: bp = 37; break;
                case 39: bp = 38; break;
                case 40: bp = 39; break;
                case 41: bp = 40; break;
                case 42: bp = 41; break;
                case 43: bp = 42; break;
                case 44: bp = 43; break;
                case 45: bp = 44; break;
                case 46: bp = 45; break;
                case 47: bp = 46; break;
                case 48: bp = 47; break;
                case 49: bp = 48; break;
                case 50: bp = 49; break;
				default: return;
			}

            ScrollofAlacrity scroll = m_Book.Entries[bp] as ScrollofAlacrity;
			SkillName sklnm = scroll.Skill;
			//double sklval = scroll.Value;
            ScrollofAlacrity newScroll = new ScrollofAlacrity(sklnm);
			m_From.AddToBackpack(newScroll);
			m_Book.Entries.RemoveAt(bp);
			m_Book.InvalidateProperties();
		}
	}
	#endregion
}
