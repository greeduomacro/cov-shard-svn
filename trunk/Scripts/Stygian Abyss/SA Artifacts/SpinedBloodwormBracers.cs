using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Collections;
using Server.ContextMenus;


namespace Server.Items
{
	public class SpinedBloodwormBracers : BaseArmor
	{
        public override int LabelNumber{ get{ return 1113865; } } // Spined Bloodworm Bracers

		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 80; } }

        public override int ArmorBase { get { return 16; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }


		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
        public SpinedBloodwormBracers(): base(0x0404)
		{
			Weight = 2.0;
            Hue = 1779;
            Attributes.RegenHits = 2;
            Attributes.RegenStam = 2;
            Attributes.DefendChance = 30;
            Attributes.WeaponDamage = 10;
            AbsorptionAttributes.EaterKinetic = 10;
				
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				if ( ((Mobile)parent).Female )
					ItemID = 0x0403;
				else
					ItemID = 0x0404;
			}
		}

        public SpinedBloodwormBracers(Serial serial): base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}