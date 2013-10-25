using System;
using Server;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a FireBird corpse" )]
	public class FireBird : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		//public override bool StatLossAfterTame { get { return true; } }

		[Constructable]
        public FireBird() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "a Fire Bird";
            Body = 243;
			Hue = 1287;

			SetStr( 900, 1100 );
			SetDex( 450, 650 );
			SetHits( 900, 1100 );
			SetInt( 480, 625 );

			//SetMana( 60 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 25);
            SetDamageType( ResistanceType.Fire, 50);
            SetDamageType( ResistanceType.Energy, 25);

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 80 );
			SetResistance( ResistanceType.Energy, 40, 50 );

            SetSkill(SkillName.EvalInt, 90.2, 100.0);
            SetSkill(SkillName.Magery, 90.2, 100.0);
            SetSkill(SkillName.Meditation, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 86.0, 135.0);
            SetSkill(SkillName.Tactics, 80.1, 90.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

			Fame = 18000;
			Karma = -18000;
			VirtualArmor = 45;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 110.1;

            PackItem(new GreaterHealPotion());
            PackItem(new GreaterHealPotion());


		}


		public override int GetAngerSound()
		{
			return 0x4FE;
		}

		public override int GetIdleSound()
		{
			return 0x4FD;
		}

		public override int GetAttackSound()
		{
			return 0x4FC;
		}

		public override int GetHurtSound()
		{
			return 0x4FF;
		}

		public override int GetDeathSound()
		{
			return 0x4FB;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
			AddLoot( LootPack.Gems, 4 );
            AddLoot(LootPack.Potions, 2);
		}

		 #region Breath
        public override int BreathFireDamage { get { return 100; } }
        public override int BreathColdDamage { get { return 0; } }
        public override int BreathEffectHue { get { return 34; } }
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers { get { return 60; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies; } }
		public override bool EnableMasterHeal { get { return (this.Controlled == true) && (this.Skills[SkillName.Magery].Value >= 90); } }
		public override bool CanAngerOnTame { get { return true; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.1 > Utility.RandomDouble() )
			{
				/* Grasping Claw
				 * Start cliloc: 1070836
				 * Effect: Physical resistance -15% for 5 seconds
				 * End cliloc: 1070838
				 * Effect: Type: "3" - From: "0x57D4F5B" (player) - To: "0x0" - ItemId: "0x37B9" - ItemIdName: "glow" - FromLocation: "(1149 808, 32)" - ToLocation: "(1149 808, 32)" - Speed: "10" - Duration: "5" - FixedDirection: "True" - Explode: "False"
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
					defender.SendLocalizedMessage( 1070837 ); // The creature lands another blow in your weakened state.
				}
				else
					defender.SendLocalizedMessage( 1070836 ); // The blow from the creature's claws has made you more susceptible to physical attacks.

				int effect = -(defender.PhysicalResistance * 15 / 100);

				ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, effect );

				defender.FixedEffect( 0x37B9, 10, 5 );
				defender.AddResistanceMod( mod );

				timer = new ExpireTimer( defender, mod, TimeSpan.FromSeconds( 5.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay )
				: base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( 1070838 ); // Your resistance to physical attacks has returned.
				DoExpire();
			}
		}

		public FireBird( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 );
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
