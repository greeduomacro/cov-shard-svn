using System;
using Server;

namespace Server.Items
{

        public class TitanWarriorSandals : Sandals
        {
                public override int BasePhysicalResistance{ get{ return 16; } }
                public override int BaseFireResistance{ get{ return 13; } }
                public override int BaseColdResistance{ get{ return 14; } }
                public override int BasePoisonResistance{ get{ return 13; } }
                public override int BaseEnergyResistance{ get{ return 15; } }
                
                [Constructable]
                public TitanWarriorSandals()
                {
                        Name = "Titan Warrior Sandals";
                        Hue = Utility.RandomList( 1161, 1150, 1266 );
                        Attributes.BonusStr = 5;
                }

                public TitanWarriorSandals( Serial Serial ) : base ( Serial )
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
                        