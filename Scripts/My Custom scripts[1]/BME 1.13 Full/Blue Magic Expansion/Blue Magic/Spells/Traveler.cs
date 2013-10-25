// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 8<br>Duration: Instantaneous<br>Target: Self/Map<br>Target a map and teleport to the first pin placed on it.<br><br>This spell is a hybrid type of both Blue Magic and Rune Magic, the scholars of Tolaria are impressive." )]
	public class TravelerSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Traveler", "", 230 );

		public override bool IsHarmful{ get{ return false; } }
		public override int PowerLevel{ get{ return 8; } }
		public override TimeSpan GetCastDelay() { return TimeSpan.FromSeconds( 17 ); }

		public TravelerSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnBeginCast()
		{
			Timer timer = new InternalTimer( this );
			timer.Start();
		}

		public override void OnCast()
		{
			Caster.SendMessage( "OnCast" );
			Caster.Target = new BlueTravelTarget( this );
		}

		public void OnMapTarget( MapItem map )
		{
			Caster.SendMessage( "OnMapTarget" );

			if ( map.RootParent != Caster )
				Caster.SendMessage( "The map must be in your backpack for you to use." );
			else if ( map.Pins.Count < 1 )
				Caster.SendMessage( "The map doesn't have any pins to teleport to." );
			else
			{
				Point3D point = new Point3D( map.Pins[0].X, map.Pins[0].Y, map.DisplayMap.GetAverageZ( map.Pins[0].X, map.Pins[0].Y ) );
				Caster.SendMessage( "Base Location " + point.X.ToString() + ", " + point.Y.ToString() );
				point.X += map.Bounds.X;
				point.Y += map.Bounds.Y;
				Caster.SendMessage( "Map Scaled Location " + point.X.ToString() + ", " + point.Y.ToString() );

				if ( !SpellHelper.FindValidSpawnLocation( map.DisplayMap, ref point, false ) )
				{
					Caster.SendMessage( "That is not a valid location." );
					Caster.SendMessage( "Failed Location " + point.X.ToString() + ", " + point.Y.ToString() );
				}
				else if ( !SpellHelper.CheckTravel( map.DisplayMap, point, TravelCheckType.RecallTo ) )
				{
					Caster.SendMessage( "Travel there is restricted." );
					Caster.SendMessage( "Failed Location " + point.X.ToString() + ", " + point.Y.ToString() );
				}
				else
				{
					Caster.SendMessage( "Teleporting to " + point.X.ToString() + ", " + point.Y.ToString() );
					Caster.Mana -= ScaleMana( GetMana() );
					Caster.MoveToWorld( point, map.DisplayMap );

					Effects.SendLocationParticles( EffectItem.Create( new Point3D ( point.X, point.Y, point.Z ), Caster.Map, EffectItem.DefaultDuration ), 0x3716, 7, 10, 1266, 3, 5052, 0 );
					Effects.SendLocationParticles( EffectItem.Create( new Point3D ( point.X, point.Y, point.Z+20 ), Caster.Map, EffectItem.DefaultDuration ), 0x3716, 7, 10, 1266, 3, 5052, 0 );
					Effects.SendLocationParticles( EffectItem.Create( new Point3D ( point.X, point.Y, point.Z+40 ), Caster.Map, EffectItem.DefaultDuration ), 0x3716, 7, 10, 1266, 3, 5052, 0 );
					Effects.SendLocationParticles( EffectItem.Create( new Point3D ( point.X, point.Y, point.Z+60 ), Caster.Map, EffectItem.DefaultDuration ), 0x3716, 7, 10, 1266, 3, 5052, 0 );

				}
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private int m_Count;
			private TravelerSpell m_Spell;
			private List<SelfDeletingItem> m_Items = new List<SelfDeletingItem>();

			public InternalTimer( TravelerSpell spell ) : base( TimeSpan.FromSeconds( 1 ), TimeSpan.FromSeconds( 1 ) )
			{
				m_Spell = spell;
			}

			private int[] m_Points = new int[]
			{
				// 1st Ring
				-1, -1,
				0, 1,
				1, 0

				// 2nd Ring
				-2, -2,
				-2, 1,
				0, 2,
				2, 0,
				1, -2

				// 3rd Ring
				-2, -2,
				-3, 0,
				-2, 2,
				0, 3,
				3, 0,
				2, -2,
				0, -3
			};

			private string[] m_Chant = new string[]
			{
				"Chattur'gha", // Chattur'gha, red, physical, hp.
				"Bankorok", // Protect
				"Santak", // Self

				"Ulyaoth", // Ulyaoth, blue, magik, mana.
				"Narokath", // Absorb
				"Magormor", // Item
				"Antorbok", // Project
				"Aretak", // Creature

				"Xel'lotath", // Xel'lotath, green, sanity, stam.
				"Pargon", // Power
				"Tier", // Summon
				"Santak", // Self
				"Redgormor", // Area
				"Nathlek", // Dispel
				"Narokath", // Absorb
			};

			private int[] m_ItemIDs = new int[]
			{
				0x0E5C,
				0x181D,
				0x1824,

				0x0E65,
				0x1821,
				0x181F,
				0x1827,
				0x1828,

				0x0E5F,
				0x1825,
				0x181E,
				0x1824,
				0x1823,
				0x1826,
				0x1821
			};

			protected override void OnTick()
			{
				m_Count += 2;

				if ( m_Spell != null && m_Spell.Caster != null && m_Spell.State == SpellState.Casting )
					Stop();
				else if ( m_Count < 16 )
				{
					m_Items.Add( new SelfDeletingItem( m_ItemIDs[m_Count], "a magical rune", 60 ) );

					int hue = 0;

					if ( m_Count > 15 )
						hue = 470;
					else if ( m_Count > 5 )
						hue = 6;
					else
						hue = 33;

					m_Items[m_Items.Count - 1].Hue = hue;
					m_Spell.Caster.PublicOverheadMessage( MessageType.Regular, hue, false, m_Chant[m_Count] );

					Point3D point = new Point3D(
							m_Spell.Caster.X + m_Points[m_Count],
							m_Spell.Caster.Y + m_Points[m_Count + 1],
							m_Spell.Caster.Z );

					Effects.SendLocationParticles(
						EffectItem.Create( point, m_Spell.Caster.Map, EffectItem.DefaultDuration ), 
						0x3709, 1, 30, hue, 4/*RenderMode*/, 0, 0 );

					m_Items[m_Items.Count - 1].MoveToWorld( point, m_Spell.Caster.Map );
				}
				else
				{
					Stop();

					for ( int i = m_Items.Count - 1; i > 0; i++ )
						m_Items[i].Delete();
				}
			}
		}

		public class BlueTravelTarget : Target
		{
			private TravelerSpell m_Owner;

			public BlueTravelTarget( TravelerSpell owner ) : base( 1, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is MapItem )
					m_Owner.OnMapTarget( (MapItem)o );
				else
					from.SendMessage( "This spell doesn't work on that." );
			}
		}

	}
}