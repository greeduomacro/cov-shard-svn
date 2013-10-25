using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Mobiles;
//using Server.Engines.Quests;

//namespace Server.Engines.Quests.TheGraveDigger
namespace Server.Mobiles
{
	public class BloodLich : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public BloodLich() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Hue = 1157;
			Female = false;
			BodyValue = 24;
			BaseSoundID = 1001;
			Name = "a blood lich";

			SetStr( 350 );
			SetDex( 100 );
			SetInt( 300 );

			SetHits( 2000 );
			SetMana( 3000 );

			SetDamage( 15, 20 );

            SetDamageType(ResistanceType.Physical, 20);
            SetDamageType(ResistanceType.Cold, 40);
            SetDamageType(ResistanceType.Energy, 40);

            SetResistance(ResistanceType.Physical, 55, 65);
            SetResistance(ResistanceType.Fire, 25, 30);
            SetResistance(ResistanceType.Cold, 50, 60);
            SetResistance(ResistanceType.Poison, 50, 60);
            SetResistance(ResistanceType.Energy, 25, 30);

            SetSkill(SkillName.EvalInt, 120.1, 130.0);
            SetSkill(SkillName.Magery, 120.1, 130.0);
            SetSkill(SkillName.Meditation, 100.1, 101.0);
            SetSkill(SkillName.Poisoning, 100.1, 101.0);
            SetSkill(SkillName.MagicResist, 175.2, 200.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 75.1, 100.0);

            Fame = 23000;
            Karma = -23000;

            VirtualArmor = 60;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
		}

        public override bool Unprovokable { get { return true; } }
        public override bool BleedImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public BloodLich( Serial serial ) : base( serial )
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