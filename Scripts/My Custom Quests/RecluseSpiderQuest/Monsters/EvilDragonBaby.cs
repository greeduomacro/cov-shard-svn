using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an evil dragon baby corpse" )]
	public class EvilDragonBaby : BaseCreature
	{
        [Constructable]
        public EvilDragonBaby()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "an evil dragon baby";
            Body = 52;
            Hue = 1164;
            BaseSoundID = 0xDB;

            SetStr(401, 430);
            SetDex(133, 152);
            SetInt(101, 140);

            SetHits(441, 458);

            SetDamage(11, 17);

            SetDamageType(ResistanceType.Physical, 80);
            SetDamageType(ResistanceType.Fire, 20);

            SetResistance(ResistanceType.Physical, 45, 50);
            SetResistance(ResistanceType.Fire, 50, 60);
            SetResistance(ResistanceType.Cold, 40, 50);
            SetResistance(ResistanceType.Poison, 20, 30);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 65.1, 90.0);
            SetSkill(SkillName.Wrestling, 65.1, 80.0);
            SetSkill(SkillName.Magery, 5.1, 10.0);
            SetSkill(SkillName.EvalInt, 5.1, 10.0);

            Fame = 300;
            Karma = -300;

            VirtualArmor = 20;

            Tamable = false;
            ControlSlots = 3;
            MinTameSkill = 96.1;

            PackItem(new DragonFlesh());

        }
		
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Greater; } }

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public EvilDragonBaby(Serial serial) : base(serial)
		{
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