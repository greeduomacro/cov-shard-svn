using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a golem corpse" )]
	public class IronGolem : BaseCreature
	{
		[Constructable]
		public IronGolem() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "an iron golem";
			Body = 766;
			Hue = 2101;

			// +75 Stats
			SetStr( 326, 425 ); // Golem 251~350
			SetDex( 151, 175 ); // Golem 76~100
			SetInt( 176, 225 ); // Golem 101~150

			// +200HP
			SetHits( 351, 410 ); // Golem 151~210

			// +5 Damage
			SetDamage( 18, 29 ); // Golem 13~24

			SetDamageType( ResistanceType.Physical, 100 );

			// +15 Resists.
			SetResistance( ResistanceType.Physical, 50, 70 ); // Golem 35~55
			SetResistance( ResistanceType.Fire, 65, 75 ); // Golem 50~60
			SetResistance( ResistanceType.Cold, 35, 30 ); // Golem 10~30
			SetResistance( ResistanceType.Poison, 35, 40 ); // Golem 10~25
			SetResistance( ResistanceType.Energy, 45, 50 ); // Golem 30~40

			// +30 Min to Starting Skills.
			SetSkill( SkillName.MagicResist, 150.1, 190.0 ); // Golem 150.1~190.0
			SetSkill( SkillName.Tactics, 90.1, 100.0 ); // Golem 60.1~100.0
			SetSkill( SkillName.Wrestling, 90.1, 100.0 ); // Golem 60.1~100.0
			SetSkill( SkillName.Swords, 90.1, 100.0 );
			SetSkill( SkillName.Macing, 90.1, 100.0 );
			SetSkill( SkillName.Fencing, 90.1, 100.0 );

			Fame = 10;
			Karma = 10;

			ControlSlots = 3;
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			from.Damage( amount / 4, this );
			base.OnDamage( amount, from, willKill );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( ControlMaster == null || !(from == ControlMaster) )
				return;

			if ( from.InRange( this, 2 ) )
				new GolemHealTimer( this, from, 5 ).Start();
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

		public IronGolem( Serial serial ) : base( serial )
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