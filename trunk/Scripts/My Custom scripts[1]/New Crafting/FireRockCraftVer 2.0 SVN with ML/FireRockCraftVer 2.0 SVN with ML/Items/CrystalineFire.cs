/* Created by Hammerhand*/

using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class CrystalineFire : Item, ICommodity
	{
        private CraftResource m_Resource;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get { return m_Resource; }
            set { m_Resource = value; InvalidateProperties(); }
        }
                string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} CrystalineFire" : "{0} CrystalineFire", Amount,  Amount, CraftResources.GetName( m_Resource ).ToLower() );
            }
        }
                int ICommodity.DescriptionNumber { get { return LabelNumber; 
                }
                }
        [Constructable]
        public CrystalineFire()
            : this(1)
        {
        }
		[Constructable]
		public CrystalineFire(int amount) : base( 7961 )
		{
            Stackable = true;
            Name = "Crystaline Fire";
            Hue = 1260;
			Weight = 1.0;
            Amount = amount;
		}

        public CrystalineFire(Serial serial)
            : base(serial)
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