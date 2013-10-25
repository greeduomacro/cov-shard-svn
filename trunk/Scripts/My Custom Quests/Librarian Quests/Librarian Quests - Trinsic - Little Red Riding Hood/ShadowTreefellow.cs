using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Shadow Treefellow corpse" )]
	public class ShadowTreefellow : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		[Constructable]
		public ShadowTreefellow() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Shadow Treefellow";
			Body = 301;
			Hue = 1104;

			SetStr( 300, 400 );
			SetDex( 100, 150 );
			SetInt( 100, 150 );

			SetHits( 400, 500 );

			SetDamage( 22, 30 );

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


				
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
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

		public ShadowTreefellow( Serial serial ) : base( serial )
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