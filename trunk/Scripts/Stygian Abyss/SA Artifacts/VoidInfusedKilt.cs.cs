using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Collections;
using Server.ContextMenus;


namespace Server.Items
{
	public class VoidInfusedKilt : BaseArmor
	{
        public override int LabelNumber{ get{ return 1113868; } } // Void Infused Kilt

		public override int BasePhysicalResistance{ get{ return 13; } }
		public override int BaseFireResistance{ get{ return 12; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 9; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 80; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public VoidInfusedKilt() : base( 0x030C )
		{
			Weight = 5.0;
            Hue = 2071;
            Attributes.RegenMana = 1;
            Attributes.RegenStam = 1;
            Attributes.BonusDex = 5;
            Attributes.BonusStr = 5;
            Attributes.AttackChance = 5;
            AbsorptionAttributes.EaterDamage = 10;
				
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				if ( ((Mobile)parent).Female )
					ItemID = 0x030B;
				else
					ItemID = 0x030C;
			}
		}

		public VoidInfusedKilt( Serial serial ) : base( serial )
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