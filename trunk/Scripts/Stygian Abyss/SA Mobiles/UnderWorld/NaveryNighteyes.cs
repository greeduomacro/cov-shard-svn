using System;
using Server;
using Server.Items;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
	public class NaveryNighteyes : BaseCreature
	{
		
		[Constructable]
        public NaveryNighteyes(): base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Body = 735;
			Name = "Navery Nighteyes";

			BaseSoundID = 0x183;

			SetStr( 1002 );
			SetDex( 198 );
			SetInt( 178 );

			SetHits( 30000 );
			SetStam( 198 );
            SetMana( 178 );

			SetDamage( 22, 29 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 25 );
            SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.EvalInt, 79.6, 80.0 );
			SetSkill( SkillName.Magery, 83.9, 85.0 );
            SetSkill( SkillName.Mysticism, 100);
			SetSkill( SkillName.MagicResist, 109.5, 110.0 );
			SetSkill( SkillName.Tactics, 82.0, 85.0 );
			SetSkill( SkillName.Wrestling, 83.3, 85.0 );
            SetSkill( SkillName.Meditation, 26.2, 27.0 );
			SetSkill( SkillName.Anatomy, 28.3, 30.0 );
            SetSkill( SkillName.Poisoning, 100 );

			Fame = 22500;
			Karma = -22500;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 4 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.33)
                c.DropItem(new UntransTome());

            if (Utility.RandomDouble() < 0.25)
            {
                switch (Utility.Random(4))
                {
                    case 0: c.DropItem(new Tangle1()); break;
                    case 1: c.DropItem(new NightEyes()); break;
                    case 2: c.DropItem(new SpiderCarapace()); break;
                    case 3: c.DropItem(new EyeOfNavery()); break;                 
                }
            }
        }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

	    private static bool m_InHere;

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (from != null && from != this && !m_InHere)
            {
                m_InHere = true;
                AOS.Damage(from, this, Utility.RandomMinMax(25, 30), 100, 0, 0, 0, 0);

                MovingEffect(from, 0xF8D, 10, 0, false, false, 0, 0);
                PlaySound(0x491);

                if (0.05 > Utility.RandomDouble())
                    Timer.DelayCall(TimeSpan.FromSeconds(1.0), new TimerStateCallback(CreateBloodwebSilk_Callback), from);

                m_InHere = false;
            }
        }

        public virtual void CreateBloodwebSilk_Callback(object state)
        {
            Mobile from = (Mobile)state;
            Map map = from.Map;

            if (map == null)
                return;

            int count = Utility.RandomMinMax(1, 3);

            for (int i = 0; i < count; ++i)
            {
                int x = from.X + Utility.RandomMinMax(-1, 1);
                int y = from.Y + Utility.RandomMinMax(-1, 1);
                int z = from.Z;

                if (!map.CanFit(x, y, z, 16, false, true))
                {
                    z = map.GetAverageZ(x, y);

                    if (z == from.Z || !map.CanFit(x, y, z, 16, false, true))
                        continue;
                }

                BloodwebSilk silk = new BloodwebSilk();

                silk.Hue = 2949;
                silk.Name = "Paralyzing Silk";
                silk.ItemID = 0xF8D;

                silk.MoveToWorld(new Point3D(x, y, z), map);
            }
        }

		public NaveryNighteyes( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}