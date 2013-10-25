using System;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public interface ICommodity
	{
		string Description{ get; }
		int DescriptionNumber{ get; }
	}

	public class CommodityDeed : Item
	{
		private Item m_Commodity;

		[CommandProperty( AccessLevel.GameMaster )]
		public Item Commodity
		{
			get
			{
				return m_Commodity;
			}
		}

		public bool SetCommodity( Item item )
		{
			InvalidateProperties();

			if ( m_Commodity == null && item is ICommodity )
			{
				m_Commodity = item;
				m_Commodity.Internalize();
				InvalidateProperties();

				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Commodity );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Commodity = reader.ReadItem();

					break;
				}
			}
		}

		public CommodityDeed( Item commodity ) : base( 0x14F0 )
		{
			Weight = 1.0;
			Hue = 0x47;

			m_Commodity = commodity;

			LootType = LootType.Blessed;
		}

		[Constructable]
		public CommodityDeed() : this( null )
		{
		}

		public CommodityDeed( Serial serial ) : base( serial )
		{
		}

		public override void OnDelete()
		{
			if ( m_Commodity != null )
				m_Commodity.Delete();

			base.OnDelete();
		}

		public override int LabelNumber{ get{ return m_Commodity == null ? 1047016 : 1047017; } }

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties( list );

			if ( m_Commodity != null )
				list.Add( 1060658, "#{0}\t{1}", ((ICommodity)m_Commodity).DescriptionNumber, m_Commodity.Amount ); // ~1_val~: ~2_val~
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( m_Commodity != null )
				from.Send( new UnicodeMessage( Serial, ItemID, MessageType.Label, 0x3B2, 3, "ENU", "", ((ICommodity)m_Commodity).Description ) );
		}

		public override void OnDoubleClick( Mobile from )
		{
			int number;

			BankBox box = from.FindBankNoCreate();

			if ( m_Commodity != null )
			{
				if ( box != null && IsChildOf( box ) )
				{
					number = 1047031; // The commodity has been redeemed.

					box.DropItem( m_Commodity );

					m_Commodity = null;
					Delete();
				}
				else
				{
					number = 1047024; // To claim the resources ....
				}
			}
			else if ( box == null || !IsChildOf( box ) )
			{
				number = 1047026; // That must be in your bank box to use it.
			}
			else
			{
				number = 1047029; // Target the commodity to fill this deed with.

				from.Target = new InternalTarget( this );
			}

			from.SendLocalizedMessage( number );
		}

		private class InternalTarget : Target
		{
			private CommodityDeed m_Deed;

			public InternalTarget( CommodityDeed deed ) : base( 3, false, TargetFlags.None )
			{
				m_Deed = deed;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Deed.Deleted )
					return;

				int number;

				if ( m_Deed.Commodity != null )
				{
					number = 1047028; // The commodity deed has already been filled.
				}
				else if ( targeted is Item )
				{
					BankBox box = from.FindBankNoCreate();
                    string XferResource = "...";
                    int XferAmount = 0;
                    int r = 0;

                    if (box != null && m_Deed.IsChildOf(box) && ((Item)targeted).IsChildOf(box))
                    {
                        // RESOURCE EDIT
                        if (targeted is BaseIngot) // || targeted is BaseBoards || targeted is BaseLog || targeted is BaseLeather || targeted is BaseScales || targeted is BasePowder || targeted is BaseCrystal)
                        {
                            from.SendMessage("You require a 'Special Commodity Deed' for this custom resource item...");
                            number = 1047027;
                            m_Deed.Delete();

                            BaseIngot youringots = (BaseIngot)targeted;
                            string s_resource = Convert.ToString(youringots.Resource);
                            XferAmount = youringots.Amount;
                            switch (s_resource)
                            {
                                case "Iron": r = 1; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "DullCopper": r = 2; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "ShadowIron": r = 3; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Copper": r = 4; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Bronze": r = 5; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Gold": r = 6; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Silver": r = 7; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Agapite": r = 8; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Verite": r = 9; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Valorite": r = 10; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Jade": r = 11; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Moonstone": r = 12; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                case "Sunstone": r = 13; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                                //case "": r = 13; box.DropItem(new YaksCommodityDeed(XferAmount, r)); youringots.Delete(); break;
                            }
                        }
                        else if (targeted is BaseLeather) // || targeted is BaseBoards || targeted is BaseLog || targeted is BaseLeather || targeted is BaseScales || targeted is BasePowder || targeted is BaseCrystal)
                        {
                            from.SendMessage("You require a 'Special Commodity Deed' for this custom resource item...");
                            number = 1047027;
                            m_Deed.Delete();

                            BaseLeather youritem = (BaseLeather)targeted;
                            string s_resource = Convert.ToString(youritem.Resource);
                            XferAmount = youritem.Amount;
                            switch (s_resource)
                            {
                                case "RegularLeather": r = 101; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "SpinedLeather": r = 102; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "HornedLeather": r = 103; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "BarbedLeather": r = 104; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "DaemonLeather": r = 105; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "DragonLeather": r = 106; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                            }
                        }
                        else if (targeted is BaseScales) // || targeted is BaseBoards || targeted is BaseLog || targeted is BaseLeather || targeted is BaseScales || targeted is BasePowder || targeted is BaseCrystal)
                        {
                            from.SendMessage("You require a 'Special Commodity Deed' for this custom resource item...");
                            number = 1047027;
                            m_Deed.Delete();

                            BaseScales youritem = (BaseScales)targeted;
                            string s_resource = Convert.ToString(youritem.Resource);
                            XferAmount = youritem.Amount;
                            switch (s_resource)
                            {
                                case "RedScales": r = 201; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "YellowScales": r = 202; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "BlackScales": r = 203; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "GreenScales": r = 204; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "WhiteScales": r = 205; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "BlueScales": r = 206; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                //case "IceScales": r = 207; box.DropItem(new YaksCommodityDeed(XferAmount, r)); youritem.Delete(); break;

                            }
                        }
                        else if (targeted is BaseLog)// || targeted is BaseLog || targeted is BaseLeather || targeted is BaseScales || targeted is BasePowder || targeted is BaseCrystal)
                        {
                            from.SendMessage("You require a 'Special Commodity Deed' for this custom resource item...");
                            number = 1047027;
                            m_Deed.Delete();

                            BaseLog youritem = (BaseLog)targeted;
                            string s_resource = Convert.ToString(youritem.Resource);
                            XferAmount = youritem.Amount;
                            switch (s_resource)
                            {
                                case "Regular": r = 301; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Oak": r = 302; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Ash": r = 303; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Yew": r = 304; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Heartwood": r = 305; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Bloodwood": r = 306; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Frostwood": r = 307; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Pine": r = 308; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Cedar": r = 309; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Cherry": r = 310; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Mahogany": r = 311; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;

                            }
                        }
                        else if (targeted is BaseBoards)// || targeted is BaseLog || targeted is BaseLeather || targeted is BaseScales || targeted is BasePowder || targeted is BaseCrystal)
                        {
                            from.SendMessage("You require a 'Special Commodity Deed' for this custom resource item...");
                            number = 1047027;
                            m_Deed.Delete();

                            BaseBoards youritem = (BaseBoards)targeted;
                            string s_resource = Convert.ToString(youritem.Resource);
                            XferAmount = youritem.Amount;
                            switch (s_resource)
                            {
                                case "Regular": r = 401; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Oak": r = 402; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Ash": r = 03; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Yew": r = 404; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Heartwood": r = 405; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Bloodwood": r = 406; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Frostwood": r = 407; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Pine": r = 408; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Cedar": r = 409; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Cherry": r = 410; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;
                                case "Mahogany": r = 411; box.DropItem(new SpecialCommodityDeed(XferAmount, r)); youritem.Delete(); break;

                            }
                        }
                        else
                        {
                            if (m_Deed.SetCommodity((Item)targeted))
                            {
                                number = 1047030; // The commodity deed has been filled.
                            }
                            else
                            {
                                number = 1047027; // That is not a commodity the bankers will fill a commodity deed with.
                            }
                        }
					}
					else
					{
						number = 1047026; // That must be in your bank box to use it.
					}
				}
				else
				{
					number = 1047027; // That is not a commodity the bankers will fill a commodity deed with.
				}

				from.SendLocalizedMessage( number );
			}
		}
	}
}