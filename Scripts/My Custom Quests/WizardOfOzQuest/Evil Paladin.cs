using System;
using Server.Misc;
using Server.Network;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class EvilPaladin : BaseCreature
	{
		public override bool ClickTitle{ get{ return true; } }
		//public override bool ShowFameTitle{ get{ return true; } }

		[Constructable]
		public EvilPaladin(): base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 400;
			Name = "Hinton";
			Title = "The Evil Paladin";
			Hue = 0;

			SetStr( 200, 250 );
			SetDex( 100, 125 );
			SetInt( 180, 200 );

			SetHits( 1900, 2000 );

			SetDamage( 25, 28 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.Wrestling, 100.0 );
			SetSkill( SkillName.Swords, 120 );
			SetSkill( SkillName.Anatomy, 120 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );

			Fame = 10000;
			Karma = -10000;         

			VirtualArmor = 45;          
         
			Broadsword weapon = new Broadsword();
			weapon.Hue = 2306;
			weapon.Movable = false;
			AddItem( weapon );

            PlateGorget gorget = new PlateGorget();
            gorget.Hue = 2306;
            gorget.Movable = false;
            AddItem( gorget );

			MetalShield shield = new MetalShield();
			shield.Hue = 2306;
			shield.Movable = false;
			AddItem( shield );

			PlateHelm helm = new PlateHelm();
			helm.Hue = 2306;
            helm.Movable = false;
			AddItem( helm );

			PlateArms arms = new PlateArms();
			arms.Hue = 2306;
            arms.Movable = false;
			AddItem( arms );

			PlateGloves gloves = new PlateGloves();
			gloves.Hue = 2306;
            gloves.Movable = false;
			AddItem( gloves );

			PlateChest tunic = new PlateChest();
			tunic.Hue = 2306;
            tunic.Movable = false;
			AddItem( tunic );

			PlateLegs legs = new PlateLegs();
			legs.Hue = 2306;
            legs.Movable = false;
			AddItem( legs );

			AddItem( new Boots() );
            Hue = 2306;
            //PackGold( 3500,4000 );
            PackItem(new LionsCourageMedallion());
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
            AddLoot(LootPack.Meager);
        }
        
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }    

		public EvilPaladin( Serial serial ) : base( serial )
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