using System;
using Server;

namespace Server.Items
{
	public class LightningKryssP : Kryss
	{

		[Constructable]
		public LightningKryssP()
		{
            Name = "a prototype of a Lightning Kryss";
			ItemID = 0x1400;
			Hue = 1172;
        }

		#region Mondain's Legacy
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = nrgy = chaos = direct = 0;
		}
		#endregion

		public LightningKryssP( Serial serial ) : base( serial )
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

			if ( ItemID == 0x1401 )
				ItemID = 0x1400;
		}
	}
}