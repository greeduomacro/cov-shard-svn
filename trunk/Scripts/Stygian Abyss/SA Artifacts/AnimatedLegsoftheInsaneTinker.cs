using System;
using Server;

namespace Server.Items
{
	public class AnimatedLegsoftheInsaneTinker : PlateLegs, ITokunoDyable
	{
		public override int LabelNumber{ get{ return 1113760; } } // Animated Legs of the Insane Tinker

		public override int BasePhysicalResistance{ get{ return 17; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public AnimatedLegsoftheInsaneTinker()
		{
			Hue = 1818;
            Weight = 7.0;
            Attributes.RegenStam = 5;
            Attributes.BonusDex = 5;
            Attributes.WeaponDamage = 10;
            Attributes.WeaponSpeed = 10;
			ArmorAttributes.LowerStatReq = 50;
		}

        public AnimatedLegsoftheInsaneTinker(Serial serial): base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}