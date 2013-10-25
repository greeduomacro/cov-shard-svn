using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class SummonedLesserEarthElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 105.8; } }
		public override double DispelFocus{ get{ return 40.5; } }

		[Constructable]
		public SummonedLesserEarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an lesser earth elemental";
			Body = 14;
			BaseSoundID = 268;

			SetStr( 180 );
			SetDex( 63 );
			SetInt( 63 );

			SetHits( 162 );

			SetDamage( 13, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 58, 67 );
			SetResistance( ResistanceType.Fire, 36, 45 );
			SetResistance( ResistanceType.Cold, 36, 45 );
			SetResistance( ResistanceType.Poison, 36, 45 );
			SetResistance( ResistanceType.Energy, 36, 45 );

			SetSkill( SkillName.MagicResist, 58.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 81.0 );

			VirtualArmor = 34;
			ControlSlots = 2;
		}

		public SummonedLesserEarthElemental( Serial serial ) : base( serial )
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