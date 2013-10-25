using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Collections;
using Server.ContextMenus;

namespace Server.Items
{
	public class CastOffZombieSkin : BaseArmor
	{
        public override int LabelNumber { get { return 1113538; } } //Cast-Off Zombie Skin

		public override int BasePhysicalResistance{ get{ return 13; } }
		public override int BaseFireResistance{ get{ return -2; } }
		public override int BaseColdResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 18; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CastOffZombieSkin() : base( 0x0302 )
		{
			Weight = 4.0;
            Hue = 2020;
            SkillBonuses.SetValues(0, SkillName.Necromancy, 5.0);
            SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 5.0);
            Attributes.LowerManaCost = 5;
            Attributes.LowerRegCost = 8;


		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
                //Misc.Titles.AwardKarma((Mobile)parent, -5, true);
			{
				if ( ((Mobile)parent).Female )
					ItemID = 0x0301;
				else
					ItemID = 0x0302;
			}
		}

		public CastOffZombieSkin( Serial serial ) : base( serial )
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