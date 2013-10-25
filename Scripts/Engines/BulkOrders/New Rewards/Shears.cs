using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class Shears : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefTailoring.CraftSystem; } }

		[Constructable]
		public Shears() : base( 0xF9D )
		{
			Weight = 2.0;
			ItemID = 3999;
			Name = "Shears";
			Hue = 1258;
		}

		[Constructable]
		public Shears( int uses ) : base( uses, 0xF9D )
		{
			Weight = 2.0;
		}

		public Shears( Serial serial ) : base( serial )
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