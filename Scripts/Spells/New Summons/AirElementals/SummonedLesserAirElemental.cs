using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class SummonedLesserAirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 105.7; } }
		public override double DispelFocus{ get{ return 40.5; } }

		[Constructable]
		public SummonedLesserAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an lesser air elemental";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 180 );
			SetDex( 180 );
			SetInt( 90 );

			SetHits( 135 );
			SetStam( 45 );

			SetDamage( 5, 8 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 36, 45 );
			SetResistance( ResistanceType.Fire, 27, 36 );
			SetResistance( ResistanceType.Cold, 31, 40 );
			SetResistance( ResistanceType.Poison, 45, 54 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			SetSkill( SkillName.Meditation, 81.0 );
			SetSkill( SkillName.EvalInt, 63.0 );
			SetSkill( SkillName.Magery, 63.0 );
			SetSkill( SkillName.MagicResist, 54.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 72.0 );

			VirtualArmor = 40;
			ControlSlots = 2;
		}

		public SummonedLesserAirElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 655;
		}
	}
}