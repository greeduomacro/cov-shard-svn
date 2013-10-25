using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public enum SnowGlobe2008Type
	{
		Minoc,
		Vesper,
		Cove,
		Yew,
		Britain,
		SkaraBrae,
		Trinsic,
		SerpentsHold,
		Nejelm,
		Haven,
		BuccaneersDen,
		Jhelom,
		Moonglow,
		Delucia,
		Papua,
		Occlo,
		EmpathsAbbey,
		TheLycaeum,
		Wind,
		Magincia,
		Luna,
		Umbra,
		CityOfMistas,
		CityOfMontor,
		EtherealFortress,
		AncientCitadel,
		ShrineOfValor,
		ShrineOfSpirtuality,
		ShrineOfSacifice,
		ShrineOfJustice,
		ShrineOfHumility,
		ShrineOfHonor,
		ShrineOfHonesty,
		ShrineOfCompassion,
		PassOfKarnaugh
	}

	public class SnowGlobe2008 : Item
	{
		private SnowGlobe2008Type m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public SnowGlobe2008Type Type
		{
			get{ return m_Type; }
			set{ m_Type = value; }
		}

		[Constructable]
		public SnowGlobe2008() : base( 0xE2D)
		{
			SnowGlobe2008Type randomtype = (SnowGlobe2008Type)Utility.Random((int)SnowGlobe2008Type.PassOfKarnaugh+1);

			m_Type = randomtype;

			LootType = LootType.Blessed;
		}

		public SnowGlobe2008( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.WriteEncodedInt( (int) m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			m_Type = (SnowGlobe2008Type)reader.ReadEncodedInt();
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if ( m_Type == SnowGlobe2008Type.Minoc )
			{
				list.Add( "a snowy scene of minoc" );
			}
			else if ( m_Type == SnowGlobe2008Type.Vesper )
			{
				list.Add( "a snowy scene of vesper" );
			}
			else if ( m_Type == SnowGlobe2008Type.Cove )
			{
				list.Add( "a snowy scene of cove" );
			}
			else if ( m_Type == SnowGlobe2008Type.Yew )
			{
				list.Add( "a snowy scene of yew" );
			}
			else if ( m_Type == SnowGlobe2008Type.Britain )
			{
				list.Add( "a snowy scene of britain" );
			}
			else if ( m_Type == SnowGlobe2008Type.SkaraBrae )
			{
				list.Add( "a snowy scene of skara brae" );
			}
			else if ( m_Type == SnowGlobe2008Type.Trinsic )
			{
				list.Add( "a snowy scene of trinsic" );
			}
			else if ( m_Type == SnowGlobe2008Type.SerpentsHold )
			{
				list.Add( "a snowy scene of serpents hold" );
			}
			else if ( m_Type == SnowGlobe2008Type.Nejelm )
			{
				list.Add( "a snowy scene of nejel'm" );
			}
			else if ( m_Type == SnowGlobe2008Type.Haven )
			{
				list.Add( "a snowy scene of haven" );
			}
			else if ( m_Type == SnowGlobe2008Type.BuccaneersDen )
			{
				list.Add( "a snowy scene of buccaneer's den" );
			}
			else if ( m_Type == SnowGlobe2008Type.Jhelom )
			{
				list.Add( "a snowy scene of jhelom" );
			}
			else if ( m_Type == SnowGlobe2008Type.Moonglow )
			{
				list.Add( "a snowy scene of moonglow" );
			}
			else if ( m_Type == SnowGlobe2008Type.Delucia )
			{
				list.Add( "a snowy scene of delucia" );
			}
			else if ( m_Type == SnowGlobe2008Type.Papua )
			{
				list.Add( "a snowy scene of papua" );
			}
			else if ( m_Type == SnowGlobe2008Type.Occlo )
			{
				list.Add( "a snowy scene of occlo" );
			}
			else if ( m_Type == SnowGlobe2008Type.EmpathsAbbey )
			{
				list.Add( "a snowy scene of empaths abbey" );
			}
			else if ( m_Type == SnowGlobe2008Type.TheLycaeum )
			{
				list.Add( "a snowy scene of the lycaeum" );
			}
			else if ( m_Type == SnowGlobe2008Type.Wind )
			{
				list.Add( "a snowy scene of the wind" );
			}
			else if ( m_Type == SnowGlobe2008Type.Magincia )
			{
				list.Add( "a snowy scene of the magincia" );
			}
			else if ( m_Type == SnowGlobe2008Type.Luna )
			{
				list.Add( "a snowy scene of the luna" );
			}
			else if ( m_Type == SnowGlobe2008Type.Umbra )
			{
				list.Add( "a snowy scene of the umbra" );
			}
			else if ( m_Type == SnowGlobe2008Type.CityOfMistas )
			{
				list.Add( "a snowy scene of the city of mistas" );
			}
			else if ( m_Type == SnowGlobe2008Type.CityOfMontor )
			{
				list.Add( "a snowy scene of the city of montor" );
			}
			else if ( m_Type == SnowGlobe2008Type.EtherealFortress )
			{
				list.Add( "a snowy scene of the city of ethereal fortress" );
			}
			else if ( m_Type == SnowGlobe2008Type.AncientCitadel )
			{
				list.Add( "a snowy scene of the city of ancient citadel" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfValor )
			{
				list.Add( "a snowy scene of the shrine of valor" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfSpirtuality )
			{
				list.Add( "a snowy scene of the shrine of spirtuality" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfSacifice )
			{
				list.Add( "a snowy scene of the shrine of sacifice" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfJustice )
			{
				list.Add( "a snowy scene of the shrine of justice" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfHumility )
			{
				list.Add( "a snowy scene of the shrine of humility" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfHonor )
			{
				list.Add( "a snowy scene of the shrine of honor" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfHonesty )
			{
				list.Add( "a snowy scene of the shrine of honesty" );
			}
			else if ( m_Type == SnowGlobe2008Type.ShrineOfCompassion )
			{
				list.Add( "a snowy scene of the shrine of compassion" );
			}
			else if ( m_Type == SnowGlobe2008Type.PassOfKarnaugh )
			{
				list.Add( "a snowy scene of the pass of karnaugh" );
			}
			//else
			//{
				//list.Add( "a snow globe" );
			//}
		}
	}
}