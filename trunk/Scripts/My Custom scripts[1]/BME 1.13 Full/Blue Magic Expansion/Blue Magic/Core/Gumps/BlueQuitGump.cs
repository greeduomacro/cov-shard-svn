// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Gumps
{
	public class BlueQuitGump : Gump
	{
		public BlueQuitGump( Mobile from ) : base( 0, 0 )
		{
			if ( !BlueMageControl.IsBlueMage( from ) )
				return;

			Closable = true;
			Disposable = true;
			Dragable = true;

			AddPage( 0 );
			AddBackground( 0, 0, 175, 290, 9270 ); // Background
			AddImage( 0, 0, 50468, 2101 ); // Cloak
			AddImage( 0, 0, 12, 1008 ); // Body
			AddImage( 0, 0, 50434, 2101 ); // Shirt
			AddImage( 0, 0, 50431, 2101 ); // Pants
			AddImage( 0, 0, 50490, 2101 ); // Sash
			AddImage( 0, 0, 50556, 2101 ); // Arms
			AddImage( 0, 0, 50702, 1109 ); // Hair
			AddImage( 0, 0, 50804, 1109 ); // Beard
			AddImage( 0, 0, 50941, 2101 ); // Boots
			AddImage( 0, 0, 50943, 2101 ); // Belt
			AddImage( 0, 1, 50409, 2101 ); // Hat
			AddButton( 15, 235, 1147, 1148, 1, GumpButtonType.Reply, 0 ); // OK Button
			AddButton( 90, 235, 1144, 1145, 2, GumpButtonType.Reply, 0 ); // Cancil Button
			AddTextEntry( 20, 15, 132, 20, 1365, 0, @"Quit being a Blue Mage?" ); // Text Entry
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int button = info.ButtonID;

			switch( button )
			{
				// OK Button
				case 1:
				{
					if ( sender.Mobile != null && sender.Mobile is PlayerMobile )
					{
						BlueMageControl.RemoveBlueMage( sender.Mobile );
						sender.Mobile.SendMessage( 1365, "You are no longer a blue mage.");
					}
				}
				break;

				/*
				// Cancil Button
				case 2: break;
				*/
			}
		}
	}
}
/*

The Blue Mage is a practitioner of Blue Magic, 
who learns to create a spell that replicates the 
special attacks of monsters through observation and contact.


Blue Magic
Blue magic operates slightly differently from other forms of magic. 
Blue magic spells are special attacks used by monsters, 
which are typically learned by Blue Mages through a form 
of observation or direct contact with the attack. 
They are not divided into levels like many other schools of magic, 
and several games in the series have referred to Blue Magic by some 
other name, most notably Final Fantasy VI ("Lores") and 
Final Fantasy VII ("Enemy Skills").

Blue Magic can provide a variety of abilities not accessible to other 
characters, but acquiring them can be difficult; the player often 
must be strong enough to be hit and survive the attack to use it, 
must control an enemy (or cast reflect) to get an ability never 
cast on an opponent, and is usually not told in the game which 
abilities can be learnt. Depending on the rarity of the enemy and 
the frequency the desired spell is cast, it can take a considerable 
amount of time to learn a given spell. Typical Blue Magics include 
White Wind (heals HP to entire party equal to the caster's HP), 
Mighty Guard (casts Shell and Protect on the party, sometimes with 
another effect like Haste or Float), and 1000 Needles (deals exactly 
1000 points of damage to the target, regardless of defenses).



*/
