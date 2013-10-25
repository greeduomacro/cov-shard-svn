/* Created by Hammerhand*/

using System;
using Server;

namespace Server.Items
{
	public class BabyTime : Item
	{
		[Constructable]
		public BabyTime() : base( 0x1AE6 )
		{
			Weight = 2.0;
			Hue = 1154;
			Name = "Baby Time";
			Light = LightType.Circle300;
		}

		public override void OnDoubleClick( Mobile from )
		{
			{
				from.PlaySound( 0x8E );

			}
		}

		public BabyTime( Serial serial ) : base( serial )
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


