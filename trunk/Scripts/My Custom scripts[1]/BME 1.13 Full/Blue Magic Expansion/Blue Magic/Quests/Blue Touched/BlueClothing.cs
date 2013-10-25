// Created by Peoharen
using System;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
/*
Insightful: Hit +12%, Defend +12%, Nightsight. Double; HCI +25%, DCI +25%.
Hasted: +1 FCR, +10% Melee Speed. Double; +2 FCR, +1 FC, +20% Speed.
Arcanic: +5% SDI, +10% LRC, & +5 Mage/Necro. Double; +10% SDI, +20% LRC, +10 Mage/Necro.
Skillful: 7 Tactics & Wrestling. Double; +15 Tactics/Wrestling.
Mighty: +10 Str & +15 HP. Double; +20 Str, +30 HP.
Nimble: +10 Dex & +15 Stamina. Double; +20 Dex, +30 Stam.
Intelligent: +10 Int & +15 Mana. Double; +20 Int, +30 Mana.
Regenerative: Regen All +3. Double; Regen All +7.
Resistive: Resist All +5 (total +10). Double; Resist All +15 (total +20).
Efficient (necklace only): Lower Mana Cost 15%. Double; Lower Mana Cost 30%.
*/
	public enum BlueEnhance
	{
		None,			// None
		Insightful,		// Hit +12%, Defend +12%, Nightsight				Double: DCI +25%, HCI +25%.
		Hasted,			// +1 FCR, +10% Melee Speed							Double: +2 FCR, +1 FC, +20% Speed.
		Arcanic,		// +5% SDI, +10% LRC, & +5 Mage/Necro				Double: +10% SDI, +20% LRC, +10 Mage/Necro.
		Skillful,		// 7 Tactics & Wrestling							Double: +15 Tactics/Wrestling.
		Mighty,			// +10 Str & +15 HP									Double: +20 Str, +30 HP.
		Nimble,			// +10 Dex & +15 Stamina							Double: +20 Dex, +30 Stam.
		Intelligent,	// +10 Int & +15 Mana								Double: +20 Int, +30 Mana.
		Regenerative,	// Regen All +3										Double: Regen All +7.
		Resistive,		// Resist All +5 (total +10)						Double: Resist All +15 (total +20).
		Efficient		// Lower Mana Cost 15%								Double: Lower Mana Cost 30%.
	}

	public class BlueClothing : BaseClothing
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		public BlueClothing( int itemid, Layer layer ) : base( itemid, layer, 1365 )
		{
			LootType = LootType.Blessed;
			Weight = 1.0;
		}

		#region NotKiddingWhenISayBlueMagesOnly
		public override bool CanEquip( Mobile from )
		{
			if ( BlueMageControl.IsBlueMage( from ) || from is BaseVendor || from is BlueMonster || from.AccessLevel > AccessLevel.Counselor )
				return base.CanEquip( from );
			else
			{
				from.SendMessage( "You may not wear this." );
				return false;
			}
		}

		public override bool AllowSecureTrade( Mobile from, Mobile to, Mobile newOwner, bool accepted )
		{
			if ( !BlueMageControl.IsBlueMage( from ) || !BlueMageControl.IsBlueMage( to ) )
				return false;

			return base.AllowSecureTrade( from, to, newOwner, accepted );
		}

		public override bool VerifyMove( Mobile from )
		{
			if ( BlueMageControl.IsBlueMage( from ) || from.AccessLevel > AccessLevel.Counselor )
				return base.VerifyMove( from );
			else
			{
				from.SendMessage( 1365, "Only a Blue Mage can touch this." );
				return false;
			}
		}
		#endregion

		#region NewPropDisplay
		public override void GetProperties( ObjectPropertyList list )
		{
			list.Add( 1114057, this.Name ); // ~1_VAL~

			if ( IsSecure )
				AddSecureProperty( list );
			else if ( IsLockedDown )
				AddLockedDownProperty( list );

			list.Add( 1038021 ); // blessed

			SkillBonuses.GetProperties( list );

			#region UO Props
			int prop;

			if ( (prop = Attributes.WeaponDamage) != 0 )
				list.Add( 1060401, prop.ToString() ); // damage increase ~1_val~%

			if ( (prop = Attributes.DefendChance) != 0 )
				list.Add( 1060408, prop.ToString() ); // defense chance increase ~1_val~%

			if ( (prop = Attributes.BonusDex) != 0 )
				list.Add( 1060409, prop.ToString() ); // dexterity bonus ~1_val~

			if ( (prop = Attributes.EnhancePotions) != 0 )
				list.Add( 1060411, prop.ToString() ); // enhance potions ~1_val~%

			if ( (prop = Attributes.CastRecovery) != 0 )
				list.Add( 1060412, prop.ToString() ); // faster cast recovery ~1_val~

			if ( (prop = Attributes.CastSpeed) != 0 )
				list.Add( 1060413, prop.ToString() ); // faster casting ~1_val~

			if ( (prop = Attributes.AttackChance) != 0 )
				list.Add( 1060415, prop.ToString() ); // hit chance increase ~1_val~%

			if ( (prop = Attributes.BonusHits) != 0 )
				list.Add( 1060431, prop.ToString() ); // hit point increase ~1_val~

			if ( (prop = Attributes.BonusInt) != 0 )
				list.Add( 1060432, prop.ToString() ); // intelligence bonus ~1_val~

			if ( (prop = Attributes.LowerManaCost) != 0 )
				list.Add( 1060433, prop.ToString() ); // lower mana cost ~1_val~%

			if ( (prop = Attributes.LowerRegCost) != 0 )
				list.Add( 1060434, prop.ToString() ); // lower reagent cost ~1_val~%

			// No lower requirements needed.

			if ( (prop = (Attributes.Luck)) != 0 )
				list.Add( 1060436, prop.ToString() ); // luck ~1_val~

			if ( (prop = Attributes.BonusMana) != 0 )
				list.Add( 1060439, prop.ToString() ); // mana increase ~1_val~

			if ( (prop = Attributes.NightSight) != 0 )
				list.Add( 1060441 ); // night sight

			if ( (prop = Attributes.ReflectPhysical) != 0 )
				list.Add( 1060442, prop.ToString() ); // reflect physical damage ~1_val~%

			// No spellchanelling needed.

			if ( (prop = Attributes.SpellDamage) != 0 )
				list.Add( 1060483, prop.ToString() ); // spell damage increase ~1_val~%

			if ( (prop = Attributes.BonusStam) != 0 )
				list.Add( 1060484, prop.ToString() ); // stamina increase ~1_val~

			if ( (prop = Attributes.BonusStr) != 0 )
				list.Add( 1060485, prop.ToString() ); // strength bonus ~1_val~

			if ( (prop = Attributes.WeaponSpeed) != 0 )
				list.Add( 1060486, prop.ToString() ); // swing speed increase ~1_val~%
			#endregion // UO props

			if ( m_EnhanceOne == BlueEnhance.Regenerative && m_EnhanceTwo == BlueEnhance.Regenerative )
				list.Add( 1042971, "Regen All: +" + Attributes.RegenHits.ToString() ); // ~1_NOTHING~
			else if ( m_EnhanceOne == BlueEnhance.Regenerative || m_EnhanceTwo == BlueEnhance.Regenerative )
				list.Add( 1042971, "Regen All: +" + Attributes.RegenHits.ToString() ); // ~1_NOTHING~

			if ( m_EnhanceOne == BlueEnhance.Resistive && m_EnhanceTwo == BlueEnhance.Resistive )
				list.Add( 1070722, "Resist All: +" + BasePhysicalResistance.ToString() ); // ~1_NOTHING~
			else if ( m_EnhanceOne == BlueEnhance.Resistive || m_EnhanceTwo == BlueEnhance.Resistive )
				list.Add( 1070722, "Resist All: +" + BasePhysicalResistance.ToString() ); // ~1_NOTHING~
			else
				list.Add( 1070722, "Resist All: +" + BasePhysicalResistance.ToString() ); // ~1_NOTHING~

			// GuildInvitationRequest.cs
			// m_Inviter.SendLocalizedMessage( 1063250, String.Format( "{0}\t{1}", player.Name, guild.Name ) ); // ~1_val~ has declined your invitation to join ~2_val~.
			if ( m_EnhanceOne != BlueEnhance.None || m_EnhanceTwo != BlueEnhance.None )
				list.Add( 1060847, "<ALIGN='CENTER><BASEFONT COLOR='#007FFF'>\t" + m_Title ); // ~1_Val~ ~2_Val~
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				switch( Layer )
				{
					case Layer.Helm:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Hat";	break;
					case Layer.Cloak:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Cloak";	break;
					case Layer.Shirt:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Shirt";	break;
					case Layer.Arms:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Arms";	break;
					case Layer.MiddleTorso:	Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Sash";	break;
					case Layer.Waist:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Belt";	break;
					case Layer.Pants:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Pants";	break;
					case Layer.Shoes:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Boots";	break;
					case Layer.Neck:		Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Blue Mage Necklace"; break;
				}

				// It would be spammed so no effect: ((Mobile)parent).FixedEffect( 0x376A, 1, 32, 1365, 0 );
			}

			base.OnAdded( parent );
		}

		public override void OnRemoved( object parent )
		{
			switch( Layer )
			{
				case Layer.Helm:		Name = "Blue Mage Hat";		break;
				case Layer.Cloak:		Name = "Blue Mage Cloak";	break;
				case Layer.Shirt:		Name = "Blue Mage Shirt";	break;
				case Layer.Arms:		Name = "Blue Mage Arms";	break;
				case Layer.MiddleTorso:	Name = "Blue Mage Sash";	break;
				case Layer.Waist:		Name = "Blue Mage Belt";	break;
				case Layer.Pants:		Name = "Blue Mage Pants";	break;
				case Layer.Shoes:		Name = "Blue Mage Boots";	break;
				case Layer.Neck:		Name = "Blue Mage Necklace"; break;
			}

			base.OnRemoved( parent );
		}
		#endregion

		#region Enhancements
		private BlueEnhance m_EnhanceOne;
		private BlueEnhance m_EnhanceTwo;
		private string m_Title;

		[CommandProperty( AccessLevel.GameMaster )]
		public BlueEnhance EnhanceOne
		{
			get { return m_EnhanceOne; }
			set { m_EnhanceOne = value; UpdateSelf(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public BlueEnhance EnhanceTwo
		{
			get { return m_EnhanceTwo; }
			set { m_EnhanceTwo = value; UpdateSelf(); }
		}

		public string Title
		{
			get { return m_Title; }
			set { m_Title = value; InvalidateProperties(); }
		}

		private void UpdateSelf()
		{
			WipeEnhance();
			AddEnhance( m_EnhanceOne );
			AddEnhance( m_EnhanceTwo );
			UpdateTitle();
		}

		private void WipeEnhance()
		{
			Attributes.AttackChance = 0;
			Attributes.DefendChance = 0;
			Attributes.NightSight = 0;
			Attributes.CastRecovery = 0;
			Attributes.CastSpeed = 0;
			Attributes.WeaponSpeed = 0;
			Attributes.SpellDamage = 0;
			Attributes.LowerManaCost = 0;
			SkillBonuses.SetValues( 0, SkillName.Tactics, 0.0 );
			SkillBonuses.SetValues( 1, SkillName.Wrestling, 0.0 );
			Attributes.BonusStr = 0;
			Attributes.BonusHits = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusStam = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusMana = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenStam = 0;
			Attributes.RegenMana = 0;
			Resistances.Physical = 0;
			Resistances.Fire = 0;
			Resistances.Cold = 0;
			Resistances.Poison = 0;
			Resistances.Energy = 0;
			Attributes.Luck = 0;

			Attributes.LowerManaCost = 0;

			Mobile m = Parent as Mobile;

			if ( m != null )
				m.UpdateResistances();

			m_Title = " ";
		}

		private void AddEnhance( BlueEnhance enhance )
		{
			switch( enhance )
			{
				case BlueEnhance.Insightful:
				{
					if ( Attributes.NightSight == 0 )
						Attributes.NightSight = 1;

					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.AttackChance = 25;
						Attributes.DefendChance = 25;
					}
					else
					{
						Attributes.AttackChance = 12;
						Attributes.DefendChance = 12;
					}

					break;
				}
				case BlueEnhance.Hasted:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.CastRecovery = 2;
						Attributes.CastSpeed = 1;
						Attributes.WeaponSpeed = 20;
					}
					else
					{
						Attributes.CastRecovery = 1;
						Attributes.WeaponSpeed = 10;
					}

					break;
				}
				case BlueEnhance.Arcanic:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.SpellDamage = 10;
						Attributes.LowerRegCost = 20;
						SkillBonuses.SetValues( 0, SkillName.Magery, 10.0 );
						SkillBonuses.SetValues( 1, SkillName.Necromancy, 10.0 );
					}
					else
					{
						Attributes.SpellDamage = 5;
						Attributes.LowerRegCost = 10;
						SkillBonuses.SetValues( 0, SkillName.Magery, 5.0 );
						SkillBonuses.SetValues( 1, SkillName.Necromancy, 5.0 );
					}

					break;
				}
				case BlueEnhance.Skillful:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						SkillBonuses.SetValues( 0, SkillName.Tactics, 15.0 );
						SkillBonuses.SetValues( 1, SkillName.Wrestling, 15.0 );
					}
					else
					{
						SkillBonuses.SetValues( 0, SkillName.Tactics, 7.0 );
						SkillBonuses.SetValues( 1, SkillName.Wrestling, 7.0 );
					}

					break;
				}
				case BlueEnhance.Mighty:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.BonusStr = 20;
						Attributes.BonusHits = 30;
					}
					else
					{
						Attributes.BonusStr = 10;
						Attributes.BonusHits = 15;
					}

					break;
				}
				case BlueEnhance.Nimble:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.BonusDex = 20;
						Attributes.BonusStam = 30;
					}
					else
					{
						Attributes.BonusDex = 10;
						Attributes.BonusStam = 15;
					}

					break;
				}
				case BlueEnhance.Intelligent:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.BonusInt = 20;
						Attributes.BonusMana = 30;
					}
					else
					{
						Attributes.BonusInt += 10;
						Attributes.BonusMana += 15;
					}

					break;
				}
				case BlueEnhance.Regenerative:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.RegenHits = 7;
						Attributes.RegenStam = 7;
						Attributes.RegenMana = 7;
					}
					else
					{
						Attributes.RegenHits = 3;
						Attributes.RegenStam = 3;
						Attributes.RegenMana = 3;
					}

					break;
				}
				case BlueEnhance.Resistive:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Resistances.Physical = 20;
						Resistances.Fire = 20;
						Resistances.Cold = 20;
						Resistances.Poison = 20;
						Resistances.Energy = 20;
					}
					else
					{
						Resistances.Physical = 10;
						Resistances.Fire = 10;
						Resistances.Cold = 10;
						Resistances.Poison = 10;
						Resistances.Energy = 10;
					}

					Mobile m = Parent as Mobile;

					if ( m != null )
						m.UpdateResistances();

					break;
				}
				case BlueEnhance.Efficient:
				{
					if ( m_EnhanceOne == m_EnhanceTwo )
					{
						Attributes.LowerManaCost = 30;
					}
					else
					{
						Attributes.LowerManaCost = 15;
					}

					break;
				}
			}

			Attributes.Luck += 100;
		}

		private void UpdateTitle()
		{
			string title = "";

			if ( m_EnhanceOne != BlueEnhance.None && m_EnhanceTwo != BlueEnhance.None )
			{
				// special combined title
				if ( m_EnhanceOne == m_EnhanceTwo )
				{
					switch( m_EnhanceOne )
					{
						case BlueEnhance.Insightful: { title = "Foresight"; break; }
						case BlueEnhance.Hasted: { title = "Quicksilver"; break; }
						case BlueEnhance.Arcanic: { title = "Archmagi"; break; }
						case BlueEnhance.Skillful: { title = "Experienced"; break; }
						case BlueEnhance.Mighty: { title = "Draconic"; break; }
						case BlueEnhance.Nimble: { title = "Mithral"; break; }
						case BlueEnhance.Intelligent: { title = "Knowledge"; break; }
						case BlueEnhance.Regenerative: { title = "Undying"; break; }
						case BlueEnhance.Resistive: { title = "Fortification"; break; }
						case BlueEnhance.Efficient: { title = "Wisdom"; break; }
					}
				}
				else
				{
					title += Enum.GetName( typeof( BlueEnhance ), m_EnhanceOne );

					switch( m_EnhanceTwo )
					{
						case BlueEnhance.Insightful: { title += " Insight"; break; }
						case BlueEnhance.Hasted: { title += " Haste"; break; }
						case BlueEnhance.Arcanic: { title += " Arcane"; break; }
						case BlueEnhance.Skillful: { title += " Skill"; break; }
						case BlueEnhance.Mighty: { title += " Might"; break; }
						case BlueEnhance.Nimble: { title += " Nimbleness"; break; }
						case BlueEnhance.Intelligent: { title += " Intelligence"; break; }
						case BlueEnhance.Regenerative: { title += " Regeneration"; break; }
						case BlueEnhance.Resistive: { title += " Resistance"; break; }
						case BlueEnhance.Efficient: { title += " Efficiency"; break; }
						
					}
				}
			}
			else if ( m_EnhanceOne != BlueEnhance.None )
			{
				title += Enum.GetName( typeof( BlueEnhance ), m_EnhanceOne );
			}
			else if ( m_EnhanceTwo != BlueEnhance.None )
			{
				title += Enum.GetName( typeof( BlueEnhance ), m_EnhanceTwo );
			}

			title += "</BASEFONT></ALIGN>";
			Title = title;
		}

		#endregion

		public BlueClothing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );

			writer.Write( (int) m_EnhanceOne );
			writer.Write( (int) m_EnhanceTwo );
			writer.Write( (string)m_Title );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			EnhanceOne = (BlueEnhance)reader.ReadInt();

			if ( version > 0 )
			{
				EnhanceTwo = (BlueEnhance)reader.ReadInt();
				m_Title = reader.ReadString();
			}
		}
	}
}
