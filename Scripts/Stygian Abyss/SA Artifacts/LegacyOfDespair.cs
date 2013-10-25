using System;
using Server.Network;
using Server.Items;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	// Based off a Longsword
	[FlipableAttribute( 0x90B, 0x4074 )]
	public class LegacyOfDespair : BaseSword
	{
        public override int LabelNumber { get { return 1113519; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public LegacyOfDespair() : base( 0x90B )
		{
            //Name = "Dread Sword";
            Weight = 6.0;
            Hue = 1711;
            WeaponAttributes.HitLowerDefend = 50;
            WeaponAttributes.HitLowerAttack = 50;
            WeaponAttributes.HitCurse = 10;
            Attributes.WeaponDamage = 60;
            Attributes.WeaponSpeed = 30;
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = nrgy = chaos = direct = 0;
            cold = 75;
            pois = 25;
        }
        #endregion

		public LegacyOfDespair( Serial serial ) : base( serial )
		{
		}

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