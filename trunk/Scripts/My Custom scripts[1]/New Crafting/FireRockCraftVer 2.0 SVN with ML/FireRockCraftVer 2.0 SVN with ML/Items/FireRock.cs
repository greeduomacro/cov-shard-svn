/* Created by Hammerhand*/

using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;

namespace Server.Items
{
    public class SmallFireRock : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} SmallFireRock" : "{0} SmallFireRock", Amount);
            }
        }
        int ICommodity.DescriptionNumber { get { return LabelNumber; 
        } 
        }
        [Constructable]
        public SmallFireRock()
            : this(1)
        {
        }

        [Constructable]
        public SmallFireRock(int amount)
            : base(0x1366)
        {
            Stackable = true;
            Weight = 1;
            Hue = 1359;
            Name = "SmallFireRock";
            Amount = amount;
        }
        public SmallFireRock(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class LargeFireRock : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} LargeFireRock" : "{0} LargeFireRock", Amount);
            }
        }
        int ICommodity.DescriptionNumber { get { return LabelNumber; 
        } 
        }
        [Constructable]
        public LargeFireRock()
            : this(1)
        {
        }

        [Constructable]
        public LargeFireRock(int amount)
            : base(0x1363)
        {
            Stackable = true;
            Weight = 3;
            Hue = 1359;
            Name = "LargeFireRock";
            Amount = amount;
        }
        public LargeFireRock(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

}