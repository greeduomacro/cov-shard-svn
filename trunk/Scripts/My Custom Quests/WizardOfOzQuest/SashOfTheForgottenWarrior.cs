using System;
using Server;

namespace Server.Items
{
    public class SashOfTheForgottenWarrior : BodySash
    {
        [Constructable]
        public SashOfTheForgottenWarrior()
        {
            Hue = 53;
            SkillBonuses.SetValues(0, SkillName.Bushido, 10.0);
            SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            Attributes.RegenHits = 5;
            Attributes.BonusStr = 5;
            Attributes.BonusHits = 10;

            LootType = LootType.Blessed;
        }

        public SashOfTheForgottenWarrior(Serial serial)
            : base(serial)
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