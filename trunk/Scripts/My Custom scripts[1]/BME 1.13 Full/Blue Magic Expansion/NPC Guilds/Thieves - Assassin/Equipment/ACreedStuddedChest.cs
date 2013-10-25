// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedStuddedChest : ACreedGarb
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public ACreedStuddedChest() : base( 5068, Layer.InnerTorso )
		{
			Hue = 2101;
		}

		public override void UpdateLevel()
		{
			if ( Level > 0 )
			{
				Attributes.ReflectPhysical = 15;
				ItemID = 5083;
			}
			else
			{
				Attributes.ReflectPhysical = 0;
				ItemID = 5068;
			}
		}

		public ACreedStuddedChest( Serial serial ) : base( serial )
		{
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
		}
	}
}