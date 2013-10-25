using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a master of greed corpse" )]
	public class MasterOfGreed : BaseCreature
	{
        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

        [Constructable]
		public MasterOfGreed() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{

            Body = 0x31C;
            Name = "Gorthus";
            Title = "Hoarder of All";          
            BaseSoundID = 0x39D;
            Hue = 50;

            SetStr( 400, 450 );
            SetDex( 220, 270 );
            SetInt( 300, 350 );

            SetHits(7700, 8000);
            SetStam(110);

            SetDamage(25, 28);

            SetDamageType(ResistanceType.Physical, 100);
            SetDamageType(ResistanceType.Energy, 30);
            SetDamageType(ResistanceType.Fire, 30);

            SetResistance(ResistanceType.Physical, 100 );
            SetResistance(ResistanceType.Fire, 75 );
            SetResistance(ResistanceType.Poison, 70 );
            SetResistance(ResistanceType.Energy, 70 );

            SetSkill(SkillName.Wrestling, 120 );
            SetSkill(SkillName.Tactics, 100 );
            SetSkill(SkillName.MagicResist, 120.0);

            Fame = 22000;
            Karma = -22000;

            VirtualArmor = 65;

            PackItem(new GreedCrystal());
            PackGold( 7500, 8000);
        }

        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        

		public MasterOfGreed( Serial serial ) : base( serial )
		{
		}

        public override bool OnBeforeDeath()
        {
            MistressOfWrath rr = new MistressOfWrath();
            rr.Team = this.Team;
            rr.Combatant = this.Combatant;
            rr.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            rr.MoveToWorld(new Point3D(1982, 1020, -28), Map.Ilshenar);

            return base.OnBeforeDeath();
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
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