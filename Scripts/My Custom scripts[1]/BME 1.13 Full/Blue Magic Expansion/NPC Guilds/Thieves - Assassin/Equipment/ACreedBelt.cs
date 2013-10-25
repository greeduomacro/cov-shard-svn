// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedBelt : ACreedGarb
	{
		private int m_Ammo;
		public DateTime HealDelay;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Ammo
		{
			get { return m_Ammo; }
			set { m_Ammo = value; }
		}

		[Constructable]
		public ACreedBelt() : base( 11112, Layer.Waist )
		{
			Hue = 1175;
			m_Ammo = 0;
			HealDelay = DateTime.Now;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from != Parent )
				from.SendLocalizedMessage( 1112886 ); // You must be wearing this item in order to use it.
			else if ( m_Ammo < 1 )
				from.SendMessage( "You do not have any medicine ready for use." );
			else if ( HealDelay > DateTime.Now )
				from.SendLocalizedMessage( 501789 ); // You must wait before trying again.
			else
			{
				int delay = 11;
				delay -= (from.Dex / 30);

				if ( delay < 6 )
					delay = 6;

				HealDelay = DateTime.Now + TimeSpan.FromSeconds( delay );
				--m_Ammo;

				int heal = AosAttributes.GetValue( from, AosAttribute.EnhancePotions );

				if ( heal > 50 )
					heal = 50;

				heal += Utility.RandomMinMax( 15, 20 );

				if ( Level > 0 ) // +10% if upgraded.
					heal = ((heal*110)/100);

				from.SendMessage( "You quickly apply medicine and heal " + heal.ToString() + " hit points." );
				from.Hits += heal;
			}
		}

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

		public ACreedBelt( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (int)m_Ammo );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Ammo = reader.ReadInt();
			HealDelay = DateTime.Now;
		}
	}
}