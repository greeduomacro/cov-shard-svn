// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class UpgradeSporkDeed : Item
	{
		[Constructable]
		public UpgradeSporkDeed() : base( 0x14F0 )
		{
			Name = "Upgrade Spork Deed";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			else
				from.Target = new UpgradeSporkTarget( from, this );

			return;
		}

		public UpgradeSporkDeed( Serial serial ) : base( serial )
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


		public class UpgradeSporkTarget : Target
		{
			private Mobile m_From;
			private UpgradeSporkDeed m_Deed;

			public UpgradeSporkTarget( Mobile from, UpgradeSporkDeed deed ) : base( 1, false, TargetFlags.None )
			{
				m_From = from;
				m_Deed = deed;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( !from.CanSee( o ) )
					from.SendLocalizedMessage( 500237 ); // Target can not be seen.

				if ( o is NeedleFork )
				{
					NeedleFork needle = (NeedleFork)o;
					needle.Attributes.WeaponDamage += 20;
					needle.WeaponAttributes.HitManaDrain = 25;
					m_Deed.Delete();
				}
				else if ( o is SilverFork )
				{
					SilverFork silver = (SilverFork)o;
					silver.Attributes.WeaponDamage += 20;
					silver.WeaponAttributes.HitLeechStam = 50;
					m_Deed.Delete();
				}
				else if ( o is BistroFork )
				{
					BistroFork bistro = (BistroFork)o;
					bistro.Attributes.WeaponDamage += 20;
					bistro.WeaponAttributes.HitFireball = 25;
					m_Deed.Delete();
				}
				else if ( o is GastroFork )
				{
					GastroFork gastro = (GastroFork)o;
					gastro.Attributes.WeaponDamage += 20;
					gastro.WeaponAttributes.HitLeechMana = 40;
					m_Deed.Delete();
				}
				else
					from.SendMessage( "You cannot use this on that." );
			}
		}

	}
}