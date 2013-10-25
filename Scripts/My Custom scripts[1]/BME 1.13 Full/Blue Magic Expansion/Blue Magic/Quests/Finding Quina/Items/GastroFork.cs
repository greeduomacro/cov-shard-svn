// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class GastroFork : WarFork, IBlueWeapon
	{
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 43; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override WeaponAnimation DefAnimation{ get{ return m_GastroAnimation; } }

		public override SkillName DefSkill{ get{ return SkillName.Wrestling; } }

		private WeaponAnimation m_GastroAnimation;

		[Constructable]
		public GastroFork()
		{
			Name = "Gastro Fork";
			Hue = 2075;
			Attributes.WeaponDamage = 30;
			Attributes.WeaponSpeed = 25;
			WeaponAttributes.SelfRepair = 1;
			m_GastroAnimation = WeaponAnimation.Slash1H;
			// WeaponAttributes.HitLeechMana = 40;
		}

		public override TimeSpan GetDelay( Mobile m )
		{
			if ( m_GastroAnimation == WeaponAnimation.Slash1H )
				return TimeSpan.FromSeconds( 1.25 );
			else
				return base.GetDelay( m );
		}


		public override bool CheckHit( Mobile attacker, Mobile defender )
		{
			switch( m_GastroAnimation )
			{
				case WeaponAnimation.Slash1H: m_GastroAnimation = WeaponAnimation.Pierce1H; break;
				case WeaponAnimation.Pierce1H: m_GastroAnimation = WeaponAnimation.Bash1H; break;
				case WeaponAnimation.Bash1H: m_GastroAnimation = WeaponAnimation.Slash1H; break;
			}

			if ( base.CheckHit( attacker, defender ) )
				return true;
			else if ( m_GastroAnimation == WeaponAnimation.Pierce1H )
				return true;
			else
				return false;
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			if ( m_GastroAnimation == WeaponAnimation.Bash1H )
				base.OnHit( attacker, defender, damageBonus + 1.0 );
			else
				base.OnHit( attacker, defender, damageBonus );
		}

		public GastroFork( Serial serial ) : base( serial )
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
			m_GastroAnimation = WeaponAnimation.Slash1H;
		}
	}
}