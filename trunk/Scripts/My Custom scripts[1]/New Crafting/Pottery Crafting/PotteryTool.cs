using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class PotteryTool : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefPottery.CraftSystem; } }

		[Constructable]
		public PotteryTool() : base( 0x10E4 )
		{
			Hue = 1824;
            Name = "Pottery Tool";
			Weight = 1.0;
		}

		[Constructable]
		public PotteryTool( int uses ) : base( uses, 0x10E4 )
		{
			Weight = 1.0;
			Hue = 1824;
		}

		public PotteryTool( Serial serial ) : base( serial )
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
	