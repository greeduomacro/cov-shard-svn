using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class NoxShield : WoodenKiteShield, ITokunoDyable
	{  
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public NoxShield()
		{
            Name = "Nox Shield";
			ItemID = 0x1B78;
			Hue = 1272;
			Attributes.NightSight = 1;
			Attributes.SpellChanneling = 1;
			Attributes.DefendChance = 15;
			Attributes.CastSpeed = 1;
		}

		public NoxShield( Serial serial ) : base( serial )
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

			if ( Attributes.NightSight == 0 )
				Attributes.NightSight = 1;
		}
	}
}