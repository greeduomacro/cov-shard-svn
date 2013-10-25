using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a dancing lady corpse" )]
	public class DancingLady : BaseCreature
	{
        [Constructable]
        public DancingLady()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "A Dancing Lady";
            Body = 247;
            BaseSoundID = 0x372;
            Hue = 1276;

            SetStr(301, 375);
            SetDex(201, 255);
            SetInt(21, 25);

            SetHits(351, 430);

            SetDamage(12, 17);

            SetDamageType(ResistanceType.Physical, 70);
            SetDamageType(ResistanceType.Fire, 10);
            SetDamageType(ResistanceType.Cold, 10);
            SetDamageType(ResistanceType.Poison, 10);

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Fire, 50, 70);
            SetResistance(ResistanceType.Cold, 50, 70);
            SetResistance(ResistanceType.Poison, 50, 70);
            SetResistance(ResistanceType.Energy, 40, 60);

            SetSkill(SkillName.MagicResist, 100.1, 110.0);
            SetSkill(SkillName.Tactics, 85.1, 95.0);
            SetSkill(SkillName.Wrestling, 85.1, 95.0);
            SetSkill(SkillName.Anatomy, 85.1, 95.0);

            Fame = 9000;
            Karma = -9000;

        }		
				
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
                        if (m_Spawning)
            {
                PackItem(new DancingShoes());
            }
		}
			
		public override bool Uncalmable{ get{ return true; } }

        public DancingLady(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}