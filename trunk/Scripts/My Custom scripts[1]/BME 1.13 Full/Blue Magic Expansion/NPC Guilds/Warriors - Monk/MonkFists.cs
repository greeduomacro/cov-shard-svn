// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class MonkFists : BaseMeleeWeapon
	{
		private int m_Teir;
		private MonkElement m_Stance;
		public int LightEnergy;
		public int DarkEnergy;
		public int MonkMinDamage;
		public int MonkMaxDamage;

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Disarm; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 0; } }
		public override int AosMinDamage{ get{ return MonkMinDamage; } }
		public override int AosMaxDamage{ get{ return MonkMaxDamage; } }
		public override int AosSpeed{ get{ return 50; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 0; } }
		public override int OldMinDamage{ get{ return MonkMinDamage; } }
		public override int OldMaxDamage{ get{ return MonkMaxDamage; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return -1; } }
		public override int DefMissSound{ get{ return -1; } }

		public override SkillName DefSkill{ get{ return SkillName.Wrestling; } }
		public override WeaponType DefType{ get{ return WeaponType.Fists; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Wrestle; } }

		[Constructable]
		public MonkFists() : base( 0x13EB )
		{
			Name = "Monk Gloves";
			Layer = Layer.Gloves;
			Weight = 2.0;
			Quality = WeaponQuality.Regular;

			WeaponAttributes.SelfRepair = 1;

			m_Teir = 0;
			MonkMinDamage = 1;
			MonkMaxDamage = 4;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent != from )
				return;

			if ( from.HasGump( typeof( MonkStrikeGump ) ) )
				from.CloseGump( typeof( MonkStrikeGump ) );

			from.SendGump( new MonkStrikeGump( from ) );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			if ( defender != null && m_Teir > 3 )
			{
				switch( m_Stance )
				{
					case MonkElement.Air: AOS.Damage( defender, attacker, 10/*Damage*/, 0, 0, 0, 0, 100 ); break;
					case MonkElement.Earth: AOS.Damage( defender, attacker, 10/*Damage*/, 100, 0, 0, 0, 0 ); break;
					case MonkElement.Fire: AOS.Damage( defender, attacker, 10/*Damage*/, 0, 100, 0, 0, 0 ); break;
					case MonkElement.Water: AOS.Damage( defender, attacker, 10/*Damage*/, 0, 0, 100, 0, 0 ); break;
				}
			}
		}

		public override bool CanEquip( Mobile from )
		{
			if ( from is PlayerMobile && from.AccessLevel == AccessLevel.Player )
			{
				if ( ((PlayerMobile)from).NpcGuild == NpcGuild.WarriorsGuild )
					return base.CanEquip( from );
				else
				{
					from.SendMessage( "You can only wear this if you are in the Warrior's Guild" );
					return false;
				}
			}

			return base.CanEquip( from );
		}

		public override bool OnEquip( Mobile from )
		{
			if ( from.FindItemOnLayer( Layer.TwoHanded ) != null )
				return false;

			if ( !from.EquipItem( new FalseGloves() ) )
				return false;

			Unique.Check( this, from );
			return true;
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Item item = ((Mobile)parent).FindItemOnLayer( Layer.TwoHanded );

				if ( item is FalseGloves )
					item.Delete();
			}
		}

		#region ContextStuff
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1114057, ("[Level " + m_Teir.ToString() + "]") ); // ~1_VAL~
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive && from == Parent && m_Teir > 0 )
			{
				list.Add( new AirStanceEntry( this ) );
				list.Add( new EarthStanceEntry( this ) );
				list.Add( new FireStanceEntry( this ) );
				list.Add( new WaterStanceEntry( this ) );
			}
		}

		private class AirStanceEntry : ContextMenuEntry
		{
			private MonkFists m_MF;

			public AirStanceEntry( MonkFists mf ) : base( 2070 ) // Air Elemental
			{
				m_MF = mf;
			}

			public override void OnClick()
			{
				m_MF.Stance = MonkElement.Air;

				Mobile m = m_MF.Parent as Mobile;

				if ( m == null )
					return;

				m.SendMessage( "You change your stance to air." );
				m.PlaySound( 0x029 );
			}
		}

		private class EarthStanceEntry : ContextMenuEntry
		{
			private MonkFists m_MF;

			public EarthStanceEntry( MonkFists mf ) : base( 2072 ) // Earth Elemental
			{
				m_MF = mf;
			}

			public override void OnClick()
			{
				m_MF.Stance = MonkElement.Earth;

				Mobile m = m_MF.Parent as Mobile;

				if ( m == null )
					return;

				m.SendMessage( "You change your stance to earth." );
				m.PlaySound( 0x22F );
			}
		}

		private class FireStanceEntry : ContextMenuEntry
		{
			private MonkFists m_MF;

			public FireStanceEntry( MonkFists mf ) : base( 2073 ) // Fire Elemental
			{
				m_MF = mf;
			}

			public override void OnClick()
			{
				m_MF.Stance = MonkElement.Fire;

				Mobile m = m_MF.Parent as Mobile;

				if ( m == null )
					return;

				m.SendMessage( "You change your stance to fire." );
				m.PlaySound( 0x227 );
			}
		}

		private class WaterStanceEntry : ContextMenuEntry
		{
			private MonkFists m_MF;

			public WaterStanceEntry( MonkFists mf ) : base( 2074 ) // Water Elemental
			{
				m_MF = mf;
			}

			public override void OnClick()
			{
				m_MF.Stance = MonkElement.Water;

				Mobile m = m_MF.Parent as Mobile;

				if ( m == null )
					return;

				m.SendMessage( "You change your stance to water." );
				m.PlaySound( 0x04F );
			}
		}
		#endregion

		#region Upgrades
		[CommandProperty( AccessLevel.GameMaster )]
		public int Teir
		{
			get{ return m_Teir; }
			set
			{
				if ( value < 0 )
					value = 0;
				if ( value > 5 )
					value = 5;

				m_Teir = value;
				MonkMinDamage = 1 + (3 * m_Teir);
				MonkMaxDamage = 4 + (3 * m_Teir);

				if ( m_Teir > 4 )
					ItemID = 0x2643; // Dragon Gloves
				else
					ItemID = 0x13EB; // Leather Gloves
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public MonkElement Stance
		{
			get { return m_Stance; }
			set
			{
				m_Stance = value;

				Attributes.BonusDex = 0;
				Attributes.DefendChance = 0;
				Attributes.WeaponSpeed = 0;
				Attributes.RegenHits = 0;
				Attributes.RegenStam = 0;
				Attributes.RegenMana = 0;
				Attributes.AttackChance = 0;
				Attributes.BonusStr = 0;
				Attributes.WeaponDamage = 0;
				Attributes.SpellDamage = 0;
				Attributes.LowerManaCost = 0;
				Attributes.BonusInt = 0;
				WeaponAttributes.HitLightning = 0;
				WeaponAttributes.HitFatigue = 0;
				WeaponAttributes.HitFireball = 0;
				WeaponAttributes.HitManaDrain = 0;
				WeaponAttributes.ResistPhysicalBonus = 0;
				WeaponAttributes.ResistFireBonus = 0;
				WeaponAttributes.ResistColdBonus = 0;
				WeaponAttributes.ResistEnergyBonus = 0;
				AosElementDamages.Fire = 0;
				AosElementDamages.Cold = 0;
				AosElementDamages.Energy = 0;

				int mod = m_Teir;

				if ( Parent is Mobile )
				{
					if ( ((Mobile)Parent).FindItemOnLayer( Layer.Arms ) is JidzTetka )
						++mod;
				}

				switch( value )
				{
					case MonkElement.Air:
					{
						Attributes.BonusDex = 5 + ( mod * 2 );
						Attributes.DefendChance = 5 + ( mod * 2 );
						Attributes.WeaponSpeed = 10 + ( mod * 3 );
						WeaponAttributes.ResistColdBonus = 5 + ( mod * 2 );
						AosElementDamages.Energy = ( mod * 10 );

						if ( m_Teir == 5 )
							WeaponAttributes.HitLightning = 25;

						break;
					}
					case MonkElement.Earth:
					{
						Attributes.RegenHits = 5 + ( mod * 2 );
						Attributes.RegenStam = 5 + ( mod * 2 );
						Attributes.RegenMana = 5 + ( mod * 2 );
						WeaponAttributes.ResistEnergyBonus = 5 + ( mod * 2 );

						if ( m_Teir == 5 )
							WeaponAttributes.HitFatigue = 25;

						break;
					}
					case MonkElement.Fire:
					{
						Attributes.AttackChance = 5 + ( mod * 2 );
						Attributes.BonusStr = 5 + ( mod * 2 );
						Attributes.WeaponDamage = 10 + ( mod * 3 );
						WeaponAttributes.ResistFireBonus = 5 + ( mod * 2 );
						AosElementDamages.Fire = ( mod * 10 );

						if ( m_Teir == 5 )
							WeaponAttributes.HitFireball = 25;

						break;
					}
					case MonkElement.Water:
					{
						Attributes.SpellDamage = 5 + mod;
						Attributes.LowerManaCost = 5 + mod;
						Attributes.BonusInt = 5 + ( mod * 2 );
						WeaponAttributes.ResistPhysicalBonus = 5 + ( mod * 2 );
						AosElementDamages.Cold = ( mod * 10 );

						if ( m_Teir == 5 )
							WeaponAttributes.HitManaDrain = 25;

						break;
					}
				}
			}
		}
		#endregion

		public MonkFists( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );

			writer.Write( (int) m_Teir );
			writer.Write( (int) m_Stance );
			writer.Write( (int) MonkMinDamage );
			writer.Write( (int) MonkMaxDamage );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_Teir = reader.ReadInt();
			m_Stance = (MonkElement)reader.ReadInt();
			MonkMinDamage = reader.ReadInt();
			MonkMaxDamage = reader.ReadInt();
		}
	}
}
