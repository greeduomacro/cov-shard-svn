/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a leaping lord corpse" )]
	[TypeAlias( "Server.Mobiles.Gianttoad" )]
	public class LeapingLord : BaseCreature
	{
        [Constructable]
        public LeapingLord()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "A Lord Of Leaping";
            Body = 80;
            BaseSoundID = 0x26B;
            Hue = 2222;

            SetStr(576, 600);
            SetDex(316, 325);
            SetInt(311, 320);

            SetHits(746, 860);
            SetMana(800);

            SetDamage(15, 27);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 25);
            SetResistance(ResistanceType.Fire, 5, 10);
            SetResistance(ResistanceType.Energy, 5, 10);

            SetSkill(SkillName.MagicResist, 25.1, 40.0);
            SetSkill(SkillName.Tactics, 40.1, 60.0);
            SetSkill(SkillName.Wrestling, 40.1, 60.0);

            Fame = 750;
            Karma = -750;

            VirtualArmor = 50;
        }

            public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
            if (m_Spawning)
            {
                PackItem(new LeapingLordStatue());
            }

		}


		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

        public LeapingLord(Serial serial)
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