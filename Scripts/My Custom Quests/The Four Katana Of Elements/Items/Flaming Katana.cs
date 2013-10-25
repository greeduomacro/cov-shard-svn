
using System;
using Server;

namespace Server.Items
{ 
	public class FlamingKatana: Katana
	{
		public override int ArtifactRarity{ get{ return 10; } }

        public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 600; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 45; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 11; } }
		public override int OldMaxDamage{ get{ return 16; } }
		public override int OldSpeed{ get{ return 45; } }

                public override int DefMaxRange{ get{ return 1; } }
		public override int DefHitSound{ get{ return 0x1F3; } }
		public override int DefMissSound{ get{ return 0x160; } }



		[Constructable]
		public FlamingKatana()
		{
            Name = "Flaming Katana";
			Hue = 39;

            Attributes.Luck = 200;
			Attributes.WeaponDamage = 30;
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
            Attributes.CastRecovery = 3;
            Attributes.SpellDamage = 15;
            WeaponAttributes.SelfRepair = 8;
            WeaponAttributes.HitFireball = 25;
            WeaponAttributes.HitDispel = 10;
            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.HitFireArea = 20;
        }

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = cold = pois = nrgy = chaos = direct = 0;
            fire = 100;
        }
        #endregion
		
		public FlamingKatana( Serial serial ) : base( serial )
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