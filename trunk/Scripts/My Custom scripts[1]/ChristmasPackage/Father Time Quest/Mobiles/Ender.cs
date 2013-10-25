using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;

namespace Server.Mobiles
{
    [CorpseName("an Ender corpse")]
    public class Ender : BaseCreature
    {
        private Mobile m_Owner;
        private DateTime m_ExpireTime;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime ExpireTime
        {
            get { return m_ExpireTime; }
            set { m_ExpireTime = value; }
        }

        [Constructable]
        public Ender()
            : this(null)
        {
        }

        public override bool AlwaysMurderer { get { return true; } }

        public override void DisplayPaperdollTo(Mobile to)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] is ContextMenus.PaperdollEntry)
                    list.RemoveAt(i--);
            }
        }

        public override void OnThink()
        {
            bool expired;

            expired = (DateTime.Now >= m_ExpireTime);

            if (!expired && m_Owner != null)
                expired = m_Owner.Deleted || Map != m_Owner.Map || !InRange(m_Owner, 16);

            if (expired)
            {
                PlaySound(GetIdleSound());
                Delete();
            }
            else
            {
                base.OnThink();
            }
        }

        public Ender(Mobile owner)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            m_Owner = owner;
            m_ExpireTime = DateTime.Now + TimeSpan.FromMinutes(8.0);

            Name = "an Ender";
            Hue = 0;

            switch (Utility.Random(10))
            {
                case 0: // wyvern
                    Body = 62;
                    BaseSoundID = 362;
                    break;
                case 1: // dread spider
                    Body = 11;
                    BaseSoundID = 1170;
                    break;
                case 2: // skittering hopper
                    Body = 302;
                    BaseSoundID = 959;
                    break;
                case 3: // swamp tentacle
                    Body = 66;
                    BaseSoundID = 352;
                    break;
                default:
                case 4: // raiju
                    Body = 199;
                    BaseSoundID = 0x346;
                    break;
            }

            SetStr(201, 350);
            SetDex(180);
            SetInt(160, 200);

            SetHits(400, 580);

            SetDamage(21, 37);

            SetDamageType(ResistanceType.Physical, 80);

            SetResistance(ResistanceType.Physical, 65, 75);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 65, 75);
            SetResistance(ResistanceType.Energy, 55, 65);

            SetSkill(SkillName.MagicResist, 25.0);
            SetSkill(SkillName.Tactics, 25.0);
            SetSkill(SkillName.Wrestling, 50.0);

            Fame = 1000;
            Karma = -1000;

            VirtualArmor = 40;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
            AddLoot(LootPack.Gems);

        }
        public Ender(Serial serial)
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