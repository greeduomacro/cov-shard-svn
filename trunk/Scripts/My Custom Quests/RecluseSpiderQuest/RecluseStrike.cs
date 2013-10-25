using System;
using Server;
using System.Collections;
using Server.Mobiles;
using Server.Gumps;
using Server.Items;

namespace Server.Items
{
    /// <summary>
    /// A successful Recluse Strike will render its victim unable to heal itself without the antidote for several hours. 
    /// It also morphs you into a rotten corpse, and if you dont get the antidote in time you die, and lose 
    /// 10% in all your skills.!!
    /// </summary>
    public class RecluseStrike : WeaponAbility
    {
        public RecluseStrike()
        {
        }
        public override int BaseMana { get { return 30; } }

        public static readonly TimeSpan PlayerDuration = TimeSpan.FromHours(3.0);
        public static readonly TimeSpan NPCDuration = TimeSpan.FromSeconds(12.0);

        public override void OnHit(Mobile attacker, Mobile defender, int damage)
        {
            if (!Validate(attacker) || !CheckMana(attacker, true ))
                return;
            //{
               // SolidHueOverride == 340;
               // defender;
            //}
    
            ClearCurrentAbility(attacker);
            attacker.Kill();
             
                    IMount mount = defender.Mount;

                    if (defender.Mounted)

                        mount.Rider = null;

                    if (defender.BodyMod == 155 )
                    {
                        defender.SendMessage("The Recluse senses you have been bitten already!");
                        attacker.Kill();
                    }
                    else
                    {
                   
                    defender.SendGump(new RecluseInfectedGump());

                    defender.PlaySound(0x474);
                    defender.FixedParticles(0x37B9, 244, 25, 9944, 31, 0, EffectLayer.Waist);
                    defender.BodyMod = 155;
                    defender.Hue = 340;
                    defender.AddToBackpack(new RecluseStingMarker());
                    // Do not reset timer if one is already in place.
                    if (!IsWounded(defender))
                        BeginWound(defender, defender.Player ? PlayerDuration : NPCDuration);
                }
            }  

        private static Hashtable m_Table = new Hashtable();

        public static bool IsWounded(Mobile m)
        {                             
            return m_Table.Contains(m);
        }

        public static void BeginWound(Mobile m, TimeSpan duration)
        {
            Timer t = (Timer)m_Table[m];

            if (t != null)
                t.Stop();

            t = new InternalTimer(m, duration);
            m_Table[m] = t;

            t.Start();

            m.YellowHealthbar = true;
        }

        public static void EndWound(Mobile m)
        {
            Timer t = (Timer)m_Table[m];

            if (t != null)
                t.Stop();

            m_Table.Remove(m);

            PlayerMobile mobile = (PlayerMobile)m;
            {
                Item am = m.Backpack.FindItemByType(typeof(RecluseStingMarker));

               // if (m == null)
               // {
                   // return;
               // }

                if (m is PlayerMobile && am != null)
                {
                    m.BodyMod = 0;
                    m.Hue = 0;
                    m.Kill();

                    double decreaseAmount;

                    decreaseAmount = 10.0;

                    for (int i = 0; i < m.Skills.Length; ++i)	//Decrease all skills on you.
                    m.Skills[i].Base -= decreaseAmount;
                    m.YellowHealthbar = false;
                    m.SendGump(new RecluseDeathGump());
                    am.Delete();

                }
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer(Mobile m, TimeSpan duration)
                : base(duration)
            {
                m_Mobile = m;
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                EndWound(m_Mobile);
            }
        }
    }
}
