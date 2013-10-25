// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class UpgradeACreedGarbDeed : Item
	{
		[Constructable]
		public UpgradeACreedGarbDeed() : base( 0x14F0 )
		{
			Name = "Upgrade Assassin Garb Deed";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			else
				from.Target = new UpgradeACreedGarbTarget( from, this );

			return;
		}

		public UpgradeACreedGarbDeed( Serial serial ) : base( serial )
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


		public class UpgradeACreedGarbTarget : Target
		{
			private Mobile m_From;
			private UpgradeACreedGarbDeed m_Deed;

			public UpgradeACreedGarbTarget( Mobile from, UpgradeACreedGarbDeed deed ) : base( 1, false, TargetFlags.None )
			{
				m_From = from;
				m_Deed = deed;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( !from.CanSee( o ) )
					from.SendLocalizedMessage( 500237 ); // Target can not be seen.

				if ( o is ACreedGarb )
				{
					ACreedGarb ag = (ACreedGarb)o;

					if ( ag.Level < 3 )
					{
						++ag.Level;
						from.SendMessage( "You upgrade the Assassin's Garb." );
						m_Deed.Delete();
					}
					else
					{
						from.SendMessage( "That is fully upgraded." );
					}
				}
				else
					from.SendMessage( "You cannot use this on that." );
			}
		}

	}
}