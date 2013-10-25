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
	public class Calisto : BaseCreature
	{
		[Constructable]
		public Calisto() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Calisto";
			Body = 400;

			Female = false;

			SetStr( 536, 585 );
			SetDex( 126, 145 );
			SetInt( 281, 305 );

			SetHits( 322, 351 );

			SetDamage( 13, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.EvalInt, 85.1, 100.0 );
			SetSkill( SkillName.Magery, 85.1, 100.0 );
			SetSkill( SkillName.MagicResist, 80.2, 110.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.Wrestling, 40.1, 50.0 );

			Fame = 11500;
			Karma = -11500;

			VirtualArmor = 40;
			
			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomHairHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
			
			NinjaTabi ninjatabi = new NinjaTabi();
			ninjatabi.Hue = 0x1;
			AddItem( ninjatabi );

			LeatherNinjaPants ninjapants = new LeatherNinjaPants();
			ninjapants.Hue = 1;
			AddItem(ninjapants);
			
			LeatherNinjaJacket ninjajacket = new LeatherNinjaJacket();
			ninjajacket.Hue = 1;
			AddItem(ninjajacket);
			
			LeatherJingasa jingasa = new LeatherJingasa();
			jingasa.Hue = 1;
			AddItem(jingasa);	
			
		}
		

		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public Calisto( Serial serial ) : base( serial )
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

                    pm.AddToBackpack(new ShatteredBreastPlate());
                    
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
						bc.ControlMaster.AddToBackpack(new ShatteredBreastPlate());

                    }

                }

            }
            base.OnDeath(c);
        }
	}
}