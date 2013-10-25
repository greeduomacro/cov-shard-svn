using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a treefellow guardian corpse" )]
	public class TreefellowGuardian : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		[Constructable]
		public TreefellowGuardian() : base( AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a Treefellow Guardian";
			Body = 301;

			SetStr( 500, 700 );
			SetDex( 30, 60 );
			SetInt( 400, 450 );

			SetHits( 700, 850 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Cold, 50, 55 );
			SetResistance( ResistanceType.Poison, 20, 25 );
			SetResistance( ResistanceType.Energy, 80 );

			SetSkill( SkillName.MagicResist, 120.0, 128.0 );// Unknown
			SetSkill( SkillName.Tactics, 90.0, 120.0 );// Unknown
			SetSkill( SkillName.Wrestling, 100.0, 105.0 );// Unknown

			Fame = 1000;  //Unknown
			Karma = -3000;  //Unknown

			VirtualArmor = 44;
			PackItem( new Log( Utility.RandomMinMax( 20, 35 ) ) );
            PackItem( new EagleStrikeScroll());

            if (0.05 > Utility.RandomDouble())
                PackItem(new TreefellowWood()); 

		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound()
		{
			return 443;
		}

		public override int GetDeathSound()
		{
			return 31;
		}

		public override int GetAttackSound()
		{
			return 672;
		}

		public override bool BleedImmune{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average ); //Unknown
		}

		public TreefellowGuardian( Serial serial ) : base( serial )
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
