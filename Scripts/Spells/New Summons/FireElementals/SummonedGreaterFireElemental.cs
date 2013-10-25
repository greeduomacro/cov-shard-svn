using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class SummonedGreaterFireElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedGreaterFireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a greater fire elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 220 );
			SetDex( 220 );
			SetInt( 110 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 55, 66 );
			SetResistance( ResistanceType.Fire, 75, 80 );
			SetResistance( ResistanceType.Cold, 0, 11 );
			SetResistance( ResistanceType.Poison, 55, 66 );
			SetResistance( ResistanceType.Energy, 55, 66 );

			SetSkill( SkillName.EvalInt, 99.0 );
			SetSkill( SkillName.Magery, 99.0 );
			SetSkill( SkillName.MagicResist, 94.0 );
			SetSkill( SkillName.Tactics, 110.0 );
			SetSkill( SkillName.Wrestling, 101.0 );

			VirtualArmor = 40;
			ControlSlots = 4;

			AddItem( new LightSource() );
		}

		public SummonedGreaterFireElemental( Serial serial ) : base( serial )
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
