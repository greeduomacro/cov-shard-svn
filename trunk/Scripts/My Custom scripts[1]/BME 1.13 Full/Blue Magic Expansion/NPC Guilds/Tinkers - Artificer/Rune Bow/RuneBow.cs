// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public enum RuneBowShotType
	{
		ForceShot,
		FireBlast,
		ColdBolts,
		AcidShot,
		EnergyStorm
	}

	public enum RuneBowBuildType
	{
		Accurate,
		Powerful,
		Quick,
		Balanced
	}

	public enum RuneBowRunes
	{
		Draconic,
		Champion,
		Faith,
		Paragon,
		Peerless
	}

	[FlipableAttribute( 0x26C3, 0x26CD )]
	public class RuneBow : BaseRanged
	{
		[Constructable]
		public RuneBow( RuneBowShotType shot, RuneBowBuildType build, RuneBowRunes runes ) : base( 0x26C3 )
		{
			ShotType = shot;
			BuildType = build;
			Runes = runes;

			Name = "Rune Bow";
			LootType = LootType.Blessed;
			UpdateTitle();

			Weight = 6.0;
			Attributes.SpellDamage = 25;
		}

		#region BaseRanged
		public override int EffectID{ get{ return 0x1BFE; } }
		public override Type AmmoType{ get{ return typeof( Bolt ); } }
		public override Item Ammo{ get{ return new Bolt(); } }

		//public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		//public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }

		public override int OldStrengthReq{ get{ return AosStrengthReq; } }
		public override int OldMinDamage{ get{ return AosMinDamage; } }
		public override int OldMaxDamage{ get{ return AosMaxDamage; } }
		public override int OldSpeed{ get{ return AosSpeed; } }
		public override int AosSpeed { get { return 20; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage
		{
			get
			{
				switch( BuildType )
				{
					case RuneBowBuildType.Accurate: return 10;
					case RuneBowBuildType.Powerful: return 20;
					case RuneBowBuildType.Quick: return 10;
					case RuneBowBuildType.Balanced: default: return 18;
				}
			}
		}

		public override int AosMaxDamage
		{
			get
			{
				switch( BuildType )
				{
					case RuneBowBuildType.Accurate: return 22;
					case RuneBowBuildType.Powerful: return 24;
					case RuneBowBuildType.Quick: return 12;
					case RuneBowBuildType.Balanced: default: return 22;
				}
			}
		}
		public override float MlSpeed
		{
			get
			{
				switch( BuildType )
				{
					case RuneBowBuildType.Accurate: return 5.00f;
					case RuneBowBuildType.Powerful: return 5.00f;
					case RuneBowBuildType.Quick: return 2.75f;
					case RuneBowBuildType.Balanced: default: return 4.50f;
				}
			}
		}

		public override int DefMaxRange{ get{ return 12; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }
		#endregion

		#region BaseWeapon
		public override SkillName DefSkill { get { return SkillName.ItemID; } }

		public override bool CanEquip( Mobile from )
		{
			if ( ArtificerSystem.IsArtificer( from ) )
				return base.CanEquip( from );
			else
			{
				from.SendMessage( "You can only use this if you are an Artificer." );
				return false;
			}
		}

		public override void OnRemoved( object parent )
		{
			if ( m_Timer != null )
			{
				m_Timer.Stop();
				m_Timer = null;
				m_Charge = 0;
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent == from )
			{
				if ( m_Timer == null )
				{
					m_Timer = new RuneBowChargeTimer( this );
					m_Timer.Start();
				}

				OpenGump();
			}
			else
				base.OnDoubleClick( from );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			switch( m_Runes )
			{
				case RuneBowRunes.Draconic:
				{
					if ( defender is BaseCreature && ((BaseCreature)defender).CanBreath )
						base.OnHit( attacker, defender, damageBonus + 1.0 );
					else
						base.OnHit( attacker, defender, damageBonus );
					break;
				}
				case RuneBowRunes.Champion:
				{
					if ( defender is BaseChampion )
						base.OnHit( attacker, defender, damageBonus + 1.0 );
					else
						base.OnHit( attacker, defender, damageBonus );
					break;
				}
				case RuneBowRunes.Faith:
				{
					if ( TrueSlayer.IsUndead( defender ) )
						base.OnHit( attacker, defender, damageBonus + 1.0 );
					else
						base.OnHit( attacker, defender, damageBonus );
					break;
				}
				case RuneBowRunes.Paragon:
				{
					if ( defender is BaseCreature && ((BaseCreature)defender).IsParagon )
						base.OnHit( attacker, defender, damageBonus + 1.0 );
					else
						base.OnHit( attacker, defender, damageBonus );
					break;
				}
				case RuneBowRunes.Peerless:
				{
					if ( defender is BasePeerless )
						base.OnHit( attacker, defender, damageBonus + 1.0 );
					else
						base.OnHit( attacker, defender, damageBonus );
					break;
				}
				default: base.OnHit( attacker, defender, damageBonus ); break;
			}
		}
		#endregion

		#region Custom
		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );
			list.Add( 1070722, "[" + m_Title + "]" ); // ~1_NOTHING~
		}

		private RuneBowShotType m_ShotType;
		private RuneBowBuildType m_BuildType;
		private RuneBowRunes m_Runes;
		private int m_Charge;
		private string m_Title;
		private RuneBowChargeTimer m_Timer;

		[CommandProperty( AccessLevel.GameMaster )]
		public RuneBowShotType ShotType
		{
			get { return m_ShotType; }
			set { m_ShotType = value; UpdateTitle(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public RuneBowBuildType BuildType
		{
			get { return m_BuildType; }
			set { m_BuildType = value; UpdateTitle(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public RuneBowRunes Runes
		{
			get { return m_Runes; }
			set { m_Runes = value; UpdateTitle(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charge
		{
			get { return m_Charge; }
			set { m_Charge = value; OpenGump(); }
		}

		private void UpdateTitle()
		{
			StringBuilder sb = new StringBuilder();

			switch( m_BuildType )
			{
				case RuneBowBuildType.Accurate: sb.Append( "An accurate " ); break;
				case RuneBowBuildType.Powerful: sb.Append( "A powerful " ); break;
				case RuneBowBuildType.Quick: sb.Append( "a quick " ); break;
				case RuneBowBuildType.Balanced: sb.Append( "a balanced " ); break;
			}

			switch( m_Runes )
			{
				case RuneBowRunes.Draconic: sb.Append( "draconic " ); break;
				case RuneBowRunes.Champion: sb.Append( "champion " ); break;
				case RuneBowRunes.Faith: sb.Append( "faithful " ); break;
				case RuneBowRunes.Paragon: sb.Append( "paragon " ); break;
				case RuneBowRunes.Peerless: sb.Append( "peerless " ); break;
			}

			sb.Append( "Rune Bow of " );

			switch( m_ShotType )
			{
				case RuneBowShotType.ForceShot: sb.Append( "force shot" ); break;
				case RuneBowShotType.FireBlast: sb.Append( "fire blast" ); break;
				case RuneBowShotType.ColdBolts: sb.Append( "cold bolts" ); break;
				case RuneBowShotType.AcidShot: sb.Append( "acid shot" ); break;
				case RuneBowShotType.EnergyStorm: sb.Append( "energy storm" ); break;
			}

			m_Title = sb.ToString();
		}

		public void OpenGump()
		{
			if ( Parent is PlayerMobile )
			{
				Mobile m = (PlayerMobile)Parent;

				m.CloseGump( typeof( RuneBowChargeGump ) );
				m.SendGump( new RuneBowChargeGump( this )  );
			}
		}

		public void FireRuneBow( Mobile from )
		{
			if ( from == null || from != Parent )
				return;

			if ( Charge / 20 < 1 )
			{
				from.SendMessage( "You need to wait for this to recharge." );
				return;
			}
			else if ( from.Combatant == null )
			{
				from.SendMessage( "You have no combatant and so you hold off using your bow." );
				return;
			}
			else if ( from.InRange( from.Combatant, 12 ) )
			{
				from.SendMessage( "That is out of range." );
				return;
			}

			switch( m_ShotType )
			{
				case RuneBowShotType.ForceShot: // Shot
				{
					from.MovingEffect( from.Combatant, 0x1BFE, 18, 1, false, false, 1272, 0 );
					from.Combatant.PlaySound( 0x3F );
					AOS.Damage( from.Combatant, from, GetDamage( from, false ), 100, 0, 0, 0, 0 );
					break;
				}
				case RuneBowShotType.FireBlast: // Explosive Shot
				{
					List<Mobile> targets = new List<Mobile>();
					targets.Add( from.Combatant );

					foreach ( Mobile mob in from.Combatant.GetMobilesInRange( 2 ) )
					{
						if ( mob != null && mob != from )
							if ( from.CanBeHarmful( mob ) )
								targets.Add( mob );
					}

					for ( int i = targets.Count - 1; i > 0; i-- )
					{
						if ( targets[i] != null )
						{
							targets[i].FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
							targets[i].PlaySound( 0x307 );
							AOS.Damage( targets[i], from, GetDamage( from, false ), 0, 0, 0, 0, 100 );
						}
					}

					targets.Clear();
					break;
				}
				case RuneBowShotType.ColdBolts: // Line
				{
					List<Mobile> targets = new List<Mobile>();
					List<Mobile> potentialtargets = new List<Mobile>();
					Point3D point = new Point3D( from.Location );

					foreach ( Mobile mob in from.GetMobilesInRange( 6 ) )
					{
						if ( mob != null )
							if ( from.CanBeHarmful( mob ) )
								potentialtargets.Add( mob );
					}

					for ( int i = 1; i < 6; i++ )
					{
						switch( from.Direction )
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

						if ( !from.CanSee( point ) )
							break;

						foreach ( Mobile mob in potentialtargets )
						{
							if ( mob != null && mob.X == point.X && mob.Y == point.Y ) // Ignore Z axis per RunUO's spells.
								targets.Add( mob );
						}
					}

					Effects.SendMovingParticles( 
						from, 
						new Entity( Serial.Zero, point, from.Map ), 
						0x22C8, 10, 0, false, false, 1281/*hue*/, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

					for ( int i = targets.Count - 1; i > 0; i-- )
					{
						if ( targets[i] != null )
							AOS.Damage( targets[i], from, GetDamage( from, false ), 0, 0, 0, 0, 100 );
					}

					targets.Clear();
					potentialtargets.Clear();
					break;
				}
				case RuneBowShotType.AcidShot: // Shot
				{
					from.MovingEffect( from.Combatant, 0x1BFE, 18, 1, false, false, 1271, 0 );
					from.Combatant.PlaySound( 0x28 );
					AOS.Damage( from.Combatant, from, GetDamage( from, false ), 0, 0, 0, 100, 0 );
					break;
				}
				case RuneBowShotType.EnergyStorm:
				{
					from.Combatant.PlaySound( 0x29 );
					break;
				}
			}

			Charge = 0;
		}

		private int GetDamage( Mobile from, bool multi )
		{
			/*
				Base Damage (affected by spell damage increase)
					Single Target
						1: Deals 4d3+(1),    10~17.
						2: Deals 6d3+(1d2),  12~30.
						3: Deals 8d3+(1d4),  14~48.
						4: Deals 10d3+(1d6), 16~66.
						5: Deals 12d3+(1d8), 18~84.
					Multi Target
						As above, but -33%.
				Bonus Damage
					Intelligence: Int / 15 (max +10)
					Knowledge: ItemID + Arms Lore / 10 (max +20, since no PSes exist)
			*/

			int damage = 0;
			int level = Charge / 20;

			if ( level < 0 )
				return 1;
			else if ( level > 5 )
				level = 5;

			damage += Utility.Dice( (2*level)+2, 3, 0 ); // 100 (level) / 20 = 5, 5*2+2=12, 12*3=36, Max 12~36.

			if ( level == 1 )
				damage += level;
			else
				damage += Utility.Dice( level, (level*2)-2, 0 ); // 10d8=80, 10~80.

			damage += from.Int / 15; // 150 Int cap, Max +10.
			damage += (int)((from.Skills[SkillName.ItemID].Value + from.Skills[SkillName.ArmsLore].Value) / 10); // 100.0 Cap (or even 120), Max 10~12.
			// Min  44 = 12 (charge) + 10 (bonus) + 10 (int) + 12 (skill)
			// Max 138 = 36 (charge) + 80 (bonus) + 10 (int) + 12 (skill)

			damage *= 100 + AosAttributes.GetValue( from, AosAttribute.SpellDamage );
			damage /= 100;

			if ( multi )
				damage -= (damage / 3);
				
			return damage;
		}
		#endregion

		public RuneBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_ShotType );
			writer.Write( (int) m_BuildType );
			writer.Write( (int) m_Runes );
			writer.Write( (string) m_Title );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_ShotType = (RuneBowShotType)reader.ReadInt();
			m_BuildType = (RuneBowBuildType)reader.ReadInt();
			m_Runes = (RuneBowRunes)reader.ReadInt();
			m_Title = reader.ReadString();
		}

		public class RuneBowChargeTimer : Timer
		{
			private RuneBow m_RuneBow;

			public RuneBowChargeTimer( RuneBow bow ) : base( TimeSpan.FromSeconds( 2 ), TimeSpan.FromSeconds( 2 ) )
			{
				m_RuneBow = bow;
			}

			protected override void OnTick()
			{
				if ( m_RuneBow == null )
					Stop();
				else if ( m_RuneBow.Charge < 100 )
					m_RuneBow.Charge += 5;
			}
		}

		public class RuneBowChargeGump : Gump
		{
			private RuneBow m_RuneBow;

			public RuneBowChargeGump( RuneBow bow ) : base( 0, 0 )
			{
				m_RuneBow = bow;

				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddPage( 0 );

				AddBackground( 0, 0, 160, 90, 9270 );
				AddImage( 30, 40, 9750 );
				AddLabel( 15, 15, 1191, "Rune Bow Charge" );
				AddLabel( 45, 55, 1191, "Fire:" );
				AddButton( 85, 55, 9903, 9904, 1 /*Button*/, GumpButtonType.Reply, 0 );

				if ( bow != null && bow.Charge > 10 )
				{
					AddImageTiled( 30, 40, bow.Charge - 5, 7, 9751 );
				}
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( info.ButtonID == 1 && m_RuneBow != null && m_RuneBow.Parent == sender.Mobile )
				{
					m_RuneBow.FireRuneBow( sender.Mobile );
					m_RuneBow.OpenGump();
				}
			}
		}

	}
}