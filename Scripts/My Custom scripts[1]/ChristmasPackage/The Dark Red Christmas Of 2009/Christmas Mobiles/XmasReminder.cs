using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a corpse")]
	public class XmasReminder : BaseCreature
	{
		private static bool m_Talked;
		string[] XmasReminderSay = new string[]
		{
			"Happy Holidays!",
			"Merry Christmas Everyone!",
            "I Heard Santa and Misses Clause along with one of the Elfs have gone Mad!",
            "We must stop this Christmas of Terror!",
            "We can't let the Exploding Presents get into any Child's Hand!",
            "Somebody! Anybody! Please Help us Stop this Horrible Madness or Christmas will never be the same Again!",
		};

		public override bool ShowFameTitle{ get{ return false; } }

        [Constructable]
        public XmasReminder()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SpeechHue = Utility.RandomDyedHue();
            Hue = 0x83EA;

            Body = 400;
            Name = "The Christmas Reminder";

            
            VirtualArmor = 90;

            AddItem(new HoodedShroudOfShadows(0x26));


        }
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if( m_Talked == false )
			{
				if ( m.InRange( this, 3 ) && m is PlayerMobile)
				{
					m_Talked = true;
					SayRandom( XmasReminderSay, this );
					this.Move( GetDirectionTo( m.Location ) );
					SpamTimer t = new SpamTimer();
					t.Start();
				}
			}
		}

		private class SpamTimer : Timer
		{
			public SpamTimer() : base( TimeSpan.FromSeconds( 12 ) )
			{
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_Talked = false;
			}
		}

		private static void SayRandom( string[] say, Mobile m )
		{
			m.Say( say[Utility.Random( say.Length )] );
		}

		public XmasReminder( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
