using System;
using Server.Misc;
using Server.Network;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class PaladinOfPride : BaseCreature
	{
		public override bool ClickTitle{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return true; } }

		[Constructable]
		public PaladinOfPride(): base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 0x190;
			Name = "Frothos";
			Title = "Master of Pride";
			Hue = 0;

			SetStr( 400, 450 );
			SetDex( 151, 165 );
			SetInt( 180, 200 );

			SetHits( 5000, 5500 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.Wrestling, 100.0 );
			SetSkill( SkillName.Swords, 120.1, 130.0 );
			SetSkill( SkillName.Anatomy, 120.1, 130.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );

			Fame = 10000;
			Karma = -10000;         

			VirtualArmor = 65;          
         
			Broadsword weapon = new Broadsword();
			weapon.Hue = 1153;
			weapon.Movable = false;
			AddItem( weapon );

            PlateGorget gorget = new PlateGorget();
            gorget.Hue = 1153;
            gorget.Movable = false;
            AddItem( gorget );

			MetalShield shield = new MetalShield();
			shield.Hue = 1153;
			shield.Movable = false;
			AddItem( shield );

			PlateHelm helm = new PlateHelm();
			helm.Hue = 1153;
            helm.Movable = false;
			AddItem( helm );

			PlateArms arms = new PlateArms();
			arms.Hue = 1153;
            arms.Movable = false;
			AddItem( arms );

			PlateGloves gloves = new PlateGloves();
			gloves.Hue = 1153;
            gloves.Movable = false;
			AddItem( gloves );

			PlateChest tunic = new PlateChest();
			tunic.Hue = 1153;
            tunic.Movable = false;
			AddItem( tunic );

			PlateLegs legs = new PlateLegs();
			legs.Hue = 1153;
            legs.Movable = false;
			AddItem( legs );

			AddItem( new Boots() );
            Hue = 1153;
            PackGold( 3500,4000 );
            PackItem(new PrideCrystal());
        }
          
		public override int GetIdleSound()
		{
			return 0x184;
		}

		public override int GetAngerSound()
		{
			return 0x286;
		}

		public override int GetDeathSound()
		{
			return 0x288;
		}

		public override int GetHurtSound()
		{
			return 0x19F;
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
        }
        
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }    

		public PaladinOfPride( Serial serial ) : base( serial )
		{
		}

        public override bool OnBeforeDeath()
        {
            MasterOfEnvy rm = new MasterOfEnvy();
            rm.Team = this.Team;
            rm.Combatant = this.Combatant;
            rm.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            rm.MoveToWorld(new Point3D(2003, 1083, -28),Map.Ilshenar);

            return base.OnBeforeDeath();           
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