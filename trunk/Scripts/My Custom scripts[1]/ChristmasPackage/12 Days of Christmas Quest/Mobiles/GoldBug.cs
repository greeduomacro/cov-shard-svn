/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Targeting;
using System.Collections.Generic;
using System.Collections;

namespace Server.Mobiles
{
    [CorpseName("a goldbug corpse")]
	public class GoldBug : BaseMount
	{
        public override int GetAngerSound()
        {
            return 0x21D;
        }

        public override int GetIdleSound()
        {
            return 0x21D;
        }

        public override int GetAttackSound()
        {
            return 0x162;
        }

        public override int GetHurtSound()
        {
            return 0x163;
        }

        public override int GetDeathSound()
        {
            return 0x21D;
        }
		[Constructable]
        public GoldBug(): this("A GoldBug")
		{
		}

		[Constructable]
        public GoldBug(string name): base(name, 0x317, 0x3EBC, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
            Hue = 1260;
            
			SetStr( 750 );
			SetDex( 375 );
			SetInt( 500 );

            SetHits(610, 750);
            SetMana(375, 425);
            SetStam(125, 145);

			SetDamage( 27, 39);

            SetDamageType(ResistanceType.Physical, 85);

            SetResistance(ResistanceType.Physical, 50, 60);
            SetResistance(ResistanceType.Fire, 70, 75);
            SetResistance(ResistanceType.Poison, 25, 30);
            SetResistance(ResistanceType.Energy, 25, 30);

            SetSkill(SkillName.MagicResist, 80.0, 100.0);
            SetSkill(SkillName.Tactics, 70.0, 90.0);
            SetSkill(SkillName.Wrestling, 50.0, 55.0);

                        
            Fame = 4000;
			Karma = -4000;
        }
                    public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            if (m_Spawning)
            {
                PackItem(new GoldenRing());
            }
        }

        public override bool AutoDispel { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Deadly; } }
        public override Poison HitPoison { get { return Poison.Deadly; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }

        public GoldBug(Serial serial)
            : base(serial)
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
		}
	}

}