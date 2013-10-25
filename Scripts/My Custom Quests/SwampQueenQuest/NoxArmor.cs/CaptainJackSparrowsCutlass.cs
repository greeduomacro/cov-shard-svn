using System;
using Server;

namespace Server.Items
{
	public class CaptainJackSparrowsCutlass : Cutlass
	{
		
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
        public override int AosMinDamage { get { return 19; } }
        public override int AosMaxDamage { get { return 31; } }

		[Constructable]
		public CaptainJackSparrowsCutlass()
		{
			Hue = 0x5C;
            Name = "Captain Jack Sparrows Cutlass";
			Attributes.BonusDex = 5;
			Attributes.AttackChance = 10;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 50;
            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.ResistEnergyBonus = 25;
		}

		public CaptainJackSparrowsCutlass( Serial serial ) : base( serial )
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

			if( Attributes.AttackChance == 50 )
				Attributes.AttackChance = 10;
		}
	}
}