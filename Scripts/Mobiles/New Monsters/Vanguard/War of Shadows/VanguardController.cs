using System;
using Server.Misc;
using Server.Network;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class VanguardController : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }

     public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 35.0 );
     public DateTime m_NextTalk;

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && !InRange( oldLocation, 4 ) && InLOS( m ) ) // check if its time to talk + Player in range.
			{
				m_NextTalk = DateTime.Now + TalkDelay;
				switch ( Utility.Random( 5 ))		   
				{
					case 0: Say("We are Vanguard!!"); break;
					case 1: Say("You should run!!!"); break;
					case 2: Say("Alea iacta est!"); break;
					case 3: Say("Supero omnia!"); break;
					case 4: Say("Aut vincere aut mori!"); break;
				};
		
			}
		}

		[Constructable]
		public VanguardController(): base( AIType.AI_Necromage, FightMode.Closest, 10, 1, 0.2, 0.2 )
		{
			Body = 0x190;			
			Name = "a vanguard controller";
			Hue = Utility.RandomSkinHue(); 
			SpeechHue = 44;

			SetStr( 351, 400 );
			SetDex( 151, 165 );
			SetInt( 76, 100 );

			SetHits( 1448, 1470 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Fire, 75 );
			SetDamageType( ResistanceType.Physical, 25 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 45, 60 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 95 );

			SetSkill( SkillName.Wrestling, 70.1, 80.0 );
			SetSkill( SkillName.Swords, 120.1, 130.0 );
			SetSkill( SkillName.Necromancy, 120.1, 130.0 );
			SetSkill( SkillName.Anatomy, 120.1, 130.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );

			Fame = 10000;
			Karma = -10000;
			VirtualArmor = 40;

			PackItem( new Planesword () );
			PackItem( new Planeshield () );

			ObsidianBlade sword = new ObsidianBlade();
			sword.Movable = false;
			sword.Attributes.SpellChanneling = 1;
			AddItem( sword );

			ObsidianChaosShield shield = new ObsidianChaosShield();
			shield.Movable = false;
			shield.Attributes.SpellChanneling = 1;
			AddItem( shield );

			CloakOfCorruption chest = new CloakOfCorruption();
			chest.Movable = false;
			chest.Name = "cloak of shadows";
			AddItem( chest );
/*
			MaleElvenRobe chest = new MaleElvenRobe();
			chest.Hue = 1175;
			chest.Movable = false;
			chest.Name = "cloak of shadows";
			AddItem( chest );
*/

			PackGold( 2000, 4000 );

			new DreadMare().Rider = this;
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public void SpawnBrigand( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newBrigand = 1;

			for ( int i = 0; i < newBrigand; ++i )
			{
				Brigand Brigand = new Brigand();

				Brigand.Team = this.Team;
				Brigand.FightMode = FightMode.Closest;

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

				Brigand.MoveToWorld( loc, map );
				Brigand.Combatant = target;
			}
		}

		public void SpawnLich( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newLich = 1;

			for ( int i = 0; i < newLich; ++i )
			{
				Lich Lich = new Lich();

				Lich.Team = this.Team;
				Lich.FightMode = FightMode.Closest;

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

				Lich.MoveToWorld( loc, map );
				Lich.Combatant = target;
			}
		}


		public void SpawnZombie( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newZombie = 1;

			for ( int i = 0; i < newZombie; ++i )
			{
				Zombie Zombie = new Zombie();

				Zombie.Team = this.Team;
				Zombie.FightMode = FightMode.Closest;

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

				Zombie.MoveToWorld( loc, map );
				Zombie.Combatant = target;
			}
		}
		public void SpawnDaemon( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newDaemon = 1;

			for ( int i = 0; i < newDaemon; ++i )
			{
				Daemon Daemon = new Daemon();

				Daemon.Team = this.Team;
				Daemon.FightMode = FightMode.Closest;

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

				Daemon.MoveToWorld( loc, map );
				Daemon.Combatant = target;
			}
		}

		public void SpawnShadowIronElemental( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newShadowIronElemental = 1;

			for ( int i = 0; i < newShadowIronElemental; ++i )
			{
				ShadowIronElemental ShadowIronElemental = new ShadowIronElemental();

				ShadowIronElemental.Team = this.Team;
				ShadowIronElemental.FightMode = FightMode.Closest;

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

				ShadowIronElemental.MoveToWorld( loc, map );
				ShadowIronElemental.Combatant = target;
			}
		}

		public void SpawnRestlessSoul( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newRestlessSoul = 1;

			for ( int i = 0; i < newRestlessSoul; ++i )
			{
				RestlessSoul RestlessSoul = new RestlessSoul();

				RestlessSoul.Team = this.Team;
				RestlessSoul.FightMode = FightMode.Closest;

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

				RestlessSoul.MoveToWorld( loc, map );
				RestlessSoul.Combatant = target;
			}
		}

		public void SpawnNightmare( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newNightmare = 1;

			for ( int i = 0; i < newNightmare; ++i )
			{
				Nightmare Nightmare = new Nightmare();

				Nightmare.Team = this.Team;
				Nightmare.FightMode = FightMode.Closest;

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

				Nightmare.MoveToWorld( loc, map );
				Nightmare.Combatant = target;
			}
		}

		public void SpawnDarkWolf( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newDireWolf = 1;

			for ( int i = 0; i < newDireWolf; ++i )
			{
				DireWolf DireWolf = new DireWolf();

				DireWolf.Team = this.Team;
				DireWolf.FightMode = FightMode.Closest;

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

				DireWolf.MoveToWorld( loc, map );
				DireWolf.Combatant = target;
			}
		}
		public void SpawnSuperDarkWisp( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newSuperDarkWisp = 1;

			for ( int i = 0; i < newSuperDarkWisp; ++i )
			{
				SuperDarkWisp SuperDarkWisp = new SuperDarkWisp();

				SuperDarkWisp.Team = this.Team;
				SuperDarkWisp.FightMode = FightMode.Closest;

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

				SuperDarkWisp.MoveToWorld( loc, map );
				SuperDarkWisp.Combatant = target;
			}
		}

		public void DoSpecialAbility( Mobile target )
		{
			if ( 0.01 >= Utility.RandomDouble() )
				SpawnLich( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnBrigand( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnZombie( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnDaemon( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnShadowIronElemental( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnRestlessSoul( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnNightmare( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnDarkWolf( target );

			if ( 0.01 >= Utility.RandomDouble() )
				SpawnSuperDarkWisp( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );

		}

		public override void OnDamagedBySpell( Mobile from )
		{
			base.OnDamagedBySpell( from );

			DoSpecialAbility( from );
		}


		public VanguardController( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}