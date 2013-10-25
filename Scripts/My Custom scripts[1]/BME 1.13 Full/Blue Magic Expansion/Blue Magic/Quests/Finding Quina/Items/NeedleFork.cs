// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class NeedleFork : WarFork, IBlueWeapon
	{
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 14; } }
		public override int AosSpeed{ get{ return 43; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override SkillName DefSkill{ get{ return SkillName.Wrestling; } }

		[Constructable]
		public NeedleFork()
		{
			Name = "Needle Fork";
			Hue = 2965;
			Attributes.WeaponDamage = 30;
			Attributes.WeaponSpeed = 25;
			WeaponAttributes.SelfRepair = 1;
			// WeaponAttributes.HitManaDrain = 25;
		}

		private Type[] SlayerVs = new Type[]
		{
			typeof( Drake ),
			typeof( Gazer ),
			typeof( Lich ),
			typeof( Daemon ),
			typeof( Dragon ),
			typeof( ElderGazer ),
			typeof( LichLord ),
			typeof( IceFiend ),
			typeof( ShadowWyrm ),
			typeof( BlueBeholder ),
			typeof( AncientLich ),
			typeof( Balron )
		};

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			bool bonus = false;
			Type t = defender.GetType();

			for( int i = 0; i < SlayerVs.Length; i++ )
			{
				if ( t == SlayerVs[i] )
				{
					bonus = true;
					break;
				}
			}

			if ( bonus )
				base.OnHit( attacker, defender, damageBonus + 2.0 );
			else
				base.OnHit( attacker, defender, damageBonus );
		}

		public NeedleFork( Serial serial ) : base( serial )
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