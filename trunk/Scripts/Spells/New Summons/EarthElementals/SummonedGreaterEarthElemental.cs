using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class SummonedGreaterEarthElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedGreaterEarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an greater earth elemental";
			Body = 14;
			BaseSoundID = 268;

			SetStr( 220 );
			SetDex( 77 );
			SetInt( 77 );

			SetHits( 198 );

			SetDamage( 15, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 72, 75 );
			SetResistance( ResistanceType.Fire, 44, 55 );
			SetResistance( ResistanceType.Cold, 44, 55 );
			SetResistance( ResistanceType.Poison, 44, 55 );
			SetResistance( ResistanceType.Energy, 44, 55 );

			SetSkill( SkillName.MagicResist, 72.0 );
			SetSkill( SkillName.Tactics, 110.0 );
			SetSkill( SkillName.Wrestling, 99.0 );

			VirtualArmor = 34;
			ControlSlots = 2;
		}

		public SummonedGreaterEarthElemental( Serial serial ) : base( serial )
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