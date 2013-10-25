using System;
using Server;
using Server.Items;
using System.Collections;


namespace Server.Mobiles
{

	[CorpseName( "a Dread Lord corpse" )]
	public class dreadlordspk : BaseCreature
	{

	private static bool m_Talked;

        string[] kfcsay = new string[]
        { 
		 "Prepare yourself to die.",
		 "Fool! How dare you come into my presence!",
		 "I have no dispute with killing you.",
		 "I shall leave your corpse for the wolves.",
		 "There is nothing you can do to stop me.",
		 "I shall be victorious!",
		 "Who sends this welp to challenge me?!",
		 "Run while you still have the legs to carry you.",
		 "Feel the wrath of the dread lords!",
	}; 

		[Constructable]
		public dreadlordspk () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "male" );
			Body = 0x190;
			SpeechHue = 2124;
			Hue = 33784;
			VirtualArmor = 100;
			Kills = 50;

			SetStr( 200 );
			SetDex( 90 );
			SetInt( 40 );

			SetHits( 200, 300 );
			SetDamage( 25, 35 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 65, 70 );
			SetResistance( ResistanceType.Poison, 75, 95 );
			SetResistance( ResistanceType.Energy, 20, 30 );



			SetSkill( SkillName.Swords, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Anatomy, 100.0 );

			Fame = 10000;
			Karma = -10000;


			PackItem( new Gold( 200 , 800 ) );


			AddItem( new PlateChest() );
			AddItem( new PlateArms() );
			AddItem( new PlateLegs() );
			AddItem( new PlateHelm() );
			AddItem( new Cloak( 32 ) );
			AddItem( new HalfApron( 32 ) );
			AddItem( new BodySash( 32 ) );
			AddItem( new HeaterShield() );
			AddItem( new VikingSword() );

			
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

		


		

		public dreadlordspk( Serial serial ) : base( serial )
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
