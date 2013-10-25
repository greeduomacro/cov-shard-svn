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
	[CorpseName( "Second Little Pig Corpse" )]
	public class FiddlerPig : Mobile
	{
				public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public FiddlerPig()
		{
            Name = "Fiddler Pig";
						Title = "Second Little Pig";
			Body = 290;
			CantWalk = true;
			Hue = 1104;
			Blessed = true;

			}



        public FiddlerPig(Serial serial)
            : base(serial)
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
			{
					base.GetContextMenuEntries( from, list );
                    list.Add(new FiddlerPigEntry(from, this));
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

		public class FiddlerPigEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

            public FiddlerPigEntry(Mobile from, Mobile giver)
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
                    if (!mobile.HasGump(typeof(FiddlerPigQuestGump)))
					{
                        mobile.SendGump(new FiddlerPigQuestGump(mobile));
                        mobile.AddToBackpack(new FiddlersWoodBox());
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
                if (dropped is FullWoodBox)
			{
				if( dropped.Amount!=1)
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "AH, you have done it. Now I can rebuild my home! Thank you!", mobile.NetState );
					return false;
				}

					dropped.Delete();
                    mobile.SendGump(new FiddlerPigQuestGump2(m));

             	if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

                case 0: mobile.AddToBackpack(new FiddlerPigsScroll()); break;


			}

			if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

					case 0: mobile.AddToBackpack( new WoodenHorseStatueRare() ); break;


			}

					return true;
				}
                else if (dropped is FullWoodBox)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
					return false;
				}
				else
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This is not the full box i requested! Please try again!", mobile.NetState );
				}
			}
			return false;
		}
	}
}
				


				


