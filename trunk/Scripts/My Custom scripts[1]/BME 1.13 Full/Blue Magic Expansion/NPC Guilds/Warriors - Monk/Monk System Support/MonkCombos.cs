// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server
{
	public partial class MonkCombos
	{
	
		// The Gathering Storm: Target takes a -2 on attack rolls for 30 seconds. 
		// A successful Fortitude save ends this effect. Undead are immune.
		public static void AirCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: The Gathering Storm" );

			object[] objs =
			{
				AosAttribute.AttackChance, -10
			};

			new EnhancementTimer( target, 30, "monk", objs ).Start();
			target.SendMessage( 2075, "Your opponent disturbs your equilibrium: -10% Attack." );
			target.PlaySound( 0x015 );
		}

		// The Trembling Earth: The force of the earth is behind your attacks, 
		// increasing your critical attack multiplyer by 2 and partially bewildering 
		// your foe, preventing them from casting spells. A successfull Fortitude 
		// ends this effect. Lasts 30 seconds.
		public static void EarthCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: The Trembling Earth" );

			object[] objs =
			{
				AosAttribute.CastSpeed, -2,
				AosAttribute.CastRecovery, -2
			};

			new EnhancementTimer( target, 60, "monk", objs ).Start();
			target.SendMessage( 2075, "You are dazed from a bone shattering punch: Casting Speed -2." );
			target.PlaySound( 0x041 );
		}

		// Breath of the Fire Dragon: A cone of searing flame shoots forth, 
		// damaging the targets in the area of the flames for 1d6 (1 to 6) damage 
		// each monk level. A successful Reflex save reduces the damage by half.
		public static void FireCombo( Mobile from )
		{
			from.SendMessage( 2075, "You execute the maneuver: Breath Of The Fire Dragon" );

			int x = from.X, y = from.Y, xoffset = 0, yoffset = 0;
			List<Mobile> mobiles = new List<Mobile>();
			List<Point3D> points = new List<Point3D>();

			foreach ( Mobile m in from.GetMobilesInRange( 4 ) )
			{
				if ( m != null )
					if ( SpellHelper.ValidIndirectTarget( from, m ) )
						mobiles.Add( m );
			}

			switch( from.Direction )
			{
				case (Direction)0x0: case (Direction)0x80: yoffset--; break; //North
				case (Direction)0x1: case (Direction)0x81: { xoffset++; yoffset--; break; } //Right
				case (Direction)0x2: case (Direction)0x82: xoffset++; break; //East
				case (Direction)0x3: case (Direction)0x83: { xoffset++; yoffset++; break; } //Down
				case (Direction)0x4: case (Direction)0x84: yoffset++; break; //South
				case (Direction)0x5: case (Direction)0x85: { xoffset--; yoffset++; break; } //Left
				case (Direction)0x6: case (Direction)0x86: xoffset--; break; //West
				case (Direction)0x7: case (Direction)0x87: { xoffset--; yoffset--; break; } //Up
				default: { break; }
			}

			for ( int i = 0; i < 4; i++ ) // goes to the sides
			{
				for ( int j = i + 1; j <= 4; j++ ) // j goes forward
				{
					if ( j >= i + 1 )
					{
						Point3D point = new Point3D( 0, 0, 0 );
						point.X = ( x + j * xoffset - i * yoffset );
						point.Y = ( y + j * yoffset + i * xoffset );
						point.Z = from.Map.GetAverageZ( point.X, point.Y );
						points.Add( point );

						if ( i > 0 )
						{
							point.X = ( x + j * xoffset + i * yoffset );
							point.Y = ( y + j * yoffset - i * xoffset );
							point.Z = from.Map.GetAverageZ( point.X, point.Y );
							points.Add( point );
						}
					}
				}
			}

			MonkFists mf = from.FindItemOnLayer( Layer.Gloves ) as MonkFists;
			int amount = 0;	

			if ( mf != null )
				amount = Utility.Dice( mf.Teir, 3, (3 * mf.Teir) );
			else
				amount = Utility.Dice( 2, 6, 0 );

			if ( from.FindItemOnLayer( Layer.Waist ) is MonksBelt )
				amount *= 2;

			from.Freeze( TimeSpan.FromSeconds( 1 ) );
			from.Animate( 17, 7, 1, true, false, 0 );
			from.PlaySound( 0x228 );

			for ( int i = 0; i < points.Count; i++ )
			{
				if ( mobiles.Count > 0 )
				{
					for ( int j = mobiles.Count - 1; j > -1; j-- )
					{
						if ( mobiles[j].X == points[i].X && mobiles[j].Y == points[i].Y )
						{
							AOS.Damage( mobiles[j], from, amount, 0, 100, 0, 0, 0 );

							if ( mobiles[j] != null )
								mobiles.Remove( mobiles[j] );
						}
					}
				}

				Effects.SendLocationParticles( EffectItem.Create( points[i], from.Map, EffectItem.DefaultDuration ), 0x36BD, 1, 20, 0/*Hue*/, 4, 0, 0 );
			}

			mobiles.Clear();
			points.Clear();

			MonkSystem.AddHit( from, MonkElement.FireCombo );

			if ( from.HasGump( typeof( MonkStrikeGump ) ) )
				from.CloseGump( typeof( MonkStrikeGump ) );

			from.SendGump( new MonkStrikeGump( from ) );
		}

		// The Raging Sea: This attack slows your enemies attacks. 
		// A successful Fortitude ends this effect. Lasts for 30 seconds.
		public static void WaterCombo( Mobile from, Mobile target )
		{
			from.SendMessage( 2075, "You execute the maneuver: The Raging Sea" );

			Slow.SlowWalk( target, 30 );
			target.FixedParticles( 0x37CC, 10, 20, 5013, 1364, 2, EffectLayer.Waist );
			target.SendMessage( 2075, "Your ki has been twisted by your opponent's whirlpool: Slowed." );
			target.PlaySound( 0x365 );
		}

		public class WholenessOfBodyTimer : Timer
		{
			private Mobile m_From;
			private int m_OldMana;
			private int m_Count;

			public WholenessOfBodyTimer( Mobile from ) : base( TimeSpan.FromMilliseconds( 200 ), TimeSpan.FromMilliseconds( 200 ) )
			{
				m_From = from;
				m_OldMana = from.Mana;
				m_Count = 5;

				MonkFists mf = from.FindItemOnLayer( Layer.Gloves ) as MonkFists;

				if ( mf != null )
					m_Count = mf.Teir * 5;

				from.Mana = 0;
				from.Meditating = true;
				from.BeginAction( typeof( WholenessOfBodyTimer ) );
			}

			protected override void OnTick()
			{
				if ( m_From == null )
				{
					Stop();
				}
				else if ( m_Count > 0 && m_From.Meditating )
				{
					if ( m_From.Poisoned )
						m_From.CurePoison( m_From );

					m_From.Hits += 4; // +20 HP per monk level
					m_OldMana += 2; // +10 Mana per monk level
					m_From.Mana = 0;

					Effects.SendMovingParticles( 
						new Entity( Serial.Zero, new Point3D( m_From.X - Utility.RandomMinMax( -3, 3 ), m_From.Y - Utility.RandomMinMax( -3, 3 ), m_From.Z ), m_From.Map ), 
						m_From, 0xF26, 15, 0, false, false, 1153/*hue*/, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

					m_Count--;
				}
				else if ( !m_From.Meditating || m_Count < 0 )
				{
					if ( m_From.Meditating )
						m_From.Mana = m_OldMana;
					else
						m_From.Mana = m_OldMana / 2; // Penalize Mana regen for failure to fully meditate.

					m_From.Meditating = false;
					m_From.EndAction( typeof( WholenessOfBodyTimer ) );
					Stop();
				}
			}
		}

	}
}










