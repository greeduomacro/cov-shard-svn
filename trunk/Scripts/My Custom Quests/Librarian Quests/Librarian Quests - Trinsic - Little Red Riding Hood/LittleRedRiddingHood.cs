using System;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Accounting;

namespace Server.Mobiles
{
	[CorpseName( "Little Red Riding Hood Corpse" )]
	public class LittleRedRiddingHood : Mobile
	{
				public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public LittleRedRiddingHood()
		{
			Name = "Maisie";
						Title = "Little Red Riding Hood";
			Body = 0x191;
			CantWalk = true;
			Hue = 0x83F8;
			AddItem( new Server.Items.Shoes( 32 ) );
			AddItem( new Server.Items.Shirt( 32 ) );
			AddItem( new Server.Items.Skirt( 32 ) );
			AddItem( new Server.Items.Bonnet( 32 ) );
			AddItem( new Server.Items.Cloak( 32 ) );




						int hairHue = 32;

			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new ShortHair( hairHue ) ); break;
			}

			Blessed = true;

			}



		public LittleRedRiddingHood( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
			{
					base.GetContextMenuEntries( from, list );
					list.Add( new LittleRedRiddingHoodEntry( from, this ) );
			}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public class LittleRedRiddingHoodEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

			public LittleRedRiddingHoodEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{


						  if( !( m_Mobile is PlayerMobile ) )
					return;

				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( LittleRedRiddingHoodGump ) ) )
					{
						mobile.SendGump( new LittleRedRiddingHoodGump( mobile ));
						mobile.AddToBackpack( new EmptyRedsBasket() );
					}
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
					Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is FruitBasket )
			{
				if( dropped.Amount!=1)
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "AH! grandmother will be so happy! Thank you!", mobile.NetState );
					return false;
				}

					dropped.Delete();
					mobile.SendGump( new LittleRedRiddingHoodGump2(m) );

             	if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

					case 0: mobile.AddToBackpack( new RedsScroll() ); break;


			}

			if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

					case 0: mobile.AddToBackpack( new RedsRing() ); break;


			}

					return true;
				}
				else if ( dropped is FruitBasket )
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
					return false;
				}
				else
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I don't think my grandmother will like that!", mobile.NetState );
				}
			}
			return false;
		}
	}
}
				


				


