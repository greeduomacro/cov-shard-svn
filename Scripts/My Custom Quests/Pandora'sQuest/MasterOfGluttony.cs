using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a corpse of gluttony" )] // TODO: Corpse name?
	public class MasterOfGluttony : BaseCreature
	{
        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

		[Constructable]
		public MasterOfGluttony() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Body = 319;
			Name = "Trechor";
            Title = "The Master Of Gluttony";			
			BaseSoundID = 898;
            Hue = 643;

			SetStr( 400, 470 );
			SetDex( 200, 270 );
			SetInt( 300, 330 );

			SetHits( 7000, 7500 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Poison, 70 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Poison, 100 );
            SetResistance( ResistanceType.Energy, 60 );
            SetResistance( ResistanceType.Cold, 70 );
            SetResistance( ResistanceType.Fire, 60 );

			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );
            SetSkill( SkillName.MagicResist, 100.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 65;

			PackItem( new GluttonyCrystal());
			PackGold( 6000, 6500 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public MasterOfGluttony( Serial serial ) : base( serial )
		{
		}

        public override bool OnBeforeDeath()
        {
            MasterOfSloth rp = new MasterOfSloth();
            rp.Team = this.Team;
            rp.Combatant = this.Combatant;
            rp.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            rp.MoveToWorld(new Point3D(1966, 1033, -28), Map.Ilshenar);

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