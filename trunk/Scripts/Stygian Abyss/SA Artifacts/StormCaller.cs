using System;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class StormCaller : BaseThrown
	{
        public override int LabelNumber { get { return 1113530; } }// Storm Caller

		public override int MinThrowRange{ get{ return 2; } }	// MaxRange 6

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.MysticArc; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

		/*
		Boomerang 0x8FF: MysticArc, ConcussionBlow
		Cyclone 2305/0x901: MovingShot, InfusedThrow
		Soul Glaive 2314/0x090A: ArmorIgnore, MortalStrike
		*/

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return 8; } }
		public override int AosMaxDamage{ get{ return 12; } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 9; } }
		public override int OldMaxDamage{ get{ return 41; } }
		public override int OldSpeed{ get{ return 20; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public StormCaller() : base( 0x8FF )
		{
			Weight = 4.0;
			Layer = Layer.OneHanded;
            Hue = 1169;
           
            WeaponAttributes.BattleLust = 25;
            WeaponAttributes.HitLowerDefend = 30;
            WeaponAttributes.HitLightning = 40;
            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 40;
            Attributes.BonusStr = 5;
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            chaos = direct = 0;
            phys = 20;
            fire = 20;
            cold = 20;
            pois = 20;
            nrgy = 20;
        }
        #endregion

		public StormCaller( Serial serial ) : base( serial )
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