// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Gumps
{
	public class BlueAcceptGump : Gump
	{
		public BlueAcceptGump( Mobile from ) : base( 0, 0 )
		{
			if ( BlueMageControl.IsBlueMage( from ) )
				return;

			Closable = true;
			Disposable = true;
			Dragable = true;

			AddPage( 0 );
			AddBackground( 0, 0, 175, 290, 9270 ); // Background
			AddImage( 0, 0, 50468, 1365 ); // Cloak
			AddImage( 0, 0, 12, 1008 ); // Body
			AddImage( 0, 0, 50434, 1365 ); // Shirt
			AddImage( 0, 0, 50431, 1365 ); // Pants
			AddImage( 0, 0, 50490, 1365 ); // Sash
			AddImage( 0, 0, 50556, 1365 ); // Arms
			AddImage( 0, 0, 50702, 2223 ); // Hair
			AddImage( 0, 0, 50804, 2223 ); // Beard
			AddImage( 0, 0, 50941, 1365 ); // Boots
			AddImage( 0, 0, 50943, 1365 ); // Belt
			AddImage( 0, 1, 50409, 1365 ); // Hat
			AddButton( 15, 235, 1147, 1148, 1, GumpButtonType.Reply, 0 ); // OK Button
			AddButton( 90, 235, 1144, 1145, 2, GumpButtonType.Reply, 0 ); // Cancil Button
			AddTextEntry( 20, 15, 132, 20, 1365, 0, @"Become a Blue Mage?" ); // Text Entry

			AddBackground( 175, 0, 175, 290, 3600 ); //HTML Background

			if ( BlueMageControl.SkillLock )
				AddHtml( 190, 15, 145, 260, @"The Blue Mage is a practitioner of Blue Magic, who learns to create a spell that replicates the special attacks of monsters through observation and contact.<br><br>Blue Magic can provide a variety of abilities not accessible to other spellcasters, but acquiring them can be difficult; the mage often must be strong enough to be hit and survive a monster's attack to try to learn it, assuming it can be learned at all.<br><br>!WARNING!<br>You cannot become a master in other spellcasting skills and if you already are your current values will be reduced to 50.0 and so long as you use blue magic you cannot remain higher than that total (you may however continue to use items).", (bool)true, (bool)true ); //HTML
			else
				AddHtml( 190, 15, 145, 260, @"The Blue Mage is a practitioner of Blue Magic, who learns to create a spell that replicates the special attacks of monsters through observation and contact.<br><br>Blue Magic can provide a variety of abilities not accessible to other spellcasters, but acquiring them can be difficult; the mage often must be strong enough to be hit and survive a monster's attack to try to learn it, assuming it can be learned at all.", (bool)true, (bool)true ); //HTML
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
						BlueMageControl.AddBlueMage( sender.Mobile );
						sender.Mobile.SendMessage( 1365, "You are now a blue mage, use \"[bm help\" and learn about the blue mage command you now have access too.");
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



Blue Magic can provide a variety of abilities not accessible to other spellcasters, but acquiring them can be difficult; the mage often must be strong enough to be hit and survive a monster's attack to try to learn it, assuming it can be learned at all.





*/
