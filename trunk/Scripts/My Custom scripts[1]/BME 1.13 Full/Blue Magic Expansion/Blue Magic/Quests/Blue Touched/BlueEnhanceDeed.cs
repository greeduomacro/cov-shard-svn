// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class BlueEnhanceDeed : Item
	{
		private BlueEnhance m_Enhance;
		private int m_Teir;

		[CommandProperty( AccessLevel.GameMaster )]
		public BlueEnhance Enhance
		{
			get { return m_Enhance; }
			set { m_Enhance = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Teir
		{
			get { return m_Teir; }
			set
			{
				m_Teir = value;

				if ( m_Teir < 1 )
					m_Teir = 1;
				else if ( m_Teir > 2 )
					m_Teir = 2;
			}
		}

		public BlueEnhanceDeed( BlueEnhance enhance, int teir ) : base( 0x14F0 )
		{
			if ( teir == 1 )
				Name = "A Blue Enhance Deed";
			else if ( teir == 2 )
				Name = "A Powerful Blue Enhance Deed";

			Hue = 1365;
			LootType = LootType.Blessed;
			m_Enhance = enhance;
			m_Teir = teir;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			else
				from.Target = new BlueEnhanceTarget( from, this );

			return;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			list.Add( 1114057, this.Name ); // ~1_VAL~
			list.Add( 1038021 ); // blessed
			list.Add( 1070722, "(Enchants Blue Mage Clothing)" ); // ~1_NOTHING~
			list.Add( 1042971, "<ALIGN='CENTER'><BASEFONT COLOR='#007FFF'>*{0}*</BASEFONT></ALIGN>", Enum.GetName( typeof( BlueEnhance ), m_Enhance ) ); // ~1_NOTHING~
		}

		public BlueEnhanceDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Enhance );
			writer.Write( (int) m_Teir );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_Enhance = (BlueEnhance)reader.ReadInt();

			if ( version > 0 )
				m_Teir = reader.ReadInt();
			else
				m_Teir = 1;
		}

		public class BlueEnhanceTarget : Target
		{
			private Mobile m_From;
			private BlueEnhanceDeed m_Deed;

			public BlueEnhanceTarget( Mobile from, BlueEnhanceDeed deed ) : base( 1, false, TargetFlags.None )
			{
				m_From = from;
				m_Deed = deed;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( !from.CanSee( o ) )
					from.SendLocalizedMessage( 500237 ); // Target can not be seen.

				if ( o is BlueClothing )
				{
					BlueClothing cloth = (BlueClothing)o;

					if ( m_Deed.Enhance == BlueEnhance.Efficient && !(cloth is BlueNecklace) )
					{
						from.SendMessage( 1365, "You may only use the Efficient enhancement on the necklace." );
						return;
					}
					
					if ( m_Deed.Teir == 1 )
					{
						if ( cloth.EnhanceOne == m_Deed.Enhance )
						{
							from.SendMessage( 1365, "This piece of clothing already has this enhancement." );
							return;
						}

						cloth.EnhanceOne = m_Deed.Enhance;
						from.SendMessage( 1365, "You enhance the clothing with a Touched enhancement." );
					}
					else if ( m_Deed.Teir == 2 )
					{
						if ( cloth.EnhanceTwo == m_Deed.Enhance )
						{
							from.SendMessage( 1365, "This piece of clothing already has this enhancement." );
							return;
						}

						cloth.EnhanceTwo = m_Deed.Enhance;
						from.SendMessage( 1365, "You enhance the clothing with a Touched enhancement." );
					}

					m_Deed.Delete();
				}
				else
					from.SendMessage( "You cannot use this on that." );
			}
		}


	}

	public class BlueTeirOneEnhanceDeed : BlueEnhanceDeed
	{
		[Constructable]
		public BlueTeirOneEnhanceDeed() : base( (BlueEnhance)( Utility.Random( 9 ) + 1 ), 1 )
		{
		}

		public BlueTeirOneEnhanceDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class BlueTeirTwoEnhanceDeed : BlueEnhanceDeed
	{
		[Constructable]
		public BlueTeirTwoEnhanceDeed() : base( (BlueEnhance)( Utility.Random( 9 ) + 1 ), 2 )
		{
		}

		public BlueTeirTwoEnhanceDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

}