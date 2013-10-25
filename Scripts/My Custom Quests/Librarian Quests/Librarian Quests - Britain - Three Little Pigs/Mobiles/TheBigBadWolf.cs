using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "The Big Bad Wolf corpse" )]
	
	public class TheBigBadWolf : BaseCreature
	{
        private static bool m_Talked;

        string[] kfcsay = new string[] 
      		{ 
			"Pigs in a blanket will be my dessert after you!",//You can change up the words he uses here.
			"I will huff and puff and blow you down!",//You can change up the words he uses here.
			"After I dispose of you those pigs will pay for this outrage!",//You can change up the words he uses here.
		
      		};
        private Timer m_Timer;
        
        [Constructable]
		public TheBigBadWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "The Big Bad Wolf";
			Body = Utility.RandomList( 34, 37 );
            BaseSoundID = 0xE5;
            Hue = 1150;

            SetStr(1000);
            SetDex(151, 175);
            SetInt(171, 220);

            SetHits(3600);

            SetDamage(34, 36);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Cold, 50);

            SetResistance(ResistanceType.Physical, 75);
            SetResistance(ResistanceType.Fire, 60);
            SetResistance(ResistanceType.Cold, 90);
            SetResistance(ResistanceType.Poison, 100);
            SetResistance(ResistanceType.Energy, 60);

            SetSkill(SkillName.EvalInt, 77.6, 87.5);
            SetSkill(SkillName.Magery, 77.6, 87.5);
            SetSkill(SkillName.Meditation, 100.0);
            SetSkill(SkillName.MagicResist, 50.1, 75.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 100.0);

            Fame = 20000;
            Karma = -20000;

            VirtualArmor = 50;

            
            PackMagicItems(1, 5);
		}
        public override void GenerateLoot()
        {
            
            AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.Gems, 8);
        
    
       
           
    }

        public override bool ReacquireOnMovement { get { return !Controlled; } }
        public override bool HasBreath { get { return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
        public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }
   
    public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m_Talked == false)
            {
                
                {
                    m_Talked = true;
                    SayRandom(kfcsay, this);
                    this.Move(GetDirectionTo(m.Location));
                    SpamTimer t = new SpamTimer();
                    t.Start();
                }
            }
        }        
        
    public TheBigBadWolf (Serial serial) : base(serial)
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

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}