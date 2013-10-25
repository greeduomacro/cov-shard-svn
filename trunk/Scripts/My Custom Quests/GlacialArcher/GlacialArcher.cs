using System; 
using System.Collections; 
using Server.Items; 
using Server.Targeting; 
 

namespace Server.Mobiles 
{ 
    [CorpseName( "a archer's corpse" )] 
    public class GlacialArcher : BaseCreature 
    { 
	    
        [Constructable] 
        public GlacialArcher() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
        { 
           Body = 400; 
           Hue = Utility.RandomSkinHue(); 
           Name = NameList.RandomName( "male" );
           Title = "the Glacial Archer"; 

           SetStr( 226, 350 ); 
           SetDex( 100, 127 ); 
           SetInt( 107, 138 ); 

           SetHits( 700, 850 );

           SetDamage( 15, 27 );


           SetDamageType( ResistanceType.Physical, 25 );
           SetDamageType( ResistanceType.Cold, 75 );

           SetResistance( ResistanceType.Physical, 50, 65 );
           SetResistance( ResistanceType.Fire, 25, 30 );
           SetResistance( ResistanceType.Cold, 100 );
           SetResistance( ResistanceType.Poison, 50, 65 );
           SetResistance( ResistanceType.Energy, 50, 65 );

           SetSkill( SkillName.Archery, 100, 120 );
           SetSkill( SkillName.Wrestling, 70.1, 80.0 );
           SetSkill( SkillName.EvalInt, 95.1, 100.0 );
		   SetSkill( SkillName.Magery, 95.1, 100.0 );
           SetSkill( SkillName.Tactics, 100, 100 ); 
           SetSkill( SkillName.MagicResist, 100 ); 
           SetSkill( SkillName.Anatomy, 100 ); 
           SetSkill( SkillName.Hiding, 85, 95 );
           
           Fame = 9500;
		   Karma = -9500; 

           VirtualArmor = 75; 
           
           GlacialCrossbow weapon = new GlacialCrossbow();
		   weapon.Hue = 1152;
		   weapon.Movable = false;
		   AddItem( weapon );
 

           AddItem( new NorseHelm() );
           AddItem( new PlateGorget() );
           AddItem( new PlateArms() );
           AddItem( new PlateGloves() );
           AddItem( new FemalePlateChest() );
           AddItem( new PlateLegs() );
           PackItem( new IceBolt( 10 ) );

           switch ( Utility.Random( 7 ))
		   {
	           case 0: PackItem( new GlacialCrossbow() ); break;
	           case 1: PackItem( new Scimitar() ); break;
	           case 2: PackItem( new Katana() ); break;
	           case 3: PackItem( new WarMace() ); break;
	           case 4: PackItem( new Kryss() ); break;
	           case 5: PackItem( new WarHammer() ); break;
	           case 6: PackItem( new Pitchfork() ); break;
		   }

           PackItem( new IceBolt( Utility.Random( 10, 20 ) ) ); 
           PackItem( new Gold( 1500, 1800 ) ); 
      } 
 
           public override bool AlwaysMurderer{ get{ return true; } }
           public override bool Unprovokable{ get{ return true; } }
           public override bool CanRummageCorpses{ get{ return true; } }
		   public override int TreasureMapLevel{ get{ return 3; } }
           public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

           public GlacialArcher( Serial serial ) : base( serial ) 
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


