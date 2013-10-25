//Scripted by LordDarkScythe 11-01-2004
//With Help from UO Stratics and InsideUO

using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a master of sloth corpse" )]
	public class MasterOfSloth : BaseCreature
	{

        public override bool ClickTitle { get { return true; } }
        public override bool ShowFameTitle { get { return true; } }

		[Constructable]
		public MasterOfSloth() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
            Body = 248;
			Name = "Procor";
            Title = "Master of all that is lazy";	
            Hue = 98;

			SetStr( 445, 475 );
			SetDex( 215, 245 );
			SetInt( 345, 360 );

			SetHits( 8000, 8500 );
            SetStam(115);

			SetDamage( 25, 29 );

			SetDamageType( ResistanceType.Physical, 100 );
            SetDamageType( ResistanceType.Energy, 30 );
            SetDamageType( ResistanceType.Cold, 30 );
            SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 75 );
			SetResistance( ResistanceType.Energy, 75 );

			SetSkill( SkillName.MagicResist, 120 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 100 );
			SetSkill( SkillName.Anatomy, 100 );

			Fame = 23000;
			Karma = -23000;
			
            VirtualArmor = 65;

            PackItem(new SlothCrystal());
	        PackGold( 7000, 7500 );
	}
		public override int GetAngerSound()
		{
			return 0x4F7;
		}

		public override int GetIdleSound()
		{
			return 0x4F9;
		}

		public override int GetAttackSound()
		{
			return 0x4F6;
		}

		public override int GetHurtSound()
		{
			return 0x4FA;
		}

		public override int GetDeathSound()
		{
			return 0x4F5;
		}
		
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
     	public override bool BardImmune{ get{ return true; } }
		
        public MasterOfSloth( Serial serial ) : base( serial )
		{
		}

        public override bool OnBeforeDeath()
        {
            MasterOfGreed rq = new MasterOfGreed();
            rq.Team = this.Team;
            rq.Combatant = this.Combatant;
            rq.NoKillAwards = true;

            Effects.PlaySound(this, Map, GetDeathSound());
            Effects.SendLocationEffect(Location, Map, 0x3709, 30, 10, 0x835, 0);
            rq.MoveToWorld(new Point3D(1997, 1033, -28), Map.Ilshenar);

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