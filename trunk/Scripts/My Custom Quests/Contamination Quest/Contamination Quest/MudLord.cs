using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Mud Lord corpse" )]
	[TypeAlias( "Server.Mobiles.Gianttoad" )]
	public class MudLord : BaseCreature
	{
		[Constructable]
		public MudLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Mud Lord";
			Body = 80;
            Hue = 2963;
			BaseSoundID = 0x26B;

            SetStr(600, 650);
            SetDex(210, 250);
            SetInt(310, 330);

            SetHits(18000, 18500);

            SetDamage(25, 35);

            SetDamageType(ResistanceType.Physical, 60);
            //SetDamageType(ResistanceType.Cold, 40);
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

            VirtualArmor = 85;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
        public override bool AlwaysMurderer { get { return true; } }
		

		public MudLord(Serial serial) : base(serial)
		{
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.75)
                c.DropItem(new LilyPad4());
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