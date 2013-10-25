// Created by Peoharen
using System;
using System.Collections;
using Server;
using Server.Misc;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a mindflayer's corpse" )]
	public class BlueMindflayer : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 12.0 ); } }
		public override Type SpellToCast{ get{ return typeof( MindBlastSpell ); } }

		private bool m_Grappling;
		private Mobile m_GrappledFoe;
		private int m_GrappleCount;

		[Constructable]
		public BlueMindflayer() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mindflayer";

			if ( Core.SA )
				Body = 721;
			else
				Body = 772;

			Hue = 991;
			NameHue = 991;

			SetStr( 436, 525 );
			SetDex( 166, 185 );
			SetInt( 586, 675 );

			SetHits( 2350, 2403 );

			SetDamage( 16, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 35, 45 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 150.5, 200.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 44;

			m_Grappling = false;
			m_GrappledFoe = null;
			m_GrappleCount = 0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.HighScrolls, 2 );
		}


		public override int GetHurtSound()
		{
			return 0x167;
		}

		public override int GetDeathSound()
		{
			return 0xBC;
		}

		public override int GetAttackSound()
		{
			return 0x28B;
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( m_Grappling == false && Utility.Random( 10 ) == 1 )
			{
				to.CantWalk = true;
				m_GrappledFoe = to;
				m_Grappling = true;
				m_GrappleCount++;
				to.SendMessage( "The mindflayer's tentacles latch onto you!" );
			}
			else if ( m_Grappling == true )
			{
				if ( to == m_GrappledFoe )
				{
					m_GrappleCount++;

					switch ( Utility.Random( 4 ) )
					{
						case 0: to.SendMessage( "Another one of the mindflayer's tentacles latch onto you!" ); break;
						case 1: to.SendMessage( "The mindflayer wraps a tentacle around your neck" ); break;
						case 2: to.SendMessage( "You feel the mindflayer's foul breath as it inches it's way closer to your head." ); break;
						case 3: to.SendMessage( "One of the mindflayer's tentacle lashes out and grabs you" ); break;
					}
				}
				else
				{
					if ( m_GrappledFoe != null )
						m_GrappledFoe.CantWalk = false;

					m_GrappledFoe = null;
					m_Grappling = false;
					m_GrappleCount = 0;
				}
			}

			if ( m_GrappleCount >= 5 && to == m_GrappledFoe )
			{
				to.SendMessage( "The mindflayer has extracted your brain!" );
				to.CantWalk = false;
				to.Kill();
				Hits += 1000;
				Mana += 1000;
				m_GrappledFoe = null;
				m_Grappling = false;
				m_GrappleCount = 0;
			}
		}


		public override bool OnBeforeDeath()
		{
			if ( m_GrappledFoe != null )
				m_GrappledFoe.CantWalk = false;

			return base.OnBeforeDeath();
		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 5 : 4; } }

		public BlueMindflayer( Serial serial ) : base( serial )
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

			m_Grappling = false;
			m_GrappledFoe = null;
			m_GrappleCount = 0;
		}
	}
}