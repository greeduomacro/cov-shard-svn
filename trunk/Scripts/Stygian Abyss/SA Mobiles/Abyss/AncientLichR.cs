using System;
using Server;
using Server.Items;
using Server.Targeting;
using System.Collections;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a renowned ancient liche's corpse" )]
	public class AncientLichR : BaseCreature
	{
		[Constructable]
		public AncientLichR() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Ancient Lich( Renowned )";
			Body = 78;
			BaseSoundID = 412;

			SetStr( 299, 325 );
			SetDex( 113, 115 );
			SetInt( 1010, 1045 );

			SetHits( 6240, 6300 );

			SetDamage( 15, 27 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 60, 65 );
			SetResistance( ResistanceType.Energy, 25, 30 );

			SetSkill( SkillName.EvalInt, 125.1, 130.0 );
			SetSkill( SkillName.Magery, 125.1, 130.0 );
			SetSkill( SkillName.Meditation, 100.1, 102.0 );
			SetSkill( SkillName.Poisoning, 100.1, 101.0 );
			SetSkill( SkillName.MagicResist, 185.2, 200.0 );
			SetSkill( SkillName.Tactics, 91.1, 95.5 );
			SetSkill( SkillName.Wrestling, 98.5, 100.0 );

			Fame = 23000;
			Karma = -23000;

			VirtualArmor = 60;
			PackNecroReg( 30, 275 );
			
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound()
		{
			return 0x19D;
		}

		public override int GetAngerSound()
		{
			return 0x175;
		}

		public override int GetDeathSound()
		{
			return 0x108;
		}

		public override int GetAttackSound()
		{
			return 0xE2;
		}

		public override int GetHurtSound()
		{
			return 0x28B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            c.DropItem(new UndyingFlesh());

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new EssenceDirection()); break;

                    case 1: c.DropItem(new BlueDiamond(1)); break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
            {
               
                    c.DropItem(new SpinedBloodwormBracers());
            }   
        }

        public override bool GivesSAArtifact { get { return true; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public AncientLichR( Serial serial ) : base( serial )
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