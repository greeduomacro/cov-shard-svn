// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public sealed class Unique
	{
		public static void Check( Item from, object parent )
		{
			Mobile m = parent as Mobile;

			if ( m == null )
				m = ((Item)parent).RootParent as Mobile;

			if ( m != null )
			{
				bool drop = false;
				Type type = from.GetType();

				for( int i = 0; i < m.Items.Count; i++ )
				{
					// CS0246: Line 24: The type or namespace name 'type' could not be found (are you missing a using directive or an assembly reference?)
					// if ( m.Items[i] != null && m.Items[i] is type )

					if ( m.Items[i] != null && m.Items[i].GetType() == type )
						drop = true;
				}

				if ( !drop && m.Backpack != null )
				{
					Container c = (Container)m.Backpack;

					if ( c.FindItemsByType( type ).Length > 1 )
						drop = true;
				}

				if ( drop )
				{
					new InternalTimer( from ).Start();
				}
			}
		}

		private sealed class InternalTimer : Timer
		{
			private Item m_Item;

			public InternalTimer( Item item ) : base( TimeSpan.FromMilliseconds( 100.0 ) )
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				if ( m_Item == null || !(m_Item.RootParent is Mobile) )
					return;

				Mobile m = (Mobile)m_Item.RootParent;
				m.SendMessage( "You may only carry one unique item at a time." );
				m_Item.MoveToWorld( m.Location, m.Map );
				Stop();
			}
		}
	}

	public abstract class BaseUniqueItem : Item
	{
		public BaseUniqueItem( int itemid ) : base( itemid )
		{
		}

		public override void OnAdded( object parent )
		{
			Unique.Check( this, parent );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( 1114057, this.Name ); // ~1_VAL~
			list.Add( 1042971, "<ALIGN='CENTER'><BASEFONT COLOR='#FFFF00'>[Unique]</BASEFONT></ALIGN>" ); // ~1_NOTHING~
		}

		public BaseUniqueItem( Serial serial ) : base( serial )
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
		}
	}
}