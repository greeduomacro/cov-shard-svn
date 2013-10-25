using System;
using Server;

namespace Server.Items
{
	public class ProtectoroftheBattleMage: LeatherChest
	{
		public override int LabelNumber{ get{ return 1113761; } } // Protector of the Battle Mage
		public override int ArtifactRarity{ get{ return 11; } }

        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 16; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 8; } }
        public override int BaseEnergyResistance { get { return 8; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ProtectoroftheBattleMage()
		{
            Weight = 6.0;
			Hue = 879;

            Attributes.RegenMana = 2;
            Attributes.LowerManaCost = 8;
			Attributes.LowerRegCost = 10;
            Attributes.SpellDamage = 5;
			ArmorAttributes.MageArmor = 1;
		}

		public ProtectoroftheBattleMage( Serial serial ) : base( serial )
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