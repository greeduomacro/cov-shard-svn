// Created by Peoharen
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Regions;
using Server.Targeting;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	public class BlueWight : BlueMonster
	{
		public static void Initialize()
		{
			EventSink.PlayerDeath += new PlayerDeathEventHandler( EventSink_PlayerDeath );
		}
 
		public static void EventSink_PlayerDeath( PlayerDeathEventArgs e )
		{
			if ( e.Mobile == null )
				return;

			if ( e.Mobile.Region != null )
			{
				if ( e.Mobile.Region.Name == "Spectre Dungeon" || e.Mobile.Region.Name == "Doom" )
				{
					if ( Utility.Random( 100 ) > 75 )
					{
						new BlueWight( ScaleByMobile( e.Mobile ) ).MoveToWorld( e.Mobile.Location, e.Mobile.Map );
						return;
					}
				}
				else if ( e.Mobile.Region is DungeonRegion ) 
				{
					bool spawn = false;

					for ( int i = 0; i < e.Mobile.Skills.Length; ++i )
					{
						if ( ( spawn = (e.Mobile.Skills[i].Value == 0) ) )
							continue;
						else
							break;
					}

					if ( spawn )
						new BlueWight( ScaleByMobile( e.Mobile ) ).MoveToWorld( e.Mobile.Location, e.Mobile.Map );
				}
			}
		}

		public static double ScaleByMobile( Mobile m )
		{
			double scale = 1.0;

			// a 225 stat point paladin build scale total will be
			scale += (double)m.RawStr * 0.01; // 100 str = 1.0
			scale += (double)m.RawDex * 0.01; // 80 dex = 0.8
			scale += (double)m.RawInt * 0.01; // 45 int = 0.45
			scale += (double)m.SkillsTotal * 0.01 / 2; // GM all skills (700.0) = 3.5
			// 5.8

			if ( scale > 7.0 )
				scale = 7.0;

			return scale;
		}

		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 30.0 ); } }
		public override Type SpellToCast{ get{ return typeof( DrainTouchMove ); } }

		[Constructable]
		public BlueWight() : this( 1.0 )
		{
		}

		[Constructable]
		public BlueWight( double scale ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.18, 0.36 )
		{
			Name = "a wight";
			Body = 3;
			BaseSoundID = 471;

			SetStr( (int)(56 * scale), (int)(80 * scale) );
			SetDex( (int)(41 * scale), (int)(60 * scale) );
			SetInt( (int)(36 * scale), (int)(50 * scale) );

			SetHits( (int)(78 * scale), (int)(92 * scale) );

			SetDamage( (int)(2 * scale), (int)(5 * scale) );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 65, 70 );

			SetSkill( SkillName.MagicResist, 25.1, 50.0 );
			SetSkill( SkillName.Tactics, 65.1, 80.0 );
			SetSkill( SkillName.Wrestling, 65.1, 80.0 );

			Fame = 600;
			Karma = -600;

			VirtualArmor = (int)(18 * scale);
			
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new BonePile() ); break;
			}
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			Ability.EnergyDrain( this, to, 3, 5, true );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( !(from.Weapon is BaseBashing) )
				damage /= 2;
		}

		public BlueWight( Serial serial ) : base( serial )
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