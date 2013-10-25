//Scripted By James4245
using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
    [CorpseName( "corpse of Grandma" )]
    public class Grandma : BaseCreature
        {
            private static bool m_Talked;

            string[] kfcsay = new string[] 
      		{ 
			"So you want my story, well come and get it if you can?!",//You can change up the words he uses here.
			"You will not leave this place alive.",//You can change up the words he uses here.
			"You will be my meal this night.",//You can change up the words he uses here.
		
      		}; 
        private Timer m_Timer;

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        [Constructable]
        public Grandma () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            
            Name = "Grandma";
            Body = 606;
            Hue = Utility.RandomSkinHue();

            Item hair = new Item(Utility.RandomList(0x2FC0, 0x2FC1, 0x2FCD, 0x2FD1));
            hair.Hue = 1109;
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem(hair);

            SetStr(350, 400);//Adjust this to fit your shard.
            SetDex(100, 150);//Adjust this to fit your shard.
            SetInt(100, 150);//Adjust this to fit your shard.

            SetHits(800, 1000);//Adjust this to fit your shard.

            SetDamage(25, 30);//Adjust this to fit your shard.

            SetDamageType(ResistanceType.Physical, 45);//Adjust this to fit your shard.
            SetDamageType(ResistanceType.Energy, 75);//Adjust this to fit your shard.

            SetResistance(ResistanceType.Physical, 80, 85);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Fire, 50, 70);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Cold, 50);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Poison, 90, 100);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Energy, 40);//Adjust this to fit your shard.

            SetSkill(SkillName.Anatomy, 90.1, 100.0);//Adjust this to fit your shard.
            SetSkill(SkillName.EvalInt, 90.1, 100.0);//Adjust this to fit your shard.
            SetSkill(SkillName.Magery, 90.1, 100.0);//Adjust this to fit your shard.
            SetSkill(SkillName.Meditation, 90.1, 100.0);//Adjust this to fit your shard.
            SetSkill(SkillName.MagicResist, 100.0, 150.0);//Adjust this to fit your shard.
            SetSkill(SkillName.Tactics, 90.1, 100.0);//Adjust this to fit your shard.
            SetSkill(SkillName.Swords, 90.1, 100.0);//Adjust this to fit your shard.

            Fame = 8000;//Adjust this to fit your shard.
            Karma = -8000;//Adjust this to fit your shard.

            VirtualArmor = 35;//Adjust this to fit your shard. 

            Shoes Shoes = new Shoes();
            Shoes.Hue = 1150;
            AddItem(Shoes);

            PlainDress PlainDress = new PlainDress();
            PlainDress.Hue = 1150;
            AddItem(PlainDress);

            SkullCap SkullCap = new SkullCap();
            SkullCap.Hue = 1150;
            AddItem(SkullCap);
            
            m_Timer = new TeleportTimer(this);
            m_Timer.Start();
        }
            
        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool AlwaysMurderer { get { return true; } }

            public override void OnMovement(Mobile m, Point3D oldLocation)
            {
                if (m_Talked == false)
                {
                    if (m.InRange(this, 1))
                    {
                        m_Talked = true;
                        SayRandom(kfcsay, this);
                        this.Move(GetDirectionTo(m.Location));
                        SpamTimer t = new SpamTimer();
                        t.Start();
                    }
                }
            }        

        private class TeleportTimer : Timer
        {
            private Mobile m_Owner;

            private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

            public TeleportTimer(Mobile owner)
                : base(TimeSpan.FromSeconds(20.0), TimeSpan.FromSeconds(20.0))
            {
                m_Owner = owner;
            }

            protected override void OnTick()
            {
                if (m_Owner.Deleted)
                {
                    Stop();
                    return;
                }

                Map map = m_Owner.Map;

                if (map == null)
                    return;

                if (0.25 < Utility.RandomDouble())
                    return;

                Mobile toTeleport = null;

                foreach (Mobile m in m_Owner.GetMobilesInRange(16))
                {
                    if (m != m_Owner && m.Player && m_Owner.CanBeHarmful(m) && m_Owner.CanSee(m))
                    {
                        toTeleport = m;
                        break;
                    }
                }

                if (toTeleport != null)
                {
                    int offset = Utility.Random(8) * 2;

                    Point3D to = m_Owner.Location;

                    for (int i = 0; i < m_Offsets.Length; i += 2)
                    {
                        int x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
                        int y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

                        if (map.CanSpawnMobile(x, y, m_Owner.Z))
                        {
                            to = new Point3D(x, y, m_Owner.Z);
                            break;
                        }
                        else
                        {
                            int z = map.GetAverageZ(x, y);

                            if (map.CanSpawnMobile(x, y, z))
                            {
                                to = new Point3D(x, y, z);
                                break;
                            }
                        }
                    }

                    Mobile m = toTeleport;

                    Point3D from = m.Location;

                    m.Location = to;

                    Server.Spells.SpellHelper.Turn(m_Owner, toTeleport);
                    Server.Spells.SpellHelper.Turn(toTeleport, m_Owner);

                    m.ProcessDelta();

                    Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3709, 1, 30, 9904, 1108);
                    Effects.SendLocationParticles(EffectItem.Create(to, m.Map, EffectItem.DefaultDuration), 0x3709, 1, 30, 9904, 1108);

                    m.PlaySound(0x1FE);

                    m_Owner.Combatant = toTeleport;
                    m_Owner.PrivateOverheadMessage(MessageType.Regular, 1153, false, "AHHHHH!!!! Help me!!!", m_Owner.NetState);
                }
            }
        }


            public Grandma (Serial serial) : base(serial)
        {
        }
        private class SpamTimer : Timer
        {
            public SpamTimer()
                : base(TimeSpan.FromSeconds(8))
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Talked = false;
            }
        }

        private static void SayRandom(string[] say, Mobile m)
        {
            m.Say(say[Utility.Random(say.Length)]);
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
        public override void OnDeath(Container c)
        {
            Grandma2 s2 = new Grandma2();
            s2.Map = this.Map;
            s2.Location = this.Location;

            base.OnDeath(c);
            c.Delete();
        }
    }
}
