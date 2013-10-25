
using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Regions;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;

namespace Server.Items
{
	public class PotteryVaseOne : Item, IDyable
	{
		[Constructable]
		public PotteryVaseOne() : base( 0xB48 )
		{
            Name = "Baked Vase";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryVaseOne( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryVaseTwo : Item, IDyable
	{
		[Constructable]
		public PotteryVaseTwo() : base( 0xB46 )
		{
            Name = "Baked Vase";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryVaseTwo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryLargeVaseOne : Item, IDyable
	{
		[Constructable]
		public PotteryLargeVaseOne() : base( 0xB47 )
		{
            Name = "Baked Large Vase";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryLargeVaseOne( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryLargeVaseTwo : Item, IDyable
	{
		[Constructable]
		public PotteryLargeVaseTwo() : base( 0xB45 )
		{
            Name = "Baked Large Vase";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryLargeVaseTwo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryLargeVaseThree : Item, IDyable
	{
		[Constructable]
		public PotteryLargeVaseThree() : base( 0x42B3 )
		{
			Name = "Baked Large Vase";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryLargeVaseThree( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryLargeVaseFour : Item, IDyable
	{
		[Constructable]
		public PotteryLargeVaseFour() : base( 0x42B2 )
		{
			Name = "Baked Large Vase";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryLargeVaseFour( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotterySmallUrnOne : Item, IDyable
	{
		[Constructable]
		public PotterySmallUrnOne() : base( 0x241C )
		{
		}

		public PotterySmallUrnOne( Serial serial ) : base( serial )
		{
            Name = "Baked Small Urn";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryUrnOne : Item, IDyable
	{
		[Constructable]
		public PotteryUrnOne() : base( 0x241D )
		{
            Name = "Baked Urn";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryUrnOne( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PotteryUrnTwo : Item, IDyable
	{
		[Constructable]
		public PotteryUrnTwo() : base( 0x241E )
		{
            Name = "Baked Urn";
            Hue = 1824;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public PotteryUrnTwo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class GargishVaseOne : Item, IDyable
    {
        [Constructable]
        public GargishVaseOne()
            : base(0x4042)
        {
            Name = "Baked Gargish Vase";
            Hue = 1824;
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

        public GargishVaseOne(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class GargishVaseTwo : Item, IDyable
    {
        [Constructable]
        public GargishVaseTwo()
            : base(0x4043)
        {
            Name = "Baked Gargish Vase";
            Hue = 1824;
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

        public GargishVaseTwo(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

}