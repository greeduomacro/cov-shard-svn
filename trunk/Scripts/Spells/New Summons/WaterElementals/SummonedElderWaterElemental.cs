using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water elemental corpse" )]
	public class SummonedElderWaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 119.5; } }
		public override double DispelFocus{ get{ return 54.0; } }

		[Constructable]
		public SummonedElderWaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a elder water elemental";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 240 );
			SetDex( 84 );
			SetInt( 120 );

			SetHits( 198 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 60, 72 );
			SetResistance( ResistanceType.Fire, 24, 36 );
			SetResistance( ResistanceType.Cold, 75, 80 );
			SetResistance( ResistanceType.Poison, 54, 66 );
			SetResistance( ResistanceType.Energy, 48, 60 );

			SetSkill( SkillName.Meditation, 108.0 );
			SetSkill( SkillName.EvalInt, 96.0 );
			SetSkill( SkillName.Magery, 96.0 );
			SetSkill( SkillName.MagicResist, 90.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 102.0 );

			VirtualArmor = 40;
			ControlSlots = 3;
			CanSwim = true;
		}

		public SummonedElderWaterElemental( Serial serial ) : base( serial )
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