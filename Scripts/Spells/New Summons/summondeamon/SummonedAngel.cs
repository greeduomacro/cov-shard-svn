using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an angel corpse" )]
	public class SummonedAngel : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 125.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedAngel () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ethereal warrior" ) + " the Angel";
			Body = 123;
			BaseSoundID = 0x467;

			SetStr( 300 );
			SetDex( 210 );
			SetInt( 250 );

			SetDamage( 18, 25 );

			SetDamageType( ResistanceType.Energy, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 60, 80 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 98.1, 99.0 );

			VirtualArmor = 58;
			ControlSlots = 5;
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } } // TODO: Immune to poison?

		public SummonedAngel( Serial serial ) : base( serial )
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