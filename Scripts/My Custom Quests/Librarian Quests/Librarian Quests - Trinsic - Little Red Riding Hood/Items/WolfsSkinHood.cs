using System;
using Server;

namespace Server.Items
{
	public class WolfsSkinHood : BearMask
	{
		public override int LabelNumber{ get{ return 1070637; } }

		[Constructable]
		public WolfsSkinHood()
		{
			Hue = 1864;
			Name = "Wolfs Head Mask";
			Resistances.Physical = 10;
			Resistances.Fire = 10;

			ClothingAttributes.SelfRepair = 5;

			Attributes.RegenHits = 5;
			Attributes.NightSight = 1;
		}

		public WolfsSkinHood( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				Resistances.Physical = 10;
				Resistances.Cold = 13;
			}

			if ( Attributes.NightSight == 0 )
				Attributes.NightSight = 1;
		}
	}
}