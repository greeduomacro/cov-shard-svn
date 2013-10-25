
using System;
using Server;
using System.Collections.Generic;
using Server.Items;
using Server.ContextMenus;

namespace Server.Mobiles 
{
    [CorpseName( "an evil librarian corpse" )]
   	public class EvilLibrarian : BaseCreature
   	{
        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

        private static bool m_Talked; // flag to prevent spam 

        string[] kfcsay = new string[] // things to say while greeting 
		      { 
		         "Ha Ha Ha, so you seek the answers to the King's riddles, the only way to get those, is to defeat me!",   
      };

        [Constructable]
        public EvilLibrarian() : base (AIType.AI_Mage, FightMode.Closest, 10, 1, 0.15, 0.4)          
        {
            Body = 0x190;
            Name = "Ashton";
            Title = "The Evil Librarian";
            AddItem(new FancyShirt());
            AddItem(new LongPants());
            AddItem(new Server.Items.Sandals(1));
            Utility.AssignRandomHair(this);
            HairHue = 1;
                                
                SetStr( 400, 450 );
                SetDex( 210, 250 );
                SetInt( 310, 330 );

                SetHits( 2800, 3000 );

                SetDamage( 20, 25 );

                SetDamageType( ResistanceType.Physical, 100 );
                SetDamageType( ResistanceType.Energy, 25 );
                SetDamageType( ResistanceType.Poison, 20);
                SetDamageType( ResistanceType.Energy, 20);

                SetResistance( ResistanceType.Physical, 100 );
                SetResistance( ResistanceType.Fire, 70 );
                SetResistance( ResistanceType.Cold, 70 );
                SetResistance( ResistanceType.Poison, 70 );
                SetResistance( ResistanceType.Energy, 70 );

                SetSkill( SkillName.Magery, 100.0 );
                SetSkill( SkillName.MagicResist, 120.0 );
                SetSkill( SkillName.Tactics, 100.0 );
                SetSkill( SkillName.Wrestling, 100.0 );

         		Fame = 20000; 
		 	    Karma = -20000;

                VirtualArmor = 65;

                PackItem( new ClueBook());
                PackItem( new YourMind());
            }

       		public override bool BardImmune { get { return true; } }
       		public override bool Unprovokable { get { return true; } }
       		public override bool Uncalmable { get { return true; } }	
       		public override bool AlwaysMurderer { get { return true; } }

        public override void OnMovement( Mobile m, Point3D oldLocation ) 
			               {                                                    
			         if( m_Talked == false ) 
			         { 
			            if ( m.InRange( this, 5 ) ) 
			            {                
			               m_Talked = true; 
			               SayRandom( kfcsay, this ); 
			               this.Move( GetDirectionTo( m.Location ) ); 
			                  // Start timer to prevent spam 
			               SpamTimer t = new SpamTimer(); 
			               t.Start(); 
			            } 
			         } 
			      } 
			
			      private class SpamTimer : Timer 
			      { 
			         public SpamTimer() : base( TimeSpan.FromSeconds( 90 ) ) 
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
					public EvilLibrarian( Serial serial ) : base( serial )
					{
		}
	
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 3);
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

