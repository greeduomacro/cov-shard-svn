using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SashOfLunaInvasion : BodySash
    {
        [Constructable]
        public SashOfLunaInvasion()
        {
            Hue = 53;
            Name = "I survived the Luna Invasion 2011";
            SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            Attributes.RegenHits = 5;
            Attributes.BonusInt = 5;
           
            LootType = LootType.Blessed;
        }

        public SashOfLunaInvasion(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}