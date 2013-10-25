
using System;
using Server;
using Server.Items;

namespace Server.Mobiles 
{
    [CorpseName( "a mistress of lust corpse" )]
   	public class MistressOfLust : BaseCreature
   	{
        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

        [Constructable]
        public MistressOfLust() : base (AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.4)          
        {
            Body = 0x191;
            Name = "Selendra";
            Title = "Mistress of Lust";
            Hue = 1506;
            AddItem(new ChestOfLust());
            AddItem(new SkirtOfLust());
            AddItem(new Server.Items.Sandals(34));
            Utility.AssignRandomHair(this);
            HairHue = 34;
                                
                SetStr( 400, 450 );
                SetDex( 210, 250 );
                SetInt( 310, 330 );

                SetHits( 6000, 6500 );

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

			    PackGold( 5500, 6000);
                PackItem( new LustCrystal());
            }

       		public override bool BardImmune { get { return true; } }
       		public override bool Unprovokable { get { return true; } }
       		public override bool Uncalmable { get { return true; } }	
       		public override bool AlwaysMurderer { get { return true; } }
             	  	

        public MistressOfLust(Serial serial) : base(serial)
		{
		}

        public override bool OnBeforeDeath()
        {
            MasterOfGluttony ro = new MasterOfGluttony();
            ro.Team = this.Team;
            ro.Combatant = this.Combatant;
            ro.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            ro.MoveToWorld(new Point3D(2008, 1059, -28), Map.Ilshenar);

            return base.OnBeforeDeath();
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
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

