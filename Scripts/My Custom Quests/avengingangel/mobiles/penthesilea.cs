/*

Scripted by Rosey1
Thought up by Ashe


*/
using System;
using Server;
using Server.ContextMenus;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Misc;
using System.Collections;
using System.Collections.Generic;
using Server.Targeting;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a noble corpse" )]
	public class Penthesilea : Mobile
	{
	
	    private bool m_Decays;
        private DateTime m_DecayTime;
        private Timer m_Timer;
        public virtual bool IsInvulnerable{ get{ return true; } }
        

		[Constructable]
        public Penthesilea() : this(true)
        {
        }        

		
		[Constructable]
        public Penthesilea(bool decays, Point3D loc, Map map)
            : this(decays)
        {
            MoveToWorld(loc, map);
            Effects.PlaySound(loc, map, 0x20E);
        }

        [Constructable]
        public Penthesilea(bool decays) : base()
        {
			Name = "Penthesilea";
		    Body = 401;
            VirtualArmor = 50;
			CantWalk = true;
			Female = true;

            HairItemID= 0x203C;
			HairHue = 1153;
			
            AddItem( new Server.Items.FancyDress( 0x481) );
			AddItem( new Server.Items.Sandals( 0x481) );;
			
			Blessed = true;

            if (decays)
            {
                m_Decays = true;
                m_DecayTime = DateTime.Now + TimeSpan.FromSeconds(30);

                m_Timer = new InternalTimer(this, m_DecayTime);
                m_Timer.Start();
            }
        }
		
		
		public Penthesilea( Serial serial ) : base( serial )
		{
		}
		

		
		
		 public override void OnAfterDelete()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            base.OnAfterDelete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Decays);

            if (m_Decays)
                writer.WriteDeltaTime(m_DecayTime);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Decays = reader.ReadBool();

                        if (m_Decays)
                        {
                            m_DecayTime = reader.ReadDeltaTime();

                            m_Timer = new InternalTimer(this, m_DecayTime);
                            m_Timer.Start();
                        }

                        break;
                    }
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_mobile;

            public InternalTimer(Mobile m, DateTime end)
                : base(end - DateTime.Now)
            {
                m_mobile = m;
            }

            protected override void OnTick()
            {
                m_mobile.Delete();
            }
        }
    }
}