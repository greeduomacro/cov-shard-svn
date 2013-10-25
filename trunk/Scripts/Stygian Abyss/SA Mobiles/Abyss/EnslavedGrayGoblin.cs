using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an enslaved goblin corpse" )]
	public class EnslavedGrayGoblin : BaseCreature
	{
		[Constructable]
		public EnslavedGrayGoblin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Enslaved Gray Goblin";
			Body = 334;
			BaseSoundID = 0x45A;

			SetStr( 331 );
			SetDex( 69 );
			SetInt( 114 );

			SetHits( 200 );
			SetStam( 69 );
			SetMana( 114 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 35, 40 );
			SetResistance( ResistanceType.Cold, 30, 33 );
			SetResistance( ResistanceType.Poison, 12, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 120, 125 );
			SetSkill( SkillName.Tactics, 82, 85 );
			SetSkill( SkillName.Anatomy, 85, 90 );
			SetSkill( SkillName.Wrestling, 96, 100 );


			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;

            AddItem(new Gold(295, 325));

			switch ( Utility.Random( 20 ) )
			{
				case 0: PackItem( new Scimitar() ); break;
				case 1: PackItem( new Katana() ); break;
				case 2: PackItem( new WarMace() ); break;
				case 3: PackItem( new WarHammer() ); break;
				case 4: PackItem( new Kryss() ); break;
				case 5: PackItem( new Pitchfork() ); break;
			}

			PackItem( new ThighBoots() );

			switch ( Utility.Random( 3 ) )
			{
				case 0: PackItem( new Ribs() ); break;
				case 1: PackItem( new Shaft() ); break;
				case 2: PackItem( new Candle() ); break;
			}

			if ( 0.2 > Utility.RandomDouble() )
				PackItem( new BolaBall() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.15)
                c.DropItem(new GoblinBlood());

            if (Utility.RandomDouble() < 0.1)
                c.DropItem(new EssenceControl());
        }

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		//public override bool IsEnemy( Mobile m )
		//{
		//	if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
		//		return false;

		//	return base.IsEnemy( m );
		//}

		//public override void AggressiveAction( Mobile aggressor, bool criminal )
		//{
			//base.AggressiveAction( aggressor, criminal );

			//Item item = aggressor.FindItemOnLayer( Layer.Helm );

			//if ( item is OrcishKinMask )
			//{
			//	AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
			//	item.Delete();
			//	aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
			//	aggressor.PlaySound( 0x307 );
			//}
		//}

		public EnslavedGrayGoblin( Serial serial ) : base( serial )
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
