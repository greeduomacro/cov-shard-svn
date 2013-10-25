using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2641, 0x2642 )]
	public class MonksDragonsaleChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 25; } }
		public override int BaseFireResistance{ get{ return 25; } }
		public override int BaseColdResistance{ get{ return 25; } }
		public override int BasePoisonResistance{ get{ return 25; } }
		public override int BaseEnergyResistance{ get{ return 25; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override int AosStrReq{ get{ return 100; } }
		public override int OldStrReq{ get{ return 100; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Dragon; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.WhiteScales; } }

		[Constructable]
		public MonksDragonsaleChest() : base( 0x2641 )
		{
			Name = "Dragonscale Chest";
			Hue = 2500;
			Weight = 5.0;
			Attributes.BonusHits = 50;
		}

		public override bool CanEquip( Mobile from )
		{
			if ( from.Account != null && from.AccessLevel == AccessLevel.Player )
			{
				if ( Server.Engines.VeteranRewards.RewardSystem.GetRewardLevel( from ) < 3 )
				{
					from.SendMessage( "Your account is not old enough to use this item. You must be on your third reward level to use this." );
					return false;
				}
			}

			return base.CanEquip( from );
		}

		public MonksDragonsaleChest( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}