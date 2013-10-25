//Scripted by Raven's Keeper
using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{

	public class EmptyWheyBowl: Item
	{
		[Constructable]
		public EmptyWheyBowl() : this( null )
		{
		}

		[Constructable]
        public EmptyWheyBowl(string name) : base(0x990)
		{
			Name = "Whey Bowl (It's Empty)";
			Hue = 0;
		}

        public EmptyWheyBowl(Serial serial)
            : base(serial)
		{
		}


        public override void OnDoubleClick(Mobile m)
        {
            Item[] a = m.Backpack.FindItemsByType(typeof(Whey));
            // are there at least 10 elements in the returned array?
            if (a != null && a.Length >= 10)
            {
               
                Item b = m.Backpack.FindItemByType(typeof(EmptyWheyBowl));
                if (b != null)
                        {
                            // delete the first 10 of them
                            for (int i = 0; i < 10; i++) a[i].Delete();
                            b.Delete();
                            
                            // one pile of curd
                            m.AddToBackpack(new Curd());
                            m.SendMessage("At last I have enough whey to make a curd! Now to finish the bowl of curds and whey.");
                        }
                    
                }
                else
                {
                    m.SendMessage("You must have more whey");
                }
            }
        		
		
		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}
