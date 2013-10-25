using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gibberling corpse" )]
	public class GibberlingQueen : BaseCreature
	{
		[Constructable]
		public GibberlingQueen() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gibberling queen";
			Body = 307;
            BaseSoundID = 422;
            Hue = 1164;

			SetStr( 401, 500 );
			SetDex( 246, 465 );
			SetInt( 236, 350 );

			SetHits( 481, 540 );
			SetMana( 481, 540 );

			SetDamage( 10, 23 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 80 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 20, 25 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 110, 120 );
			SetResistance( ResistanceType.Energy, 20, 25 );

			SetSkill( SkillName.MagicResist, 90.1, 95.0 );
            SetSkill( SkillName.EvalInt, 200.0 );
			SetSkill( SkillName.Magery, 112.6, 117.5 );
			SetSkill( SkillName.Meditation, 200.0 );
            SetSkill( SkillName.Poisoning, 70.1, 100.0 );
			SetSkill( SkillName.Tactics, 70.1, 85.0 );
			SetSkill( SkillName.Wrestling, 65.1, 80.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 88;

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( new Bone( 10 ) );
			else
				PackItem( new LesserExplosionPotion() );

			PackReg( 3 );
			PackItem( new Ribs() );
			PackItem( new Bandage( 10 ) );
                        PackItem( new GibberlingHead() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
                        AddLoot( LootPack.UltraRich );
                        AddLoot( LootPack.Gems, 8 );
		}

		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
                public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

		public GibberlingQueen( Serial serial ) : base( serial )
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

		public void SpawnGibberling( Mobile m )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			Gibberling spawned = new Gibberling();

			spawned.Team = this.Team;

			bool validLocation = false;
			Point3D loc = this.Location;

			for ( int j = 0; !validLocation && j < 10; ++j )
			{
				int x = X + Utility.Random( 3 ) - 1;
				int y = Y + Utility.Random( 3 ) - 1;
				int z = map.GetAverageZ( x, y );

				if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
					loc = new Point3D( x, y, Z );
				else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
					loc = new Point3D( x, y, z );
			}

			spawned.MoveToWorld( loc, map );
			spawned.Combatant = m;
		}

		public void EatGibberling()
		{
			ArrayList toEat = new ArrayList();
  
			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m is Gibberling )
					toEat.Add( m );
			}

			if ( toEat.Count > 0 )
			{
				PlaySound( Utility.Random( 0x3B, 2 ) ); // Eat sound

				foreach ( Mobile m in toEat )
				{
					Hits += (m.Hits / 2);
					m.Delete();
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( this.Hits > (this.HitsMax / 4) )
			{
				if ( 0.25 >= Utility.RandomDouble() )
					SpawnGibberling( attacker );
			}
			else if ( 0.25 >= Utility.RandomDouble() )
			{
				EatGibberling();
			}
		}
	}
}