
using System;
using Server;

namespace Server.Items
{
    public class LegendaryKryssOfCOV : Kryss
    {
        public override int ArtifactRarity{ get{ return 12; } }
        public override int InitMinHits{ get{ return 185; } }
        public override int InitMaxHits{ get{ return 200; } }

        [Constructable]
        public LegendaryKryssOfCOV()
        {
            Name = "LegendaryKryssOfCOV";
            Hue = 2406;
            Slayer = SlayerName.Repond;
            Attributes.SpellChanneling = 1;
            Attributes.BonusStr = 5;
            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;
            WeaponAttributes.HitLeechMana = 30;
            WeaponAttributes.HitLeechStam = 10;
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 15;
            Attributes.WeaponDamage = 40;
            Attributes.WeaponSpeed = 35;
            //Attributes.ReflectPhysical = 25;
            WeaponAttributes.ResistPhysicalBonus = 15;
            WeaponAttributes.DurabilityBonus = 10;
            WeaponAttributes.SelfRepair = 5;
            //WeaponAttributes.HitLightning = 10;
        }

        public LegendaryKryssOfCOV(Serial serial)
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
