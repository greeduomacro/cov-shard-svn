
using System;
using Server;
using Server.Items;
using Server.Factions;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a renowned fire daemon corpse" )]
	public class FireDaemon1 : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 125.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		public override Faction FactionAllegiance { get { return Shadowlords.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Evil; } }

		[Constructable]
		public FireDaemon1 () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "Fire Deamon(Renowned)";
            Body = 40;
            Hue = 1359;
            //IsParagon = true;
            BaseSoundID = 357;

            SetStr(1110, 1120);
            SetDex(235, 240);
            SetInt(225, 230);

            SetHits(4185, 4200);

            SetDamage(22, 29);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Fire, 25);
            SetDamageType(ResistanceType.Energy, 25);

            SetResistance(ResistanceType.Physical, 70, 75);
            SetResistance(ResistanceType.Fire, 75, 80);
            SetResistance(ResistanceType.Cold, 55, 60);
            SetResistance(ResistanceType.Poison, 100);
            SetResistance(ResistanceType.Energy, 40, 50);

            SetSkill(SkillName.Anatomy, 45.1, 50.0);
            SetSkill(SkillName.EvalInt, 96.3, 100.0);
            SetSkill(SkillName.Magery, 96.5, 100.0);
            SetSkill(SkillName.Meditation, 41.1, 50.0);
            SetSkill(SkillName.MagicResist, 125.5, 130.0);
            SetSkill(SkillName.Tactics, 95.6, 100.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

            Fame = 24000;
            Karma = -24000;

            VirtualArmor = 90;

            PackItem(new Longsword());
        }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                   
                    case 0: c.DropItem(new EssencePassion()); break;
                    
                    case 1: c.DropItem(new EssenceOrder()); break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(2))
                {
                    case 1: c.DropItem(new MantleoftheFallen()); break;
                    case 2: c.DropItem(new ResonantStaffofEnlightenment()); break;
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 1; } }

		public FireDaemon1( Serial serial ) : base( serial )
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
