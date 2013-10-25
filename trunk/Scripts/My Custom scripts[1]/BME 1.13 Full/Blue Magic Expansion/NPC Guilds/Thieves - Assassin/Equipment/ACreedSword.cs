// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class ACreedSword : Longsword
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ACreedSword()
		{
			Name = "Altair's Sword";
			Attributes.AttackChance = 25;
			Attributes.DefendChance = 25;
			Attributes.WeaponSpeed = 40;
			Attributes.WeaponDamage = 75;
		}

		public override bool CanEquip( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				if ( ((PlayerMobile)from).NpcGuild == NpcGuild.ThievesGuild )
					return base.CanEquip( from );
				else
				{
					from.SendMessage( "You may not wear this." );
					return false;
				}
			}

			return base.CanEquip( from );
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
				Name = "<BASEFONT ALIGN='CENTER' COLOR='#C0C0C0'>Altair's Sword";

			base.OnAdded( parent );
		}

		public override void OnRemoved( object parent )
		{
			Name = "Altair's Sword";
			Layer = Layer.TwoHanded;
			base.OnRemoved( parent );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			if ( attacker.FindItemOnLayer( Layer.Arms ) is ACreedBoneArms )
			{
				if ( defender.Hits < (defender.HitsMax/10) )
					damageBonus += 1.5; // +150%
			}

			// Back Attack
			if ( attacker.GetDirectionTo( defender.Location ) == defender.Direction )
				damageBonus += 1.0; // +100%

			base.OnHit( attacker, defender, damageBonus );
		}

		public ACreedSword( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}