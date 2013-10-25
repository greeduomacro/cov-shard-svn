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
	[Description( "Level: 8<br>Duration: *<br>Target: Area *<br>Summons frogs to fall from the sky showering the area and dealing damage. The spell's range, duration and damage is based on having certain items in your pack.<br><br>Item List<br><i>World Map<br>Red Leaves<br>Sand<br>Special Hair Dye<br>Rope, Vines<br>Tribal Paint<br>A Rock<br>Sheaf Of Hay<br>No Gold<br></i>" )]
	public class FrogDropSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"FrogDrop Spell", "", 230 );

		public override int PowerLevel{ get{ return 8; } }

		public FrogDropSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new BlueSpellTarget( this, TargetFlags.Harmful, true );
		}

		public override void OnTarget( Point3D point )
		{
			new InternalTimer( this, point ).Start();
		}

		private class InternalTimer : Timer
		{
			private FrogDropSpell m_Spell;
			private Mobile m_From;
			private Point3D m_Point; // point originally targeted
			private Point3D m_Target; // point the frogs are targeting
			private Map m_Map;

			private int m_Count;
			private int m_MaxCount;

			private List<int> m_Hues = new List<int>();
			private int m_Min;
			private int m_Max;
			private int m_Range;

			public InternalTimer( FrogDropSpell spell, Point3D point ) : base( TimeSpan.FromMilliseconds( 100.0 ), TimeSpan.FromMilliseconds( 100.0 ) )
			{
				m_Spell = spell;
				m_From = m_Spell.Caster;
				m_Point = point;
				m_Target = new Point3D( m_Point.X, m_Point.Y, m_Point.Z );
				m_Map = spell.Caster.Map;
				m_Count = 0;
				m_MaxCount = 10;
				m_Min = 0;
				m_Max = 0;
				m_Range = 0;

				CheckItems();
			}

			protected override void OnTick()
			{
				if ( m_From == null || m_Hues.Count == 0 )
				{
					Stop();
					return;
				}
				else if ( m_Count < m_MaxCount )
				{
					m_Target.X = m_Point.X + Utility.RandomMinMax( -m_Range, m_Range );
					m_Target.Y = m_Point.Y + Utility.RandomMinMax( -m_Range, m_Range );

					if ( (m_Count % 2) == 0 )
					{
						Effects.SendMovingParticles( 
							new Entity( Serial.Zero, new Point3D( m_Target.X, m_Target.Y, m_Target.Z + 30), m_From.Map ), 
							new Entity( Serial.Zero, m_Target, m_From.Map ), 
							15117 /*ItemID*/, 15/*Speed*/, 0, false, true, (m_Hues[Utility.Random( m_Hues.Count )] - 1)/*hue*/, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
					}

					if ( (m_Count % 10) == 0 )
						Ability.Aura( m_Point, m_Map, m_From, m_Min, m_Max, ResistanceType.Cold, m_Range, null, "", false, false );

						//Ability.Aura( m_Point, m_Map, m_From, m_Min, m_Max, ResistanceType.Cold, m_Range, null, "" );

					m_Count++;
				}
				else
				{
					//foreach ( Mobile m in Map.AllMaps[m_Map.MapID].GetMobilesInRange( m_Point, m_Range ) )
						//if ( m != null )
							//BlueMageControl.CheckKnown( m, m_Spell, m_Spell.CanTeach( m ) );

					Stop();
				}
			}

			private void CheckItems()
			{
				int damage = 0;

				#region hasitem
				if ( HasItem( typeof( WorldMap ) ) )
				{
					m_Hues.Add( 0x972 ); // Bronze
					damage++;
				}

				if ( HasItem( typeof( RedLeaves ) ) )
				{
					m_Hues.Add( 0x21 ); // PigmentType.BerserkerRed
					damage++;
				}

				if ( HasItem( typeof( Sand ) ) )
				{
					m_Hues.Add( 0x979 ); // Agapite
					damage++;
				}

				if ( HasItem( typeof( SpecialHairDye ) ) )
				{
					m_Hues.Add( 0x89F ); // Verite
					damage++;
				}

				if ( HasItem( typeof( Rope ) ) )
				{
					m_Hues.Add( 0x96D ); // Copper
					damage++;
				}

				if ( HasItem( typeof( Vines ) ) )
				{
					m_Hues.Add( 0x59C ); // Ranger Green
					damage++;
				}

				if ( HasItem( typeof( TribalPaint ) ) )
				{
					m_Hues.Add( 0x48F ); // PigmentType.DryadGreen
					damage++;
				}

				if ( HasItem( typeof( RockArtifact ) ) )
				{
					m_Hues.Add( 2101 ); // Khaldrun Gray
					damage++;
				}

				if ( HasItem( typeof( SheafOfHay ) ) )
				{
					m_Hues.Add( 1724 ); // Dunno
					damage++;
				}

				if ( HasItem( typeof( Gold ) ) )
				{
					m_Hues.Add( 1 ); // 
					damage++;
				}
				#endregion

				if ( damage == 0 )
					damage = 1;

				m_MaxCount = damage * 10;
				m_Range = damage / 2;
				m_Min = damage * 2;
				m_Max = damage * 4;
			}

			private bool HasItem( Type t )
			{
				if ( m_From == null || m_From.Backpack == null )
					return false;
				else
				{
					Item[] items = m_From.Backpack.FindItemsByType( t );
					return items.Length != 0;
				}
			}
		}
	}
}