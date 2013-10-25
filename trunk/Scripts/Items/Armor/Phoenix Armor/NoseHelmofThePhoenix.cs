using System;
using Server;

namespace Server.Items
{
	public class NoseHelmofThePhoenix : NorseHelm
	{
		public override int LabelNumber{ get{ return 1041609; } } // Norse Helm of the Phoenix
		
		public override SetItem SetID{ get{ return SetItem.Phoenix; } }
		public override int Pieces{ get{ return 6; } }
		
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public NoseHelmofThePhoenix() : base()
		{
            Hue = 0;
            SetHue = 242;

            SetSelfRepair = 3;

            SetPhysicalBonus = 2;
            SetFireBonus = 5;
            SetColdBonus = 2;
            SetPoisonBonus = 2;
            SetEnergyBonus = 2;
		}

		public NoseHelmofThePhoenix( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}