using System;
using Server;
using System.Collections;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server
{
    public class PetMoves
    {
        public static void DoMoves(BaseCreature from, Mobile target)
        {
            if (from == null || target == null || from.Blessed)
                return;

            switch (Utility.Random(5))
            {
                case 0:
                    {
                        if (from.RoarAttack > 10)
                            RoarAttack(from, target);
                        else
                            goto case 1;
                        break;
                    }
                case 1:
                    {
                        if (from.FireBreathAttack > 10)
                            FireBreathAttack(from, target);
                        else
                            goto case 2;
                        break;
                    }
                case 2:
                    {
                        if (from.IcyWindAttack > 10)
                            IcyWindAttack(from, target);
                        else
                            goto case 3;
                        break;
                    }
                case 3:
                    {
                        if (from.ShockAttack > 10)
                            ShockAttack(from, target);
                        else
                            goto case 4;
                        break;
                    }
                case 4:
                    {
                        if (from.PetPoisonAttack > 10)
                            PetPoisonAttack(from, target);
                        break;
                    }
            }
        }

        public static void RoarAttack(BaseCreature from, Mobile target)
        {
            if (from.RoarAttack < 10 || from == null || target == null)
                return;

            int power = from.RoarAttack / 10;
            int mindam = from.RoarAttack / 3;
            int maxdam = from.RoarAttack / 2;
            from.Say("*Roars*");

            ArrayList targets = new ArrayList();

            foreach (Mobile m in from.GetMobilesInRange(power))
            {
                if (m != from && from.CanBeHarmful(m))
                    targets.Add(m);
            }

            for (int i = 0; i < targets.Count; ++i)
            {
                Mobile m = (Mobile)targets[i];

                if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;

                   // if (bc.Controlled == true && bc.ControlMaster != null)
                       // return;//////////////////////////////////////////////////////////////////////////////
                    
                  //  else
                    
                    bc.BeginFlee(TimeSpan.FromSeconds(10.0));
                    AOS.Damage(target, from, Utility.RandomMinMax(mindam, maxdam), 100, 0, 0, 0, 0);
                }
            }
        }

        public static void FireBreathAttack(BaseCreature from, Mobile target)
        {
            if (from.FireBreathAttack < 10 || from == null || target == null)
                return;

            // Scale FireBreath Attack, IE 100 points = 100% of the standard 25% breath scaler, then drop to 75% since it later reburns them.
            // Confused yet? 100 points is equal to 75% of the damage of every other fire breathing monster.
            int damage = (int)((from.Hits * (0.01 * ((28 * from.FireBreathAttack) / 100))) * 0.75);

            from.MovingParticles(target, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
            from.PlaySound(Core.AOS ? 0x15E : 0x44B);
            from.Say("Fire Breath");
            target.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
            target.PlaySound(0x208);

            AOS.Damage(target, from, damage, 0, 0, 0, 0, 100);

            new FireBreathDOT(target, from, from.FireBreathAttack).Start();
        }

        public static void IcyWindAttack(BaseCreature from, Mobile target)
        {
            if (from.IcyWindAttack < 10 || from == null || target == null)
                return;

            Effects.SendLocationParticles(EffectItem.Create(target.Location, target.Map, EffectItem.DefaultDuration), 0x37CC, 1, 40, 97, 3, 9917, 0);
            int mindam = from.IcyWindAttack / 3;
            int maxdam = from.IcyWindAttack / 2;

            ArrayList targets = new ArrayList();

            foreach (Mobile m in from.GetMobilesInRange(from.IcyWindAttack / 10))
            {
                if (m != from && from.CanBeHarmful(m))
                    targets.Add(m);
            }

            for (int i = 0; i < targets.Count; ++i)
            {
                Mobile m = (Mobile)targets[i];
                from.Say("Icy Wind Attack");
                AOS.Damage(target, from, Utility.RandomMinMax(mindam, maxdam), 0, 0, 100, 0, 0);
                Slow.SlowWalk(m, 10);
            }
        }

        public static void ShockAttack(BaseCreature from, Mobile target)
        {
            if (from.ShockAttack < 10 || from == null || target == null)
                return;

            int mindam = from.ShockAttack / 2;
            int maxdam = from.ShockAttack;

            from.Say("Shock Attack");
            target.SendMessage("Your body is paralyzed from the electrical current!");
            target.Freeze(TimeSpan.FromSeconds(3));
            AOS.Damage(target, from, Utility.RandomMinMax(mindam, maxdam), 0, 0, 0, 0, 100);
        }

        public static void PetPoisonAttack(BaseCreature from, Mobile target)
        {
            if (from.PetPoisonAttack < 10 || from == null || target == null)
                return;

            Effects.SendLocationParticles(EffectItem.Create(target.Location, target.Map, EffectItem.DefaultDuration), 0x36B0, 1, 14, 63, 7, 9915, 0);
            Effects.PlaySound(target.Location, target.Map, 0x229);

            int mindam = from.PetPoisonAttack / 3;
            int maxdam = from.PetPoisonAttack / 2;

            int level = from.PetPoisonAttack / 20;

            if (level > 3)
                level = 3; // 3 is Deadly

            from.Say("Poison Attack");
            target.ApplyPoison(from.ControlMaster, Poison.GetPoison(level));
            AOS.Damage(target, from, Utility.RandomMinMax(mindam, maxdam), 0, 0, 0, 0, 100);
        }

        public class FireBreathDOT : Timer
        {
            private Mobile m_Mobile;
            private Mobile m_From;
            private int m_Count;

            public FireBreathDOT(Mobile m, Mobile from, int count)
                : base(TimeSpan.FromSeconds(10.0), TimeSpan.FromSeconds(20.0))
            {
                m_Mobile = m;
                m_From = from;
                m_Count = count;
            }

            protected override void OnTick()
            {
                if (m_Mobile == null || m_From == null)
                {
                    Stop();
                    return;
                }

                m_Mobile.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
                m_Mobile.PlaySound(0x208);
                AOS.Damage(m_Mobile, m_From, Utility.RandomMinMax((m_Count / 3), (m_Count / 2)), 0, 100, 0, 0, 0);
                m_Mobile.SendMessage("You are on fire.");

                m_Count -= 20;

                if (m_Count < 1)
                {
                    m_Mobile.SendMessage("You have stopped burning.");
                    Stop();
                }
            }
        }
    }
}
