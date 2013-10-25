using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF5E, 0xF5F )]
	public class Mangler : BaseSword
	{
        public override int LabelNumber { get { return 1114842; } }//Mangler
        
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 33; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.25f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 25; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 29; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public Mangler() : base( 0xF5E )
		{
			Weight = 6.0;
            Hue = 1442;
            WeaponAttributes.HitLowerDefend = 30;
            WeaponAttributes.HitLeechMana = 50;
            WeaponAttributes.HitHarm = 50;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.WeaponSpeed = 25;
            Attributes.WeaponDamage = 50;
		}

		public Mangler( Serial serial ) : base( serial )
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