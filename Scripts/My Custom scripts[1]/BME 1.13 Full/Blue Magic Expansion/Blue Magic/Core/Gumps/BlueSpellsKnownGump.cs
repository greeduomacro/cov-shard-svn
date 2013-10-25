// Created by Peoharen
using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Spells.BlueMagic;

namespace Server.Gumps
{
	public class BlueSpellsKnownGump : Gump
	{
		Mobile m_From;

		public BlueSpellsKnownGump( Mobile from ) : base( 0, 0 )
		{
			m_From = from;

			if ( !BlueMageControl.IsBlueMage( m_From ) )
				return;

			this.Closable = true;
			this.Disposable = true;
			this.Dragable = true;
			this.Resizable = false;

			bool[] boollist = BlueMageControl.GetBoolList( m_From );
			int count = 0, x = 0, y = 0;
			List<LabelInfo> labels = new List<LabelInfo>();

			for ( int i = 0; i < boollist.Length; i++ )
			{
				if ( boollist[i] )
				{
					x = (count % 2) == 0 ? 15 : 140;
					y = (((count / 2)-1) * 25) + 125;
					labels.Add( new LabelInfo( x, y, 1365, BlueSpellInfo.GetName( i ), i ) );

					count++;
				}
			}

			int knownY = labels.Count / 2 + 1;

			AddPage( 0 );

			AddBackground( 0, 0, 190 + 80, 85, 9270 ); // Top layer
			AddBackground( 0, 80, 190 + 80, (knownY * 25) + 30, 9270 ); // Middle Layer
			AddBackground( 0, 85 + (knownY * 25) + 30 - 10,	190 + 80, 85,						9270 ); // Bottem Layer

			AddImage( 15, 15, 11013, 1365 ); // Arms book
			AddLabel( 60, 15, 1365, @"Blue Spells Known" );

			AddLabel( 28 + 40, 85 + (knownY * 25) + 25 + 12, 1365, @"Created By Peoharen" );
			AddImage( 75 + 40, 85 + (knownY * 25) + 25 + 32, 113, 1365 ); // Virtue

			for ( int i = 0; i < labels.Count; i++ )
			{
				AddButton( labels[i].X, labels[i].Y + 5, 1209, 1210, labels[i].SpellNumber + 1, GumpButtonType.Reply, 0 );
				AddButton( labels[i].X + 20, labels[i].Y + 3, 22153, 22154, labels[i].SpellNumber + 100, GumpButtonType.Reply, 0 );
				AddLabel( labels[i].X + 40, labels[i].Y, labels[i].Hue, labels[i].Words );
			}

		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

			if ( info.ButtonID < 100 && info.ButtonID > 0 )
			{
				BlueSpellInfo.UseBluePower( from, info.ButtonID - 1 );

				if ( from.HasGump( typeof( BlueSpellsKnownGump ) ) )
					from.CloseGump( typeof( BlueSpellsKnownGump ) );

				from.SendGump( new BlueSpellsKnownGump( from ) );
			}
			else if ( info.ButtonID > 99 && info.ButtonID < (BlueSpellInfo.SPELLCOUNT + 100) )
			{
				if ( from.HasGump( typeof( BlueSpellsKnownGump ) ) )
					from.CloseGump( typeof( BlueSpellsKnownGump ) );

				from.SendGump( new BlueSpellsKnownGump( from ) );

				if ( from.HasGump( typeof( BlueSpellInfoGump ) ) )
					from.CloseGump( typeof( BlueSpellInfoGump ) );

				from.SendGump( new BlueSpellInfoGump( info.ButtonID - 100 ) );
			}
		}
	}

	class LabelInfo
	{
		public int X;
		public int Y;
		public int Hue;
		public string Words;
		public int SpellNumber;

		public LabelInfo( int x, int y, int hue, string words, int number )
		{
			X = x;
			Y = y;
			Hue = hue;
			Words = words;
			SpellNumber = number;
		}
	}
}