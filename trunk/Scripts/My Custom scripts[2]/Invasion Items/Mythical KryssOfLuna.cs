
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class MythicalKryssOfLuna : Kryss
    {
        public override int ArtifactRarity{ get{ return 12; } }
        public override int InitMinHits{ get{ return 185; } }
        public override int InitMaxHits{ get{ return 200; } }

        [Constructable]
        public MythicalKryssOfLuna()
        {
            Name = "Mythical Kryss Of Luna (Invasion 2011)";
            Hue = 26;
            Slayer = SlayerName.Repond;

            Attributes.SpellChanneling = 1;
            Attributes.BonusStr = 5;
            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;
        
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 15;
            Attributes.WeaponDamage = 40;
            Attributes.WeaponSpeed = 35;

            WeaponAttributes.HitLeechMana = 30;
            WeaponAttributes.HitLeechStam = 10;
            WeaponAttributes.ResistPhysicalBonus = 15;
            WeaponAttributes.DurabilityBonus = 10;
            WeaponAttributes.SelfRepair = 5;
           
        }

        public MythicalKryssOfLuna (Serial serial) : base(serial)
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
