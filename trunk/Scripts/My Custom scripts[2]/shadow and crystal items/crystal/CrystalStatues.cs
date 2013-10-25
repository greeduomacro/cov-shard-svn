using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute(0x35F8, 0x35F9)]
	public class CrystalBeggarStatue : Item
	{
		[Constructable]
		public CrystalBeggarStatue() : base(0x35F8)
		{
			Movable = true;
			Name = "Crystal Beggar Statue";
		}

		public CrystalBeggarStatue(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 6.0 )
				Weight = 20.0;
		}
	}
	
	[FlipableAttribute(0x35FA, 0x35FB)]
	public class CrystalSupplicantStatue : Item
	{
		[Constructable]
		public CrystalSupplicantStatue() : base(0x35FA)
		{
			Movable = true;
			Name = "Crystal Supplicant Statue";
		}

		public CrystalSupplicantStatue(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 6.0 )
				Weight = 20.0;
		}
	}
	
	[FlipableAttribute(0x35FC, 0x35FD)]
	public class CrystalRunnerStatue : Item
	{
		[Constructable]
		public CrystalRunnerStatue() : base(0x35FC)
		{
			Movable = true;
			Name = "Crystal Runner Statue";
		}

		public CrystalRunnerStatue(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 6.0 )
				Weight = 20.0;
		}
	}
	
	[FlipableAttribute(0x35F6, 0x35F7)]
	public class CrystalPillar : Item
	{
		[Constructable]
		public CrystalPillar() : base(0x35F6)
		{
			Movable = true;
			Name = "Crystal Pillar";
		}

		public CrystalPillar(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 6.0 )
				Weight = 20.0;
		}
	}
}
