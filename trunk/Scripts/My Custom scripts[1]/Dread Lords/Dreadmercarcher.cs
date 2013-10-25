using System;
using Server;
using Server.Items;
using System.Collections;


namespace Server.Mobiles
{

	[CorpseName( "a Dread Mercenary corpse" )]
	public class dreadmercarcher : BaseCreature
	{

	private static bool m_Talked;

        string[] kfcsay = new string[]
        { 
		 "",
	}; 

		[Constructable]
		public dreadmercarcher () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "male" );
			Body = 0x190;
			SpeechHue = 2124;
			Hue = 33784;
			VirtualArmor = 100;
			Kills = 50;

            SetStr(90);
            SetDex(90);
            SetInt(40);

            SetHits(100, 150);
            SetDamage(15, 25);

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 65, 70 );
			SetResistance( ResistanceType.Poison, 75, 95 );
			SetResistance( ResistanceType.Energy, 20, 30 );



			SetSkill( SkillName.Archery, 95.0 );
            SetSkill(SkillName.Tactics, 90.0);
            SetSkill(SkillName.MagicResist, 100.0);
            SetSkill(SkillName.Anatomy, 100.0);

            Fame = 100;
            Karma = -10000;


            PackItem(new Gold(50, 100));
			PackItem( new Bolt( 80 ) );


            AddItem(new RingmailChest());
            AddItem(new RingmailArms());
            AddItem(new RingmailLegs());
            AddItem(new NorseHelm());
            AddItem(new RingmailGloves());
			AddItem( new Crossbow() );

			
			Item hair = new Item( Utility.RandomList( 0x203B, 0x203C, 0x203D, 0x2044, 0x2045, 0x2047, 0x2049, 0x204A ) );

			hair.Hue = Utility.RandomHairHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;

			AddItem( hair );

			if( Utility.RandomBool() && !this.Female )
			{
				Item beard = new Item( Utility.RandomList( 0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D ) );

				beard.Hue = hair.Hue;
				beard.Layer = Layer.FacialHair;
				beard.Movable = false;

				AddItem( beard );
			
   }		}

		

		public override void OnMovement( Mobile m, Point3D oldLocation ) 
               {                                                    
         	if( m_Talked == false ) 
               { 
            	if ( m.InRange( this, 3 ) ) 
               {                
               	m_Talked = true; 
               	SayRandom( kfcsay, this ); 
               	this.Move( GetDirectionTo( m.Location ) ); 
               	SpamTimer t = new SpamTimer(); 
               	t.Start(); 
               } 
	       }
	       }		

		


		

		public dreadmercarcher( Serial serial ) : base( serial )
		{
		}

     		private class SpamTimer : Timer 
      		{ 
         	public SpamTimer() : base( TimeSpan.FromSeconds( 5 ) ) 
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


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
