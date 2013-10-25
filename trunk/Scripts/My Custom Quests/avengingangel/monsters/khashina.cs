/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class Khashina : BaseCreature
	{
		[Constructable]
		public Khashina() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Khashina";
			Body = 401;
			Female = true;

			SetStr( 767, 945 );
			SetDex( 66, 75 );
			SetInt( 46, 70 );

			SetHits( 476, 552 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Cold, 70 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 125.1, 140.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 50;

            Item hair = new Item( Utility.RandomList( 0x203B, 0x203C, 0x203D, 0x2044, 0x2045, 0x2047, 0x2049, 0x204A ) );
            hair.Hue = Utility.RandomHairHue();
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem( hair );

			
			StuddedArms studdedarms = new StuddedArms();
			studdedarms.Hue = 0x486;
			AddItem( studdedarms );

			FemaleStuddedChest femalesc = new FemaleStuddedChest();
			femalesc.Hue = 0x486;
			AddItem(femalesc);
			
			StuddedGloves studdedg = new StuddedGloves();
			studdedg.Hue = 0x486;
			AddItem(studdedg);
			
			StuddedGorget studdedgg = new StuddedGorget();
			studdedgg.Hue = 0x486;
			AddItem(studdedgg);			
			
			LeatherSkirt leatherskirt = new LeatherSkirt();
			leatherskirt.Hue = 0x486;
			AddItem(leatherskirt);
			
			ThighBoots thighboots = new ThighBoots();
			thighboots.Hue = 0x486;
			AddItem(thighboots);
			
            AddItem( new Server.Items.KhashinaShroud() );


			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public Khashina( Serial serial ) : base( serial )
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
		
		public override void OnDeath(Container c)
        {
            Mobile m = this.FindMostRecentDamager(false);

            if (m is PlayerMobile)
            {
                PlayerMobile pm = m as PlayerMobile;


                Item a = pm.Backpack.FindItemByType(typeof(FallenWarriorMarker2));
                if (a != null)
                {

                    pm.AddToBackpack(new EnergizedIngot());
                    
                }
 
            }
            else if (m is BaseCreature)
            {
                BaseCreature bc = m as BaseCreature;
				PlayerMobile pm = m as PlayerMobile;

                if (bc.Controlled == true)
                {
                    Item a = bc.ControlMaster.Backpack.FindItemByType(typeof(FallenWarriorMarker2));
                    if (a != null)
                    {
						bc.ControlMaster.AddToBackpack(new EnergizedIngot());

                    }

                }

            }
            base.OnDeath(c);
        }
	}
}