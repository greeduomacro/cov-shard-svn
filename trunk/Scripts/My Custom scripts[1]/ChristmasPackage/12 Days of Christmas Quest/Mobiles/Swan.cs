/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a swan corpse" )]
	public class Swan : BaseCreature
	{
        [Constructable]
        public Swan()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "A Swan";
            Body = 254;
            BaseSoundID = 0x4D7;
            Hue = 1150;

            SetStr(226, 235);
            SetDex(116, 125);
            SetInt(211, 215);

            SetHits(26, 35);
            SetMana(0);

            SetDamage(20, 30);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 85, 95);

            SetSkill(SkillName.MagicResist, 104.1, 105.0);
            SetSkill(SkillName.Tactics, 70.1, 81.0);
            SetSkill(SkillName.Wrestling, 80.1, 91.0);

            Fame = 0;
            Karma = 200;

            VirtualArmor = 35;
        }
            		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
                        if (m_Spawning)
            {
                PackItem(new SwimmingCap());
            }
		}

		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }


		public override int GetAngerSound()
		{
			return 0x4D9;
		}

		public override int GetIdleSound()
		{
			return 0x4D8;
		}

		public override int GetAttackSound()
		{
			return 0x4D7;
		}

		public override int GetHurtSound()
		{
			return 0x4DA;
		}

		public override int GetDeathSound()
		{
			return 0x4D6;
		}

        public Swan(Serial serial)
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