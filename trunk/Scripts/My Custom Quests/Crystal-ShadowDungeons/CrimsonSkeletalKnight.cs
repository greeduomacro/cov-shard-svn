using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("a Crimson Skeletal Knight")]
	public class CrimsonSkeletalKnight : BaseCreature
	{
		[Constructable]
        public CrimsonSkeletalKnight()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a Crimson Skeletal Knight";
			Body = 147;
            Hue = 1109;
			BaseSoundID = 451;

			SetStr( 300, 350 );
			SetDex( 100, 120 );
			SetInt( 50, 75 );

			SetHits( 200, 250 );

			SetDamage( 18, 28 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Fire, 10, 20);
            SetResistance(ResistanceType.Cold, 90, 100);
            SetResistance(ResistanceType.Poison, 50, 80);
            SetResistance(ResistanceType.Energy, 50, 80);

            SetSkill(SkillName.MagicResist, 60.3, 105.0);
            SetSkill(SkillName.Tactics, 80.1, 100.0);
            SetSkill(SkillName.Wrestling, 80.1, 90.0);

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 48;

			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new PlateArms() ); break;
				case 1: PackItem( new PlateChest() ); break;
				case 2: PackItem( new PlateGloves() ); break;
				case 3: PackItem( new PlateGorget() ); break;
				case 4: PackItem( new PlateLegs() ); break;
				case 5: PackItem( new PlateHelm() ); break;
			}

			PackItem( new Scimitar() );
			PackItem( new WoodenShield() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
		}

        public CrimsonSkeletalKnight(Serial serial)
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