//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class BlueFrog : BaseCreature
	{
		public enum FrogAge
		{
			Young = 0x5AC,
			OneDay = 0x5A3,
			TwoDays = 0x59A,
			ThreeDays = 0x591,
			FourDays = 0x588,
			FiveDays = 0x57F,
			SixDays = 0x4AD
		}

		[Constructable]
		public BlueFrog() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 81;
			Hue = (int)FrogAge.Young;
			Name = "a frog";

			SetStr( 10, 20 );
			SetDex( 10, 20 );
			SetInt( 10, 20 );

			SetHits( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Cold, 1, 5 );
			SetResistance( ResistanceType.Poison, 1, 5 );
		}

		private DateTime m_Delay;

		public override void OnThink()
		{
			if ( DateTime.Now > m_Delay )
			{
				TimeSpan age = DateTime.Now - CreationTime;

				switch( age.Days )
				{
					case 0: Hue = (int)FrogAge.Young; break;
					case 1: Hue = (int)FrogAge.OneDay; break;
					case 2: Hue = (int)FrogAge.TwoDays; break;
					case 3: Hue = (int)FrogAge.ThreeDays; Body = 81; break;
					case 4: Hue = (int)FrogAge.FourDays; Body = 81; break;
					case 5: Hue = (int)FrogAge.FiveDays; Body = 81; break;
					default: Hue = (int)FrogAge.SixDays; Body = 81; break;
				}

				m_Delay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 60, 120 ) );
			}

			base.OnThink();
		}

		public override void OnDeath( Container c )
		{
			double chance = 0.0;

			if ( Hue == (int)FrogAge.OneDay )
				chance = 0.01;
			else if ( Hue == (int)FrogAge.TwoDays )
				chance = 0.02;
			else if ( Hue == (int)FrogAge.ThreeDays )
				chance = 0.04;
			else if ( Hue == (int)FrogAge.FourDays )
				chance = 0.08;
			else if ( Hue == (int)FrogAge.FiveDays )
				chance = 0.16;
			else if ( Hue == (int)FrogAge.SixDays )
				chance = 1.0;

			base.OnDeath( c );

			if ( chance > 0 && chance > Utility.RandomDouble() )
			{
				switch( Utility.Random ( 6 ) )
				{
					case 0: DemonKnight.DistributeArtifact( this, new WorldMap() ); break;
					case 1: DemonKnight.DistributeArtifact( this, new RedLeaves() ); break;
					case 2: DemonKnight.DistributeArtifact( this, new Sand() ); break;
					// SpecialHairDye
					case 3: DemonKnight.DistributeArtifact( this, new Rope() ); break;
					case 4: DemonKnight.DistributeArtifact( this, new Vines() ); break;
					// TribalPaint
					// RockArtifact
					// Runebook
					// Gold
					case 5: DemonKnight.DistributeArtifact( this, new Gold( 50 ) ); break;
				}
			}
		}

		public BlueFrog( Serial serial ) : base( serial )
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

			m_Delay = DateTime.Now;
		}
	}
}
