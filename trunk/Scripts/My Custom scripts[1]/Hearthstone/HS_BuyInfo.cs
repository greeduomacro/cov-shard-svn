using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		public sealed class BuyInfo : GenericBuyInfo
		{
			public override bool CanCacheDisplay { get { return true; } }

			public BuyInfo()
				: base(DefStoneName, typeof(Hearthstone), DefVendorPrice, 1, DefStoneItemID, DefStoneHue)
			{
				Name = DefStoneName;
			}

			public override IEntity GetEntity()
			{
				return (IEntity)Activator.CreateInstance(typeof(Hearthstone));
			}
		}
	}
}