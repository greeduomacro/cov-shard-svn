using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Baby Bear's corpse" )]
	public class BabyBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		[Constructable]
		public BabyBear() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Baby Bear";
			Body = 167;
			Hue = 0;
			BaseSoundID = 0xA3;

			SetStr( 1000, 1200 );
			SetDex( 200, 250 );
			SetInt( 100, 150 );

			SetHits( 1000, 1200 );

			SetDamage( 40, 45 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 50, 60 );

			SetSkill( SkillName.MagicResist, 55.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 105.0 );
			SetSkill( SkillName.Wrestling, 85.1, 105.0 );

			Fame = 500;
			Karma = -1500;

			VirtualArmor = 65;
		

			 PackMagicItems( 2, 5 );
			 switch ( Utility.Random( 3 ))
				 { 
					case 0: PackItem( new PillowJustRight() ); break;
					case 1: PackItem( new PillowSoft() ); break;
					case 2: PackItem( new PillowHard() ); break;
				 }

				
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
		}

	

		public BabyBear( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 442 )
				BaseSoundID = -1;
		}
	}
}