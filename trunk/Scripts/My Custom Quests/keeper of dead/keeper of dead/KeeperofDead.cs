using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a keeper of the dead corpse" )] // TODO: Corpse name?
	public class KeeperofDead : BaseCreature
	{
		[Constructable]
		public KeeperofDead() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Keeper of the Dead";
			Body = 78;
			BaseSoundID = 412;
			Hue = 2969;

			SetStr( 416, 505 );
			SetDex( 156, 175 );
			SetInt( 1066, 1245 );

			SetHits( 2760, 2895 );

			SetDamage( 29, 59 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 25, 40 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 25, 40 );

			SetSkill( SkillName.EvalInt, 100.1, 120.0 );
			SetSkill( SkillName.Magery, 100.1, 120.0 );
			SetSkill( SkillName.Meditation, 100.1, 101.0 );
			SetSkill( SkillName.Poisoning, 100.1, 101.0 );
			SetSkill( SkillName.MagicResist, 100.1, 120.0 );
			SetSkill( SkillName.Tactics, 100.1, 110.0 );
			SetSkill( SkillName.Wrestling, 95.1, 100.0 );

			Fame = 23000;
			Karma = -23000;

			VirtualArmor = 80;

			PackGold( 2000, 3000 );
			PackItem( new KBow() );
			PackItem( new CloakOfTheNecromancer() );
		
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool Unprovokable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public KeeperofDead( Serial serial ) : base( serial )
		{
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.1 >= Utility.RandomDouble() ) // 1% chance to drop or throw an unholy bone
				AddInsaneDagger( defender, 0.07 );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() ) // 1% chance to drop or throw an unholy bone
				AddInsaneDagger( attacker, 0.07 );
		}
		
		public void AddInsaneDagger( Mobile target, double chanceToThrow )
		{
			if ( chanceToThrow >= Utility.RandomDouble() )
			{
				Direction = GetDirectionTo( target );
				MovingEffect( target, 0xF7E, 10, 1, true, false, 0x496, 0 );
				new DelayTimer( this, target ).Start();
			}
			else
			{
				new InsaneDagger().MoveToWorld( Location, Map );
			}
		}

		private class DelayTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_Target;

			public DelayTimer( Mobile m, Mobile target ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_Target = target;
			}

			protected override void OnTick()
			{
				if ( m_Mobile.CanBeHarmful( m_Target ) )
				{
					m_Mobile.DoHarmful( m_Target );
					AOS.Damage( m_Target, m_Mobile, Utility.RandomMinMax( 10, 20 ), 100, 0, 0, 0, 0 );
					new InsaneDagger().MoveToWorld( m_Target.Location, m_Target.Map );
				}
			}
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