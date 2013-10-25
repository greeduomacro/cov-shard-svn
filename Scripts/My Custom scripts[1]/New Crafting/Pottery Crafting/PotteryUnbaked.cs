// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{
	public class PotteryVaseOneUnbaked : Item
	{
		public PotteryVaseOneUnbaked() : base( 0xB48 )
		{
			Hue = 1190;
			Name = "Unbaked Vase";
		}

		public PotteryVaseOneUnbaked( Serial serial ) : base( serial )
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

	public class PotteryVaseTwoUnbaked : Item
	{
		public PotteryVaseTwoUnbaked() : base( 0xB46 )
		{
			Hue = 1190;
			Name = "Unbaked Vase";
		}

		public PotteryVaseTwoUnbaked( Serial serial ) : base( serial )
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

	public class PotteryLargeVaseOneUnbaked : Item
	{
		public PotteryLargeVaseOneUnbaked() : base( 0xB47 )
		{
			Hue = 1190;
			Name = "Unbaked Vase";
		}

		public PotteryLargeVaseOneUnbaked( Serial serial ) : base( serial )
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

	public class PotteryLargeVaseTwoUnbaked : Item
	{
		public PotteryLargeVaseTwoUnbaked() : base( 0xB45 )
		{
			Hue = 1190;
			Name = "Unbaked Vase";
		}

		public PotteryLargeVaseTwoUnbaked( Serial serial ) : base( serial )
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

	public class PotteryLargeVaseThreeUnbaked : Item
	{
		public PotteryLargeVaseThreeUnbaked() : base( 0x42B3 )
		{
			Hue = 1190;
			Name = "Unbaked Vase";
		}

		public PotteryLargeVaseThreeUnbaked( Serial serial ) : base( serial )
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

	public class PotteryLargeVaseFourUnbaked : Item
	{
		public PotteryLargeVaseFourUnbaked() : base( 0x42B2 )
		{
			Hue = 1190;
			Name = "Unbaked Vase";
		}

		public PotteryLargeVaseFourUnbaked( Serial serial ) : base( serial )
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

	public class PotterySmallUrnOneUnbaked : Item
	{
		public PotterySmallUrnOneUnbaked() : base( 0x241C )
		{
			Hue = 1190;
			Name = "Unbaked Urn";
		}

		public PotterySmallUrnOneUnbaked( Serial serial ) : base( serial )
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

	public class PotteryUrnOneUnbaked : Item
	{
		public PotteryUrnOneUnbaked() : base( 0x241D )
		{
			Hue = 1190;
			Name = "Unbaked Urn";
		}

		public PotteryUrnOneUnbaked( Serial serial ) : base( serial )
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

	public class PotteryUrnTwoUnbaked : Item
	{
		public PotteryUrnTwoUnbaked() : base( 0x241E )
		{
			Hue = 1190;
			Name = "Unbaked Urn";
		}

		public PotteryUrnTwoUnbaked( Serial serial ) : base( serial )
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

    public class GargishVaseOneUnbaked : Item
    {
        public GargishVaseOneUnbaked()
            : base(0x4042)
        {
            Hue = 1190;
            Name = "Unbaked Gargish Vase";
        }

        public GargishVaseOneUnbaked(Serial serial)
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

    public class GargishVaseTwoUnbaked : Item
    {
        public GargishVaseTwoUnbaked()
            : base(0x4043)
        {
            Hue = 1190;
            Name = "Unbaked Gargish Vase";
        }

        public GargishVaseTwoUnbaked(Serial serial)
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