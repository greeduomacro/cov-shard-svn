using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a golem corpse" )]
	public class FireGolem : AuraCreature
	{
		[Constructable]
		public FireGolem() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire golem";
			Body = 196;
			Hue = 1161;

			// +100 to Stats
			SetStr( 351, 450 ); // Golem 251~350
			SetDex( 176, 200 ); // Golem 76~100
			SetInt( 201, 250 ); // Golem 101~150

			// +200HP
			SetHits( 351, 510 ); // Golem 151~210

			// +2 Damage
			SetDamage( 15, 26 ); // Golem 13~24

			SetDamageType( ResistanceType.Physical, 0 ); // Golem 100
			SetDamageType( ResistanceType.Fire, 100 ); // Golem 100

			// +10 Min Resists, immune to fire, weak vs cold.
			SetResistance( ResistanceType.Physical, 45, 55 ); // Golem 35~55
			SetResistance( ResistanceType.Fire, 100 ); // Golem 50~60
			SetResistance( ResistanceType.Cold, -50 ); // Golem 10~30
			SetResistance( ResistanceType.Poison, 20, 25 ); // Golem 10~25
			SetResistance( ResistanceType.Energy, 40 ); // Golem 30~40

			// +30 Min to Starting Skills.
			SetSkill( SkillName.MagicResist, 150.1, 190.0 ); // Golem 150.1~190.0
			SetSkill( SkillName.Tactics, 90.1, 100.0 ); // Golem 60.1~100.0
			SetSkill( SkillName.Wrestling, 90.1, 100.0 ); // Golem 60.1~100.0
			SetSkill( SkillName.Macing, 90.1, 100.0 );

			Fame = 10;
			Karma = 10;

			ControlSlots = 3;

			Mace mace = new Mace();
			mace.WeaponAttributes.HitFireArea = 25;
			mace.WeaponAttributes.HitFireball = 25;
			EquipItem( mace );
			mace.Movable = false;

			MinAuraDelay = 5;
			MaxAuraDelay = 15;
			MinAuraDamage = 15;
			MaxAuraDamage = 25;
			AuraRange = 3;
			AuraType = ResistanceType.Fire;
		}

		// Deals 2d6+5 Fire Damage when hit by or hit with melee.
		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			AOS.Damage( from, this, Utility.Dice( 2, 6, 5) , 0, 100, 0, 0, 0 );
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			AOS.Damage( to, this, Utility.Dice( 2, 6, 5) , 0, 100, 0, 0, 0 );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( ControlMaster == null || !(from == ControlMaster) )
				return;

			if ( from.InRange( this, 2 ) )
				new GolemHealTimer( this, from, 6 ).Start();
			else
				from.SendLocalizedMessage( 500332 ); // I am too far away to do that.
		}

		public override void OnHeal( ref int amount, Mobile from )
		{
			if ( amount > 999 )
				amount -= 1000;
			else
			{
				amount /= 2;

				//if ( from != null )
					//from.SendLocalizedMessage( 500951 ); // You cannot heal that.
			}
		}

		public override int GetAngerSound() { return 541; }
		public override int GetIdleSound() { return 542; }
		public override int GetDeathSound() { return 545; }
		public override int GetAttackSound() { return 562; }
		public override int GetHurtSound() { return 320; }

		public override bool BardImmune{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override bool DeleteOnRelease{ get{ return true; } }
		public override FoodType FavoriteFood { get { return FoodType.None; } }
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BreathImmune { get { return true; } }

		public override bool OverrideBondingReqs()
		{
			if ( Server.Spells.BlueMagic.BlueMageControl.IsBlueMage( ControlMaster ) )
				return false;
			else if ( ControlMaster.Skills[SkillName.ItemID].Base >= 75.0 )
				return true;

			return false;
		}

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			return m.Skills[SkillName.ItemID].Base * 0.01;
		}

		public FireGolem( Serial serial ) : base( serial )
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

	public class GolemHealTimer : Timer
	{
		private BaseCreature m_Golem;
		private Mobile m_Healer;
		private int m_Count;

		public GolemHealTimer( BaseCreature golem, Mobile healer, int delay ) : base( TimeSpan.FromMilliseconds( 250.0 ), TimeSpan.FromMilliseconds( 250.0 ) )
		{
			m_Golem = golem;
			m_Healer = healer;
			m_Count = delay;

			m_Healer.SendMessage( "You begin to rebind the enchantments." );
			m_Healer.Meditating = true;
		}

		protected override void OnTick()
		{
			--m_Count;

			if ( m_Golem == null || m_Healer == null )
				Stop();
			else if ( !m_Healer.Meditating )
			{
				m_Healer.SendMessage( "You are interrupted during rebinding and fail." );
				Stop();
			}
			else if ( !m_Healer.InRange( m_Golem, 2 ) )
			{
				m_Healer.Meditating = false;
				m_Healer.SendLocalizedMessage( 500963 ); // You did not stay close enough to heal your patient!
				Stop();
			}
			else if ( m_Count < 1 )
			{
				m_Healer.Meditating = false;
				m_Golem.Heal( 1000 + ((int)m_Healer.Skills[SkillName.ItemID].Value) );
				Stop();
			}
		}
	}

}



















