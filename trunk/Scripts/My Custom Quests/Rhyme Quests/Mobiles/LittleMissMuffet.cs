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
    [CorpseName("Miss Muffet Corpse")]
	public class LittleMissMuffet : Mobile
	{
				public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public LittleMissMuffet()
		{
            Name = "Miss Muffet";
						
			Body = 0x191;
			CantWalk = false;
			Hue = 0x83F8;
			AddItem( new Server.Items.Shoes( 1102 ) );
            AddItem(new Server.Items.GildedDress(1150));
			AddItem( new Server.Items.Bonnet( 1150 ) );
			AddItem( new Server.Items.Cloak( 1102 ) );




						int hairHue = 1645;

			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new ShortHair( hairHue ) ); break;
			}

			Blessed = true;

			}



        public LittleMissMuffet(Serial serial)
            : base(serial)
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
			{
					base.GetContextMenuEntries( from, list );
                    list.Add(new MissMuffetEntry(from, this));
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

		public class MissMuffetEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

            public MissMuffetEntry(Mobile from, Mobile giver)
                : base(6146, 3)
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
                    if (!mobile.HasGump(typeof(MissMuffetGump)))
					{
                        mobile.SendGump(new MissMuffetGump(mobile));
                        mobile.AddToBackpack(new EmptyWheyBowl());
                        mobile.AddToBackpack(new EmptyCurdBowl());
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
                if (dropped is BowlofWhey)
			{
				if( dropped.Amount!=1)
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Bless you traveler!", mobile.NetState );
					return false;
				}

					dropped.Delete();
                    mobile.SendGump(new MissMuffetGump2(m));

             	if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

					case 0: mobile.AddToBackpack( new MissMuffetScroll() ); break;


			}

			if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

					case 0: mobile.AddToBackpack( new MissMuffetRing() ); break;


			}

					return true;
				}
                else if (dropped is BowlofWhey)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
					return false;
				}
				else
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Tis a shame this is not my curds and whey. I may go hungry yet.", mobile.NetState );
				}
			}
			return false;
		}
	}
}
				


				


