// Created by Peoharen
using System;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class ACreedGarb : BaseClothing
	{
		private int m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level
		{
			get { return m_Level; }
			set
			{
				if ( value > 2 )
					value = 2;

				m_Level = value;
				UpdateLevel();

				if ( m_Level > 1 )
					LootType = LootType.Blessed;
				else
					LootType = LootType.Regular;
			}
		}

		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		public ACreedGarb( int itemid, Layer layer ) : base( itemid, layer, 0 )
		{
			Name = "Assassin's Garb";
			Weight = 3.0;
			Attributes.BonusHits = 15;
			Attributes.RegenHits = 1;
			Attributes.RegenMana = 1;
			Attributes.BonusStr = 5;
			Attributes.BonusDex = 3;
			Attributes.AttackChance = 2;
			Attributes.DefendChance = 2;
			Attributes.WeaponSpeed = 2;
			Attributes.WeaponDamage = 5;
			Attributes.Luck = 100;
			m_Level = 0;
		}

		public virtual void UpdateLevel()
		{
			if ( Level == 0 )
			{
			}
			else
			{
			}
		}

		#region Props and such
		public override bool CanEquip( Mobile from )
		{
			if ( from is PlayerMobile && from.AccessLevel == AccessLevel.Player )
			{
				if ( ((PlayerMobile)from).NpcGuild == NpcGuild.ThievesGuild )
					return base.CanEquip( from );
				else
				{
					from.SendMessage( "You can only wear this if you are in the Thieves' Guild" );
					return false;
				}
			}

			return base.CanEquip( from );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( 1114057, this.Name ); // ~1_VAL~

			// AMMO: list.Add( 1070722, "<BASEFONT ALIGN='CENTER' COLOR='#C0C0C0'>Special" ); // ~1_NOTHING~
			// OTHER: list.Add( 1042971, "<BASEFONT ALIGN='CENTER' COLOR='#C0C0C0'>[Assassin]" ); // ~1_NOTHING~
		}

		public override void AddResistanceProperties( ObjectPropertyList list )
		{
			list.Add( 1060847, "Resist All:\t+6" ); // ~1_Val~ ~2_Val~
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
				Name = "<BASEFONT ALIGN='CENTER' COLOR='#C0C0C0'>Assassin's Garb";

			base.OnAdded( parent );
		}

		public override void OnRemoved( object parent )
		{
			Name = "Assassin's Garb";
			base.OnRemoved( parent );
		}
		#endregion

		public override int OnHit( BaseWeapon weapon, int damageTaken )
		{
			if ( Level > 0 && Utility.Random( 100 ) > 90 && Parent is Mobile )
			{
				Mobile m = (Mobile)Parent;

				if ( m.FindItemOnLayer( Layer.Shoes ) is ACreedThighBoots )
				{
					m.SendLocalizedMessage( 1063120 ); // You feel that you might be able to deflect any attack!
					Spells.Bushido.Evasion.BeginEvasion( m );
				}
			}

			return base.OnHit( weapon, damageTaken );
		}

		public ACreedGarb( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (int) m_Level );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = reader.ReadInt();
		}

		#region Context Menu
		public class LoadACreedGarbEntry : ContextMenuEntry
		{
			private ACreedGarb Garb;

			public LoadACreedGarbEntry( ACreedGarb garb ) : base( 6230, 0 ) // Refill from stock
			{
				Garb = garb;

				if ( Garb is ACreedJinBori )
				{
					ACreedJinBori jinbori = (ACreedJinBori)Garb;
					Enabled = jinbori.Ammo < (jinbori.Level * 5);
				}
				else if ( Garb is ACreedBelt )
				{
					ACreedBelt belt = (ACreedBelt)Garb;
					Enabled = belt.Ammo < (belt.Level * 5);
				}
			}

			public override void OnClick()
			{
				if ( Garb is ACreedJinBori )
					Owner.From.SendMessage( "Select a dagger in your backpack to load into the vest (enhancements will be removed)." );
				else if ( Garb is ACreedBelt )
					Owner.From.SendMessage( "Select a greater heal potion in your backpack to load into the belt." );

				Owner.From.BeginTarget( 10, false, TargetFlags.None, new TargetStateCallback<ACreedGarb>( LoadTarget_Callback ), Garb );
			}
		}

		public class UnloadACreedGarbEntry : ContextMenuEntry
		{
			private ACreedGarb Garb;

			public UnloadACreedGarbEntry( ACreedGarb garb ) : base( 6221, 0 ) // Unpack Container
			{
				Garb = garb;
			}

			public override void OnClick()
			{

			}
		}

		public static void LoadTarget_Callback( Mobile from, object target, ACreedGarb garb )
		{
			if ( garb is ACreedJinBori )
			{
				Dagger dagger = target as Dagger;

				if ( dagger == null )
					from.SendMessage( "That isn't a dagger." );
				else if ( dagger.RootParent != from )
					from.SendMessage( "That isn't yours to load." );
				else
				{
					dagger.Delete();
					from.SendMessage( "You load the dagger into the vest." );
					((ACreedJinBori)garb).Ammo++;

					from.SendMessage( "Select a dagger in your backpack to load into the vest (enhancements will be removed)." );
					from.BeginTarget( 10, false, TargetFlags.None, new TargetStateCallback<ACreedGarb>( LoadTarget_Callback ), (ACreedGarb)garb );
				}
			}
			else if ( garb is ACreedBelt )
			{
				GreaterHealPotion potion = target as GreaterHealPotion;

				if ( potion == null )
					from.SendMessage( "That isn't a greater heal potion." );
				else if ( potion.RootParent != from )
					from.SendMessage( "That isn't yours to load." );
				else
				{
					potion.Consume();
					from.SendMessage( "You load the potion into the belt." );
					((ACreedBelt)garb).Ammo++;

					from.SendMessage( "Select a greater heal potion in your backpack to load into the belt." );
					from.BeginTarget( 10, false, TargetFlags.None, new TargetStateCallback<ACreedGarb>( LoadTarget_Callback ), (ACreedGarb)garb );
				}
			}
		}
		#endregion

	}
}
