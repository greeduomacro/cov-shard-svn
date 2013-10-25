// Created by GreyWolf
// Created On: 10/4/2007

using System;
using Server;

namespace Server.Items
{
    public class CapofExpertTailoring : LeatherCap
    {
        public override int BasePhysicalResistance{ get{ return 5; } }
        public override int BaseColdResistance{ get{ return 5; } }
        public override int BaseFireResistance{ get{ return 5; } }
        public override int BaseEnergyResistance{ get{ return 5; } }
        public override int BasePoisonResistance{ get{ return 5; } }
        public override int InitMinHits{ get{ return 50; } }
        public override int InitMaxHits{ get{ return 100; } }

        [Constructable]
        public CapofExpertTailoring()
        {
            Name = "Cap of Expert Tailoring";
            Hue = 62;
            LootType = LootType.Blessed;
            Attributes.NightSight = 1;
            Attributes.BonusStr = 5;
            Attributes.BonusDex = 5;
            Attributes.RegenStam = 5;
            SkillBonuses.SetValues( 0, SkillName.Tailoring, 5.0 );
        }

        public CapofExpertTailoring(Serial serial)
            : base(serial)
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
    } // End Class
} // End Namespace
