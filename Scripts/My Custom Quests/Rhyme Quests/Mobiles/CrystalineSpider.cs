//Scripted by Raven's Keeper
using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a crystaline spider corpse")]
	public class CrystalineSpider : BaseCreature
	{
		[Constructable]
		public CrystalineSpider() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a crystaline spider spawn";
			Body = 20;
            Hue = 1266;
			BaseSoundID = 0x388;

			SetStr( 150, 200 );
			SetDex( 150, 200 );
			SetInt( 75, 100 );

			SetHits( 80, 125 );
			SetMana( 200 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );
            

			SetResistance( ResistanceType.Physical, 75, 85 );
			SetResistance( ResistanceType.Fire, 50, 75 );
			SetResistance( ResistanceType.Cold, 85, 95 );
			SetResistance( ResistanceType.Poison, 95, 100 );
			SetResistance( ResistanceType.Energy, 50, 75 );

            SetSkill(SkillName.EvalInt, 70.3, 100.0);
            SetSkill(SkillName.Magery, 70.3, 100.0);
            SetSkill(SkillName.Poisoning, 60.1, 80.0);
            SetSkill(SkillName.MagicResist, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

			Fame = 1750;
			Karma = -1750;

			VirtualArmor = 65; 

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 95;

			PackItem( new SpidersSilk( 25 ) );
            if (0.50 > Utility.RandomDouble())
                PackItem(new Whey());
            
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 1 );
			AddLoot(LootPack.FilthyRich, 1);
            AddLoot(LootPack.Gems, 10);
		}

        public override Poison PoisonImmune { get { return Poison.Deadly; } }
        public override Poison HitPoison { get { return Poison.Deadly; } }
        public override double HitPoisonChance { get { return 0.4; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
        public override int TreasureMapLevel { get { return 2; } }

        public CrystalineSpider(Serial serial)
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

			if ( BaseSoundID == 387 )
				BaseSoundID = 0x388;
		}
	}
}