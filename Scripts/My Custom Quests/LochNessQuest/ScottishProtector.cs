using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "An Scottish Protectors Corpse" )]
	public class ScottishProtector : BaseCreature
	{
		[Constructable]
		public ScottishProtector() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "A Scottish Protector";
			Body = 400;

			SetStr( 165, 200 );
			SetDex( 60, 100 );
			SetInt( 400, 900 );

			SetHits( 1000 );

			SetDamage( 5, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 60 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 30, 80 );
			SetResistance( ResistanceType.Fire, 20, 100 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 0, 20 );

			SetSkill( SkillName.Anatomy, 120 );
			SetSkill( SkillName.EvalInt, 150, 195.0 );
			SetSkill( SkillName.Magery, 150.5, 200.0 );
			SetSkill( SkillName.Meditation, 60 );
			SetSkill( SkillName.MagicResist, 130.1, 250.0 );
			SetSkill( SkillName.Tactics, 115, 125 );
			SetSkill( SkillName.Swords, 115, 125 );

			Fame = 8000;
			Karma = -8000;

			Kills = 0;

			Hue = 1141;

			VirtualArmor = 50;

			AddItem( new BodySash( 1167 ) );
			AddItem( new Skirt( 1167 ) );
			AddItem( new Bonnet( 1167 ) );
			//AddItem( new PegLeghook() );


		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public ScottishProtector( Serial serial ) : base( serial )
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