
using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("an Evil Bunny Protector")]
    public class EvilBunnyProtector : BaseCreature
    {
        [Constructable]
        public EvilBunnyProtector()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            Name = " Evil Bunny Protector";
            //Title = "The Player Eating";
            Body = 776;
            Hue = 1172;

            SetStr(60, 100);
            SetDex(26, 38);
            SetInt(6, 14);

            SetHits(60, 100);
            SetMana(0);

            SetDamage(10, 12);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 34);
            SetResistance(ResistanceType.Fire, 10, 14);
            SetResistance(ResistanceType.Cold, 30, 35);
            SetResistance(ResistanceType.Poison, 20, 25);
            SetResistance(ResistanceType.Energy, 20, 25);

            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.Wrestling, 120.0);

            Fame = 500;
            Karma = 100;

            VirtualArmor = 25;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public EvilBunnyProtector(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [CorpseName("an Evil Bunny Protector")]
    public class EvilBunnyProtector1 : BaseCreature
    {
        [Constructable]
        public EvilBunnyProtector1()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            Name = "an Evil Bunny Protector";
            //Title = "The Player Eating";
            Body = 795;
            Hue = 1172;

            SetStr(200, 300);
            SetDex(86, 110);
            SetInt(51, 75);

            SetHits(200, 300);

            SetDamage(15, 17);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 34);
            SetResistance(ResistanceType.Fire, 10, 14);
            SetResistance(ResistanceType.Cold, 30, 35);
            SetResistance(ResistanceType.Poison, 20, 25);
            SetResistance(ResistanceType.Energy, 20, 25);

            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.Wrestling, 120.0);

            Fame = 500;
            Karma = 100;

            VirtualArmor = 35;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
        }

        public EvilBunnyProtector1(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [CorpseName("an Evil Bunny Protector2")]
    public class EvilBunnyProtector2 : BaseCreature
    {
        [Constructable]
        public EvilBunnyProtector2()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            Name = "an Evil Bunny Protector";
            //Title = "The Player Eating";
            Body = 796;
            Hue = 1172;

            SetStr(300, 400);
            SetDex(45, 55);
            SetInt(31, 43);

            SetHits(300, 400);

            SetDamage(25, 30);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 34);
            SetResistance(ResistanceType.Fire, 10, 14);
            SetResistance(ResistanceType.Cold, 30, 35);
            SetResistance(ResistanceType.Poison, 20, 25);
            SetResistance(ResistanceType.Energy, 20, 25);

            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.Wrestling, 120.0);

            Fame = 500;
            Karma = 100;

            VirtualArmor = 45;

        }

        public override bool HasBreath { get { return true; } } // fire breath enabled

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public EvilBunnyProtector2(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}