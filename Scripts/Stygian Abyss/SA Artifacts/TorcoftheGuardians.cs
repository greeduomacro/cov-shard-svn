using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class TorcoftheGuardians : GoldNecklace
	{
		public override int LabelNumber{ get{ return 1113721; } } // Torc of the Guardians

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public TorcoftheGuardians()
		{
            Weight = 1.0;
			Hue = 1872;

			Attributes.BonusStr = 5;
            Attributes.BonusDex = 5;
            Attributes.BonusInt = 5;
			Attributes.RegenMana = 2;
            Attributes.RegenStam = 2;
			Attributes.LowerManaCost = 5;

            Resistances.Physical = 5;
            Resistances.Fire = 5;
            Resistances.Cold = 5;
            Resistances.Poison = 5;
            Resistances.Energy = 5;
			
		}

		public TorcoftheGuardians( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
