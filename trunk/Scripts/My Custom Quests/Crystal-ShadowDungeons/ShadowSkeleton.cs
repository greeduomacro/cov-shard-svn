using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Shadow Skeleton's corpse" )]
	public class ShadowSkeleton : BaseCreature
	{
		[Constructable]
		public ShadowSkeleton() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Shadow Skeleton";
			Body = Utility.RandomList( 50, 56 );
			BaseSoundID = 0x48D;
            Hue = Utility.RandomList(1109,1108, 1107, 1105, 1104, 1103);


			SetStr( 80, 120 );
			SetDex( 80, 120 );
			SetInt( 30, 60 );

			SetHits( 75, 100 );

			SetDamage( 13, 17 );

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 45, 50);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 60.3, 105.0);
            SetSkill(SkillName.Tactics, 80.1, 100.0);
            SetSkill(SkillName.Wrestling, 80.1, 90.0);

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 40;

			switch ( Utility.Random( 5 ))
			{
				case 0: PackItem( new BoneArms() ); break;
				case 1: PackItem( new BoneChest() ); break;
				case 2: PackItem( new BoneGloves() ); break;
				case 3: PackItem( new BoneLegs() ); break;
				case 4: PackItem( new BoneHelm() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

		public ShadowSkeleton( Serial serial ) : base( serial )
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
