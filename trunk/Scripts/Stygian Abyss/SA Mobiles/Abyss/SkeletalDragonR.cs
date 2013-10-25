using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal dragon corpse" )]
	public class SkeletalDragonR : BaseCreature
	{
		[Constructable]
		public SkeletalDragonR() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Skeletal Dragon(Renowned)";
            Hue = 1153;
			Body = 104;
			BaseSoundID = 0x488;


			SetStr( 940, 950 );
			SetDex( 130, 135 );
			SetInt( 550, 560 );

			SetHits( 6000, 6200 );

			SetDamage( 29, 35 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 55, 60 );
			SetResistance( ResistanceType.Cold, 55, 60 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 45, 60 );

			SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.Magery, 120.0, 130.0 );
			SetSkill( SkillName.MagicResist, 113.2, 130.0 );
			SetSkill( SkillName.Tactics, 115.0, 130.0 );
			SetSkill( SkillName.Wrestling, 115.0, 145.0 );

			Fame = 22500;
			Karma = -22500;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, 5 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            c.DropItem(new EssencePersistence());

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(3))
                {
                    case 0: c.DropItem(new VoidInfusedKilt()); break;

                    case 1: c.DropItem(new AxeOfAbandon()); break;

                    case 2: c.DropItem(new BladeOfBattle()); break; 
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x480; } }
		public override double BonusPetDamageScalar{ get{ return (Core.SE)? 3.0 : 1.0; } }
        public override bool AlwaysMurderer { get { return true; } }

		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune{ get{ return true; } }
		public override int Meat{ get{ return 19; } } // where's it hiding these? :)
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }

		public SkeletalDragonR( Serial serial ) : base( serial )
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