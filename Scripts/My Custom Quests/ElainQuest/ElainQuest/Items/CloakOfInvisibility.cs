using System;
using Server;
using Server.Network;
using Server.Misc;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1515, 0x1530 )] 
	public class CloakOfInvisibility : Cloak, ITokunoDyable, IUsesRemaining
	{
        private int m_UsesRemaining;

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining
        {
            get { return m_UsesRemaining; }
            set { m_UsesRemaining = value; InvalidateProperties(); }
        }

        public virtual bool ShowUsesRemaining
        {
            get { return true; }
            set { }
        }
 
        [Constructable]
		public CloakOfInvisibility() : this( 100 )
		{
		}

		[Constructable] 
		public CloakOfInvisibility( int uses) : base( 0x309 ) 
		{ 
			Name = "Cloak of Invisibility";
			Hue = 0x29B;
            m_UsesRemaining = uses;

            //list.Add(1060584, m_UsesRemaining.ToString()); // uses remaining: ~1_val~
		}

        public override bool OnEquip(Mobile m)
        {
            if (m_UsesRemaining > 0)
            {
                m.Hidden = true;
                m_UsesRemaining -= 1;
                return true;

            }
            else
            {
                m.SendMessage("That Item is out of charges");
                return false;
            }
        }

		public override void OnRemoved( object parent ) 
		{ 
			if ( parent is Mobile ) 
			{ 
				Mobile m = (Mobile)parent;
				m.Hidden = false;
			} 
		} 

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		}

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (ShowUsesRemaining)
                list.Add(1060584, m_UsesRemaining.ToString()); // uses remaining: ~1_val~			
        }

		public CloakOfInvisibility( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 );
            writer.Write((int)m_UsesRemaining);
		} 

		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt();
            m_UsesRemaining = reader.ReadInt();
		} 
	} 
} 
