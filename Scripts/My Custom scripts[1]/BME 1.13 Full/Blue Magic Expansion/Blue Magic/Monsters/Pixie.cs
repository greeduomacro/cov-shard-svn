using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a pixie corpse" )]
	public class BluePixie : BlueMonster
	{
		public override bool InitialInnocent{ get{ return true; } }
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 7.0 ); } }
		public override Type SpellToCast{ get{ return typeof( Level4HolySpell ); } }

		[Constructable]
		public BluePixie() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "holy pixie";
			Body = 128;
			Hue = 1153;
			BaseSoundID = 0x467;

			SetStr( 41, 50 );
			SetDex( 321, 420 );
			SetInt( 221, 270 );

			SetHits( 113, 118 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 95 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 45, 55 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 60.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 62.5 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 100;

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();				
		}
		
		#region Mondain's Legacy
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( Utility.RandomDouble() < 0.3 )
				c.DropItem( new PixieLeg() );

			if ( Utility.RandomDouble() <= 0.01 ) // 1% chance
				c.DropItem( new AngelSnack() );
		}
			#endregion

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Gems, 2 );
		}

		public override HideType HideType{ get{ return HideType.Spined; } }
		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public BluePixie( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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