
using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Wicked Tinker's corpse" )]
	public class WickedTinker : BaseCreature
	{			
		[Constructable]
		public WickedTinker() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Jasper";
			Title = "The Wicked Tinker";
			Body = 0x190;
			Hue = Utility.RandomSkinHue();

			SetStr( 90, 100 );
			SetDex( 50, 75 );
			SetInt( 150, 250  );
			SetHits( 1900, 2000 );
			SetDamage( 22, 28 );
			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 70 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 50, 70 );
			SetResistance( ResistanceType.Poison, 50, 70 );
			SetResistance( ResistanceType.Energy, 50, 70 );

			SetSkill( SkillName.EvalInt, 95.0, 120.0 );
			SetSkill( SkillName.Magery, 95.0, 120.0 );
			SetSkill( SkillName.Meditation, 95.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 120.0 );
			SetSkill( SkillName.Tactics, 95.0, 120.0 );
			SetSkill( SkillName.Wrestling, 95.0, 120.0 );

			Fame = 13000;
			Karma = -13000;

			VirtualArmor = 60;

			AddItem( new LongPants( 1 ) );
			AddItem( new Sandals( 1 ) );
			AddItem( new StrawHat( 877 ) );
            AddItem(new HalfApron( 877 ));
            AddItem(new Shirt( 1 ));

			PackGold( 40, 60 );
			PackItem(new TinMansHeart());
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		//public override int TreasureMapLevel{ get{ return 5; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public WickedTinker( Serial serial ) : base( serial )
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