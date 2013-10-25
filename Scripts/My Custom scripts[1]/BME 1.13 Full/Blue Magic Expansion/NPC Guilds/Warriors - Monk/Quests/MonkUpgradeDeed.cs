// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class MonkUpgradeDeed : Item
	{
		private int m_Teir;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Teir
		{
			get { return m_Teir; }
			set { m_Teir = value; }
		}

		[Constructable]
		public MonkUpgradeDeed( int teir ) : base( 0x14F0 )
		{
			m_Teir = teir;
			Name = "Monk Upgrade Deed";
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1114057, ("[Upgrades to level " + m_Teir.ToString() + "]")  );// ~1_VAL~
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			else
			{
				from.SendMessage( "Select a pair of Monk Fists you own." );
				from.BeginTarget( 1, false, TargetFlags.None, new TargetCallback( OnTarget ) );
			}

			return;
		}

		public void OnTarget( Mobile from, object targeted )
		{
			if ( Deleted )
				return;
			else if ( targeted is MonkFists )
			{
				MonkFists fists = (MonkFists)targeted;

				if ( fists.Parent == from.Backpack )
					from.SendMessage( "Those are not yours." );
				else if ( fists.Teir != (Teir-1) )
					from.SendMessage( "This can only be used to upgrade from one certain level to another." );
				else
				{
					fists.Teir = Teir;
					from.SendMessage( "You upgreaded your Monk Fists." );
					Delete();
				}
					
			}
			else
				from.SendMessage( "That is not a Monk Fist." );
		}

		public MonkUpgradeDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_Teir );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Teir = reader.ReadInt();
		}
	}

	public class MonkUpgradeOne : MonkUpgradeDeed
	{
		[Constructable]
		public MonkUpgradeOne() : base( 1 )
		{
		}

		public MonkUpgradeOne( Serial serial ) : base( serial )
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

	public class MonkUpgradeTwo : MonkUpgradeDeed
	{
		[Constructable]
		public MonkUpgradeTwo() : base( 2 )
		{
		}

		public MonkUpgradeTwo( Serial serial ) : base( serial )
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

	public class MonkUpgradeThree : MonkUpgradeDeed
	{
		[Constructable]
		public MonkUpgradeThree() : base( 3 )
		{
		}

		public MonkUpgradeThree( Serial serial ) : base( serial )
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

	public class MonkUpgradeFour : MonkUpgradeDeed
	{
		[Constructable]
		public MonkUpgradeFour() : base( 4 )
		{
		}

		public MonkUpgradeFour( Serial serial ) : base( serial )
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

	public class MonkUpgradeFive : MonkUpgradeDeed
	{
		[Constructable]
		public MonkUpgradeFive() : base( 5 )
		{
		}

		public MonkUpgradeFive( Serial serial ) : base( serial )
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