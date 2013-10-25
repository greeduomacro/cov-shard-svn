using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BreastplateoftheBerserker : BaseArmor
	{
        public override int LabelNumber { get { return 1113539; } } // Breastplate of the Berserker

		public override int BasePhysicalResistance{ get{ return 18; } }
		public override int BaseFireResistance{ get{ return 16; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 11; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 45; } }

		public override int AosStrReq{ get{ return 35; } }
		public override int OldStrReq{ get{ return 35; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public BreastplateoftheBerserker() : base( 0x030A )
		{
			Weight = 10.0;
            Hue = 33;
            Attributes.WeaponDamage = 15;
            Attributes.WeaponSpeed = 10;
            Attributes.LowerManaCost = 4;
            Attributes.BonusStr = 5;
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				if ( ((Mobile)parent).Female )
					ItemID = 0x0309;
				else
					ItemID = 0x030A;
			}
		}

		public BreastplateoftheBerserker( Serial serial ) : base( serial )
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