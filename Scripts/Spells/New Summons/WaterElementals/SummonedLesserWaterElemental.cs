using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water elemental corpse" )]
	public class SummonedLesserWaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 105.7; } }
		public override double DispelFocus{ get{ return 40.5; } }

		[Constructable]
		public SummonedLesserWaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lesser water elemental";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 180 );
			SetDex( 63 );
			SetInt( 90 );

			SetHits( 148 );

			SetDamage( 11, 14 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 45, 54 );
			SetResistance( ResistanceType.Fire, 18, 27 );
			SetResistance( ResistanceType.Cold, 63, 72 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 36, 45 );

			SetSkill( SkillName.Meditation, 81.0 );
			SetSkill( SkillName.EvalInt, 72.0 );
			SetSkill( SkillName.Magery, 72.0 );
			SetSkill( SkillName.MagicResist, 67.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 76.0 );

			VirtualArmor = 40;
			ControlSlots = 3;
			CanSwim = true;
		}

		public SummonedLesserWaterElemental( Serial serial ) : base( serial )
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