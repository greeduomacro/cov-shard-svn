using System;
using Server;
using Server.Items;
using Server.Engines.Plants;

namespace Server.Items
{	
	public class PlantClippings : Item
    {
        private PlantHue m_PlantHue;

        [CommandProperty(AccessLevel.GameMaster)]
        public PlantHue PlantHue
        {
            get { return m_PlantHue; }
            set { m_PlantHue = value; Hue = PlantHueInfo.GetInfo(value).Hue; InvalidateProperties(); }
        }

        public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

        public override int LabelNumber { get { return 1112131; } } // Plant Clippings

        [Constructable]
        public PlantClippings()
            : this(1)
        {
        }

        [Constructable]
        public PlantClippings(int amount)
            : base(0x4022)
        {
            Stackable = true;
            Amount = amount;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            PlantHueInfo hueInfo = PlantHueInfo.GetInfo(m_PlantHue);
            list.Add(1112122, "#" + hueInfo.Name);  // ~1_COLOR~ plant clippings
        }

        public PlantClippings(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_PlantHue);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    m_PlantHue = (PlantHue)reader.ReadInt();
                    break;
            }
        }
    }
}
