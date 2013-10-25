using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ObsidianEarrings : GoldEarrings
	{

        public override int LabelNumber { get { return 1113820; } } // Obsidian Earrings

		[Constructable]
		public ObsidianEarrings()
		{
            Weight = 1.0;
			Hue = 2019;

            Attributes.CastSpeed = 1;
            Attributes.RegenMana = 2;
            Attributes.RegenStam = 2;
            Attributes.BonusMana = 8;
            Attributes.SpellDamage = 8;

            Resistances.Physical = 4;
            Resistances.Fire = 10;
            Resistances.Cold = 10;
            Resistances.Poison = 3;
            Resistances.Energy = 13;
           
		}

		public ObsidianEarrings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}