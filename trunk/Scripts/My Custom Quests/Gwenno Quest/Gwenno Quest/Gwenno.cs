using System; 
using System.Collections; 
using Server.Items; 

namespace Server.Mobiles 
{ 
   [CorpseName( "Gwenno's Corpse" )] 
   public class Gwenno : BaseCreature 
   { 
   		 
         [Constructable]
			public Gwenno() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 ) 
			{ 
         Name = "King Gwenno"; 
         Title = "The Scourge !"; 
	     Body = 0x190;
		 Hue = Utility.RandomSkinHue();
         Fame = 0; 
         Karma = 0;
         VirtualArmor = 100;
 
		 AddItem( new Server.Items.Cloak( 22222 ) );
		 AddItem( new Server.Items.Robe( 1131 ) );
		 /*AddItem( new Server.Items.SwordofGwenno() );
		 AddItem( new Server.Items.ShieldofGwenno() );*/

         SwordofGwenno Broadsword = new SwordofGwenno();
         Broadsword.Movable = false;
         AddItem(Broadsword);

         ShieldofGwenno Shield = new ShieldofGwenno();
         Shield.Movable = false;
         AddItem(Shield);
			
         
		 SetDex( 225 );
		 SetInt( 225 );
		 SetStr( 160 );
		 

         SetHits( 9000, 10000 ); 

         
         SetDamage( 25, 30 ); 
         

         SetDamageType( ResistanceType.Physical, 50 ); 
         SetDamageType( ResistanceType.Cold, 50 ); 
         //SetDamageType( ResistanceType.Fire, 25 ); 
         //SetDamageType( ResistanceType.Energy, 0 );
         //SetDamageType( ResistanceType.Poison, 25 ); 

         SetResistance( ResistanceType.Physical, 50, 65 ); 
         SetResistance( ResistanceType.Fire, 75, 85 ); 
         SetResistance( ResistanceType.Cold, 65, 75 ); 
         SetResistance( ResistanceType.Poison, 100, 100 ); 
         SetResistance( ResistanceType.Energy, 65, 75 ); 

         SetSkill( SkillName.Anatomy, 150.0 );
         SetSkill( SkillName.ArmsLore, 120.0 ); 
         SetSkill( SkillName.EvalInt, 120.0 );
         SetSkill( SkillName.Tactics, 120 ); 
         SetSkill( SkillName.Healing, 120.0 );
         SetSkill( SkillName.Fencing, 120.0 );
         SetSkill( SkillName.MagicResist, 120 );
         SetSkill( SkillName.Magery, 120 );
         SetSkill( SkillName.Parry, 120 );
         SetSkill( SkillName.Meditation, 120 );   
		 SetSkill( SkillName.Swords, 120 );
		 
                                    
         
        PackItem( new Bandage( 100 ) );
		PackItem( new Gold( 10000) );
	    PackItem( new HeadofGwenno() ); 
				
      	
   }
   private int bandages = 0;
   public override void OnDamage( int amount, Mobile from, bool willKill )
 	        {
			if ( (!willKill) ) 
			{
 	        if ( (this.Hits < (int)(this.HitsMax / 0.5)) && (((bandages > 0)) ) ) {
		      
 	        }
			}
 	        if (bandages > 0) {
			BandageContext.BeginHeal( this, this );
			bandages--;
		      }
 	        }
    
	  public override bool Unprovokable{ get{ return true; } }  
	  public override int TreasureMapLevel{ get{ return 5; } } 
      public override bool CanRummageCorpses{ get{ return true; } } 
      public override bool AlwaysMurderer{ get{ return true; } }
      public override bool HasBreath{ get{ return true; } } 
      public override bool BardImmune{ get{ return true; } }
	  public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
	  public override bool AutoDispel{ get{ return true; } }
        
      public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
			
		}
			
      public Gwenno( Serial serial ) : base( serial ) 
      { 
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
