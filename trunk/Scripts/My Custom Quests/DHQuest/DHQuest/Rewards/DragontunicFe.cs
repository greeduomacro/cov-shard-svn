// Scripted by Karmageddon
using System;
using Server;
using Server.Guilds;
using Server.Items;

namespace Server.Items
{
    public class TunicofDragonF : FemalePlateChest, ITokunoDyable	
	{
		//public override int LabelNumber{ get{ return 1061099; } } // Tunic of Fire
		public override int ArtifactRarity{ get{ return 15; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public TunicofDragonF()
		{
			Hue = 1157;
			Name = "Chest of the Dragon";
            Attributes.RegenMana = 3;
            Attributes.RegenStam = 3;
            Attributes.RegenHits = 3;
            Attributes.WeaponSpeed = 20;
            Attributes.AttackChance = 20;
            ArmorAttributes.MageArmor = 1;
            PhysicalBonus = 10;
            FireBonus = 10;
            ColdBonus = 10;
            PoisonBonus = 10;
            EnergyBonus = 10;		
		}

		public TunicofDragonF( Serial serial ) : base( serial )
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
				m.SendMessage( "You feel the power of a dragon embrace you as the tunic attaches to you!" );

			}
			
			return true;
		}
	}
}
