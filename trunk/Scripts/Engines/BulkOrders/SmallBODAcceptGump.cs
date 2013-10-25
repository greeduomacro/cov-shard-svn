using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Engines.BulkOrders
{
	public class SmallBODAcceptGump : Gump
	{
		private SmallBOD m_Deed;
		private Mobile m_From;

		public SmallBODAcceptGump( Mobile from, SmallBOD deed ) : base( 50, 50 )
		{
			m_From = from;
			m_Deed = deed;

			m_From.CloseGump( typeof( LargeBODAcceptGump ) );
			m_From.CloseGump( typeof( SmallBODAcceptGump ) );

			AddPage( 0 );

			AddBackground( 25, 10, 430, 264, 5054 );

			AddImageTiled( 33, 20, 413, 245, 2624 );
			AddAlphaRegion( 33, 20, 413, 245 );

			AddImage( 20, 5, 10460 );
			AddImage( 430, 5, 10460 );
			AddImage( 20, 249, 10460 );
			AddImage( 430, 249, 10460 );

			AddHtmlLocalized( 190, 25, 120, 20, 1045133, 0x7FFF, false, false ); // A bulk order
			AddHtmlLocalized( 40, 48, 350, 20, 1045135, 0x7FFF, false, false ); // Ah!  Thanks for the goods!  Would you help me out?

			AddHtmlLocalized( 40, 72, 210, 20, 1045138, 0x7FFF, false, false ); // Amount to make:
			AddLabel( 250, 72, 1152, deed.AmountMax.ToString() );

			AddHtmlLocalized( 40, 96, 120, 20, 1045136, 0x7FFF, false, false ); // Item requested:
			AddItem( 385, 96, deed.Graphic );
			AddHtmlLocalized( 40, 120, 210, 20, deed.Number, 0xFFFFFF, false, false );

			if ( deed.RequireExceptional || deed.Material != BulkMaterialType.None )
			{
				AddHtmlLocalized( 40, 144, 210, 20, 1045140, 0x7FFF, false, false ); // Special requirements to meet:

				if ( deed.RequireExceptional )
					AddHtmlLocalized( 40, 168, 350, 20, 1045141, 0x7FFF, false, false ); // All items must be exceptional.

				switch ((int)deed.Material)
				{
					case 1: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with dull copper ingots", false, false ); break;
					case 2: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with shadow iron ingots", false, false ); break;
					case 3: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with copper ingots", false, false ); break;
					case 4: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with bronze ingots", false, false ); break;
					case 5: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with gold ingots", false, false ); break;
					case 6: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with agapite ingots", false, false ); break;
					case 7: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with verite ingots", false, false ); break;
					case 8: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with valorite ingots", false, false ); break;
					case 9: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with silver ingots", false, false ); break;
					//case 10: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with platinum ingots", false, false ); break;
					//case 11: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with mythril ingots", false, false ); break;
					//case 12: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with obsidian ingots", false, false ); break;
					case 10: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with jade ingots", false, false ); break;
					case 11: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with moonstone ingots", false, false ); break;
					case 12: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with sunstone ingots", false, false ); break;
					//case 16: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with bloodstone ingots", false, false ); break;
					case 13: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with spined leather", false, false ); break;
					case 14: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with horned leather", false, false ); break;
					case 15: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with barbed leather", false, false ); break;
					case 16: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with dragon leather", false, false ); break;
					case 17: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FFF000>All items must be crafted with daemon leather", false, false ); break;
					case 18: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FF0000>All items must be crafted with pine wood", false, false ); break;
					case 19: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FF0000>All items must be crafted with ash wood", false, false ); break;
					case 20: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FF0000>All items must be crafted with mohogany wood", false, false ); break;
					case 21: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FF0000>All items must be crafted with yew wood", false, false ); break;
					case 22: AddHtml( 40, deed.RequireExceptional ? 192 : 168, 350, 25, "<basefont color=#FF0000>All items must be crafted with oak wood", false, false ); break;
					
				}
			}

			AddHtmlLocalized( 40, 216, 350, 20, 1045139, 0x7FFF, false, false ); // Do you want to accept this order?

			AddButton( 100, 240, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 135, 240, 120, 20, 1006044, 0x7FFF, false, false ); // Ok

			AddButton( 275, 240, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 310, 240, 120, 20, 1011012, 0x7FFF, false, false ); // CANCEL
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 ) // Ok
			{
				if ( m_From.PlaceInBackpack( m_Deed ) )
				{
					m_From.SendLocalizedMessage( 1045152 ); // The bulk order deed has been placed in your backpack.
				}
				else
				{
					m_From.SendLocalizedMessage( 1045150 ); // There is not enough room in your backpack for the deed.
					m_Deed.Delete();
				}
			}
			else
			{
				m_Deed.Delete();
			}
		}

		public static int GetMaterialNumberFor( BulkMaterialType material )
		{
			if ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Sunstone )
				return 1045142 + (int)(material - BulkMaterialType.DullCopper);
			else if ( material >= BulkMaterialType.Spined && material <= BulkMaterialType.Daemon )
				return 1049348 + (int)(material - BulkMaterialType.Spined);
			else if ( material >= BulkMaterialType.Pine && material <= BulkMaterialType.Oak )
				return 1049348 + (int)(material - BulkMaterialType.Pine);

			return 0;
		}
	}
}