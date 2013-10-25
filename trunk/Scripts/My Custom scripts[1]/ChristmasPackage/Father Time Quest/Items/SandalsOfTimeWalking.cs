/* Created by Hammerhand */

using System;
using Server.Misc;

namespace Server.Items
{

	public class SandalsOfTimeWalking : Sandals
	{
		
		[Constructable] 
		public SandalsOfTimeWalking() : base( 0x170d ) 
		{
            Name = "Sandals Of TimeWalking";
			Hue = 1151;

            Attributes.BonusDex = 15;
			
		}

        public SandalsOfTimeWalking(Serial serial)
            : base(serial) 
		{ 

		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		} 
	} 
} 
