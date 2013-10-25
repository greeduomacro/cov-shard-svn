//Scripted by Mimi & Kila Ventru
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class FullWoodBox : Item
	{
		[Constructable]
        public FullWoodBox(): base(2474)
		{
            Name = "A Full Wood Box";
				  Hue = 1004;
			
		}

        public FullWoodBox(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}