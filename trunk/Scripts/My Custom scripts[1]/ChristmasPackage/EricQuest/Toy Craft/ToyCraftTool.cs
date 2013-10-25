using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{

	public class ToyCraftTool : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefToy.CraftSystem; } }

		[Constructable]
		public ToyCraftTool() : base( 0x1028 )
		{
			Weight = 2.0;
            Name = "Toy Craft Tool";
            Hue = 1167;
		}

		[Constructable]
		public ToyCraftTool( int uses ) : base( uses, 0x1028 )
		{
			Weight = 2.0;
            Hue = 1167;
		}

        public ToyCraftTool(Serial serial): base(serial)
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}