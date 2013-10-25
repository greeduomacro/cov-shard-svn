// Scripted by Karmageddon
using System;
using Server;
using Server.Guilds;
using Server.Items;

namespace Server.Items
{
    public class DragonShield : MetalKiteShield, ITokunoDyable
	{		
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public DragonShield()
		{
			Hue = 1157;
			Name = "Shield of the Dragons";			
			Attributes.DefendChance = 10;
			Attributes.AttackChance = 10;
			Attributes.BonusHits = 20;
			Attributes.SpellChanneling = 1;
			ArmorAttributes.MageArmor = 1;
			PhysicalBonus = 5;
			FireBonus = 5;
			ColdBonus = 5;
			PoisonBonus = 5;
			EnergyBonus = 5;			
		}

		public DragonShield( Serial serial ) : base( serial )
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
		public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "You feel the power of a dragon surround you as the shield attaches to you!" );

			}
			
			return true;
		}
	}
}