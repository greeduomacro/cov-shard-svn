
using System;
using Server;
using Server.Items;

namespace Server.Mobiles 
{
    [CorpseName( "a Wicked Witch of the West corpse" )]
   	public class WickedWitch : BaseCreature
   	{
        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.WhirlwindAttack;
        }

        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

        [Constructable]
        public WickedWitch() : base (AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.4)          
        {
            Body = 401;
            Name = "Tantra";
            Title = "The Wicked Witch of the West";
            Hue = 0;
            AddItem(new Robe(2051));
            AddItem(new HalfApron(1163));
            AddItem(new Server.Items.Sandals(2051));
            AddItem(new WizardsHat(2051));
            Utility.AssignRandomHair(this);
            HairHue = 2401;
                                
                SetStr( 200, 250 );
                SetDex( 90, 110 );
                SetInt( 310, 330 );

                SetHits( 1900, 2000 );

                SetDamage( 25, 35 );

                SetDamageType( ResistanceType.Physical, 100 );
                SetDamageType( ResistanceType.Energy, 25 );
                SetDamageType( ResistanceType.Poison, 20);
                SetDamageType( ResistanceType.Energy, 20);

                SetResistance( ResistanceType.Physical, 100 );
                SetResistance( ResistanceType.Fire, 60 );
                SetResistance( ResistanceType.Cold, 50 );
                SetResistance( ResistanceType.Poison, 50 );
                SetResistance( ResistanceType.Energy, 60 );

                SetSkill( SkillName.Magery, 120.0 );
                SetSkill( SkillName.MagicResist, 120.0 );
                SetSkill( SkillName.Tactics, 100.0 );
                SetSkill( SkillName.Wrestling, 100.0 );

         		Fame = 20000; 
		 	    Karma = -20000;

                VirtualArmor = 75;

			    PackGold( 40, 60);
                PackItem( new RubyRedSlippers());
            }

       		public override bool BardImmune { get { return true; } }
       		public override bool Unprovokable { get { return true; } }
       		public override bool Uncalmable { get { return true; } }	
       		public override bool AlwaysMurderer { get { return true; } }
             	  	

        public WickedWitch(Serial serial) : base(serial)
		{
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
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

