using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a purple dragon corpse")]
    public class PurpleDragon : BasePeerless
    {
        public override bool AlwaysMurderer { get { return true; } }
        // peace
        public virtual bool CanPeace { get { return true; } }
        public virtual int PeaceDuration { get { return 20; } }
        public virtual int PeaceMinDelay { get { return 10; } }
        public virtual int PeaceMaxDelay { get { return 10; } }

        // discord
        public virtual bool CanDiscord { get { return true; } }
        public virtual int DiscordDuration { get { return 20; } }
        public virtual int DiscordMinDelay { get { return 5; } }
        public virtual int DiscordMaxDelay { get { return 22; } }
        public virtual double DiscordModifier { get { return 0.28; } }

        // provocation
        public virtual bool CanProvoke { get { return true; } }
        public virtual int ProvokeMinDelay { get { return 5; } }
        public virtual int ProvokeMaxDelay { get { return 5; } }

        public virtual int PerceptionRange { get { return 12; } }

        [Constructable]
        public PurpleDragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            //int i_Resource = 0;
            //i_Resource = Utility.RandomMinMax(1, 25);

            Body = 197;
            Name = "a Purple Dragon";
            BaseSoundID = 362;
            Hue = 16;

            SetStr(2250, 2500);
            SetDex(200, 250);
            SetInt(580, 625);

            SetHits(7250, 7500);

            SetDamage(17, 25);

            //SetDamageType( ResistanceType.Physical, 25 );
            SetDamageType(ResistanceType.Energy, 100);

            SetResistance(ResistanceType.Physical, 100);
            SetResistance(ResistanceType.Fire, 75);
            SetResistance(ResistanceType.Cold, 75);
            SetResistance(ResistanceType.Poison, 75);
            SetResistance(ResistanceType.Energy, 100);

            SetSkill(SkillName.EvalInt, 120.0);
            SetSkill(SkillName.Magery, 140.0);
            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.Wrestling, 120.0);

            Fame = 18000;
            Karma = -18000;

            VirtualArmor = 85;

            Tamable = false;

            PackItem(new PurpleCrystallineFragments());

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
            AddLoot(LootPack.Gems, Utility.Random(1, 5));
        }

        public override void OnThink()
        {
            if (CanPeace && m_NextPeaceTime <= DateTime.Now)
            {
                Mobile target = Combatant;

                if (target != null && target.InRange(this, PerceptionRange) && CanBeHarmful(target))
                    Peace(target);
            }

            if (CanDiscord && m_NextDiscordTime <= DateTime.Now)
            {
                Mobile target = Combatant;

                if (target != null && target.InRange(this, PerceptionRange) && CanBeHarmful(target))
                    Discord(target);
            }

            if (CanProvoke && m_NextProvokeTime <= DateTime.Now)
            {
                Mobile target = Combatant;

                if (target != null && target.InRange(this, PerceptionRange) && CanBeHarmful(target))
                    Provoke(target);
            }
        }

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathEnergyDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 16; } }
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion


        public override bool ReacquireOnMovement { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override int TreasureMapLevel { get { return 5; } }
        public override int Meat { get { return 19; } }
        public override int Hides { get { return 20; } }
        public override HideType HideType { get { return HideType.Barbed; } }
        public override int Scales { get { return 9; } }
        public override ScaleType ScaleType { get { return ScaleType.White; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat | FoodType.Gold; } }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.PsychicAttack;
        }

        private DateTime m_NextPeaceTime;
        private DateTime m_NextDiscordTime;
        private DateTime m_NextProvokeTime;

        public void Peace(Mobile target)
        {
            if (target is PlayerMobile)
            {
                PlayerMobile player = (PlayerMobile)target;

                if (player.PeacedUntil <= DateTime.Now)
                {
                    player.PeacedUntil = DateTime.Now + TimeSpan.FromSeconds(PeaceDuration);
                    player.SendLocalizedMessage(500616); // You hear lovely music, and forget to continue battling!					
                }
            }
            else if (target is BaseCreature)
            {
                BaseCreature creature = (BaseCreature)target;

                if (!creature.BardPacified)
                    creature.Pacify(this, DateTime.Now + TimeSpan.FromSeconds(PeaceDuration));
            }

            PlaySound(0x58B);

            m_NextPeaceTime = DateTime.Now + TimeSpan.FromSeconds(PeaceMinDelay + Utility.RandomDouble() * PeaceMaxDelay);
        }

        public void Provoke(Mobile target)
        {
            foreach (Mobile m in GetMobilesInRange(PerceptionRange))
            {
                if (m is BaseCreature)
                {
                    BaseCreature c = (BaseCreature)m;

                    if (!c.CanBeHarmful(target, false) || target == c || c.BardTarget == target)
                        continue;

                    if (Utility.RandomDouble() < 0.9)
                    {
                        c.BardMaster = this;
                        c.BardTarget = target;
                        c.Combatant = target;
                        c.BardEndTime = DateTime.Now + TimeSpan.FromSeconds(30.0);

                        target.SendLocalizedMessage(1072062); // You hear angry music, and start to fight.
                        PlaySound(0x58A);
                    }
                    else
                    {
                        target.SendLocalizedMessage(1072063); // You hear angry music that fails to incite you to fight.
                        PlaySound(0x58C);
                    }

                    break;
                }
            }

            m_NextProvokeTime = DateTime.Now + TimeSpan.FromSeconds(ProvokeMinDelay + Utility.RandomDouble() * ProvokeMaxDelay);
        }

        public void Discord(Mobile target)
        {
            if (Utility.RandomDouble() < 0.9)
            {
                target.AddSkillMod(new TimedSkillMod(SkillName.Fencing, true, Combatant.Skills.Fencing.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Wrestling, true, Combatant.Skills.Wrestling.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Tactics, true, Combatant.Skills.Tactics.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Swords, true, Combatant.Skills.Swords.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Macing, true, Combatant.Skills.Macing.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Focus, true, Combatant.Skills.Focus.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Archery, true, Combatant.Skills.Archery.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));
                target.AddSkillMod(new TimedSkillMod(SkillName.Magery, true, Combatant.Skills.Magery.Base * DiscordModifier * -1, TimeSpan.FromSeconds(DiscordDuration)));

                Timer.DelayCall(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), (int)DiscordDuration, new TimerStateCallback(Animate), target);

                target.SendLocalizedMessage(1072061); // You hear jarring music, suppressing your strength.
                target.PlaySound(0x58B);
            }
            else
            {
                target.SendLocalizedMessage(1072064); // You hear jarring music, but it fails to disrupt you.
                target.PlaySound(0x58C);
            }

            m_NextDiscordTime = DateTime.Now + TimeSpan.FromSeconds(DiscordMinDelay + Utility.RandomDouble() * DiscordMaxDelay);
        }

        private void Animate(object state)
        {
            if (state is Mobile)
            {
                Mobile mob = (Mobile)state;

                mob.FixedEffect(0x376A, 1, 32);
            }
        }


        public PurpleDragon(Serial serial)
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

		
		
	


	
