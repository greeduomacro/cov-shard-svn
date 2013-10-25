using System;
using System.Collections;
using Server;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a bloodweb spider corpse" )]
	public class BloodwebSpider : BaseCreature
	{
		[Constructable]
		public BloodwebSpider () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bloodweb spider";
			Body = 173;
            Hue = 2949;
			BaseSoundID = 1170;

            SetStr(392, 440);
            SetDex(252, 292);
            SetInt(572, 620);

            SetHits(1118, 1132);

            SetDamage(25, 27);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Energy, 50);

            SetResistance(ResistanceType.Physical, 85);
            SetResistance(ResistanceType.Fire, 85);
            SetResistance(ResistanceType.Cold, 85);
            SetResistance(ResistanceType.Poison, 120);
            SetResistance(ResistanceType.Energy, 85);

            SetSkill( SkillName.EvalInt, 120.0 );
            SetSkill(SkillName.Magery, 120.0);
            SetSkill(SkillName.Meditation, 120);
            SetSkill(SkillName.MagicResist, 120);
            SetSkill(SkillName.Tactics, 100);
            SetSkill(SkillName.Wrestling, 140);

            Fame = 5000;
            Karma = -5000;
            Tamable = false;

            VirtualArmor = 56;

            PackItem(new SpidersSilk(18));
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosUltraRich, 3);
        }		

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 3; } }

        private static bool m_InHere;

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (from != null && from != this && !m_InHere)
            {
                m_InHere = true;
                AOS.Damage(from, this, Utility.RandomMinMax(8, 20), 100, 0, 0, 0, 0);

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
                silk.Name = "Bloodweb Silk";
                silk.ItemID = 0xF8D;

                silk.MoveToWorld(new Point3D(x, y, z), map);
            }
        }


		public BloodwebSpider( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;
		}
	}
}