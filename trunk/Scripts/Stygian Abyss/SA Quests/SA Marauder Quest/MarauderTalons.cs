using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    [FlipableAttribute(0x41D8, 0x41D9)]
    public class MarauderTalons : LeatherTalons
    {
        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

        //public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

                public override int BasePhysicalResistance{ get{ return 16; } }
                public override int BaseFireResistance{ get{ return 13; } }
                public override int BaseColdResistance{ get{ return 14; } }
                public override int BasePoisonResistance{ get{ return 13; } }
                public override int BaseEnergyResistance{ get{ return 15; } }
                
                [Constructable]
                public MarauderTalons() : base (0x41D8)
                {
                        Name = "Marauder Talons";
                        Hue = Utility.RandomList( 1161, 1150, 1266 );
                        Attributes.BonusStr = 5;
                }

                public MarauderTalons( Serial Serial ) : base ( Serial )
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
                        