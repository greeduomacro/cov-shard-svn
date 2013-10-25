/* Created By Hammerhand*/

using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("a Time Thief's corpse")]
    public class TimeThief : BaseCreature
    {
        [Constructable]
        public TimeThief()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a Time Thief";
            Body = 146;
            Hue = 0;

            SetStr(400, 650);
            SetDex(165);
            SetInt(160, 200);

            SetHits(3180, 4040);

            SetDamage(35, 60);

            SetDamageType(ResistanceType.Physical, 55);
            SetDamageType(ResistanceType.Poison, 50);

            SetResistance(ResistanceType.Physical, 70, 90);
            SetResistance(ResistanceType.Fire, 45, 55);
            SetResistance(ResistanceType.Cold, 35, 45);
            SetResistance(ResistanceType.Poison, 100, 110);
            SetResistance(ResistanceType.Energy, 65, 85);

            SetSkill(SkillName.MagicResist, 95.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 100.0);

            Fame = 13000;
            Karma = -13000;

            VirtualArmor = 50;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);

            if (m_Spawning)
            {
             PackItem(new BabyTime());
                
            }
        }
        public override bool AlwaysMurderer{ get{ return true; } }

        public override void OnDamagedBySpell(Mobile caster)
        {
            if (caster != this && 0.25 > Utility.RandomDouble())
            {
                BaseCreature spawn = new Ender(this);

                spawn.Team = this.Team;
                spawn.MoveToWorld(this.Location, this.Map);
                spawn.Combatant = caster;

                Say("Come forth and do my bidding Ender!"); // * The Time Thief summons another beast! *
            }

            base.OnDamagedBySpell(caster);
        }

        //public override bool AutoDispel { get { return true; } }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            if (attacker != this && 0.25 > Utility.RandomDouble())
            {
                BaseCreature spawn = new Ender(this);

                spawn.Team = this.Team;
                spawn.MoveToWorld(this.Location, this.Map);
                spawn.Combatant = attacker;

                Say("Come forth and do my bidding Ender!");  // * The Time Thief summons another beast! *
            }

            base.OnGotMeleeAttack(attacker);
        }

        public TimeThief(Serial serial)
            : base(serial)
        {
        }

        public override int GetIdleSound()
        {
            return 0x1BF;
        }

        public override int GetAttackSound()
        {
            return 0x1C0;
        }

        public override int GetHurtSound()
        {
            return 0x1C1;
        }

        public override int GetDeathSound()
        {
            return 0x1C2;
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