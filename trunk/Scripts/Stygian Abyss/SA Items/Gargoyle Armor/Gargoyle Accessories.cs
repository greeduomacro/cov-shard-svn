using System;

namespace Server.Items
{
	[FlipableAttribute( 0x450D, 0x450D )]
	public class GargoyleTailMale : BaseWaist
	{
		public override Race RequiredRace { get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		[Constructable]
		public GargoyleTailMale() : this( 0 )
		{
		}

		[Constructable]
		public GargoyleTailMale( int hue ) : base( 0x450D, hue )
		{
			Weight = 2.0;
		}

		public GargoyleTailMale( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x44C1, 0x44C2 )]
	public class GargoyleTailFemale : BaseWaist
	{
		public override Race RequiredRace { get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		[Constructable]
		public GargoyleTailFemale() : this( 0 )
		{
		}

		[Constructable]
		public GargoyleTailFemale( int hue ) : base( 0x44C1, hue )
		{
			Weight = 2.0;
		}

		public GargoyleTailFemale( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x50D8, 0x50D9 )]
	public class GargoyleHalfApron : BaseWaist
	{
		public override Race RequiredRace { get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		[Constructable]
		public GargoyleHalfApron() : this( 0 )
		{
		}

		[Constructable]
		public GargoyleHalfApron( int hue ) : base( 0x50D8, hue )
		{
			Weight = 2.0;
		}

		public GargoyleHalfApron( Serial serial ) : base( serial )
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
	}		///////////////////////////////////////////////////

[FlipableAttribute( 4000, 4001 )]
	public class GargishFancyRobe : BaseOuterTorso
	{
		public override Race RequiredRace { get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		[Constructable]
		public GargishFancyRobe() : this( 0 )
		{
		}

		[Constructable]
		public GargishFancyRobe( int hue ) : base( 4000, hue )
		{
			Weight = 2.0;
		}

		public GargishFancyRobe( Serial serial ) : base( serial )
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

[FlipableAttribute(4002, 4003)]
public class GargishRobe : BaseOuterTorso
{
    public override Race RequiredRace { get { return Race.Gargoyle; } }
    public override bool CanBeWornByGargoyles { get { return true; } }

    [Constructable]
    public GargishRobe() : this(0)
    {
    }

    [Constructable]
    public GargishRobe(int hue) : base(4002, hue)
    {
        Weight = 2.0;
    }

    public GargishRobe(Serial serial) : base(serial)
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