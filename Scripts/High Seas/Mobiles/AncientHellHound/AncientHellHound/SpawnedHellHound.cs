using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an hell hound corpse" )]
	public class SpawnedHellHound : HellHound
	{
		[Constructable]
		public SpawnedHellHound()
		{
			Container pack = this.Backpack;

			if ( pack != null )
			{
				pack.Delete();
			}

			NoKillAwards = true;
			Tamable = false;
		}

		public SpawnedHellHound( Serial serial ) : base( serial )
		{
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			c.Delete();
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
			NoKillAwards = true;
		}
	}
}
