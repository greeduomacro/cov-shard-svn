using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("a gray goblin keeper corpse")]
    public class GrayGoblinKeeper : BaseCreature
    {
        //public override InhumanSpeech SpeechType { get { return InhumanSpeech.Orc; } }

        [Constructable]
        public GrayGoblinKeeper()
            : base(AIType.AI_OrcScout, FightMode.Closest, 10, 7, 0.2, 0.4)
        {
            Name = "an Gray goblin keeper";
            Body = 334;
            Hue = 641;
            BaseSoundID = 0x45A;

            SetStr(315, 330);
            SetDex(61, 79);
            SetInt(103, 112);

            SetHits(179, 190);
            SetMana(103, 112);

            SetDamage(5, 7);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 40, 50);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 10, 19);
            SetResistance(ResistanceType.Energy, 12, 19);

            SetSkill(SkillName.MagicResist, 124.7, 129.8);
            SetSkill(SkillName.Tactics, 81.6, 87.3);
            SetSkill(SkillName.Wrestling, 99.2, 103.9);
            SetSkill(SkillName.Anatomy, 85.5, 87.6);


            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 38;

            AddItem(new Gold(305, 325));

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.1)
                c.DropItem(new GoblinBlood());
        }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.SavagesAndOrcs; }
        }


        private Mobile FindTarget()
        {
            foreach (Mobile m in this.GetMobilesInRange(10))
            {
                if (m.Player && m.Hidden && m.AccessLevel == AccessLevel.Player)
                {
                    return m;
                }
            }

            return null;
        }

        private void TryToDetectHidden()
        {
            Mobile m = FindTarget();

            if (m != null)
            {
                if (DateTime.Now >= this.NextSkillTime && UseSkill(SkillName.DetectHidden))
                {
                    Target targ = this.Target;

                    if (targ != null)
                        targ.Invoke(this, this);

                    Effects.PlaySound(this.Location, this.Map, 0x340);
                }
            }
        }

        public override void OnThink()
        {
            if (Utility.RandomDouble() < 0.2)
                TryToDetectHidden();
        }

        public override bool CanRummageCorpses { get { return true; } }
        public override int Meat { get { return 1; } }

        public GrayGoblinKeeper(Serial serial)
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