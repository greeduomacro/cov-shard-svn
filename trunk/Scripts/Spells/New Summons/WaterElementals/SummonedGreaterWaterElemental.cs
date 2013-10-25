using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water elemental corpse" )]
	public class SummonedGreaterWaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedGreaterWaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a greater water elemental";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 220 );
			SetDex( 77 );
			SetInt( 110 );

			SetHits( 182 );

			SetDamage( 13, 18 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 55, 66 );
			SetResistance( ResistanceType.Fire, 22, 33 );
			SetResistance( ResistanceType.Cold, 72, 80 );
			SetResistance( ResistanceType.Poison, 50, 61 );
			SetResistance( ResistanceType.Energy, 44, 55 );

			SetSkill( SkillName.Meditation, 99.0 );
			SetSkill( SkillName.EvalInt, 88.0 );
			SetSkill( SkillName.Magery, 88.0 );
			SetSkill( SkillName.MagicResist, 83.0 );
			SetSkill( SkillName.Tactics, 110.0 );
			SetSkill( SkillName.Wrestling, 94.0 );

			VirtualArmor = 40;
			ControlSlots = 3;
			CanSwim = true;
		}

		public SummonedGreaterWaterElemental( Serial serial ) : base( serial )
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