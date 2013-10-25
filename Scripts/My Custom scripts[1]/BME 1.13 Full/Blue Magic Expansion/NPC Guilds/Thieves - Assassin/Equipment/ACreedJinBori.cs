// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class ACreedJinBori : ACreedGarb
	{
		private int m_Ammo;
		public DateTime ThrowDelay;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Ammo
		{
			get { return m_Ammo; }
			set { m_Ammo = value; }
		}

		[Constructable]
		public ACreedJinBori() : base( 10145, Layer.MiddleTorso )
		{
			Hue = 1175;
			m_Ammo = 0;
			ThrowDelay = DateTime.Now;
		}

		#region ThrowingDagger
		public override void OnDoubleClick( Mobile from )
		{
			if ( from != Parent )
				from.SendLocalizedMessage( 1112886 ); // You must be wearing this item in order to use it.
			else if ( m_Ammo < 1 )
				from.SendMessage( "You do not have any knives ready for use." );
			else if ( ThrowDelay > DateTime.Now )
				from.SendLocalizedMessage( 501789 ); // You must wait before trying again.
			else
			{
				from.BeginTarget( 10, false, TargetFlags.Harmful, new TargetStateCallback<ACreedJinBori>( Target ), this );
			}
		}

		public static void Target( Mobile from, object target, ACreedJinBori jinbori )
		{
			if ( from == null || jinbori.Parent != from )
				return;

			Mobile to = target as Mobile;

			if ( to == null )
				return;

			int delay = 11;
			delay -= (from.Dex / 30);

			if ( delay < 6 )
				delay = 6;

			jinbori.ThrowDelay = DateTime.Now + TimeSpan.FromSeconds( delay );
			--jinbori.m_Ammo;

			from.Direction = from.GetDirectionTo( to );
			from.Animate( 31, 5, 1, true, false, 0 );
			// SendMovingEffect( IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes )
			Effects.SendMovingEffect( from, to, 0xF51, 10, 1, false, false );

			Timer.DelayCall( TimeSpan.FromSeconds( 1 ), new TimerStateCallback( jinbori.ACreedDaggerDamage_CallBack ), to );
		}

		public void ACreedDaggerDamage_CallBack( object state )
		{
			Mobile from = Parent as Mobile;
			Mobile to = state as Mobile;

			if ( from == null || to == null )
				return;

			int damage = Utility.RandomMinMax( 10, 15 );
			int bonus = (from.Str / 5 );

			if ( bonus > 25 )
				bonus = 25;

			damage += bonus;

			bonus = AosAttributes.GetValue( from, AosAttribute.WeaponDamage );

			if ( from.FindItemOnLayer( Layer.Arms ) is ACreedBoneArms )
			{
				if ( to.Hits == to.HitsMax || to.Hits < (to.HitsMax/10) )
					bonus += 200;
			}

			if ( bonus > 300 )
				bonus = 300;

			if ( Level > 0 ) // +25% DI if upgraded, uncapped.
				bonus += 25;

			damage = ( damage * (100 + bonus) ) / 100;

			AOS.Damage( to, from, damage, 100, 0, 0, 0, 0 );
		}
		#endregion

		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );
			list.Add( 1070722, "<BASEFONT ALIGN='CENTER' COLOR='#C0C0C0'>Ammo: " + m_Ammo.ToString() + "</BASEFONT>" ); // ~1_NOTHING~
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( IsChildOf( from ) )
			{
				list.Add( new LoadACreedGarbEntry( this ) );
				list.Add( new UnloadACreedGarbEntry( this ) );
			}
		}

		public ACreedJinBori( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (int) m_Ammo );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Ammo = reader.ReadInt();
			ThrowDelay = DateTime.Now;
		}
	}
}