using System;
using Server.Misc;
using Server.Network;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class ShadowLord : BaseCreature
	{

		[Constructable]
		public ShadowLord(): base( AIType.AI_Necromage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 704;
			BaseSoundID = 0x482;			
			Name = "a Shadowlord";

			SetStr( 850, 950 );
			SetDex( 570, 600 );
			SetInt( 1700, 1900 );

			SetHits( 50000 );

			SetDamage( 35, 41 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Poison, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 70, 90 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			SetSkill( SkillName.Wrestling, 75.0, 85.0 );
			SetSkill( SkillName.EvalInt, 120.0, 140.0 );
			SetSkill( SkillName.Meditation, 120.0, 140.0 );
			SetSkill( SkillName.Magery, 80.0, 105.0 );
			SetSkill( SkillName.Necromancy, 120.0, 140.0 );
			SetSkill( SkillName.MagicResist, 95.0, 117.0 );
			SetSkill( SkillName.Tactics, 55.0, 85.0 );

			Fame = 10000;
			Karma = -10000;
			VirtualArmor = 40;

            switch (Utility.Random(20))
            {
                case 0: PackItem(new ObsidianBlade()); break;
                case 1: PackItem(new ObsidianChaosShield()); break;
                case 2: PackItem(new DarkSource()); break;
                case 3: PackItem(new CloakOfCorruption()); break;
                case 4: PackItem(new PersonalAttendantToken()); break;
               
            }
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss, 4 );
			AddLoot( LootPack.Meager );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public ShadowLord( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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