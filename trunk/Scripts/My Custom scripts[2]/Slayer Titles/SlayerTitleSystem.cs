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
using Server;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

/// THIS IS A CORE SCRIPT AND SHOULD NOT BE ALTERED ///

namespace Server.SlayerTitles
{
    public class SlayerTitleSystem
    {
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
        }

        public static void EventSink_Login(LoginEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                SlayerTitleAttachment attachment = FindAttachment(e.Mobile);
            }
        }

        public static SlayerTitleAttachment FindAttachment(Mobile m)
        {
            SlayerTitleAttachment attachment = (SlayerTitleAttachment)XmlAttach.FindAttachment(m, typeof(SlayerTitleAttachment));

            if (attachment == null)
            {
                attachment = new SlayerTitleAttachment();
                XmlAttach.AttachTo(m, attachment);
            }

            return attachment;
        }
    }
}
