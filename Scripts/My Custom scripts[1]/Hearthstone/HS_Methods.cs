using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		public void InvalidateOwner()
		{
			Mobile owner = null;

			if (this.Parent != null && this.Parent is Mobile)
			{
				owner = (Mobile)this.Parent;
			}
			else if (this.RootParent != null && this.RootParent is Mobile)
			{
				owner = (Mobile)this.RootParent;
			}

			if (owner != null)
				SetOwner(owner);
		}

		public void SetOwner(Mobile owner)
		{
			if (owner != null)
			{
				_Owner = owner;
				this.BlessedFor = _Owner;
				Register(_Owner, this);
			}
			else
			{
				_Owner = null;
				this.BlessedFor = null;
			}
		}

		public bool MoveToBackpack()
		{
			if (_Owner != null)
			{
				Container c = _Owner.Backpack;

				if (c != null)
				{
					return c.TryDropItem(_Owner, this, false);
				}
			}

			return false;
		}

		public bool MoveToBankBox()
		{
			if (_Owner != null)
			{
				Container c = _Owner.BankBox;

				if (c != null)
				{
					return c.TryDropItem(_Owner, this, false);
				}
			}

			return false;
		}
	}
}