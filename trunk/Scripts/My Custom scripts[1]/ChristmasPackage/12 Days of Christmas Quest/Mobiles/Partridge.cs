/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a partridge corpse" )]
	public class Partridge : BaseCreature
	{
        [Constructable]
        public Partridge()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "A Partridge";
            Body = 6;
            BaseSoundID = 0x1B;
            Hue = 2419;


            SetStr(210, 250);
            SetDex(125, 135);
            SetInt(310, 350);

            SetDamage(20, 35);
            SetHits(800, 950);

            SetDamageType(ResistanceType.Physical, 100);

            SetSkill(SkillName.Wrestling, 94.2, 106.4);
            SetSkill(SkillName.Tactics, 74.0, 86.0);
            SetSkill(SkillName.MagicResist, 74.0, 85.0);

            SetFameLevel(1);
            SetKarmaLevel(0);

            Tamable = false;
        }
            public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            if (m_Spawning)
            {
                PackItem(new PearBranch());
            }

		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }


        public Partridge(Serial serial)
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
		} 
	}
}
	

	
