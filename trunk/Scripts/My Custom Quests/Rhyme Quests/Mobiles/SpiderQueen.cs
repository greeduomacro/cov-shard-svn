using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "the Spider Queen's corpse" )]
	public class SpiderQueen : BaseCreature
	{
		[Constructable]
        public SpiderQueen() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Body = 173;
            Hue = 1284;
			Name = "Spider Queen";

			BaseSoundID = 0x183;

			SetStr( 505, 1000 );
			SetDex( 102, 300 );
			SetInt( 402, 600 );

			SetHits( 1000 );
			SetStam( 105, 600 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.MagicResist, 70.7, 140.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 97.6, 100.0 );

			Fame = 22500;
			Karma = -22500;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 4 );
            switch (Utility.Random(50))
            {
                case 0: PackItem(new RewardSpiderMask()); break;

                case 1: PackItem(new RewardBowlofWhey()); break;
                case 2: PackItem(new RewardCrystalineSpider()); break;
            }
		}
        public override int TreasureMapLevel{ get{ return 4; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override Poison HitPoison { get { return Poison.Deadly; } }
        public override double HitPoisonChance { get { return 0.3; } }

		
        public SpiderQueen(Serial serial)
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;
		}
	}
}