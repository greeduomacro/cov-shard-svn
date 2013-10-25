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
using Server.Engines.XmlSpawner2;

/// THIS IS A CORE SCRIPT AND SHOULD NOT BE ALTERED ///

namespace Server.SlayerTitles
{
    public class SlayerTitleAttachment : XmlAttachment
    {
        private List<SlayerSystemTracker> m_SystemEntries = new List<SlayerSystemTracker>();

        [CommandProperty(AccessLevel.GameMaster)]
        public List<SlayerSystemTracker> SystemEntries { get { return m_SystemEntries; } set { m_SystemEntries = value; } }

        // a serial constructor is REQUIRED
        public SlayerTitleAttachment(ASerial serial)
            : base(serial)
        {
        }

        [Attachable]
        public SlayerTitleAttachment()
        {
        }

        public SlayerSystemTracker FindSystemName(string name)
        {
            SlayerSystemTracker tracker = null;

            foreach (SlayerSystemTracker iTracker in m_SystemEntries)
                if (iTracker.SystemName == name)
                    tracker = iTracker;

            if (tracker == null)
            {
                tracker = new SlayerSystemTracker(name, 0, null);
                m_SystemEntries.Add(tracker);
            }

            return tracker;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write((int)m_SystemEntries.Count);

            foreach (SlayerSystemTracker entry in SystemEntries)
            {
                writer.Write((string)entry.SystemName);
                writer.Write((int)entry.SlayerCount);
                writer.Write((string)entry.LastTitleAwarded);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            int entryCount = reader.ReadInt();

            for (int i = 0; i < entryCount; i++)
                SystemEntries.Add(new SlayerSystemTracker(reader.ReadString(), reader.ReadInt(), reader.ReadString()));
        }
    }

    public class SlayerSystemTracker
    {
        private string m_SystemName = "";
        public string SystemName { get { return m_SystemName; } set { m_SystemName = value; } }

        private int m_SlayerCount = 0;
        public int SlayerCount { get { return m_SlayerCount; } set { m_SlayerCount = value; } }

        private string m_LastTitleAwarded = null;
        public string LastTitleAwarded { get { return m_LastTitleAwarded; } set { m_LastTitleAwarded = value; } }

        public SlayerSystemTracker(string systemName, int slayerCount, string lastTitleAwarded)
        {
            m_SystemName = systemName;
            m_SlayerCount = slayerCount;
            m_LastTitleAwarded = lastTitleAwarded;
        }
    }
}
