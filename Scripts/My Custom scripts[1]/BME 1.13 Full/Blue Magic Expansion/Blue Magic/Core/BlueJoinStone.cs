// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class BlueJoinStone : Item
	{
		[Constructable]
		public BlueJoinStone() : base( 0x2254 )
		{
			Hue = 1365;
			Movable = false;
			Name = "How to use your enemies strengths as your weapon";
			Weight = 255;
		}

		public override void OnDoubleClick( Mobile from )
		{	
			if ( from.InRange( GetWorldLocation(), 2 ) )
			{
				if ( BlueMageControl.IsBlueMage( from ) )
				{
					if ( from.HasGump( typeof( BlueQuitGump ) ) )
						from.CloseGump( typeof( BlueQuitGump ) );

					from.SendGump( new BlueQuitGump( from ) );
				}
				else
				{
					if ( from.AccessLevel == AccessLevel.Player )
						from.SendMessage( "Please speak to Ben in New Haven" );
					else
					{
						if ( from.HasGump( typeof( BlueAcceptGump ) ) )
							from.CloseGump( typeof( BlueAcceptGump ) );
						
						from.SendGump( new BlueAcceptGump( from ) );
					}
				}
			}

		}

		public BlueJoinStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}