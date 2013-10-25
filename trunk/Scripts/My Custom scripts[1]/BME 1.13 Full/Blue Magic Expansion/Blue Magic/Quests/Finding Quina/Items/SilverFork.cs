// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class SilverFork : WarFork, IBlueWeapon
	{
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 14; } }
		public override int AosSpeed{ get{ return 43; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override SkillName DefSkill{ get{ return SkillName.Wrestling; } }

		[Constructable]
		public SilverFork()
		{
			Name = "Silver Fork";
			Hue = 2101;
			Slayer = SlayerName.Silver;
			Attributes.WeaponDamage = 30;
			Attributes.WeaponSpeed = 25;
			WeaponAttributes.SelfRepair = 1;
			// WeaponAttributes.HitLeechStam = 100;
		}

		public SilverFork( Serial serial ) : base( serial )
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