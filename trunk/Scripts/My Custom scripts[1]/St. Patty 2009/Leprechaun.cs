using System; 
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an Leprechaun corpse" )] 
	public class Leprechaun : BaseCreature 
	{ 
		[Constructable] 
		public Leprechaun() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "the leprechaun";
			Body = 400;
                        Hue = 33770;

                        AddItem( new LeprechaunCloakBL () );
                        AddItem( new LeprechaunPantsBL () );
                        AddItem( new LeprechaunBootsBL () );
                        AddItem( new LeprechaunShirtBL () );
                        AddItem( new LeprechaunHat1BL () );
                        AddItem( new Shillelagh () );

			SetStr( 281, 295 );
			SetDex( 191, 215 );
			SetInt( 126, 150 );

			SetHits( 3149, 3163 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 65, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			//Fame = 10500;
			//Karma = -10500;

			VirtualArmor = 56;
                     
                        Container pack = new Backpack();  
                        pack.Movable = false; 
                        AddItem( pack );
                        PackItem(new LeprechaunCloak());
                        PackItem(new LeprechaunPants());
                        PackItem(new LeprechaunBoots());
                        PackItem(new LeprechaunShirt());
                        PackItem(new LeprechaunHat1());
                        PackItem(new Shillelagh());
                        PackItem(new GreenGlass());
                        
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public Leprechaun( Serial serial ) : base( serial ) 
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
