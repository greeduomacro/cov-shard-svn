
using System;
using Server;

namespace Server.Items
{ 
	public class BurningKatana: Katana
	{
		public override int ArtifactRarity{ get{ return 10; } }

        public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 600; } }
                
		public override int AosStrengthReq{ get{ return 100; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 46; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 11; } }
		public override int OldMaxDamage{ get{ return 16; } }
		public override int OldSpeed{ get{ return 20; } }

        public override int DefMaxRange{ get{ return 1; } }
		public override int DefHitSound{ get{ return 0x1F3; } }
		public override int DefMissSound{ get{ return 0x160; } }
	
	

		[Constructable]
		public BurningKatana()
		{
            Name = "Burning Katana";
			Hue = 1359;

            Attributes.Luck = 100;
			Attributes.WeaponSpeed =45;
			Attributes.WeaponDamage = 20;
            Attributes.SpellChanneling = 1;
            Attributes.AttackChance = 15;
            WeaponAttributes.SelfRepair = 8;
            WeaponAttributes.HitMagicArrow = 25;
            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.HitFireArea = 100;
		}
        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = cold = pois = nrgy = chaos = direct = 0;
            fire = 100;
        }
        #endregion
		

		public BurningKatana( Serial serial ) : base( serial )
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