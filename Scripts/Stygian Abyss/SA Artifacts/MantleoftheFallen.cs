using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Collections;
using Server.ContextMenus;

namespace Server.Items
{
    public class MantleoftheFallen : BaseClothing
    {
        public override int LabelNumber { get { return 1113819; } } // Mantle of the Fallen

        public override int BasePhysicalResistance { get { return 5; } }
        public override int BaseFireResistance { get { return 8; } }
        public override int BaseColdResistance { get { return 11; } }
        public override int BasePoisonResistance { get { return 12; } }
        public override int BaseEnergyResistance { get { return 8; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override int AosStrReq { get { return 80; } }
        public override int OldStrReq { get { return 80; } }

       

       
        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

        [Constructable]
        public MantleoftheFallen(): this(0)
        {
        }

        [Constructable]
        public MantleoftheFallen(int hue): base(0x0406, Layer.InnerTorso, hue)
        {
            Weight = 6.0;
            Hue = 1516;

            Attributes.RegenMana = 1;
            Attributes.LowerRegCost = 25;
            Attributes.SpellDamage = 5;
            Attributes.BonusMana = 8;
            Attributes.BonusInt = 8;

        }

        public override void OnAdded(object parent)
        {
            if (parent is Mobile)
            {
                if (((Mobile)parent).Female)
                    ItemID = 0x0405;
                else
                    ItemID = 0x0406;
            }
        }

        public MantleoftheFallen(Serial serial): base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}

	