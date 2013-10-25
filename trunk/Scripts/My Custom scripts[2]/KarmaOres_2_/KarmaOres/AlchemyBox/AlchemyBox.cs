
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class AlchemyBox : Item//BaseContainer
	{
		private static Type[][] m_AllTypes = new Type[][]
		{
			AlchemyBoxTypes.Bottle,
			AlchemyBoxTypes.PotionKeg,
			AlchemyBoxTypes.NightSightPotion,
           // AlchemyBoxTypes.LesserCurePotion,
            AlchemyBoxTypes.CurePotion,
            //AlchemyBoxTypes.GreaterCurePotion,
            AlchemyBoxTypes.AgilityPotion,
            //AlchemyBoxTypes.GreaterAgilityPotion,
            AlchemyBoxTypes.StrengthPotion,
           // AlchemyBoxTypes.GreaterStrengthPotion,
            //AlchemyBoxTypes.LesserPoisonPotion,
            AlchemyBoxTypes.PoisonPotion,
            //AlchemyBoxTypes.GreaterPoisonPotion,
            //AlchemyBoxTypes.DeadlyPoisonPotion,
            //AlchemyBoxTypes.LesserHealPotion,
            AlchemyBoxTypes.RefreshPotion,
            ////////////////////////////////////////
            AlchemyBoxTypes.HealPotion,
            //AlchemyBoxTypes.GreaterHealPotion,
            //AlchemyBoxTypes.LesserExplosionPotion,
            AlchemyBoxTypes.ExplosionPotion
            //AlchemyBoxTypes.GreaterExplosionPotion
		};
		public Type[][] AllTypes{ get{ return m_AllTypes; } }

		private Hashtable m_Resources;
		public Hashtable Resources{ get{ return m_Resources; } }

		[Constructable]
		public AlchemyBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 1.0;
			Hue = 51;
			Name = "Alchemy Box";

			m_Resources = new Hashtable();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
				from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				from.SendGump( new AlchemyBoxGump( from, this, AlchemyBoxGump.Pages.Start ) );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			AddNameProperty( list );
		}

		public bool TryAdd( Item item )
		{
			foreach( Type[] cat in m_AllTypes )
			{
				foreach( Type type in cat )
				{
					if( item.GetType() == type )
					{
						if( m_Resources.ContainsKey( type ) && (int)m_Resources[type] + item.Amount >= 100000 )
						{
							this.PublicOverheadMessage( MessageType.Whisper, 0, false, "I cannot hold more of that resource!" );
							return false;
						}
                    								
						AddResource( type, item.Amount );
						this.PublicOverheadMessage( MessageType.Whisper, 0, false, "Resource Added." );
						item.Delete();
						return true;
					}
				}
			}
			this.PublicOverheadMessage( MessageType.Whisper, 0, false, "I don't hold that resource!" );
			return false;
		}

		public void AddResource( Type type, int amount )
		{
			if( m_Resources == null )
			{
				m_Resources = new Hashtable();
				m_Resources.Add( type, amount );
				return;
			}

			if( m_Resources.ContainsKey( type ) )
			{
				m_Resources[type] = (int)m_Resources[type] + amount;
				return;
			}

			else
				m_Resources.Add( type, amount );
		}

		public void ExtractResource( Mobile from, Type type, int count )
		{
			int m_Amount;
			if ( count > 0 )
				m_Amount = count;
			else
				m_Amount = 1;

			if( !m_Resources.ContainsKey(type) )
			{
				this.PublicOverheadMessage( MessageType.Whisper, 0, false, "I do not have that resource!" );
				return;
			}

			if( ((int)m_Resources[type] - m_Amount) >= 0 )
			{
				m_Resources[type] = (int)m_Resources[type] - m_Amount;
				Item toGive;
				toGive = Activator.CreateInstance( type ) as Item;
				toGive.Amount = m_Amount;
				from.AddToBackpack( toGive );
			}
			else 
				from.SendMessage( "You do not have that many!" );
		}

        public AlchemyBox(Serial serial) : base (serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version

			writer.Write( m_Resources.Count );
			foreach( DictionaryEntry de in m_Resources )
			{
				writer.Write( ((Type)de.Key).Name );
				writer.Write( (int)de.Value );
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_Resources = new Hashtable();

			switch( version )
			{
				case 0:
				{
					int count = reader.ReadInt();
					for (int i=0; i < count; i++)
					{
						Type type = ScriptCompiler.FindTypeByName(reader.ReadString());
						if( type == null )
						{
							int bad = reader.ReadInt();
							continue;
						}
						m_Resources.Add( type, reader.ReadInt() );
					}
					break;
				}
			}
		}
	}
}
