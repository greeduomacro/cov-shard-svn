using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a beetle corpse" )]
	public class BlueIronBeetle : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 30.0 ); } }
		public override Type SpellToCast{ get{ return typeof( MightyGuardSpell ); } }

		[Constructable]
		public BlueIronBeetle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.2 )
		{
			Name = "Iron Beetle";
			Body = 714;
			BaseSoundID = 0x45A;

			SetStr( 100, 150 );
			SetDex( 100, 150 );
			SetInt( 100, 150 );

			SetHits( 500, 750 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			// Use Armor Ignore, a Rune Beetle, or Guard Off to damage it.
			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.MagicResist, 1000.0 );
			SetSkill( SkillName.Wrestling, 50.0 );
			SetSkill( SkillName.Tactics, 50.0 );

			Fame = 5500;
			Karma = -5500;

			VirtualArmor = 54;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 10 );
		}

		public override int GetAngerSound()
		{
			return 0x21D;
		}

		public override int GetIdleSound()
		{
			return 0x21D;
		}

		public override int GetAttackSound()
		{
			return 0x162;
		}

		public override int GetHurtSound()
		{
			return 0x163;
		}

		public override int GetDeathSound()
		{
			return 0x21D;
		}

		public override int Meat{ get{ return 1; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BreathImmune{ get{ return true; } }

		public BlueIronBeetle( Serial serial ) : base( serial )
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