using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class SummonedElderFireElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 119.5; } }
		public override double DispelFocus{ get{ return 54.0; } }

		[Constructable]
		public SummonedElderFireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a  elder fire elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 240 );
			SetDex( 240 );
			SetInt( 120 );

			SetDamage( 11, 16 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 60, 72 );
			SetResistance( ResistanceType.Fire, 72, 80 );
			SetResistance( ResistanceType.Cold, 0, 12 );
			SetResistance( ResistanceType.Poison, 60, 72 );
			SetResistance( ResistanceType.Energy, 60, 72 );

			SetSkill( SkillName.EvalInt, 108.0 );
			SetSkill( SkillName.Magery, 108.0 );
			SetSkill( SkillName.MagicResist, 102.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 110.0 );

			VirtualArmor = 40;
			ControlSlots = 4;

			AddItem( new LightSource() );
		}

		public SummonedElderFireElemental( Serial serial ) : base( serial )
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
