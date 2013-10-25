using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Marshmallow : Item
  {


      
      [Constructable]
		public Marshmallow()
			: base(3888)
		{
          Name = "A Marshmallow";
          Hue = 26;
		}
		
		public override void OnDoubleClick( Mobile m )
		{
		  m.SendMessage( 48, "You feel more energetic as you eat the sweet." );
		  m.Stam = m.Stam + 48;
		  this.Delete();
		}

		public Marshmallow( Serial serial ) : base( serial )
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
