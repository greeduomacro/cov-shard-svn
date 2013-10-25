// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Spells.BlueMagic;

namespace Server.Mobiles 
{ 
	[CorpseName( "an ethereal warrior corpse" )] 
	public class BlueEtherealWarrior : BlueMonster 
	{ 
		public override bool InitialInnocent{ get{ return true; } }
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 7.0 ); } }
		public override Type SpellToCast{ get{ return typeof( WhiteWindSpell ); } }

		[Constructable] 
		public BlueEtherealWarrior() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "holy ethereal warrior";
			Body = 123;
			Hue = 1153;

			SetStr( 606, 805 );
			SetDex( 197, 275 );
			SetInt( 371, 470 );

			SetHits( 1352, 1471 );

			SetDamage( 18, 24 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 95 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 45, 55 );

			SetSkill( SkillName.Anatomy, 50.1, 75.0 );
			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 98.0 );
			SetSkill( SkillName.Wrestling, 97.6, 98.0 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 120;
		}

		public override int TreasureMapLevel{ get{ return Core.AOS ? 5 : 0; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Gems );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int Feathers{ get{ return 100; } }

		public override int GetAngerSound()
		{
			return 0x2F8;
		}

		public override int GetIdleSound()
		{
			return 0x2F8;
		}

		public override int GetAttackSound()
		{
			return Utility.Random( 0x2F5, 2 );
		}

		public override int GetHurtSound()
		{
			return 0x2F9;
		}

		public override int GetDeathSound()
		{
			return 0x2F7;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( Utility.RandomDouble() <= 0.02 ) // 2% chance
				c.DropItem( new AngelSnack() );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			defender.Damage( Utility.Random( 10, 10 ), this );
			defender.Stam -= Utility.Random( 10, 10 );
			defender.Mana -= Utility.Random( 10, 10 );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			attacker.Damage( Utility.Random( 10, 10 ), this );
			attacker.Stam -= Utility.Random( 10, 10 );
			attacker.Mana -= Utility.Random( 10, 10 );
		}

		public BlueEtherealWarrior( Serial serial ) : base( serial ) 
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