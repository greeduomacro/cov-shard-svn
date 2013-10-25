/*
 * User: Masternightmage
 * Date: 10/16/2005
 * Time: 8:11 PM
 *
 * Please do not remove header or try and claim this script as your own!
 * This is a cutom quest and the first quest I have ever made so leave it as it is do not mod these files!
 *
 */
using System;
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an fallen angel corpse" )] 
	public class AngelOfHeaven : BaseCreature 
	{ 
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable] 
		public AngelOfHeaven() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Angel Of Heaven";
			Body = 123;
			Hue = 1153;

			SetStr( 386, 485 );
			SetDex( 177, 255 );
			SetInt( 351, 450 );

			SetHits( 10000, 15000 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 50.1, 75.0 );
			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 97.6, 100.0 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 85;
			
			PackItem( new AngelFeather( 5 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Gems );
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

		public AngelOfHeaven( Serial serial ) : base( serial ) 
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
