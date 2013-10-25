using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a mistress of wrath corpse" )]
	public class MistressOfWrath : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}

        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

		[Constructable]
		public MistressOfWrath() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "The Mistress of Wrath";
            Title = "Ruler of all Sins";
            Body = 310;
			BaseSoundID = 0x482;
            Hue = 1200;

			SetStr( 400, 450 );
			SetDex( 276, 300 );
			SetInt( 486, 510 );

			SetHits( 10000, 11000 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 120 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.MagicResist, 100 );
			SetSkill( SkillName.Tactics, 120 );
			SetSkill( SkillName.Wrestling, 120 );

			Fame = 35000;
			Karma = -35000;

			VirtualArmor = 85;

            PackItem( new WrathCrystal());
            PackGold(10000);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 5 );
		}

		public MistressOfWrath( Serial serial ) : base( serial )
		{
		}

        public override bool OnBeforeDeath()
        {
            PaladinOfPride rm = new PaladinOfPride();
            rm.Team = this.Team;
            rm.Combatant = this.Combatant;
            rm.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            rm.MoveToWorld(new Point3D(1956, 1087, -28), Map.Ilshenar);

            return base.OnBeforeDeath();
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