using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an ancient hell hound corpse" )]
	public class AncientHellHound : BaseCreature
	{
		[Constructable]
		public AncientHellHound() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.075, 0.015 )
		{
			Name = "an ancient hell hound";
			Body = 0x42D;
			BaseSoundID = 229;

			SetStr( 527, 580 );
			SetDex( 284, 322 );
			SetInt( 426, 526 );

			SetHits( 2250, 2500 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 80 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 85, 95 );
			SetResistance( ResistanceType.Cold, 52, 57 );
			SetResistance( ResistanceType.Poison, 30, 50 );
			SetResistance( ResistanceType.Energy, 40, 60 );

			SetSkill( SkillName.MagicResist, 105.1, 115.0 );
			SetSkill( SkillName.Anatomy, 105.1, 128.0 );
			SetSkill( SkillName.Tactics, 102.1, 120.0 );
			SetSkill( SkillName.Wrestling, 111.1, 119.0 );
			
			Fame = 24000;
			Karma = -24000;
			
			if ( Paragon.ChestChance > Utility.RandomDouble() )
				PackItem( new ParagonChest( Name, TreasureMapLevel ) );

			PackItem( new SulfurousAsh( 30 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich, 4 );
		}
		
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );		
			
			if ( Utility.RandomDouble() < 0.25 )
			{
				switch ( Utility.Random( 10 ) )
				{
					case 0: c.DropItem( new SorcererArms() );	break;//1		
					case 1: c.DropItem( new SorcererChest() ); break;//1
					case 2: c.DropItem( new SorcererFemaleChest() ); break;//2
					case 3: c.DropItem( new SorcererGloves() ); break;//2
					case 4: c.DropItem( new SorcererGorget() ); break;//3
					case 5: c.DropItem( new SorcererHat() ); break;//3
					case 6: c.DropItem( new SorcererLegs() ); break;//3
					case 7: c.DropItem( new SorcererSkirt() ); break;//4
					case 8: c.DropItem( new EtoileBleue() ); break;//3
					case 9: c.DropItem( new NovoBleue() ); break;//4					
				}
			}
		}
		
		#region Breath
		public override double BreathDamageScalar{ get{ return 0.13; } }
		public override int BreathRange{ get{ return 7; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }		
		//public override int BreathEffectHue{ get{ return 0x989; } }
		public override int BreathEffectSound{ get{ return 0x56D; } }		
		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 7.0; } }
		public override bool HasBreath{ get{ return true; } } 
		
		public override void BreathStart( Mobile target )
		{			
						
			this.Direction = this.GetDirectionTo( target );
			
			int count = 0;
			
			foreach ( Mobile m in GetMobilesInRange( BreathRange ) )
			{
				if ( count++ > 3 )
					break;
					
				if ( m != null && m != target && m.Alive && !m.IsDeadBondedPet && CanBeHarmful( m ) && m.Map == this.Map && !IsDeadBondedPet && !(m is SpawnedHellHound) && m.InRange( this, BreathRange ) && InLOS( m ) && !BardPacified )
					Timer.DelayCall( TimeSpan.FromSeconds( BreathEffectDelay ), new TimerStateCallback( BreathEffect_Callback ), m );
			}
			Timer.DelayCall( TimeSpan.FromSeconds( BreathEffectDelay ), new TimerStateCallback( BreathEffect_Callback ), target );
		}
		#endregion

		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override int TreasureMapLevel { get { return 5; } }
		public override int Meat { get { return 10; } }
		public override int Hides { get { return 20; } }
		public override HideType HideType { get { return HideType.Horned; } }
		
		public override void OnDamagedBySpell( Mobile caster )
		{
			if ( caster != this && 0.10 > Utility.RandomDouble() )
			{
				BaseCreature wolf = new SpawnedHellHound( );

				wolf.Team = this.Team;
				wolf.MoveToWorld( this.Location, this.Map );
				wolf.Combatant = caster;

				Say( "*The ancient hound summons another beast!*"  ); 
			}

			base.OnDamagedBySpell( caster );
		}
		public override void OnGotMeleeAttack( Mobile attacker )
		{
			if ( attacker != this && 0.10 > Utility.RandomDouble() )
			{
				BaseCreature wolf = new SpawnedHellHound();

				wolf.Team = this.Team;
				wolf.MoveToWorld( this.Location, this.Map );
				wolf.Combatant = attacker;

				Say( "*The ancient hound summons another beast!*" ); 
			}

			base.OnGotMeleeAttack( attacker );
		}

		public AncientHellHound( Serial serial ) : base( serial )
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
