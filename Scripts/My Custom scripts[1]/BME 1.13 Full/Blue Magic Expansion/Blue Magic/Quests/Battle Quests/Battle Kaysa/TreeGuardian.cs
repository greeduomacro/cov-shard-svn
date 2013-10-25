// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a treefellow corpse" )]
	public class BlueTreeGuardian : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 30.0 ); } }
		public override Type SpellToCast{ get{ return typeof( FiftyNeedlesSpell ); } }

		[Constructable]
		public BlueTreeGuardian() : base( AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4 )
		{
			Name = "a treefellow";
			Body = 301;
			Hue = 1436;

			SetStr( 396, 420 );
			SetDex( 51, 75 );
			SetInt( 86, 110 );

			SetHits( 318, 332 );

			SetDamage( 14, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			SetResistance( ResistanceType.Fire, 30, 35 );
			SetResistance( ResistanceType.Cold, 30, 35 );
			SetResistance( ResistanceType.Poison, 95 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 60.1, 75.0 );
			SetSkill( SkillName.Tactics, 85.1, 110.0 );
			SetSkill( SkillName.Wrestling, 85.1, 105.0 );

			Fame = 2500;
			Karma = 2500;

			VirtualArmor = 44;
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

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m is BlueKaysa || m is BlueTreeGuardian )
				return false;

			return base.IsEnemy( m );
		}

		public override bool BardImmune{ get{ return true; } }
		public override bool BleedImmune { get { return false; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public BlueTreeGuardian( Serial serial ) : base( serial )
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
