using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.CannedEvil;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "an Mirage dragon corpse" )]
	public class MirageDragon : BasePeerless
	{
        public override bool AlwaysMurderer { get { return true; } }
        public override bool IsScaryToPets { get { return true; } }

		[Constructable]
		public MirageDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 103;
			Name = "an Mirage Dragon";
			BaseSoundID = 362;
            Hue = 1267;

            SetStr(2250, 2500);
            SetDex(200, 250);
            SetInt(580, 625);

            SetHits(7250, 7500);

            SetDamage(25, 30);

			//SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Energy, 100 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 75 );
			SetResistance( ResistanceType.Cold, 75 );
			SetResistance( ResistanceType.Poison, 75 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Magery, 120.0 );
			SetSkill( SkillName.MagicResist, 130.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 85;

			Tamable = false;

            PackItem(new MirageCrystallineFragments());
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathEnergyDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 1267; } }
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion

       
		public override bool ReacquireOnMovement{ get{ return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 6; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }

        public override void OnDamagedBySpell(Mobile caster)
        {
            if (this.Map != null && caster != this && 0.50 > Utility.RandomDouble())
            {
                Map = caster.Map;
                Location = caster.Location;
                Combatant = caster;
                Effects.PlaySound(this.Location, this.Map, 0x1FE);
            }

            base.OnDamagedBySpell(caster);
        }

        private DateTime m_NextTerror;

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            base.OnMovement(m, oldLocation);

            if (m_NextTerror < DateTime.Now && m != null && InRange(m.Location, 3) && m.AccessLevel == AccessLevel.Player)
            {
                m.Frozen = true;
                m.SendLocalizedMessage(1080342, Name, 33); // Terror slices into your very being, destroying any chance of resisting ~1_name~ you might have had

                Timer.DelayCall(TimeSpan.FromSeconds(5), new TimerStateCallback(Terrorize), m);
            }
        }

        private void Terrorize(object o)
        {
            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.Frozen = false;
                m.SendLocalizedMessage(1005603); // You can move again!

                m_NextTerror = DateTime.Now + TimeSpan.FromMinutes(5);
            }
        }

		
		public MirageDragon( Serial serial ) : base( serial )
		{
		}

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            if (this.Map != null && attacker != this && 0.25 > Utility.RandomDouble())
            {
                BaseCreature spawn = new MirageSpawn(this);

                spawn.Team = this.Team;
                spawn.MoveToWorld(this.Location, this.Map);
                spawn.Combatant = attacker;

                Say("The Mirage dragon creates another from its flesh to help in battle!"); 
            }

            base.OnGotMeleeAttack(attacker);

            if (!Core.SE && 0.2 > Utility.RandomDouble() && attacker is BaseCreature)
            {
                BaseCreature c = (BaseCreature)attacker;

                if (c.Controlled && c.ControlMaster != null)
                {
                    c.ControlTarget = c.ControlMaster;
                    c.ControlOrder = OrderType.Attack;
                    c.Combatant = c.ControlMaster;
                }
            }
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