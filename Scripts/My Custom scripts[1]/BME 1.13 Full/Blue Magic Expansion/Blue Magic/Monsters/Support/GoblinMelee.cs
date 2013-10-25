//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class BlueGoblinMelee : BaseCreature
	{
		private static FightMode GetRandomFightMode()
		{
			switch( Utility.Random( 3 ) )
			{
				default: return FightMode.Closest;
				case 0: return FightMode.Strongest;
				case 1: return FightMode.Weakest;
			}
		}

		[Constructable]
		public BlueGoblinMelee() : base( AIType.AI_Melee, GetRandomFightMode(), 10, 1, 0.2, 0.4 )
		{
			Name = "a goblin";
			Body = 334;
			BaseSoundID = 0x45A;

			SetStr( 80, 100 );
			SetDex( 50, 60 );
			SetInt( 50, 60 );

			SetHits( 200, 225 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Cold, 40 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 35, 45 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.MagicResist, 40.1, 50.0 );
			SetSkill( SkillName.Tactics, 70.1, 80.0 );
			SetSkill( SkillName.Wrestling, 70.1, 80.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 25;
		}

		public override PackInstinct PackInstinct { get { return PackInstinct.Daemon; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor, 3 );
		}

		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
				damage /= 2;
		}

		public override void AlterSpellDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature )
				damage *= 2;
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
				damage /= 2;
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature )
				damage *= 2;
		}

		public BlueGoblinMelee( Serial serial ) : base( serial )
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
