using System;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{	
	public class FoodPlate : Item
	{
        [Constructable]
        public FoodPlate() : base(0x9D7)
        {
           
            //this.Stackable = true;
            this.Weight = 1.0;    
        }

		public FoodPlate( Serial serial ) : base( serial )
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