// Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Spells.Seventh; // Polymorph
using Server.Spells.Fifth; // Incognito
using Server.Spells.Ninjitsu; //AnimalForm

namespace Server.Mobiles
{
	[CorpseName( "a mongbat corpse" )]
	public class BlueMongbat : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 5.0 ); } }
		public override Type SpellToCast{ get{ return typeof( SwitchSpell ); } }

		[Constructable]
		public BlueMongbat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mongbat";
			Body = 39;
			BaseSoundID = 422;

			SetStr( 6, 10 );
			SetDex( 76, 88 );
			SetInt( 6, 14 );

			SetHits( 250, 500 );
			SetMana( 0 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 10 );

			SetSkill( SkillName.MagicResist, 5.1, 14.0 );
			SetSkill( SkillName.Tactics, 50.1, 100.0 );
			SetSkill( SkillName.Wrestling, 50.1, 100.0 );

			Fame = 150;
			Karma = -150;

			VirtualArmor = 10;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.BleedAttack : WeaponAbility.MortalStrike;
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			Polymorph( defender );
		}

		public void Polymorph( Mobile m )
		{
			if ( !m.CanBeginAction( typeof( PolymorphSpell ) ) || !m.CanBeginAction( typeof( IncognitoSpell ) ) || m.IsBodyMod )
				return;

			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( m.Mounted )
				return;

			if ( m.BeginAction( typeof( PolymorphSpell ) ) )
			{
				Item disarm = m.FindItemOnLayer( Layer.OneHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				disarm = m.FindItemOnLayer( Layer.TwoHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				m.BodyMod = 39;
				m.HueMod = 0;

				new ExpirePolymorphTimer( m ).Start();
			}
		}

		private class ExpirePolymorphTimer : Timer
		{
			private Mobile m_Owner;

			public ExpirePolymorphTimer( Mobile owner ) : base( TimeSpan.FromMinutes( 3.0 ) )
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );
				}
			}
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public BlueMongbat( Serial serial ) : base( serial )
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