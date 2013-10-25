// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class BlueSerpentMark : Item
	{
		private Mobile m_Owner;
		private int m_VisibleItemID;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Owner
		{
			get { return m_Owner; }
			set { m_Owner = value; }
		}

		[Constructable]
		public BlueSerpentMark() : this( null, 1181 )
		{
		}

		[Constructable]
		public BlueSerpentMark( Mobile owner, int itemid ) : base( 0x2199 )
		{
			Movable = false;
			m_VisibleItemID = itemid;
			Owner = owner;
		}

		public override bool HandlesOnMovement{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( !m.InRange( this.GetWorldLocation(), 2 ) )
				return;
			else if ( m == Owner && m.Alive )
			{
				Container pack = m.Backpack;

				if ( pack == null )
					m.SendMessage( 33, "Error: You do not have a backpack. Please equip a backpack." );
				else
				{
					ItemID = m_VisibleItemID;
					pack.DropItem( this );
				}
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this.GetWorldLocation(), 2 ) )
				from.SendLocalizedMessage( 500446 ); // That is too far away.
			else if ( Parent == from )
				from.SendMessage( 1365, "That is already in your backpack." );
			else if ( from == Owner )
			{
				Container pack = from.Backpack;

				if ( pack == null )
					from.SendMessage( 33, "Error: You do not have a backpack. Please equip a backpack." );
				else
				{
					ItemID = m_VisibleItemID;
					pack.DropItem( this );
				}
			}
			else if ( from.AccessLevel >= AccessLevel.GameMaster )
				from.SendMessage( 1365, "Please do not mess with this tile, doing so will greatly affect a player's quest for this." );
		}

		protected override Packet GetWorldPacketFor( NetState state )
		{
			Mobile mob = state.Mobile;

			if ( mob != null && (mob.AccessLevel >= AccessLevel.GameMaster || mob == m_Owner ) )
				return new RevealItemPacket( this, m_VisibleItemID );

			return base.GetWorldPacketFor( state );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
		}

		public BlueSerpentMark( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (Mobile) m_Owner );
			writer.Write( (int) m_VisibleItemID );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Owner = reader.ReadMobile();
			m_VisibleItemID = reader.ReadInt();
		}

		
		public sealed class RevealItemPacket : Packet
		{
			public RevealItemPacket( Item item, int itemid ) : base( 0x1A )
			{
				this.EnsureCapacity( 20 );

				// 14 base length
				// +2 - Amount
				// +2 - Hue
				// +1 - Flags

				uint serial = (uint)item.Serial.Value;
				int itemID = itemid;
				int amount = item.Amount;
				Point3D loc = item.Location;
				int x = loc.X;
				int y = loc.Y;
				int hue = item.Hue;
				int flags = item.GetPacketFlags();
				int direction = (int)item.Direction;

				if ( amount != 0 )
					serial |= 0x80000000;
				else
					serial &= 0x7FFFFFFF;

				m_Stream.Write( (uint) serial );
				m_Stream.Write( (short) (itemID & 0x7FFF) );

				if ( amount != 0 )
					m_Stream.Write( (short) amount );

				x &= 0x7FFF;

				if ( direction != 0 )
					x |= 0x8000;

				m_Stream.Write( (short) x );

				y &= 0x3FFF;

				if ( hue != 0 )
					y |= 0x8000;

				if ( flags != 0 )
					y |= 0x4000;

				m_Stream.Write( (short) y );

				if ( direction != 0 )
					m_Stream.Write( (byte) direction );

				m_Stream.Write( (sbyte) loc.Z );

				if ( hue != 0 )
					m_Stream.Write( (ushort) hue );

				if ( flags != 0 )
					m_Stream.Write( (byte) flags );
			}
		}
		

	}
}