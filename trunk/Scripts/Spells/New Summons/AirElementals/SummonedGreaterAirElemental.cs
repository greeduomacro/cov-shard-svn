using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class SummonedGreaterAirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedGreaterAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an greater air elemental";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 220 );
			SetDex( 220 );
			SetInt( 110 );

			SetHits( 165 );
			SetStam( 55 );

			SetDamage( 7, 10 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 44, 55 );
			SetResistance( ResistanceType.Fire, 33, 44 );
			SetResistance( ResistanceType.Cold, 39, 50 );
			SetResistance( ResistanceType.Poison, 55, 66 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.EvalInt, 77.0 );
			SetSkill( SkillName.Magery, 77.0 );
			SetSkill( SkillName.MagicResist, 66.0 );
			SetSkill( SkillName.Tactics, 110.0 );
			SetSkill( SkillName.Wrestling, 88.0 );

			VirtualArmor = 40;
			ControlSlots = 2;
		}

		public SummonedGreaterAirElemental( Serial serial ) : base( serial )
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