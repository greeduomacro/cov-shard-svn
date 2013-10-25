
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class NoxKatana : Katana, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 9; } }

        public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 600; } }
                
		public override int AosStrengthReq{ get{ return 100; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 18; } }
		public override int AosSpeed{ get{ return 48; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 12; } }
		public override int OldMaxDamage{ get{ return 18; } }
		public override int OldSpeed{ get{ return 48; } }

        public override int DefMaxRange{ get{ return 1; } }
		public override int DefHitSound{ get{ return 1140; } }
		public override int DefMissSound{ get{ return 517; } }
	
	

		[Constructable]
		public NoxKatana()
		{
            Name = " Katana of the Swamp Queen";
			Hue = 677;
            Attributes.Luck = 100;
			Attributes.WeaponSpeed = 46;
			Attributes.WeaponDamage = 15;
			Attributes.SpellChanneling = 1;
            Attributes.AttackChance = 25;
            WeaponAttributes.SelfRepair = 8;
            WeaponAttributes.HitPoisonArea = 100;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.ResistPoisonBonus = 25;
		}
        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = nrgy = chaos = direct = 0;
            pois = 100;
        }
        #endregion
		

		public NoxKatana( Serial serial ) : base( serial )
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