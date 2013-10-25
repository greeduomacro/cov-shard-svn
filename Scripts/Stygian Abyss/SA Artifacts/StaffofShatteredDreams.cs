using System;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	// Based off a BlackStaff
	[FlipableAttribute( 0x905, 0x4070 )]
	public class StaffofShatteredDreams : BaseStaff
	{
        public override int LabelNumber { get { return 1112771; } } // Staff of Shattered Dreams
        public override int ArtifactRarity { get { return 11; } }
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

       // public override int FireResistance { get { return 15; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 14; } }
		public override int AosSpeed{ get{ return 39; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 35; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public StaffofShatteredDreams() : base( 0x905 )
		{
			Weight = 4.0;
            Hue = 1283;

            Attributes.CastSpeed = -1;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponDamage = 50;

            WeaponAttributes.ResistFireBonus = 15;
            WeaponAttributes.HitDispel = 25;         

		}

        public StaffofShatteredDreams(Serial serial): base(serial)
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            fire = cold = pois= nrgy = chaos = direct = 0;
            phys = 100;
        }
        #endregion

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}