using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		private Mobile _Owner;
		private HomeEntry _Home;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Owner { get { return _Owner; } set { SetOwner(value); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public HomeEntry Home { get { return _Home; } set { } }

		[Constructable]
		public Hearthstone()
			: base(DefStoneItemID)
		{
			Name = DefStoneName;
			Weight = 0.0;

			_Home = new HomeEntry(this);
		}

		public override bool DisplayLootType { get { return false; } }
		public override bool DisplayWeight { get { return false; } }

		public override void OnParentDeleted(object parent)
		{
			if (parent is Item)
			{
				if (((Item)parent) != _Owner.Backpack)
				{
					if (!MoveToBackpack())
					{
						if (((Item)parent) != _Owner.BankBox)
						{
							if (!MoveToBankBox())
							{
								Delete();
							}
						}
					}
				}
			}
			else if (parent is Mobile)
			{
				if (((Mobile)parent) == _Owner)
				{
					Delete();
				}
			}

			base.OnParentDeleted(parent);
		}

		public override void OnLocationChange(Point3D oldLocation)
		{
			base.OnLocationChange(oldLocation);

			InvalidateOwner();
		}

		public override bool OnDroppedToWorld(Mobile from, Point3D p)
		{
			return false;
		}

		public override bool OnDroppedInto(Mobile from, Container target, Point3D p)
		{
			if (target.RootParent != null && target.RootParent is Mobile)
			{
				if (((Mobile)target.RootParent) == _Owner)
				{
					return base.OnDroppedInto(from, target, p);
				}
			}

			InvalidateOwner();

			return false;
		}

		public override bool OnDroppedOnto(Mobile from, Item target)
		{
			if (target.RootParent != null && target.RootParent is Mobile)
			{
				if (((Mobile)target.RootParent) == _Owner)
				{
					return base.OnDroppedOnto(from, target);
				}
			}

			InvalidateOwner();

			return false;
		}

		public override bool OnDroppedToMobile(Mobile from, Mobile target)
		{
			if (target != null)
			{
				if (target == _Owner)
				{
					return base.OnDroppedToMobile(from, target);
				}
			}

			InvalidateOwner();

			return false;
		}

		public override void OnDelete()
		{
			base.OnDelete();
			Unregister(_Owner);
		}

		public Hearthstone(Serial serial)
			: base(serial)
		{ }

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0);

			writer.Write((Mobile)_Owner);

			SerializeUsage(writer);

			if (_Home == null)
				_Home = new HomeEntry(this);

			_Home.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			_Owner = reader.ReadMobile();

			DeserializeUsage(reader);

			_Home = new HomeEntry(this);
			_Home.Deserialize(reader);

			Register(_Owner, this);
		}
	}
}