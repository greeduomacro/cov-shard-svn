using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Recluse spider corpse" )]
	public class RecluseSpider : BaseCreature
	{
		[Constructable]
		public RecluseSpider () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Recluse spider";
			Body = 11;
            Hue = 340;
			BaseSoundID = 1170;

			SetStr( 296, 320 );
			SetDex( 126, 145 );
			SetInt( 286, 310 );

			SetHits( 1118, 1132 );

			SetDamage( 15, 19 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 80 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 120 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.EvalInt, 65.1, 80.0 );
			SetSkill( SkillName.Magery, 70, 80.0 );
			SetSkill( SkillName.Meditation, 65.1, 80.0 );
			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
            SetSkill(SkillName.Poisoning, 130.1, 140.0);
			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 75.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 56;

			PackItem( new SpidersSilk( 8 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
        public override double HitPoisonChance { get { return 0.75; } }

		public override int TreasureMapLevel{ get{ return 3; } }
        
        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if ( attacker is BaseCreature )
            {
                BaseCreature c = (BaseCreature)attacker;

                if (c.Controlled && c.ControlMaster != null)
                {
                    c.ControlMaster.SendMessage("The Recluse is immune to your pets attack.");
                    this.Combatant = c.ControlMaster;
                    c.Kill();
                    this.Emote("Your pet has been killed!", c.Name);
                }
                else if (attacker.BodyValue != 400 || attacker.BodyValue != 401 || attacker.BodyValue != 605 || attacker.BodyValue != 606)
                {
                    attacker.Kill();
                    this.Emote("Your Summons has been killed!");
                }
                else if (attacker is EvolutionDragon)
                {
                    attacker.Kill();
                    this.Emote("Your Evo pet has been killed!");
                }
                else if (attacker is VoltSpider)
                {
                    attacker.Kill();
                    this.Emote("Your Hatched pet has been killed!");
                }
            }
        }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.RecluseStrike;
        }

		public RecluseSpider( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;
		}
	}
}