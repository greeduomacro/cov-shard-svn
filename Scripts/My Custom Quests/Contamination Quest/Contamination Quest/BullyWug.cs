using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a BullyWug Mucker corpse" )]
	[TypeAlias( "Server.Mobiles.Bullfrog" )]
	public class BullyWug : BaseCreature
	{
		[Constructable]
		public BullyWug() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Bullywug Croaker ";
			Body = 81;
			Hue = 138;
			BaseSoundID = 0x266;

            SetStr(536, 585);
            SetDex(196, 215);
            SetInt(31, 55);

            SetHits(1448, 1470);

            SetDamage(15, 25);

            SetDamageType(ResistanceType.Physical, 75);
            SetDamageType(ResistanceType.Cold, 25);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 75, 80);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 65, 75);
            SetResistance(ResistanceType.Poison, 80, 100);
            SetResistance(ResistanceType.Energy, 80, 100);

            SetSkill(SkillName.MagicResist, 105.0);
            SetSkill(SkillName.Tactics, 80.1, 100.0);
            SetSkill(SkillName.Wrestling, 180.1, 190.0);
            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 50;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 4; } }
		//public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
        public override bool AlwaysMurderer { get { return true; } }

		public BullyWug(Serial serial) : base(serial)
		{
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.3)
                c.DropItem(new LilyPad1());
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

	[CorpseName( "a BullyWug Mucker corpse" )]
	public class BullyWug1 : BaseCreature
	{
		[Constructable]
		public BullyWug1() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Bullywug Mucker ";
			Body = 81;
			Hue = 1717;
			BaseSoundID = 0x266;

            SetStr(536, 585);
            SetDex(196, 215);
            SetInt(31, 55);

            SetHits(2502, 2531);
            SetMana(0);

            SetDamage(17, 23);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 75, 80);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 65, 75);
            SetResistance(ResistanceType.Poison, 80, 100);
            SetResistance(ResistanceType.Energy, 80, 100);

            SetSkill(SkillName.MagicResist, 105.0);
            SetSkill(SkillName.Tactics, 80.1, 100.0);
            SetSkill(SkillName.Wrestling, 180.1, 190.0);

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 68;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 4; } }
		//public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
        public override bool AlwaysMurderer { get { return true; } }

		public BullyWug1(Serial serial) : base(serial)
		{
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.3)
                c.DropItem(new LilyPad2());
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

    [CorpseName("a BullyWug Twitcher corpse")]
    public class BullyWug2 : BaseCreature
    {
        [Constructable]
        public BullyWug2()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a Bullywug Twitcher ";
            Body = 81;
            Hue = 1196;
            BaseSoundID = 0x266;

            SetStr(536, 585);
            SetDex(196, 215);
            SetInt(331, 355);

            SetHits(3860, 3895);

            SetDamage(15, 27);

            SetDamageType(ResistanceType.Physical, 20);
            SetDamageType(ResistanceType.Cold, 40);
            SetDamageType(ResistanceType.Energy, 40);

            SetResistance(ResistanceType.Physical, 75, 80);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 65, 75);
            SetResistance(ResistanceType.Poison, 80, 100);
            SetResistance(ResistanceType.Energy, 80, 100);

            SetSkill(SkillName.EvalInt, 120.1, 130.0);
            SetSkill(SkillName.Magery, 120.1, 130.0);
            SetSkill(SkillName.Meditation, 100.1, 101.0);
            SetSkill(SkillName.Poisoning, 100.1, 101.0);
            SetSkill(SkillName.MagicResist, 175.2, 200.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 75.1, 100.0);

            Fame = 23000;
            Karma = -23000;

            VirtualArmor = 75;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public override int Meat { get { return 1; } }
        public override int Hides { get { return 4; } }
        //public override FoodType FavoriteFood { get { return FoodType.Fish | FoodType.Meat; } }
        public override bool AlwaysMurderer { get { return true; } }

        public BullyWug2(Serial serial)
            : base(serial)
        {
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.3)
                c.DropItem(new LilyPad3());
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
    }

 