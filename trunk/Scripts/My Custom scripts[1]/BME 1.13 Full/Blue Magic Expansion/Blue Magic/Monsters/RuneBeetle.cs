// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a rune beetle corpse" )]
	public class BlueRuneBeetle : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 30.0 ); } }
		public override Type SpellToCast{ get{ return typeof( GuardOffSpell ); } }
		public override bool DontCast{ get{ return true; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public BlueRuneBeetle() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a rune beetle";
			Body = 244;

			SetStr( 421, 480 );
			SetDex( 141, 190 );
			SetInt( 396, 470 );

			SetHits( 401, 460 );

			SetDamage( 20, 27 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 10 );
			SetDamageType( ResistanceType.Energy, 70 );

			SetResistance( ResistanceType.Physical, 45, 70 );
			SetResistance( ResistanceType.Fire, 40, 55 );
			SetResistance( ResistanceType.Cold, 40, 55 );
			SetResistance( ResistanceType.Poison, 80, 100 );
			SetResistance( ResistanceType.Energy, 45, 65 );

			SetSkill( SkillName.EvalInt, 100.1, 125.0 );
			SetSkill( SkillName.Magery, 100.1, 110.0 );
			SetSkill( SkillName.Poisoning, 120.1, 140.0 );
			SetSkill( SkillName.MagicResist, 95.1, 110.0 );
			SetSkill( SkillName.Tactics, 78.1, 93.0 );
			SetSkill( SkillName.Wrestling, 70.1, 77.5 );

			Fame = 15000;
			Karma = -15000;

			if ( Utility.RandomDouble() < .25 )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new BonePile() ); break;
			}

			IsParagon = Utility.RandomDouble() > 0.50; // 50% chance to spawn as a Paragon.
		}

		public override int GetAngerSound()
		{
			return 0x4E8;
		}

		public override int GetIdleSound()
		{
			return 0x4E7;
		}

		public override int GetAttackSound()
		{
			return 0x4E6;
		}

		public override int GetHurtSound()
		{
			return 0x4E9;
		}

		public override int GetDeathSound()
		{
			return 0x4E5;
		}
		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 1 );
		}

		/*// Acid pool breath attack if not a Paragon
		public override bool HasBreath { get { return !IsParagon; } }
		public override int BreathEffectHue { get { return 1459; } }
		public override bool BreathImmune { get { return true; } }

		public override void BreathDealDamage( Mobile target )
		{
			SpillAcid( target, 3 );
		}
		// Kinda mean right?*/

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return Poison.Greater; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.25 > Utility.RandomDouble() )
			{
				DoCorruption( defender );
			}
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			base.CheckReflect( caster, ref reflect );

			if ( 0.25 > Utility.RandomDouble() )
			{
				DoCorruption( caster );
			}
		}

		public void DoCorruption( Mobile defender )
		{
			if ( defender == null )
				return;

			/* Rune Corruption
			 * Start cliloc: 1070846 "The creature magically corrupts your armor!"
			 * Effect: All resistances -70 (lowest 0) for 5 seconds
			 * End ASCII: "The corruption of your armor has worn off"
			 */

			ExpireTimer timer = (ExpireTimer)m_Table[defender];

			if ( timer != null )
			{
				timer.DoExpire();
				defender.SendLocalizedMessage( 1070845 ); // The creature continues to corrupt your armor!
			}
			else
				defender.SendLocalizedMessage( 1070846 ); // The creature magically corrupts your armor!

			List<ResistanceMod> mods = new List<ResistanceMod>();

			if ( defender.PhysicalResistance > 0 )
				mods.Add( new ResistanceMod( ResistanceType.Physical, -120 ) );

			if ( defender.FireResistance > 0 )
				mods.Add( new ResistanceMod( ResistanceType.Fire, -120 ) );

			if ( defender.ColdResistance > 0 )
				mods.Add( new ResistanceMod( ResistanceType.Cold, -120 ) );

			if ( defender.PoisonResistance > 0 )
				mods.Add( new ResistanceMod( ResistanceType.Poison, -120 ) );

			if ( defender.EnergyResistance > 0 )
				mods.Add( new ResistanceMod( ResistanceType.Energy, -120 ) );

			for ( int i = 0; i < mods.Count; ++i )
					defender.AddResistanceMod( mods[i] );

			defender.FixedEffect( 0x37B9, 10, 5 );

			timer = new ExpireTimer( defender, mods, TimeSpan.FromSeconds( 25.0 ) );
			timer.Start();
			m_Table[defender] = timer;
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private List<ResistanceMod> m_Mods;

			public ExpireTimer( Mobile m, List<ResistanceMod> mods, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mods;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				for ( int i = 0; i < m_Mods.Count; ++i )
					m_Mobile.RemoveResistanceMod( m_Mods[i] );

				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendMessage( "The corruption of your armor has worn off" );
				DoExpire();
			}
		}

		public BlueRuneBeetle( Serial serial ) : base( serial )
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