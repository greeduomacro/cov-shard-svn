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

/// THIS IS A CORE SCRIPT AND SHOULD NOT BE ALTERED ///

namespace Server.SlayerTitles
{
    public abstract class BaseSlayerTitle
    {
        #region Event Handler
        public delegate void KilledByEventHandler(BaseCreature creature, PlayerMobile player);
        public static event KilledByEventHandler KilledByEvent;

        public static void OnKilledByEvent(BaseCreature creature, PlayerMobile player)
        {
            if (KilledByEvent != null)
                KilledByEvent(creature, player);
        }
        #endregion

        public abstract string SlayerTitleName { get; }

        private List<SlayerTitleEntry> m_SlayerTitleEntries = new List<SlayerTitleEntry>();

        public BaseSlayerTitle()
        {
        }

        public void AddSlayerTitleEntry(SlayerTitleEntry entry)
        {
            m_SlayerTitleEntries.Add(entry);
            m_SlayerTitleEntries.Sort(ComapreByNumber);
        }

        public void IncrementSlayerCount(PlayerMobile player)
        {
            SlayerTitleAttachment attachment = SlayerTitleSystem.FindAttachment(player);

            if (attachment != null)
            {
                SlayerSystemTracker tracker = attachment.FindSystemName(SlayerTitleName);

                if (tracker != null)
                {
                    tracker.SlayerCount += 1;

                    string newTitle = GetTitleAwarded(tracker.SlayerCount);

                    if (newTitle != null)
                    {
                        if (tracker.LastTitleAwarded == null || tracker.LastTitleAwarded != newTitle)
                        {
                            if (tracker.LastTitleAwarded != null && tracker.LastTitleAwarded != newTitle)
                            {
                                try { player.CollectionTitles.Remove(tracker.LastTitleAwarded); }
                                catch { }
                            }

                            player.AddCollectionTitle(newTitle);
                            tracker.LastTitleAwarded = newTitle;
                            player.SendSound(0x3D);
                            player.SendMessage(0xC8, String.Format("Your have been awarded the title of '{0}' for {1} kills.", newTitle, tracker.SlayerCount));
                        }
                    }
                }
            }
        }

        private string GetTitleAwarded(int counter)
        {
            string title = null;

            foreach (SlayerTitleEntry entry in m_SlayerTitleEntries)
            {
                int lastCount = 0;

                if (counter >= entry.SlayerCount && counter >= lastCount)
                {
                    lastCount = entry.SlayerCount;
                    title = entry.SlayerTitle;
                }

            }

            return title;
        }

        public static int ComapreByNumber(SlayerTitleEntry x, SlayerTitleEntry y)
        {
            return x.SlayerCount.CompareTo(y.SlayerCount);
        }
    }

    public class SlayerTitleEntry
    {
        private int m_SlayerCount = 0;
        public int SlayerCount { get { return m_SlayerCount; } }

        private string m_SlayerTitle = "";
        public string SlayerTitle { get { return m_SlayerTitle; } }

        public SlayerTitleEntry(int slayerCount, string slayerTitle)
        {
            m_SlayerCount = slayerCount;
            m_SlayerTitle = slayerTitle;
        }
    }
}