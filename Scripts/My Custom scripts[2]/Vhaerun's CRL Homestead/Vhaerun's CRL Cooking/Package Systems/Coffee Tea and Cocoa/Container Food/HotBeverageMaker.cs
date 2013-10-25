using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class HotBeverageMaker : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefPercolate.CraftSystem; } }

		[Constructable]
        public HotBeverageMaker() : base( 0x9D6 )
		{
			Weight = 1.0;
            Name = "Hot Beverage Maker";
            Hue = 54;
		}

		[Constructable]
		public HotBeverageMaker( int uses ) : base( uses, 0x9D6 )
		{
			Weight = 1.0;
            Name = "Hot Beverage Maker";
            Hue = 54;
		}

		public HotBeverageMaker( Serial serial ) : base( serial )
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