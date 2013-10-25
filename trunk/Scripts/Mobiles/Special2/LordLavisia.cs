using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "Lord Lavisia's corpse" )] 
	public class LordLavisia : BaseCreature 
	{
        [Constructable]
        public LordLavisia() : base (AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Lord Lavisia";
            Body = 9;
            Hue = 1332;

            SetStr(600, 650);
            SetDex(150, 200);
            SetInt(850, 900);

            SetHits(18000, 21000);

            SetDamage(30, 35);

            SetDamageType(ResistanceType.Energy, 50);
            SetDamageType(ResistanceType.Physical, 50);
            
            SetResistance(ResistanceType.Physical, 0, 1);
            SetResistance(ResistanceType.Fire, 0, 1);
            SetResistance(ResistanceType.Poison, 0, 1);
            SetResistance(ResistanceType.Energy, 0, 1);

            SetSkill(SkillName.EvalInt, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Anatomy, 120.0);
            SetSkill(SkillName.Wrestling, 170);
            SetSkill(SkillName.Focus, 120);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Necromancy, 120.0);
            SetSkill(SkillName.SpiritSpeak, 120.0);
            SetSkill(SkillName.Magery, 120.0);
            
            Fame = 15000;
            Karma = -15000;

            VirtualArmor = 80;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Gems, 4);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AreaPeaceImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public LordLavisia( Serial serial ) : base( serial )
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