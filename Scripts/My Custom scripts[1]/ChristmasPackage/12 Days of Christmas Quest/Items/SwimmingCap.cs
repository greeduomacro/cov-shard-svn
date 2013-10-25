/*Created by Hammerhand*/

using System;
using Server;

namespace Server.Items
{

	public class SwimmingCap : Cap
	{

		[Constructable]
		public SwimmingCap( ) : base( 0x1715 )
		{
            Name = "Swimming Cap";
			Weight = 1.0;
            Hue = 1150;
		}

            public SwimmingCap(Serial serial)
                : base(serial)
            {
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)0); // version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();
            }
        }
    }

	
		
	
