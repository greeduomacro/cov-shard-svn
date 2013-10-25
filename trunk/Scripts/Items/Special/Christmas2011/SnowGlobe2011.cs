using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public enum SnowGlobe2011Type
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
		PassOfKarnaugh,
        TerMur
	}

	public class SnowGlobe2011 : Item
	{
		private SnowGlobe2011Type m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public SnowGlobe2011Type Type
		{
			get{ return m_Type; }
			set{ m_Type = value; }
		}

		[Constructable]
		public SnowGlobe2011() : base( 0xE2D)
		{
			SnowGlobe2011Type randomtype = (SnowGlobe2011Type)Utility.Random((int)SnowGlobe2011Type.PassOfKarnaugh+1);

			m_Type = randomtype;

			LootType = LootType.Blessed;
		}

		public SnowGlobe2011( Serial serial ) : base( serial )
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
			
			m_Type = (SnowGlobe2011Type)reader.ReadEncodedInt();
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if ( m_Type == SnowGlobe2011Type.Minoc )
			{
				list.Add( "a snowy scene of minoc" );
			}
			else if ( m_Type == SnowGlobe2011Type.Vesper )
			{
				list.Add( "a snowy scene of vesper" );
			}
			else if ( m_Type == SnowGlobe2011Type.Cove )
			{
				list.Add( "a snowy scene of cove" );
			}
			else if ( m_Type == SnowGlobe2011Type.Yew )
			{
				list.Add( "a snowy scene of yew" );
			}
			else if ( m_Type == SnowGlobe2011Type.Britain )
			{
				list.Add( "a snowy scene of britain" );
			}
			else if ( m_Type == SnowGlobe2011Type.SkaraBrae )
			{
				list.Add( "a snowy scene of skara brae" );
			}
			else if ( m_Type == SnowGlobe2011Type.Trinsic )
			{
				list.Add( "a snowy scene of trinsic" );
			}
			else if ( m_Type == SnowGlobe2011Type.SerpentsHold )
			{
				list.Add( "a snowy scene of serpents hold" );
			}
			else if ( m_Type == SnowGlobe2011Type.Nejelm )
			{
				list.Add( "a snowy scene of nejel'm" );
			}
			else if ( m_Type == SnowGlobe2011Type.Haven )
			{
				list.Add( "a snowy scene of haven" );
			}
			else if ( m_Type == SnowGlobe2011Type.BuccaneersDen )
			{
				list.Add( "a snowy scene of buccaneer's den" );
			}
			else if ( m_Type == SnowGlobe2011Type.Jhelom )
			{
				list.Add( "a snowy scene of jhelom" );
			}
			else if ( m_Type == SnowGlobe2011Type.Moonglow )
			{
				list.Add( "a snowy scene of moonglow" );
			}
			else if ( m_Type == SnowGlobe2011Type.Delucia )
			{
				list.Add( "a snowy scene of delucia" );
			}
			else if ( m_Type == SnowGlobe2011Type.Papua )
			{
				list.Add( "a snowy scene of papua" );
			}
			else if ( m_Type == SnowGlobe2011Type.Occlo )
			{
				list.Add( "a snowy scene of occlo" );
			}
			else if ( m_Type == SnowGlobe2011Type.EmpathsAbbey )
			{
				list.Add( "a snowy scene of empaths abbey" );
			}
			else if ( m_Type == SnowGlobe2011Type.TheLycaeum )
			{
				list.Add( "a snowy scene of the lycaeum" );
			}
			else if ( m_Type == SnowGlobe2011Type.Wind )
			{
				list.Add( "a snowy scene of the wind" );
			}
			else if ( m_Type == SnowGlobe2011Type.Magincia )
			{
				list.Add( "a snowy scene of the magincia" );
			}
			else if ( m_Type == SnowGlobe2011Type.Luna )
			{
				list.Add( "a snowy scene of the luna" );
			}
			else if ( m_Type == SnowGlobe2011Type.Umbra )
			{
				list.Add( "a snowy scene of the umbra" );
			}
			else if ( m_Type == SnowGlobe2011Type.CityOfMistas )
			{
				list.Add( "a snowy scene of the city of mistas" );
			}
			else if ( m_Type == SnowGlobe2011Type.CityOfMontor )
			{
				list.Add( "a snowy scene of the city of montor" );
			}
			else if ( m_Type == SnowGlobe2011Type.EtherealFortress )
			{
				list.Add( "a snowy scene of the city of ethereal fortress" );
			}
			else if ( m_Type == SnowGlobe2011Type.AncientCitadel )
			{
				list.Add( "a snowy scene of the city of ancient citadel" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfValor )
			{
				list.Add( "a snowy scene of the shrine of valor" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfSpirtuality )
			{
				list.Add( "a snowy scene of the shrine of spirtuality" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfSacifice )
			{
				list.Add( "a snowy scene of the shrine of sacifice" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfJustice )
			{
				list.Add( "a snowy scene of the shrine of justice" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfHumility )
			{
				list.Add( "a snowy scene of the shrine of humility" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfHonor )
			{
				list.Add( "a snowy scene of the shrine of honor" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfHonesty )
			{
				list.Add( "a snowy scene of the shrine of honesty" );
			}
			else if ( m_Type == SnowGlobe2011Type.ShrineOfCompassion )
			{
				list.Add( "a snowy scene of the shrine of compassion" );
			}
			else if ( m_Type == SnowGlobe2011Type.PassOfKarnaugh )
			{
				list.Add( "a snowy scene of the pass of karnaugh" );
			}
            else if (m_Type == SnowGlobe2011Type.TerMur)
            {
                list.Add("a snowy scene of TerMur");
            }
		}
	}
}