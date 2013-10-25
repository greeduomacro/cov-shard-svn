using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a Phoenix corpse" )]	
	public class Phoenix1 : BaseCreature
	{
		[Constructable]
		public Phoenix1() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.05, 0.2 )
		{
			Name = "The Phoenix";
			Body = 0x5;
			Hue = 0x674;

			SetStr( 605, 611 );
			SetDex( 391, 519 );
			SetInt( 669, 818 );

			SetHits( 1783, 1939 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );

			SetResistance( ResistanceType.Physical, 65 );
			SetResistance( ResistanceType.Fire, 72, 74 );
			SetResistance( ResistanceType.Poison, 36, 41 );
			SetResistance( ResistanceType.Energy, 50, 51 );

			SetSkill( SkillName.Wrestling, 121.9, 130.6 );
			SetSkill( SkillName.Tactics, 114.9, 117.4 );
			SetSkill( SkillName.MagicResist, 147.7, 153.0 );
			SetSkill( SkillName.Poisoning, 122.8, 124.0 );
			SetSkill( SkillName.Magery, 121.8, 127.8 );
			SetSkill( SkillName.EvalInt, 103.6, 117.0 );

            Fame = 15000;
            Karma = 0;

            VirtualArmor = 70;
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosUltraRich, 4);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(7))
                {
                    case 0: c.DropItem(new NoseHelmofThePhoenix()); break;
                    case 1: c.DropItem(new RingmailTunicofThePhoenix()); break;
                    case 2: c.DropItem(new StuddedGorgetofThePhoenix()); break;
                    case 3: c.DropItem(new RingmailGlovesofThePhoenix()); break;
                    case 4: c.DropItem(new RingmailLeggingsofThePhoenix()); break;
                    case 5: c.DropItem(new RingmailSleevesofThePhoenix()); break;
                    case 6: c.DropItem(new PhoenixBow()); break;
                }
            }
        }
		
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 2 ) )
			{
				case 0: return WeaponAbility.ParalyzingBlow;
				case 1: return WeaponAbility.BleedAttack;
			}
		
			return null;
		}
		
		bool tick = false;
		
		public override void OnThink()
		{
			tick = !tick;
		
			if ( tick )
				return;
		
			List<Mobile> targets = new List<Mobile>();

			if ( Map != null )
				foreach ( Mobile m in GetMobilesInRange( 2 ) )
					if ( this != m && SpellHelper.ValidIndirectTarget( this, m ) && CanBeHarmful( m, false ) && ( !Core.AOS || InLOS( m ) ) )
					{
						if ( m is BaseCreature && ((BaseCreature) m).Controlled )
							targets.Add( m );
						else if ( m.Player )
							targets.Add( m );
					}
					
			for ( int i = 0; i < targets.Count; ++i )
			{
				Mobile m = targets[ i ];
				
				AOS.Damage( m, this, 5, 0, 100, 0, 0, 0 );
				
				if ( m.Player )
					m.SendLocalizedMessage( 1008112, Name ); // : The intense heat is damaging you!
			}			
		}
		
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Feathers{ get{ return 36; } }		
		
		public override int GetIdleSound() { return 0x2EF; }
		public override int GetAttackSound() { return 0x2EE; }
		public override int GetAngerSound() { return 0x2EF; }
		public override int GetHurtSound() { return 0x2F1; }
		public override int GetDeathSound()	{ return 0x2F2; }

		public Phoenix1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}