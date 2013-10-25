// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a beholder corpse" )]
	public class BlueBeholder : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 30.0 ); } }
		public override Type SpellToCast{ get{ return typeof( StareSpell ); } }

		[Constructable]
		public BlueBeholder() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a beholder";
			Body = 22;
			BaseSoundID = 377;

			SetStr( 296, 325 );
			SetDex( 86, 105 );
			SetInt( 291, 385 );

			SetHits( 780, 950 );

			SetDamage( 8, 19 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 62.0, 100.0 );
			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 115.1, 130.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 12500;
			Karma = -12500;

			VirtualArmor = 50;

			m_EyeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) );
			m_EyeOneDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Charm Monster
			m_EyeTwoDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Charm Person
			m_EyeThreeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Disintegrate
			m_EyeFourDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Fear
			m_EyeFiveDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Finger Of Death
			m_EyeSixDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Flesh To Stone
			m_EyeSevenDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Inflict Moderate Wounds
			m_EyeEightDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Sleep
			m_EyeNineDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Slow
			m_EyeTenDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Telekinesis
		}

		private DateTime m_EyeDelay;
		private DateTime m_EyeOneDelay; // Charm Monster
		private DateTime m_EyeTwoDelay; // Charm Person
		private DateTime m_EyeThreeDelay; // Disintegrate
		private DateTime m_EyeFourDelay; // Fear
		private DateTime m_EyeFiveDelay; // Finger Of Death
		private DateTime m_EyeSixDelay; // Flesh To Stone
		private DateTime m_EyeSevenDelay; // Inflict Moderate Wounds
		private DateTime m_EyeEightDelay; // Sleep
		private DateTime m_EyeNineDelay; // Slow
		private DateTime m_EyeTenDelay; // Telekinesis

		public override void OnThink()
		{
			base.OnThink();

			if ( Ability.CanUse( this ) )
			{
				int fired = 0;

				Mobile target = Ability.FindRandomTarget( this, true );

				if ( target == null || target.Hidden || target.AccessLevel > AccessLevel.Player || !CanBeHarmful( target ) || !InLOS( target ) )
					return;

				if ( DateTime.Now > m_EyeOneDelay )
				{
					DDCharmMonster( this, target );
					fired++;
					m_EyeOneDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 120 ) );
				}

				if ( DateTime.Now >  m_EyeTwoDelay )
				{
					DDCharmMonster( this, target );
					fired++;
					m_EyeTwoDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 45, 75 ) );
				}

				if ( DateTime.Now >  m_EyeThreeDelay && fired < 2 )
				{
					DDDisintegrate( this, target );
					fired++;
					m_EyeThreeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 45 ) );
				}

				if ( DateTime.Now >  m_EyeFourDelay && fired < 2 )
				{
					DDFear( this, target );
					fired++;
					m_EyeFourDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 30 ) );
				}

				if ( DateTime.Now >  m_EyeFiveDelay && fired < 2 )
				{
					DDFingerOfDeath( this, target );
					fired++;
					m_EyeFiveDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 120 ) );
				}

				if ( DateTime.Now >  m_EyeSixDelay && fired < 2 )
				{
					DDFleshToStone( this, target );
					fired++;
					m_EyeSixDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 120 ) );
				}

				if ( DateTime.Now >  m_EyeSevenDelay && fired < 2 )
				{
					DDInflictModerateWounds( this, target );
					fired++;
					m_EyeSevenDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 120 ) );
				}

				if ( DateTime.Now >  m_EyeEightDelay && fired < 2 )
				{
					DDSleep( this, target );
					fired++;
					m_EyeEightDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 120 ) );
				}

				if ( DateTime.Now >  m_EyeNineDelay && fired < 2 )
				{
					DDSlow( this, target );
					fired++;
					m_EyeNineDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 120 ) );
				}

				if ( DateTime.Now >  m_EyeTenDelay && fired < 2 )
				{
					DDTelekinesis( this, target );
					fired++;
					m_EyeTenDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 120 ) );
				}

				fired = 0;
			}
		}

		public override int TreasureMapLevel{ get{ return 5; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
		}

		public BlueBeholder( Serial serial ) : base( serial )
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

			m_EyeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) );
			m_EyeOneDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Charm Monster
			m_EyeTwoDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Charm Person
			m_EyeThreeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Disintegrate
			m_EyeFourDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Fear
			m_EyeFiveDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Finger Of Death
			m_EyeSixDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Flesh To Stone
			m_EyeSevenDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Inflict Moderate Wounds
			m_EyeEightDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Sleep
			m_EyeNineDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Slow
			m_EyeTenDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 60 ) ); // Telekinesis
		}

		public static void DDCharmMonster( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Will, 20 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You failed your save verses Charm!" );

			LichLord clone = new LichLord();
			Ability.MimicThem( clone, target, true, true );
			clone.Hidden = true;
			clone.MoveToWorld( target.Location, target.Map );

			if ( target is PlayerMobile )
			{
				target.Kill();

				if ( !AutoLifeSpell.HasAutoLife( (PlayerMobile)target ) && from.Map == Map.Ilshenar )
				{
					target.MoveToWorld( new Point3D( 1704, 591, 9 ), Map.Ilshenar );
					target.SendMessage( 33, "You have been charmed, a clone of you has taken your place and you have been moved to outside the cave." );

					if ( target.Corpse != null && target.Backpack != null )
					{
						List<Item> items = new List<Item>( target.Corpse.Items );

						for( int i = 0; i < items.Count; ++i )
						{
							Item item = items[i];

							if ( item.Layer != Layer.Hair && item.Layer != Layer.FacialHair && item.Movable )
								target.Backpack.DropItem( item );
						}
					}
				}
			}
			else if ( target is BaseCreature && ((BaseCreature)target).Controlled )
			{
				target.Kill();

				if ( target == null )
					return;

				target.Freeze( TimeSpan.FromSeconds( 180 ) );
				((BaseCreature)target).ControlOrder = OrderType.Stop;
				target.Hidden = true;
			}
		}

		public static void DDDisintegrate( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Fort, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				AOS.Damage( target, from, Utility.Dice( 5, 6, 0 ), 20, 20, 20, 20, 20 );
			}
			else
			{
				target.SendMessage( "You failed your save verses Disintegrate!" );
				AOS.Damage( target, from, Utility.Dice( 40, 6, 0 ), 20, 20, 20, 20, 20 );
			}
		}

		public static void DDFear( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Will, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You are too afraid to move!" );
			target.Freeze( TimeSpan.FromSeconds( 30 ) );
		}

		public static void DDFingerOfDeath( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Fort, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You failed your save verses Finger Of Death!" );
			target.Kill();
		}

		public static void DDFleshToStone( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Fort, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You failed your save verses Flesh to Stone!" );
			target.SendMessage( "[And nothing happens, till I finish this. ~Peo]" );
		}

		public static void DDInflictModerateWounds( Mobile from, Mobile target )
		{
			if ( target == null )
				return;

			int damage = Utility.Dice( 2, 8, 10 );

			if ( BlueSpell.SavingThrow( target, DDSave.Will, 30 ) )
				damage /= 2;

			AOS.Damage( target, from, damage, 0, 0, 0, 0, 100 );
		}

		public static void DDSleep( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Fort, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You failed your save verses Sleep!" );
			// TODO use the new SA method of sleep (prevents spellcasting).
			target.Paralyze( TimeSpan.FromSeconds( 30 ) );
		}

		public static void DDSlow( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Fort, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You failed your save verses Slow!" );
			Slow.SlowWalk( target, 60 );
		}

		public static void DDTelekinesis( Mobile from, Mobile target )
		{
			if ( target == null )
				return;
			else if ( BlueSpell.SavingThrow( target, DDSave.Fort, 30 ) )
			{
				target.SendMessage( "You makes a successful save against a spell" );
				return;
			}

			target.SendMessage( "You failed your save verses Telekinesis!" );
			Ability.SlideAway( target, from.Location, Utility.RandomMinMax( 6, 12 ) );
		}

		/*
		#region DD Saves
		public enum DDSave
		{
			Fort,
			Refl,
			Will
		}

		// Max save possible is 1d20+36: +15 (stat) + 6 (120 skill) + 6 (120 skill) + 3 (luck) + 6 (120 chiv)
		public static bool SavingThrow( Mobile m, DDSave ddsave, int dc )
		{
			int save = 0;

			switch( ddsave )
			{
				case DDSave.Fort:
				{
					save += m.Str / 10;
					save += (int)(m.Skills[SkillName.Tactics].Value * 0.05);
					save += (int)(m.Skills[SkillName.Anatomy].Value * 0.05);
					break;
				}
				case DDSave.Refl:
				{
					save += m.Dex / 10;
					save += (int)(m.Skills[SkillName.Stealth].Value * 0.05);
					save += (int)(m.Skills[SkillName.Stealing].Value * 0.05);
					break;
				}
				case DDSave.Will:
				{
					save += m.Int / 10;
					save += (int)(m.Skills[SkillName.MagicResist].Value * 0.05);
					save += (int)(m.Skills[SkillName.Meditation].Value * 0.05);
					break;
				}
			}

			if ( m.Luck > 1500 )
				save += 3;
			else
				save += m.Luck / 500;

			save += (int)(m.Skills[SkillName.Chivalry].Value * 0.05);
			save += Utility.Random( 19 ) + 1;

			return save >= dc;
		}
		#endregion
		*/
	}
}

