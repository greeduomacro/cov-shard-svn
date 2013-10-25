/*
 * 
 * Slayer Title System
 * Beta Version 1.0
 * Designed for SVN 663 + ML
 * 
 * Authored by Dougan Ironfist
 * Last Updated on 3/5/2011
 *
 * The purpose of these scripts is to allow shard administrators to create fun kill-based titles that players can earn. 
 * 
 */

using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

/// THIS IS AN EXAMPLE SCRIPT AND MAY BE USED TO CREATE ADDITIONAL SLAYER TITLE GROUPS ///

namespace Server.SlayerTitles
{
    public class UndeadSlayerTitles : BaseSlayerTitle
    {
        // The Initialize routine must be present to in order to start the event used to track player kills
        public static void Initialize()
        {
            /* If you want your players to gain slayer counts by killing monsters, then this type of hook must be in place.
             * 
             * Note: In order for this hook to work, you must make a small change to the BaseCreature script.
             * See the details at the bootom of this script for details.
             */
            KilledByEvent += new KilledByEventHandler(UndeadSlayerTitles_KilledByEvent);
        }

        // This is the code for the hook we made earlier
        public static void UndeadSlayerTitles_KilledByEvent(BaseCreature creature, PlayerMobile player)
        {
            // Test for the creature type(s) that are valid for these titles
            if (creature is RottingCorpse || creature is Zombie)
            {
                // First create an instance of your slayer title (since this routine is static)
               UndeadSlayerTitles titleSystem = new UndeadSlayerTitles();

                // Increment the counter and the core does the rest
                titleSystem.IncrementSlayerCount(player);
            }
        }

        // Set the name of the slayer system so it can be found in the attachment
        public override string SlayerTitleName { get { return "Undead Slayer"; } }


        // Use the contructor section to define the number of kills needed for each level of title progression
        public UndeadSlayerTitles()
        {
            AddSlayerTitleEntry(new SlayerTitleEntry(50, "Greatly Feared Among the Undead"));
            AddSlayerTitleEntry(new SlayerTitleEntry(100, "Master Slayer of the Undead"));
            AddSlayerTitleEntry(new SlayerTitleEntry(250, "Legendary Slayer of the Undead"));
        }
    }
    /*
     * In order to hook into the slayer title system when a creature is killed, you will need to make a small change
     * to the BaseCreature.cs script.  Open the script and find the OnKilledBy routine as shown below.
     * 
     	public virtual void OnKilledBy( Mobile mob )
		{
			if ( m_Paragon && Paragon.CheckArtifactChance( mob, this ) )
				Paragon.GiveArtifactTo( mob );
		}

     * Now we need to add two lines to hook into the reputation system as shown below

		public virtual void OnKilledBy( Mobile mob )
		{
			if ( m_Paragon && Paragon.CheckArtifactChance( mob, this ) )
				Paragon.GiveArtifactTo( mob );

			if (mob is PlayerMobile)
				Server.SlayerTitles.BaseSlayerTitle.OnKilledByEvent(this, ((PlayerMobile)mob));
		}
     
     * Once this changed has been made, save the script and moster kills can now be captured by the
     * slayer title system.
     * 
     */
}
