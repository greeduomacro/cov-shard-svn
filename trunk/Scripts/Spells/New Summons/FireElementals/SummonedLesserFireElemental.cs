using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class SummonedLesserFireElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 105.7; } }
		public override double DispelFocus{ get{ return 40.5; } }

		[Constructable]
		public SummonedLesserFireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lesser fire elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 180 );
			SetDex( 180 );
			SetInt( 90 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 45, 54 );
			SetResistance( ResistanceType.Fire, 63, 72 );
			SetResistance( ResistanceType.Cold, 0, 9 );
			SetResistance( ResistanceType.Poison, 45, 54 );
			SetResistance( ResistanceType.Energy, 45, 54 );

			SetSkill( SkillName.EvalInt, 81.0 );
			SetSkill( SkillName.Magery, 81.0 );
			SetSkill( SkillName.MagicResist, 76.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 83.0 );

			VirtualArmor = 40;
			ControlSlots = 4;

			AddItem( new LightSource() );
		}

		public SummonedLesserFireElemental( Serial serial ) : base( serial )
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
