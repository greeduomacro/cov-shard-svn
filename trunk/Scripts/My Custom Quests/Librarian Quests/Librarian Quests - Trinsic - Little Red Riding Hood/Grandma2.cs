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
    [CorpseName( "corpse of the Big Bad Wolf" )]
    public class Grandma2 : BaseCreature
    {
        private static bool m_Talked;

        string[] kfcsay = new string[] 
      		{ 
			"Now you will taste the full fury of my wrath?!",//You can change up the words he uses here.
			"Your bones! I will pick them clean.",//You can change up the words he uses here.
			"You can't defeat me.",//You can change up the words he uses here.
		
      		}; 

        private Timer m_Timer;

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        [Constructable]
		public Grandma2 () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Big Bad Wolf";
			Body = 250;
			BaseSoundID = 0xE5;
						Hue = 1842;

			SetStr( 1000 );
			SetDex( 151, 175 );
			SetInt( 171, 220 );

			SetHits( 3600 );

			SetDamage( 34, 36 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 90 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.EvalInt, 77.6, 87.5 );
			SetSkill( SkillName.Magery, 77.6, 87.5 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 44;
		     PackItem( new WolfsScroll() );
			 PackItem( new Bone( Utility.RandomMinMax( 5, 14 ) ));
	         PackMagicItems( 1, 5 );
			 switch ( Utility.Random( 4 ))
				 { 
					case 0: PackItem( new WolfsFur() ); break;

					case 1: PackItem( new Head() ); break;
					case 2: PackItem( new WolfClaws() ); break;
			     }
        }  
		public override void GenerateLoot()
		{

        {
			AddLoot( LootPack.Rich, 1);

		}
                   
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

            public TeleportTimer(Mobile owner) : base(TimeSpan.FromSeconds(10.0), TimeSpan.FromSeconds(10.0))
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


        public Grandma2(Serial serial) : base(serial)
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
        private BaseCreature bc;
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        
        }
    }
}
