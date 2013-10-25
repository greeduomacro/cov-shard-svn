using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Papa Bear's corpse" )]
	public class PapaBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		[Constructable]
		public PapaBear() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Papa Bear";
			Body = 212;
			Hue = 0;
			BaseSoundID = 0xA3;

			SetStr( 500, 800 );
			SetDex( 200, 250 );
			SetInt( 100, 150 );

			SetHits( 800, 1000 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 30, 35 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.MagicResist, 40.1, 55.0 );
			SetSkill( SkillName.Tactics, 85.1, 105.0 );
			SetSkill( SkillName.Wrestling, 85.1, 105.0 );

			Fame = 500;
			Karma = -1500;

			VirtualArmor = 50;
		
			 PackItem( new Bone( Utility.RandomMinMax( 5, 14 ) ));
	         PackMagicItems( 1, 5 );
			 switch ( Utility.Random( 3 ))
				 { 
					case 0: PackItem( new SoftChair() ); break;
					case 1: PackItem( new HardChair() ); break;
					case 2: PackItem( new JustRightChair() ); break;
				 }

				
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
		}

		

		public PapaBear( Serial serial ) : base( serial )
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