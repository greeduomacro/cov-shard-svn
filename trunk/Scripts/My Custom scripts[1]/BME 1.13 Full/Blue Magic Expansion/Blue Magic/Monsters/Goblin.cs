using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a goblin corpse" )]
	public class BlueGoblin : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 2.0 ); } }
		public override Type SpellToCast{ get{ return typeof( GoblinPunchMove ); } }

		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public BlueGoblin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.2 )
		{
			Name = "a goblin";
			Body = 723;
			BaseSoundID = 0x45A;

			SetStr( 211, 245 );
			SetDex( 201, 235 );
			SetInt( 186, 210 );

			SetHits( 467, 487 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 98.1, 101.9 );
			SetSkill( SkillName.Wrestling, 80.1, 105.0 );
			SetSkill( SkillName.Tactics, 105.1, 120.0 );

			Fame = 5500;
			Karma = -5500;

			VirtualArmor = 54;

			switch ( Utility.Random( 7 ) )
			{
				case 0: PackItem( new Arrow() ); break;
				case 1: PackItem( new Lockpick() ); break;
				case 2: PackItem( new Shaft() ); break;
				case 3: PackItem( new Ribs() ); break;
				case 4: PackItem( new Bandage() ); break;
				case 5: PackItem( new BeverageBottle( BeverageType.Wine ) ); break;
				case 6: PackItem( new Jug( BeverageType.Cider ) ); break;
			}

			if ( Core.AOS )
				PackItem( Loot.RandomNecromancyReagent() );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			#region Mondain's Legacy
			if ( Utility.RandomDouble() < 0.05 )
				c.DropItem( new StoutWhip() );
			#endregion
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		private DateTime m_HealDelay;
		private DateTime m_BolaDelay;

		public override void OnThink()
		{
			if ( DateTime.Now > m_HealDelay )
				m_HealDelay = DateTime.Now + TimeSpan.FromSeconds( Ability.UseBandage( this ) );

			base.OnThink();
		}

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_BolaDelay )
			{
				Ability.TossBola( this );
				m_BolaDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 6, 24 ) );
			}

			base.OnActionCombat();
		}


		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

		public BlueGoblin( Serial serial ) : base( serial )
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