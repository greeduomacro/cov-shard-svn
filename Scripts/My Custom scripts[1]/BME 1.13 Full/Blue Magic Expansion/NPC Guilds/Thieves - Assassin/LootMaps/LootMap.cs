// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class LootMap : MapItem
	{
		private FillableContentType m_LootContentType;

		[CommandProperty( AccessLevel.GameMaster )]
		public FillableContentType LootContentType
		{
			get{ return m_LootContentType; }
			set{ m_LootContentType = value; }
		}

		[Constructable]
		public LootMap() : base()
		{
			//SetDisplay( 0, 0, 5119, 4095, 400, 400 );
			LootContentType = FillableContentType.None;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from == null )
				return;
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			if ( !AssassinControl.IsAssassin( from ) && from.AccessLevel == AccessLevel.Player )
				from.SendLocalizedMessage( 501702 ); // Only Members of the thieves guild are trained to use this item.
			if ( (from.Map != Map.Felucca) && (from.Map != Map.Trammel) )
				from.SendMessage( "This only works in Trammel and Felucca" );
			else
			{
				ClearPins();
				FillableContainer fc;
				int x = 0, y = 0;

				foreach ( Item item in World.Items.Values )
				{
					if ( item == null || item.Map != from.Map )
						continue;
					else if ( item is FillableContainer )
					{
						fc = (FillableContainer)item;

						if ( fc.ContentType == FillableContentType.None )
							continue;
						else if ( fc.ContentType == FillableContentType.Library && LootContentType != FillableContentType.Library )
							continue; // Just to many of those damn things.
						else if ( LootContentType != FillableContentType.None && fc.ContentType != LootContentType )
							continue;

						if ( (item.X >= Bounds.Start.X) && (item.X <= Bounds.End.X) && (item.Y >= Bounds.Start.Y) && (item.Y <= Bounds.End.Y) )
						{
							x = (int)( (item.X - Bounds.Start.X) / ((double)Bounds.Width / (double)Width) );
							y = (int)( (item.Y - Bounds.Start.Y) / ((double)Bounds.Height / (double)Height) );

							if ( Pins.Count < 50 )
								AddPin( x, y );
						}

					}
				}

				DisplayTo( from );
			}

		}

		public LootMap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize (writer);
			writer.Write( (int) 1 ); // version
			writer.Write( (int) m_LootContentType );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize (reader);
			int version = reader.ReadInt();
			m_LootContentType = (FillableContentType)reader.ReadInt();
		}
	}
}
