using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class SummonedElderAirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 119.5; } }
		public override double DispelFocus{ get{ return 54.0; } }

		[Constructable]
		public SummonedElderAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder air elemental";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 240 );
			SetDex( 240 );
			SetInt( 120 );

			SetHits( 180 );
			SetStam( 60 );

			SetDamage( 9, 12 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 48, 60 );
			SetResistance( ResistanceType.Fire, 36, 48 );
			SetResistance( ResistanceType.Cold, 42, 54 );
			SetResistance( ResistanceType.Poison, 60, 72 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			SetSkill( SkillName.Meditation, 108.0 );
			SetSkill( SkillName.EvalInt, 84.0 );
			SetSkill( SkillName.Magery, 84.0 );
			SetSkill( SkillName.MagicResist, 72.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 96.0 );

			VirtualArmor = 40;
			ControlSlots = 2;
		}

		public SummonedElderAirElemental( Serial serial ) : base( serial )
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