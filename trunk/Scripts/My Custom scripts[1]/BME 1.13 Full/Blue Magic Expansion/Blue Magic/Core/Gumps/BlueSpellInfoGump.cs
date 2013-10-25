// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Spells.BlueMagic;

namespace Server.Gumps
{
	public class BlueSpellInfoGump : Gump
	{
		public BlueSpellInfoGump( int number ) : base( 0, 0 )
		{
			this.Closable = true;
			this.Disposable = true;
			this.Dragable = true;
			this.Resizable = false;

			AddPage( 0 );
			AddBackground( 0, 0, 230, 155, 9270 ); // Background
			string name = BlueSpellInfo.GetName( number );

			AddLabel( 15, 15, 1365, name ); // Spell Name
			AddHtml( 15, 40, 200, 100, GetDescription( number ), true, true );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
		}

		public static string GetDescription( int number )
		{
			Type t = BlueSpellInfo.GetSpellType( number );

			object[] attrs = t.GetCustomAttributes( typeof( DescriptionAttribute ), true );

			if ( attrs != null && attrs.Length > 0 )
			{
				DescriptionAttribute attr = attrs[0] as DescriptionAttribute;

				if ( attr != null )
					return attr.Description;
			}

			return null;
		}
	}
}