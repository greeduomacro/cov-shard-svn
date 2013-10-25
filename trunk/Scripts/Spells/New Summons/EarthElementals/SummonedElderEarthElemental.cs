using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class SummonedElderEarthElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 119.5; } }
		public override double DispelFocus{ get{ return 54.0; } }

		[Constructable]
		public SummonedElderEarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder earth elemental";
			Body = 14;
			BaseSoundID = 268;

			SetStr( 240 );
			SetDex( 84 );
			SetInt( 84 );

			SetHits( 216 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 48, 60 );
			SetResistance( ResistanceType.Cold, 48, 60 );
			SetResistance( ResistanceType.Poison, 48, 60 );
			SetResistance( ResistanceType.Energy, 48, 60 );

			SetSkill( SkillName.MagicResist, 78.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 108.0 );

			VirtualArmor = 34;
			ControlSlots = 2;
		}

		public SummonedElderEarthElemental( Serial serial ) : base( serial )
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