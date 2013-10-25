//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a goblin corpse" )]
	public class BlueGoblinCaster : BaseCreature
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
		public BlueGoblinCaster() : base( AIType.AI_Mage, GetRandomFightMode(), 10, 1, 0.2, 0.4 )
		{
			Name = "a goblin";
			Body = 334;
			BaseSoundID = 0x45A;

			SetStr( 50, 60 );
			SetDex( 50, 60 );
			SetInt( 80, 100 );

			SetHits( 175, 200 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Cold, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 35, 45 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.EvalInt, 60.1, 80.0 );
			SetSkill( SkillName.Magery, 60.1, 80.0 );
			SetSkill( SkillName.MagicResist, 60.1, 70.0 );
			SetSkill( SkillName.Tactics, 50.1, 60.0 );
			SetSkill( SkillName.Wrestling, 50.1, 60.0 );

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

		public BlueGoblinCaster( Serial serial ) : base( serial )
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
