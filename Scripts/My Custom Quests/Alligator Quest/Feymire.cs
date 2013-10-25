using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Feymire corpse" )]
	public class Feymire : BaseCreature
	{
		[Constructable]
		public Feymire() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Feymire";
			Body = 0xCA;
            Hue = 2130;
			BaseSoundID = 0x5A;

            SetStr(293, 327);
            SetDex(207, 201);
            SetInt(15, 67);

            SetHits(1260, 1284);

            SetDamage(15, 25);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 63, 65);
            SetResistance(ResistanceType.Fire, 55, 59);
            SetResistance(ResistanceType.Poison, 55, 58);

            SetSkill(SkillName.Wrestling, 101.2, 118.3);
            SetSkill(SkillName.Tactics, 111.1, 117.3);
            SetSkill(SkillName.MagicResist, 102.4, 118.6);


			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 50;

			PackItem( new SulfurousAsh( Utility.Random( 4, 10 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Hides{ get{ return 1; } }
		//public override HideType HideType{ get{ return HideType.Spined; } }

		public Feymire(Serial serial) : base(serial)
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