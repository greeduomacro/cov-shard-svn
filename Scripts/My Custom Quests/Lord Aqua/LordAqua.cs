using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	[CorpseName( "Lord Aqua's corpse" )] 
	public class LordAqua : BaseCreature 
	{ 
		[Constructable]
        public LordAqua() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4) 
		{ 
			Name = "Aqua";
			Body = 400;
			Hue = 33770;  

			SetStr( 600, 650 );
			SetDex( 250, 300 );
			SetInt( 350, 400 );

			SetHits( 12000, 17000 );

			SetDamage( 10, 15 );

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Cold, 50); 

			SetResistance( ResistanceType.Physical, 0, 1 );
			SetResistance( ResistanceType.Fire, 0, 1 );
			SetResistance( ResistanceType.Poison, 0, 1 );
			SetResistance( ResistanceType.Energy, 0, 1 );

			SetSkill( SkillName.EvalInt, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Wrestling, 100.2, 105.0 );
			SetSkill( SkillName.Meditation, 120.0);
			SetSkill( SkillName.Focus, 120.0);
			SetSkill( SkillName.Swords, 110.0, 120.0 );

            Fame = 15000;
            Karma = -15000;

            VirtualArmor = 50;

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			
			hair.Hue = 1177;
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
            
			AquaChest Chest = new AquaChest();
			Chest.Movable = false;
			AddItem(Chest);
			
			AquaArms Arms = new AquaArms();
			Arms.Movable = false;
			AddItem(Arms);
			
			AquaLegs Legs = new AquaLegs();
			Legs.Movable = false;
			AddItem(Legs);
			
			AquaGloves Gloves = new AquaGloves();
			Gloves.Movable = false;
			AddItem(Gloves);
			
			AquaNeck Gorget = new AquaNeck();
			Gorget.Movable = false;
			AddItem(Gorget);
			
			AquaHelm Helm = new AquaHelm();
			Helm.Movable = false;
			AddItem(Helm);
			
			AquaGuard Shield = new AquaGuard();
			Shield.Movable = false;
			AddItem(Shield);
			
			AquaBlade Sword = new AquaBlade();
			Sword.Movable = false;
			AddItem(Sword);	
			
			if ( 1.00 > Utility.RandomDouble() ) // 0.20 = 20% = chance to drop 
			switch ( Utility.Random( 8 )) //number of alternatives of cases  
            		{ 
				case 0: PackItem( new AquaChest() ); break;
				case 1: PackItem( new AquaBlade() ); break;
				case 2: PackItem( new AquaGuard() ); break;
				case 3: PackItem( new AquaHelm() ); break;
				case 4: PackItem( new AquaNeck() ); break;
				case 5: PackItem( new AquaLegs() ); break;
				case 6: PackItem( new AquaGloves() ); break;
				case 7: PackItem( new AquaArms() ); break;
			}
		}

        public override bool AlwaysMurderer{ get{ return true; } }

		public LordAqua( Serial serial ) : base( serial )
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