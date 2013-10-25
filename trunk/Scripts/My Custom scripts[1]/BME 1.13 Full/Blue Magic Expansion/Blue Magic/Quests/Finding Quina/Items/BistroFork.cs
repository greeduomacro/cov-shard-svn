// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class BistroFork : WarFork, IBlueWeapon
	{
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 43; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override SkillName DefSkill{ get{ return SkillName.Wrestling; } }

		[Constructable]
		public BistroFork()
		{
			Name = "Bistro Fork";
			Hue = 1194;
			Attributes.WeaponDamage = 30;
			Attributes.WeaponSpeed = 25;
			WeaponAttributes.SelfRepair = 1;
			// WeaponAttributes.HitFireball = 25;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			cold = pois = nrgy = chaos = direct = 0;
			phys = 75;
			fire = 25;
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			if ( attacker != null && defender != null )
			{
				ResistanceMod[] mods = new ResistanceMod[]{ new ResistanceMod( ResistanceType.Fire, -15 ) };

				for ( int i = 0; i < mods.Length; ++i )
					attacker.AddResistanceMod( mods[i] );

				TimedResistanceMod.AddMod( 
					defender, 
					"BistroFork", 
					mods, 
					TimeSpan.FromSeconds( 10 )
				);
			}
		}

		public BistroFork( Serial serial ) : base( serial )
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