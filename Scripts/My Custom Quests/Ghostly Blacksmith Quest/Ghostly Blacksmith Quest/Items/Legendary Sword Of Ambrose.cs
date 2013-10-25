// Created with UO Weapon Generator
// Created On: 8/12/2007 10:06:14 PM
// By: Hammerhand

using System;
using Server;

namespace Server.Items
{
    public class LegendarySwordOfAmbrose : Katana
    {
        public override int ArtifactRarity{ get{ return 12; } }
        public override int InitMinHits{ get{ return 185; } }
        public override int InitMaxHits{ get{ return 200; } }

        [Constructable]
        public LegendarySwordOfAmbrose()
        {
            Name = "Legendary Sword Of Ambrose";
            Hue = 2401;
            Slayer = SlayerName.DaemonDismissal;
            Attributes.SpellChanneling = 1;
            Attributes.BonusStr = 5;
            Attributes.RegenHits = 15;
            Attributes.RegenStam = 15;
            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.HitLeechStam = 10;
            Attributes.AttackChance = 18;
            Attributes.DefendChance = 15;
            Attributes.WeaponDamage = 40;
            Attributes.WeaponSpeed = 35;
            Attributes.ReflectPhysical = 25;
            WeaponAttributes.ResistPhysicalBonus = 15;
            WeaponAttributes.DurabilityBonus = 15;
            WeaponAttributes.SelfRepair = 5;
            WeaponAttributes.HitLightning = 30;
        }

        public LegendarySwordOfAmbrose(Serial serial) : base( serial )
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
