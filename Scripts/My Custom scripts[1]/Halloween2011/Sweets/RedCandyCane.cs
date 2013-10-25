using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class RedCandyCane : Item
  {


      
      [Constructable]
		public RedCandyCane()
			: base(11230)
		{
          Name = "A Red Candy Cane";
		}
		
		public override void OnDoubleClick( Mobile m )
		{
		  m.SendMessage( 48, "You feel more energetic as you eat the sweet." );
		  m.Stam = m.Stam + 70;
		  this.Delete();
		}

		public RedCandyCane( Serial serial ) : base( serial )
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
