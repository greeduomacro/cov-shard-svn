using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a master of envy corpse" )]
	public class MasterOfEnvy : BaseCreature
	{
        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

		[Constructable]
		public MasterOfEnvy() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Body = 0x309;
			Name = "Nemiah";
            Title = " The Master of Envy";
            Hue = 563;
			BaseSoundID = 0x451;

			SetStr( 400, 450 );
			SetDex( 156, 175 );
			SetInt( 181, 205 );

			SetHits( 6500, 6700 );

			SetDamage( 25, 30 );

            SetDamageType(ResistanceType.Physical, 100);
            SetDamageType(ResistanceType.Fire, 25);

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.MagicResist, 120, 130 );
			SetSkill( SkillName.Tactics, 120, 130 );
			SetSkill( SkillName.Wrestling, 120, 130 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 65;
            PackGold(4000);
            PackItem(new EnvyCrystal());
		}

		public MasterOfEnvy( Serial serial ) : base( serial )
		{
		}

        public override bool OnBeforeDeath()
        {
            MistressOfLust rn = new MistressOfLust();
            rn.Team = this.Team;
            rn.Combatant = this.Combatant;
            rn.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            rn.MoveToWorld(new Point3D(1954, 1059, -28), Map.Ilshenar);

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