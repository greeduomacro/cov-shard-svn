using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a silver steed corpse" )]
	public class SilverSteed : BaseMount
	{
		[Constructable]
		public SilverSteed() : this( "a silver steed" )
		{
		}

		[Constructable]
		public SilverSteed( string name ) : base( name, 0x75, 0x3EA8, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
            BaseSoundID = 0xA8;

            SetStr(496, 525);
            SetDex(86, 105);
            SetInt(86, 125);

            SetHits(298, 315);

            SetDamage(16, 22);

            SetDamageType(ResistanceType.Physical, 40);
            SetDamageType(ResistanceType.Fire, 40);
            SetDamageType(ResistanceType.Energy, 20);

            SetResistance(ResistanceType.Physical, 55, 65);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 30, 40);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 20, 30);

            SetSkill(SkillName.EvalInt, 40.0, 50.0);
            SetSkill(SkillName.Magery, 100.0, 110.0);
            SetSkill(SkillName.MagicResist, 100.0, 120.0);
            SetSkill(SkillName.Tactics, 97.6, 100.0);
            SetSkill(SkillName.Wrestling, 80.5, 92.5);

			ControlSlots = 3;
			Tamable = true;
			MinTameSkill = 103.1;
		}

		public SilverSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}