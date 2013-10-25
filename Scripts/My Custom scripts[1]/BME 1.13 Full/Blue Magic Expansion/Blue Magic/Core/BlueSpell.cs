// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines;
using Server.Engines.PartySystem;
using Server.Guilds;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Second;
using Server.Spells.Spellweaving;

namespace Server.Spells.BlueMagic
{
	public enum SpellType
	{
		Self,
		Target,
		Line,
		WideLine,
		Cone,
		Burst,
		Area,
		Party
	}

	public enum DDSave
	{
		Fort,
		Refl,
		Will
	}

	public abstract class BlueSpell : Spell
	{
		public abstract int PowerLevel{ get; }

		// Ok, this is a big thing right here, let's hope I explain it right...
		// One of the things I was aiming for was to use less code overall. So instead of coding an area effect in each spell, and 12+  spells, I am trying to reuse the same methods.
		// Also, do note these fields are not abstract based and only need to be overriden when you care to change them.
		// IsHarmful allows you to change the target type allowign the same target to be recycled. It defualts to true, ie the spell hurts stuff.
		// OnCast checks the type of blue SpellType is being used, for example party, and it runs the party method invoking the spell's SpellEffect on each party member.
		// 	If the type were Brust, it would use Range and create a circle in game
		public virtual bool IsHarmful{ get{ return true; } }
		public virtual int Range{ get{ return 1; } }
		public virtual SpellType BlueSpellType{ get{ return SpellType.Target; } }

		public BlueSpell( Mobile caster, SpellInfo info ) : base( caster, null, info )
		{
		}



		#region BaseSpellOverridesForBlueSpell
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }

		public override SkillName CastSkill{ get{ return SkillName.Forensics; } }
		public override SkillName DamageSkill{ get{ return SkillName.MagicResist; } }

		public override bool ClearHandsOnCast{ get{ return false; } }
		public override double CastDelayFastScalar{ get{ return 1.0; } }

		private static double[] m_SkillTable = new double[] { 0.0, 12.5, 25.0, 37.5, 50.0, 62.5, 75, 87.5 };

		public override void GetCastSkills( out double min, out double max )
		{
			if ( PowerLevel > 0 && PowerLevel < 9 )
			{
				min = m_SkillTable[PowerLevel - 1];
				max = m_SkillTable[PowerLevel - 1] + 20.0;
			}
			else
			{
				min = 150.0;
				max = 150.0;
			}
		}

		private static int[] m_ManaTable = new int[] { 4, 6, 9, 11, 14, 20, 40, 50 };

		public override int GetMana()
		{
			if ( this is MatraMagicSpell && Caster.Mana < 50 )
				return 0;
			else if ( PowerLevel > 0 && PowerLevel < 9 )
				return m_ManaTable[PowerLevel - 1];
			else
				return 60;
		}

		public override TimeSpan GetCastRecovery()
		{	//Pre-AOS delay is 0.75 seconds.
			int fcr = AosAttributes.GetValue( Caster, AosAttribute.CastRecovery );

			if ( fcr > 4 )
				fcr = 4;

			fcr -= ThunderstormSpell.GetCastRecoveryMalus( Caster );

			double delay = 0.25 * PowerLevel;
			delay -= ((double)fcr) * 0.25;

			return TimeSpan.FromSeconds( delay );
		}

		public override TimeSpan GetCastDelay()
		{	//Pre-AOS delay is 0.25 * circle

			int fc = AosAttributes.GetValue( Caster, AosAttribute.CastSpeed );

			if ( fc > 2 )
				fc = 2;

			if ( ProtectionSpell.Registry.Contains( Caster ) )
				fc -= 2;

			if( EssenceOfWindSpell.IsDebuffed( Caster ) )
				fc -= EssenceOfWindSpell.GetFCMalus( Caster );

			double delay = 0.15 * PowerLevel;
			delay -= ((double)fc) * 0.15;

			return TimeSpan.FromSeconds( delay );
		}

		public override bool CheckCast()
		{
			if ( Caster is BaseCreature )
			{
				BaseCreature bc = Caster as BaseCreature;
				bc.DebugSay( "Blue Spell: CheckCast is returning base" );
				return base.CheckCast();
			}
			else if ( Caster.AccessLevel == AccessLevel.Counselor )
			{
				// Counselors are blocked becuase counselors are not meant to have leet god powers. Lock the level down like you're supposed to and you can hire the position out as the advice giving only position as it's supposed to be.
				Caster.SendMessage( "You are blocked from these spells." );
				return false;
			}
			else if ( Caster is PlayerMobile && !BlueMageControl.IsBlueMage( Caster ) && Caster.AccessLevel == AccessLevel.Player )
			{
				Caster.SendMessage( "Only a blue mage can cast this spell." );
				return false;
			}

			// Not a real class system, because class systems suck, but you can't use higher levels of spells as part of an intended balence.
			if ( BlueMageControl.SkillLock && Caster.AccessLevel == AccessLevel.Player )
			{
				if ( Caster.Skills[SkillName.Magery].Base > 50.0 )
				{
					//Caster.SendMessage( "You study true magic and cannot mimic such a choatic spell." );
					Caster.Skills[SkillName.Magery].Base = 50.0;
				}
				if ( Caster.Skills[SkillName.Chivalry].Base > 50.0 )
				{
					//Caster.SendMessage( "Your oath prevents you from using such a dishonorable spell." );
					Caster.Skills[SkillName.Chivalry].Base = 50.0;
				}
				if ( Caster.Skills[SkillName.Necromancy].Base > 50.0 )
				{
					//Caster.SendMessage( "Your dark power prevents you from casting this spell." );
					Caster.Skills[SkillName.Necromancy].Base = 50.0;
				}
				if ( Caster.Skills[SkillName.AnimalTaming].Base > 0.0 )
				{
					//Caster.SendMessage( "You refuse to cast the spell, you believe monsters should be used, not studied." );
					Caster.Skills[SkillName.AnimalTaming].Base = 0.0;
				}
				else if ( Caster.Skills[SkillName.Spellweaving].Base > 50.0 )
				{
					Caster.Skills[SkillName.Spellweaving].Base = 50.0;
				}
				else if ( Caster.Skills[SkillName.Mysticism].Base > 50.0 )
				{
					Caster.Skills[SkillName.Mysticism].Base = 50.0;
				}

				if ( Caster is PlayerMobile && !BlueMageControl.CheckKnown( Caster, this, false ) )
				{
					Caster.SendMessage( "You do not know this spell" );
					return false;
				}
			}

			if ( !base.CheckCast() ) //|| !base.CheckSequence() )
			{
				return false;
			}
			else
			{
				//Caster.PublicOverheadMessage( MessageType.Regular, 1365, false, this.type.toString() );
				BaseAnimation();
				return true;
			}
		}

		public override void OnCast()
		{
			if ( this is MatraMagicSpell && Caster.Mana < 50 )
			{
				int cost = (Caster.HitsMax / 2);

				if ( Caster.Hits < cost )
					Caster.SendLocalizedMessage( 501849 ); // The mind is strong but the body is weak.
				else if ( Server.Misc.RegenRates.GetArmorOffset( Caster ) > 0 )
					Caster.SendLocalizedMessage( 500135 ); // Regenative forces cannot penetrate your armor!
				else if ( Utility.RandomDouble() > Caster.Skills[SkillName.Meditation].Value )
					Caster.SendLocalizedMessage( 501850 ); // You cannot focus your concentration.
				else
				{
					Caster.Hits -= cost;
					Caster.SendLocalizedMessage( 501851 ); // You enter a meditative trance.
					Caster.Meditating = true;
					BuffInfo.AddBuff( Caster, new BuffInfo( BuffIcon.ActiveMeditation, 1075657 ) );
				}

				return;
			}
			else if ( BlueSpellType != SpellType.Target )
				Caster.Mana -= ScaleMana( GetMana() );

			switch( BlueSpellType )
			{
				case SpellType.Self: { SpellEffect( Caster ); break; }
				case SpellType.Target: { Caster.Target = new BlueSpellTarget( this, (IsHarmful) ? TargetFlags.Harmful : TargetFlags.Beneficial ); break; }
				case SpellType.Line: { DoLineEffect( this ); break; }
				case SpellType.WideLine: { DoWideLineEffect( this ); break; }
				case SpellType.Cone: { DoConeEffect( this ); break; }
				case SpellType.Burst: { DoBurstEffect( this, Caster.Location ); break; }
				case SpellType.Area: { DoAreaEffect( this, Caster.Location ); break; }
				case SpellType.Party: { DoPartyEffect( this, Caster ); break; }
			}
		}
		#endregion



		#region BlueStuff
		/* Tile Map, 1 = small, 2 = large
		Y>-3-2-1 0 1 2 3
		-3|_|_|2|_|2|_|_|
		-2|_|2|1|_|1|2|_|
		-1|2|1|_|_|_|1|2|
		 0|_|_|_|X|_|_|_|
		 1|2|1|_|_|_|1|2|
		 2|_|2|1|_|1|2|_|
		 3|_|_|2|_|2|_|_|
		*/
		private static int[] m_AnimPoints =
		{
							-3, -1,		-3,  1,
					//-2, -2,						-2,  2,
			-1, -3,										-1,  3,
									//
			1, -3,										 1,  3,
					// 2, -2,						 2,  2,
							 3, -1,		 3, 1

			/* Small, it's too small to really see.
					-2, -1,		-2,  1,
			-1, -2						-1,  2,
						   // //
			 1, -2,						 1,  2,
					 2, -1,		 2,  1
			*/

		};

		private void BaseAnimation()
		{
			for( int i = 0; i < m_AnimPoints.Length - 1; i += 2 )
				Effects.SendMovingParticles( 
					new Entity( Serial.Zero, new Point3D( Caster.X, Caster.Y, Caster.Z + 10 ), Caster.Map ), 
					new Entity( Serial.Zero, new Point3D( Caster.X + m_AnimPoints[i], Caster.Y + m_AnimPoints[i+1], Caster.Z + 10 ), Caster.Map ), 
					0x1ED0, 2, 0, false, false, 1364, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
		}

		// For single target or personal based spells, override this method and code your spell effects here.
		public virtual void OnTarget( Mobile target )
		{
			// BlueSpellTarget calls this method for target based spells.
		}

		public virtual void OnTarget( Point3D point )
		{
			// BlueSpellTarget calls this method for target based spells.
		}

		// For spells that effect an area or party you will have to code the visual effects here so DoAreaEffect & DoBurstEffect can properly display them.
		public virtual void VisualEffects( Point3D point )
		{
			// List visual effects in here
		}

		// For spells that effect an area or party this method is to contain the spell's effects, such as damage delt, healing, status mods, etc.
		public virtual void SpellEffect( Mobile target )
		{
		}

		// The general scaler, if your shard runs a custom skill cap of 200 or something, you cna rescale the spells that check your skill here.
		public static double ScaleBySkill( Mobile from, SkillName skill )
		{
			if ( from == null )
				return 0.0;

			double bonus = (from.Skills[skill].Value > 100.0) ? 0.5 : 0.0;

			return ((from.Skills[skill].Value * 0.2) + bonus);
		}

		public static int GetDamage( Mobile from, Mobile target, SkillName skill, double multiplier )
		{
			if ( from == null )
				return 0;

			double value = ScaleBySkill( from, skill );
			int bonus = AosAttributes.GetValue( from, AosAttribute.SpellDamage );

			if ( bonus > 25 )
				bonus = 25;

			// Scale in the bonus and a +/- 10% for an apperence of randomization
			value = (value * (100 + bonus + Utility.RandomMinMax( -10, 10 ))) / 100;

			value *= multiplier;

			if ( target != null && target.Player )
				value /= 2;

			return (int)value;
		}

		// If you wish to change how can teach this is where you do it.
		public bool CanTeach( Mobile m )
		{
			// The access level check allows you to use blue monsters in events and disable learning from them by setting their access level to counselor. 
			return Caster.AccessLevel == AccessLevel.Player && Caster.Player == false; // && ( m.Skills[SkillName.Forensics].Value > RequiredSkill );
		}



		// Uses the Ability System's CanTarget check, largly more useful than CanBeHarmful since RunUO never coded it in a way to support creatures using area effects. Which leads to monsters armed with HitFireArea weapons killing other monsters >.<
		public static bool CanTarget( Mobile from, Mobile to, bool harm )
		{
			return Ability.CanTarget( from, to, harm, true/*check guild/party*/, false/*allow null*/ );
		}

		public static double GetDist( Point3D start, Point3D end )
		{
			int xdiff = start.X - end.X;
			int ydiff = start.Y - end.Y;
			return Math.Sqrt( (xdiff * xdiff) + (ydiff * ydiff) );
		}

		// Max save possible is 1d20+36: +15 (stat) + 6 (120 skill) + 6 (120 skill) + 3 (luck) + 6 (120 chiv)
		public static bool SavingThrow( Mobile m, DDSave ddsave, int dc )
		{
			int save = 0;

			switch( ddsave )
			{
				case DDSave.Fort:
				{
					if ( m.Player )
						save += m.Str / 10;
					else
						save += m.Str / 100;

					save += (int)(m.Skills[SkillName.Tactics].Value * 0.05);
					save += (int)(m.Skills[SkillName.Anatomy].Value * 0.05);
					break;
				}
				case DDSave.Refl:
				{
					if ( m.Player )
						save += m.Dex / 10;
					else
						save += m.Dex / 100;

					save += (int)(m.Skills[SkillName.Stealth].Value * 0.05);
					save += (int)(m.Skills[SkillName.Stealing].Value * 0.05);
					break;
				}
				case DDSave.Will:
				{
					if ( m.Player )
						save += m.Int / 10;
					else
						save += m.Int / 100;

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

			if ( !m.Player )
				save += (m.Fame / 2) / 1000;

			return save >= dc;
		}
		#endregion



		#region AreaEffects
		/*
		X>-3-2-1 0 1 2 3
		-3|U|U|_|_|_|_|_|
		-2|U|U|U|_|_|_|_|
		-1|_|U|U|U|_|_|_|
		 0|_|_|U|X|X|_|_|
		 1|_|_|_|X|D|D|_|
		 2|_|_|_|_|D|D|D|
		 3|_|_|_|_|_|D|D|
		*/
		// Produces three lines parrel with each other.
		public void DoWideLineEffect( BlueSpell spell )
		{
			Direction direction = Caster.Direction;
			Point3D point = new Point3D( Caster.X, Caster.Y, Caster.Z );

			switch( direction )
			{
				case (Direction)0x0: case (Direction)0x80: // North
				{
					DoLineEffect( spell, direction, new Point3D( point.X - 1, point.Y + 1, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X + 1, point.Y + 1, point.Z ) );
					break;
				}
				case (Direction)0x1: case (Direction)0x81: // Right
				{
					DoLineEffect( spell, direction, new Point3D( point.X - 1, point.Y, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X, point.Y + 1, point.Z ) );
					break;
				}
				case (Direction)0x2: case (Direction)0x82: // East
				{
					DoLineEffect( spell, direction, new Point3D( point.X - 1, point.Y + 1, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X - 1, point.Y - 1, point.Z ) );
					break;
				}
				case (Direction)0x3: case (Direction)0x83: // Down
				{
					DoLineEffect( spell, direction, new Point3D( point.X, point.Y - 1, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X - 1, point.Y, point.Z ) );
					break;
				}
				case (Direction)0x4: case (Direction)0x84: // South
				{
					DoLineEffect( spell, direction, new Point3D( point.X - 1, point.Y - 1, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X + 1, point.Y - 1, point.Z ) );
					break;
				}
				case (Direction)0x5: case (Direction)0x85:  // Left
				{
					DoLineEffect( spell, direction, new Point3D( point.X, point.Y - 1, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X + 1, point.Y, point.Z ) );
					break;
				}
				case (Direction)0x6: case (Direction)0x86: // West
				{
					DoLineEffect( spell, direction, new Point3D( point.X + 1, point.Y - 1, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X + 1, point.Y + 1, point.Z ) );
					break;
				}
				case (Direction)0x7: case (Direction)0x87: // Up
				{
					DoLineEffect( spell, direction, new Point3D( point.X + 1, point.Y, point.Z ) );
					DoLineEffect( spell, direction, new Point3D( point.X, point.Y + 1, point.Z ) );
					break;
				}
			}

			DoLineEffect( spell, direction, point );
		}

		// Overload: Single line from caster effect.
		public void DoLineEffect( BlueSpell spell )
		{
			DoLineEffect( spell, Caster.Direction, new Point3D( Caster.X, Caster.Y, Caster.Z ) );
		}

		// Creates a line, and gets everyone standing in the line.
		public void DoLineEffect( BlueSpell spell, Direction direction, Point3D point )
		{
			List<Mobile> targets = new List<Mobile>();
			List<Mobile> potentialtargets = new List<Mobile>();

			foreach ( Mobile mob in Caster.GetMobilesInRange( spell.Range ) )
			{
				if ( mob != null )
					if ( CanTarget( Caster, mob, spell.IsHarmful ) )
						potentialtargets.Add( mob );
			}

			for ( int i = 1; i < spell.Range+1; i++ )
			{
				switch( direction )
				{
					case (Direction)0x0: case (Direction)0x80: point.Y--; break; //North
					case (Direction)0x1: case (Direction)0x81: { point.X++; point.Y--; break; } //Right
					case (Direction)0x2: case (Direction)0x82: point.X++; break; //East
					case (Direction)0x3: case (Direction)0x83: { point.X++; point.Y++; break; } //Down
					case (Direction)0x4: case (Direction)0x84: point.Y++; break; //South
					case (Direction)0x5: case (Direction)0x85: { point.X--; point.Y++; break; } //Left
					case (Direction)0x6: case (Direction)0x86: point.X--; break; //West
					case (Direction)0x7: case (Direction)0x87: { point.X--; point.Y--; break; } //Up
					default: { break; }
				}

				if ( !Caster.CanSee( point ) )
					break;

				spell.VisualEffects( point );

				// Running a 0 range check on each square in the line may be better than running a massive area foreach and checking every's X/Y location in it I think.
				foreach ( Mobile mob in potentialtargets )
				{
					if ( mob != null && mob.X == point.X && mob.Y == point.Y ) // Ignore Z axis per RunUO's spells.
							targets.Add( mob );
				}
			}

			for ( int i = targets.Count - 1; i > 0; i-- )
				spell.SpellEffect( targets[i] );

			targets.Clear();
			FinishSequence();
		}

		// Spffy Cone thing
		public void DoConeEffect( BlueSpell spell )
		{
			int x = Caster.X, y = Caster.Y, xoffset = 0, yoffset = 0;
			List<Mobile> mobiles = new List<Mobile>();
			List<Point3D> points = new List<Point3D>();

			foreach ( Mobile m in Caster.GetMobilesInRange( Range ) )
			{
				if ( m != null )
					if ( CanTarget( Caster, m, spell.IsHarmful ) )
						mobiles.Add( m );
			}

			switch( Caster.Direction )
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

			for ( int i = 0; i < Range; i++ ) // goes to the sides
			{
				for ( int j = i + 1; j <= Range; j++ ) // j goes forward
				{
					if ( j >= i + 1 )
					{
						Point3D point = new Point3D( 0, 0, 0 );
						point.X = ( x + j * xoffset - i * yoffset );
						point.Y = ( y + j * yoffset + i * xoffset );
						point.Z = Caster.Map.GetAverageZ( point.X, point.Y );
						points.Add( point );

						if ( i > 0 )
						{
							point.X = ( x + j * xoffset + i * yoffset );
							point.Y = ( y + j * yoffset - i * xoffset );
							point.Z = Caster.Map.GetAverageZ( point.X, point.Y );
							points.Add( point );
						}
					}
				}
			}

			for ( int i = 0; i < points.Count; i++ )
			{
				if ( mobiles.Count > 0 )
				{
					for ( int j = mobiles.Count - 1; j > -1; j-- )
					{
						if ( mobiles[j].X == points[i].X && mobiles[j].Y == points[i].Y )
						{
							spell.SpellEffect( mobiles[j] );

							if ( mobiles[j] != null )
								mobiles.Remove( mobiles[j] );
						}
					}
				}

				spell.VisualEffects( points[i] );
			}

			mobiles.Clear();
			points.Clear();
		}

		// Just an overload to DoAreaEffect.
		public void DoBurstEffect( BlueSpell spell, Point3D target )
		{
			DoAreaEffect( spell, target, true );
		}

		// An overload.
		public void DoAreaEffect( BlueSpell spell, Point3D target )
		{
			DoAreaEffect( spell, target, false );
		}

		// It gets everyone near the center, if burst is true (which the DoBurstEffect ovverload handles) it does the math to make it a circle.
		public void DoAreaEffect( BlueSpell spell, Point3D target, bool burst )
		{
			if ( Caster.Map == null || spell.Range == 0 )
				return;

			List<Mobile> targets = new List<Mobile>();

			foreach ( Mobile mob in Caster.Map.GetMobilesInRange( target, spell.Range ) )
			{
				if ( mob == null )
					continue;

				if ( CanTarget( Caster, mob, spell.IsHarmful ) )
				{
					/*if ( !Caster.Map.LineOfSight( target, mob.Location ) )
					{
						Caster.Say("LOS fail. X:" + mob.X.ToString() + " Y:" + mob.Y.ToString() );
						continue;
					}
					else /*/if ( burst )
					{
						if ( GetDist( target, mob.Location ) > ((double)Range + 0.1) )
							continue;
					}

					targets.Add( mob );
				}
			}

			if ( burst )
			{
				Point3D point = new Point3D();

				for ( int i = -Range; i < Range + 1; i++ )
					for ( int j = -Range; j < Range + 1; j++ )
					{
						point.X = target.X + i;
						point.Y = target.Y + j;

						if ( GetDist( target, point ) < ((double)Range + 0.1) )
						{
								point.Z = Caster.Map.GetAverageZ( point.X, point.Y );
								spell.VisualEffects( point );
						}	
					}
			}

			for ( int i = targets.Count - 1; i > 0; i-- )
				spell.SpellEffect( targets[i] );

			targets.Clear();
			FinishSequence();
		}

		// Every member in the target's party is effected by whatever you coded in SpellEffect.
		public void DoPartyEffect( BlueSpell spell, Mobile target )
		{
			Party p = Party.Get( target );

			if ( p == null )
				return;

			for ( int i = 0; i < p.Members.Count; ++i )
			{
				PartyMemberInfo pmi = (PartyMemberInfo)p.Members[i];

				if ( pmi == null )
					continue;

				Mobile member = pmi.Mobile;

				if ( member == null )
					continue;

				if ( target.Map == member.Map && target.CanSee( member ) )
				{
					spell.SpellEffect( member );
				}
			}

			FinishSequence();
		}
		#endregion



		// Ever wondered why in the hell RunUO coded a new target class for every spell?
		// Me too.
		public class BlueSpellTarget : Target
		{
			private BlueSpell m_Owner;
			private bool m_AllowObjects;

			public BlueSpell Owner
			{
				get{ return m_Owner; }
				set{ m_Owner = value; }
			}

			public BlueSpellTarget( BlueSpell owner, TargetFlags flags ) : this( owner, flags, false )
			{
				m_Owner = owner;
			}

			public BlueSpellTarget( BlueSpell owner, TargetFlags flags, bool allowobjects ) : base( 12, allowobjects, flags )
			{
				m_Owner = owner;
				m_AllowObjects = allowobjects;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( !from.CanSee( o ) )
					from.SendLocalizedMessage( 500237 ); // Target can not be seen.

				if ( o is Mobile && !m_AllowObjects )
				{
					Mobile m = (Mobile)o;
					SpellHelper.Turn( from, m );
					m_Owner.OnTarget( m );
					from.Mana -= m_Owner.ScaleMana( m_Owner.GetMana() );
				}
				else if ( m_AllowObjects )
				{
					IPoint3D p = o as IPoint3D;

					if ( p != null )
					{
						Point3D point = new Point3D( p );
						m_Owner.OnTarget( point );
						from.Mana -= m_Owner.ScaleMana( m_Owner.GetMana() );
					}
				}
				else
					from.SendLocalizedMessage( 501857 ); // This spell won't work on that!
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

	}
}
/*




*/