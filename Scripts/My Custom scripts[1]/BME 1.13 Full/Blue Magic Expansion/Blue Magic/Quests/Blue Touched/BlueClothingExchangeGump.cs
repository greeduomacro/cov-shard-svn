// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

namespace Server.Gumps
{
	public class BlueClothingExchangeGump : Gump
	{
		public static int COST = 5000;
		private BlueClothing m_TradeIn;

		public BlueClothingExchangeGump( BlueClothing clothing ) : base( 0, 0 )
		{

			m_TradeIn = clothing;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(  0  );

			AddBackground( 0, 0, 210, 205, 9270 );
			AddLabel( 15, 15, 1365, "Blue  Clothing  Exchange" );
			AddLabel( 15, 35, 1365, @"Cost: " + COST.ToString() );

			AddItem( 10, 60, 5912, 1365 ); // Hat
			AddButton( 60, 60, 4023, 4024, 1, GumpButtonType.Reply, 0 ); 

			AddItem( 10, 90, 5399, 1365 ); // Shirt
			AddButton( 60, 90, 4023, 4024, 2, GumpButtonType.Reply, 0 );

			AddItem( 10, 120, 11112, 1365 ); // Belt
			AddButton( 60, 120, 4023, 4024, 3, GumpButtonType.Reply, 0 );

			AddItem( 10, 150, 12227, 1365 ); // Pants
			AddButton( 60, 150, 4023, 4024, 4, GumpButtonType.Reply, 0 );

			AddItem( 105, 60, 12228, 1365 ); // Boots
			AddButton( 155, 60, 4023, 4024, 5, GumpButtonType.Reply, 0 );

			AddItem( 105, 90, 5441, 1365 ); // Sash
			AddButton( 155, 90, 4023, 4024, 6, GumpButtonType.Reply, 0 );

			AddItem( 105, 120, 5198, 1365 ); // Arms
			AddButton( 155, 120, 4023, 4024, 7, GumpButtonType.Reply, 0 );

			AddItem( 95, 145, 9901, 1365 ); // Cloak
			AddButton( 155, 150, 4023, 4024, 8, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_TradeIn == null || info.ButtonID < 1 || info.ButtonID > 8 || sender.Mobile == null || sender.Mobile.Backpack == null )
				return;

			if ( sender.Mobile.Backpack.ConsumeTotal( typeof( Gold ), COST ) )
			{
				m_TradeIn.Delete();

				switch( info.ButtonID )
				{
					case 1: sender.Mobile.AddToBackpack( new BlueHat() ); break;
					case 2: sender.Mobile.AddToBackpack( new BlueShirt() ); break;
					case 3: sender.Mobile.AddToBackpack( new BlueBelt() ); break;
					case 4: sender.Mobile.AddToBackpack( new BluePants() ); break;
					case 5: sender.Mobile.AddToBackpack( new BlueBoots() ); break;
					case 6: sender.Mobile.AddToBackpack( new BlueSash() ); break;
					case 7: sender.Mobile.AddToBackpack( new BlueArms() ); break;
					case 8: sender.Mobile.AddToBackpack( new BlueCloak() ); break;
				}
			}
			else
				sender.Mobile.SendLocalizedMessage( 503205 ); // You cannot afford this item.

		}
	}
}