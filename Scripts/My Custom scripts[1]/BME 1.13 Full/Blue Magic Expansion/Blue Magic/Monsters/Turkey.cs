// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server
{
	public class BlueTurkeyInfo
	{
		public static Dictionary<PlayerMobile, BlueTurkeyInfo> Info = new Dictionary<PlayerMobile, BlueTurkeyInfo>();
		public static Point3D Home = new Point3D( 1080, 1060, 0 ); // [go 1080 1060 0
		public PlayerMobile Owner;
		public int Points;
		public int SpawnLevel;
		public TurkeyExpireTimer Timer;

		public BlueTurkeyInfo( PlayerMobile owner, int amount )
		{
			Owner = owner;
			Points = amount;
			SpawnLevel = 0;
			Timer = new TurkeyExpireTimer( this );
			Timer.Start();
		}

		public static void AwardPoints( Mobile m, int amount )
		{
			if ( !(m is PlayerMobile) )
				return;

			PlayerMobile pm = (PlayerMobile)m;

			if ( Info.ContainsKey( pm ) )
			{
				Info[pm].Points += amount;

				if ( Info[pm].Points > 75 && Info[pm].SpawnLevel == 3 )
				{
					pm.PlaySound( 0x29 );
					++Info[pm].SpawnLevel;

					new BlueTurkey( 3 ).MoveToWorld( new Point3D( Home.X + Utility.RandomMinMax( -15, 15 ), Home.Y + Utility.RandomMinMax( -15, 15 ), Home.Z ), Map.Ilshenar );

					for ( int i = 0; i < 15; i++ )
						new BlueTurkey( 2 ).MoveToWorld( new Point3D( Home.X + Utility.RandomMinMax( -15, 15 ), Home.Y + Utility.RandomMinMax( -15, 15 ), Home.Z ), Map.Ilshenar );
				}
				else if ( Info[pm].Points > 50 && Info[pm].SpawnLevel == 2 )
				{
					pm.PlaySound( 0x29 );
					++Info[pm].SpawnLevel;

					for ( int i = 0; i < 25; i++ )
						new BlueTurkey( 2 ).MoveToWorld( new Point3D( Home.X + Utility.RandomMinMax( -15, 15 ), Home.Y + Utility.RandomMinMax( -15, 15 ), Home.Z ), Map.Ilshenar );
				}
				else if ( Info[pm].Points > 25 && Info[pm].SpawnLevel == 1 )
				{
					pm.PlaySound( 0x29 );
					++Info[pm].SpawnLevel;

					for ( int i = 0; i < 25; i++ )
						new BlueTurkey( 1 ).MoveToWorld( new Point3D( Home.X + Utility.RandomMinMax( -15, 15 ), Home.Y + Utility.RandomMinMax( -15, 15 ), Home.Z ), Map.Ilshenar );
				}
				else if ( Info[pm].Points > 15 && Info[pm].SpawnLevel == 0 )
				{
					pm.PlaySound( 0x29 );
					++Info[pm].SpawnLevel;

					for ( int i = 0; i < 9; i++ )
						new BlueTurkey( 0 ).MoveToWorld( new Point3D( Home.X + Utility.RandomMinMax( -15, 15 ), Home.Y + Utility.RandomMinMax( -15, 15 ), Home.Z ), Map.Ilshenar );
				}
			}
			else
			{
				Info.Add( pm, new BlueTurkeyInfo( pm, amount ) );
			}
		}

		public void Expire()
		{
			if ( Timer != null )
				Timer.Stop();

			if ( Info.ContainsKey( Owner ) )
				Info.Remove( Owner );
		}

		public class TurkeyExpireTimer : Timer
		{
			private BlueTurkeyInfo m_Info;

			public TurkeyExpireTimer( BlueTurkeyInfo info ) : base( TimeSpan.FromMinutes( 20 ) )
			{
				m_Info = info;
			}

			protected override void OnTick()
			{
				if ( m_Info != null )
					m_Info.Expire();
			}
		}
	}
}

namespace Server.Mobiles
{
	[CorpseName( "a turkey corpse" )]
	public class BlueTurkey : BlueMonster
	{
		public int TurkeyLevel;
		public DateTime Expires;
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromMinutes( 3.0 ); } }
		public override Type SpellToCast
		{
			get
			{
				if ( TurkeyLevel > 3 )
					return typeof( MatraMagicSpell );
				else
					return null;
			}
		}

		[Constructable]
		public BlueTurkey() : this( 0 )
		{
		}

		[Constructable]
		public BlueTurkey( int level ) : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			TurkeyLevel = (level % 4) + 1;

			Name = "a turkey";
			BaseSoundID = 0x6E;

			switch( TurkeyLevel )
			{
				case 1: Body = 208; break;
				case 2: Body = 95; break;
				case 3: Body = 1026; break;
				case 4: Body = 1026; Hue = 2075; Name = "a uber turkey"; ++TurkeyLevel; break;
			}

			if ( TurkeyLevel > 1 )
			{
				Expires = DateTime.Now + TimeSpan.FromMinutes( 10 );
				FightMode = FightMode.Closest;
				SetHits( 100 * TurkeyLevel );
			}
			else
			{
				Expires = DateTime.Now + TimeSpan.FromDays( 7 );
			}

			// On Death: Phoenix 832?

			SetStr( 50 * TurkeyLevel );
			SetDex( 50 * TurkeyLevel );
			SetInt( 50 * TurkeyLevel );

			SetDamage( 10 * TurkeyLevel );
			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Wrestling, 33.0 * TurkeyLevel );
			SetSkill( SkillName.Tactics, 33.0 * TurkeyLevel );
			SetSkill( SkillName.MagicResist, 33.0 * TurkeyLevel );

			Fame = 1000 * TurkeyLevel;
			Karma = -1000 * TurkeyLevel;
		}

		public override bool OnBeforeDeath()
		{
			BlueTurkeyInfo.AwardPoints( DemonKnight.FindRandomPlayer( this ), 1 );
			return base.OnBeforeDeath();
		}

		public override void OnThink()
		{
			if ( DateTime.Now > Expires )
				Kill();

			base.OnThink();
		}

		public BlueTurkey( Serial serial ) : base( serial )
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