using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Collections;
using Server.ContextMenus;


namespace Server.Items
{
	public class SummonersKilt : BaseArmor
	{
        public override int LabelNumber{ get{ return 1113868; } } // Summoners Kilt

		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 21; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 21; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 80; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }

		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public SummonersKilt() : base( 0x030C )
		{
			Weight = 5.0;
            Hue = 2124;

            Attributes.RegenMana = 2;
            Attributes.BonusMana = 5;
            Attributes.LowerRegCost = 10;
            Attributes.LowerManaCost = 8;
            Attributes.SpellDamage = 5;
            
            AbsorptionAttributes.CastingFocus = 2;
				
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

		public SummonersKilt( Serial serial ) : base( serial )
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