using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public enum HolidayBell2008Type
	{
		Tannis,
		Victoria,
		Alexis,
		Ravenloff,
		Melos,
		Serenity,
		Dena,
		Aisling,
		GrizzlyAdams,
        CradianDarkwolf,
        Hera
		//Vincent,
		//Lolth,
		//Arwynn
		//Melantus,
		//Nimrond,
		//Oaks,
		//Prophet,
		//Runesabre,
		//Sage,
		//Stellerex,
		//TBone,
		//Tajima,
		//Tyrant,
		//Vex
	}

	public enum HolidayBell2008Sound
	{
		Sound1,
		Sound2,
		Sound3,
		Sound4,
		Sound5,
		Sound6
	}

	public class HolidayBell2008 : Item
	{
		private HolidayBell2008Type m_Type;
		private HolidayBell2008Sound m_Sound;

		[CommandProperty( AccessLevel.GameMaster )]
		public HolidayBell2008Type Type
		{
			get{ return m_Type; }
			set{ m_Type = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public HolidayBell2008Sound Sound
		{
			get{ return m_Sound; }
			set{ m_Sound = value; }
		}

		[Constructable]
		public HolidayBell2008() : base( 0x1C12 )
		{

			HolidayBell2008Type randomtype = (HolidayBell2008Type)Utility.Random((int)HolidayBell2008Type.CradianDarkwolf+1);

			m_Type = randomtype;

			HolidayBell2008Sound randomsound = (HolidayBell2008Sound)Utility.Random((int)HolidayBell2008Sound.Sound6+1);

			m_Sound = randomsound;

			LootType = LootType.Blessed;

			Hue = Utility.RandomList( 1150 , 55, 65, 75, 85, 95, 105, 115, 125, 135, 145, 30, 35, 37 );
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{  
			if ( m_Sound == HolidayBell2008Sound.Sound1 )
			{
				from.PlaySound( 0x100 );
			}
			else if ( m_Sound == HolidayBell2008Sound.Sound2 )
			{
				from.PlaySound( 0x101 );
			}
			else if ( m_Sound == HolidayBell2008Sound.Sound3 )
			{
				from.PlaySound( 0x103 );
			}
			else if ( m_Sound == HolidayBell2008Sound.Sound4 )
			{
				from.PlaySound( 0x104 );
			}
			else if ( m_Sound == HolidayBell2008Sound.Sound5 )
			{
				from.PlaySound( 0x16 );
			}
			else if ( m_Sound == HolidayBell2008Sound.Sound6 )
			{
				from.PlaySound( 0x428 );
			}
			else
			{
				from.SendMessage( "INTERNAL ERROR: Please contact a gamemaster about your bell." );
			}
      		}

		public HolidayBell2008( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.WriteEncodedInt( (int) m_Type );

			writer.WriteEncodedInt( (int) m_Sound );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			m_Type = (HolidayBell2008Type)reader.ReadEncodedInt();

			m_Sound = (HolidayBell2008Sound)reader.ReadEncodedInt();
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if ( m_Type == HolidayBell2008Type.Tannis )
			{
				list.Add( "a holiday bell from Tannis" );
			}
			else if ( m_Type == HolidayBell2008Type.Victoria )
			{
				list.Add( "a holiday bell from Victoria" );
			}
			else if ( m_Type == HolidayBell2008Type.Alexis )
			{
				list.Add( "a holiday bell from Alexis" );
			}
			else if ( m_Type == HolidayBell2008Type.Ravenloff )
			{
				list.Add( "a holiday bell from Ravenloff" );
			}
			else if ( m_Type == HolidayBell2008Type.Melos )
			{
				list.Add( "a holiday bell from Melos" );
			}
			else if ( m_Type == HolidayBell2008Type.Serenity )
			{
				list.Add( "a holiday bell from Serenity" );
			}
			else if ( m_Type == HolidayBell2008Type.Dena )
			{
				list.Add( "a holiday bell from Dena" );
			}
			else if ( m_Type == HolidayBell2008Type.Aisling )
			{
				list.Add( "a holiday bell from Aisling" );
			}
			else if ( m_Type == HolidayBell2008Type.GrizzlyAdams )
			{
				list.Add( "a holiday bell from Grizzly Adams" );
			}
			else if ( m_Type == HolidayBell2008Type.CradianDarkwolf )
			{
				list.Add( "a holiday bell from Cradian Darkwolf" );
			}
			else if ( m_Type == HolidayBell2008Type.Hera )
			{
				list.Add( "a holiday bell from Hera" );
			}
			//else if ( m_Type == HolidayBell2007Type.Melantus )
			//{
				//list.Add( "a holiday bell from Melantus" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Nimrond )
			//{
				//list.Add( "a holiday bell from Nimrond" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Oaks )
			//{
				//list.Add( "a holiday bell from Oaks" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Prophet )
			//{
				//list.Add( "a holiday bell from Prophet" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Runesabre )
			//{
				//list.Add( "a holiday bell from Runesabre" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Sage )
			//{
				//list.Add( "a holiday bell from Sage" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Stellerex )
			//{
				//list.Add( "a holiday bell from Stellerex" );
			//}
			//else if ( m_Type == HolidayBell2007Type.TBone )
			//{
				//list.Add( "a holiday bell from TBone" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Tajima )
			//{
				//list.Add( "a holiday bell from Tajima" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Tyrant )
			//{
				//list.Add( "a holiday bell from Tyrant" );
			//}
			//else if ( m_Type == HolidayBell2007Type.Vex )
			//{
				//list.Add( "a holiday bell from Vex" );
			//}
			//else
			//{
				//list.Add( "a holiday bell" );
			//}
		}
	}
}