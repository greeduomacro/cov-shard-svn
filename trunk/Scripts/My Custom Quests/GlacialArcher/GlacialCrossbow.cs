using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class GlacialCrossbow : Crossbow
	{
		
		public override int ArtifactRarity{ get{ return 10; } }
        public override int EffectID{ get{ return   0x3728; } }
                
		public override Type AmmoType{ get{ return typeof( IceBolt ); } }
		public override Item Ammo{ get{ return new IceBolt(); } }
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public GlacialCrossbow()
		{
            Name = "Glacial Crossbow";
            Hue = 1152;
			WeaponAttributes.HitLowerDefend = 25;
			WeaponAttributes.HitColdArea = 25;
			WeaponAttributes.SelfRepair = 5;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 25;

                        //LootType = LootType.Blessed;
                        
		}
                
                public virtual void OnHit( Mobile attacker, Mobile defender )
		{
			if ( attacker.Player && !defender.Player && (defender.Body.IsAnimal || defender.Body.IsMonster) && 0.4 >= Utility.RandomDouble() )
				defender.AddToBackpack( Ammo );

			base.OnHit( attacker, defender );
			
			if ( 0.25 > Utility.RandomDouble() )
			{
				defender.PlaySound( 0xDD );
				defender.FixedParticles( 0x375A, 244, 25, 9941, 1153, 0, EffectLayer.Waist );
			}			
		}

		public GlacialCrossbow( Serial serial ) : base( serial )
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