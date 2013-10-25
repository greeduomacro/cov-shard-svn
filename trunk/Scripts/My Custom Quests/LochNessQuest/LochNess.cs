using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Loch Ness's Corpse" )]
	public class LochNess : BaseCreature
	{
		[Constructable]
		public LochNess() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Loch Ness Monster";
			Body = 150;
            CantWalk = false;
            CanSwim = true;

			SetStr( 165, 200 );
			SetDex( 500, 900 );
			SetInt( 400, 900 );

			SetHits( 3000 );

			SetDamage( 25, 45 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 60 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 30, 80 );
			SetResistance( ResistanceType.Fire, 20, 100 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 0, 20 );

			SetSkill( SkillName.Anatomy, 120 );
			SetSkill( SkillName.EvalInt, 140, 190.0 );
			SetSkill( SkillName.Magery, 140, 190.0 );
			SetSkill( SkillName.Meditation, 160 );
			SetSkill( SkillName.MagicResist, 110.1, 250.0 );
			SetSkill( SkillName.Tactics, 115, 125 );
			SetSkill( SkillName.Swords, 115, 125 );

			Fame = 8000;
			Karma = 8000;

			Kills = 0;


			VirtualArmor = 50;


 			PackItem( new LochNessScales() );
			PackItem( new LochNessScales() );
			PackItem( new LochNessScales() );
			PackItem( new LochNessScales() );
			PackItem( new LochNessScales() );

		}
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public LochNess( Serial serial ) : base( serial )
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