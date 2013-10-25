
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an Evil Crow's corpse" )]
	public class EvilCrow : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}
		[Constructable]
		public EvilCrow() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "An Evil Crow";
			Body = 5;
			Hue = 2019; 
			BaseSoundID = 0x7F;

			SetStr( 134, 139 );
			SetDex( 423, 428 );
			SetInt( 79, 84 );

			SetHits( 1900, 2000 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 65, 70 );
			SetResistance( ResistanceType.Fire, 40, 45 );
			SetResistance( ResistanceType.Cold, 38, 43 );
			SetResistance( ResistanceType.Poison, 21, 26 );
			SetResistance( ResistanceType.Energy, 40, 45 );

			SetSkill( SkillName.MagicResist, 89.1, 99.1 );
			SetSkill( SkillName.Tactics, 87.1, 97.8 );
			SetSkill( SkillName.Wrestling, 80.1, 90.2 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 65;

            PackItem(new ScarecrowBrain());

        }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );			
		}

		public override int Meat { get { return 1; } }
		public override MeatType MeatType { get { return MeatType.Bird; } }
		public override int Feathers { get { return 10; } }

		public EvilCrow( Serial serial ) : base( serial )
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
