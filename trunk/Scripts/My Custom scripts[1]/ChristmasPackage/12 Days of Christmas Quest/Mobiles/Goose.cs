/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a goose corpse" )]
	public class Goose : BaseCreature
	{
		[Constructable]
		public Goose() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a Goose";
			Body = 0xD0;
            Hue = 1154;

            SetStr(200, 350);
            SetDex(100, 250);
            SetInt(400, 500);

            SetHits(700, 850);

            SetDamage(25, 40);

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 75 );

			SetSkill( SkillName.MagicResist, 84.0 );
			SetSkill( SkillName.Tactics, 95.0 );
			SetSkill( SkillName.Wrestling, 105.0 );

			Fame = 150;
			Karma = 0;

			VirtualArmor = 40;
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            if (m_Spawning)
            {
                PackItem(new GooseEggs());
            }
        }

		public override int Meat{ get{ return 1; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

		public override int Feathers{ get{ return 25; } }

        public Goose(Serial serial)
            : base(serial)
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