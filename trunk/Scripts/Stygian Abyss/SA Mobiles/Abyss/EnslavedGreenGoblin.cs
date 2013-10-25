using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an enslaved goblin corpse" )]
	public class EnslavedGreenGoblin : BaseCreature
	{
		[Constructable]
		public EnslavedGreenGoblin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Enslaved Green Goblin";
			Body = 334;
			BaseSoundID = 0x45A;

			SetStr( 275 );
			SetDex( 77 );
			SetInt( 113 );

			SetHits( 275 );
			SetStam( 77 );
			SetMana( 113 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 42, 45 );
			SetResistance( ResistanceType.Fire, 38, 39 );
			SetResistance( ResistanceType.Cold, 25, 30 );
			SetResistance( ResistanceType.Poison, 12, 15 );
			SetResistance( ResistanceType.Energy, 18, 20 );

			SetSkill( SkillName.MagicResist, 121.6, 122.9 );
			SetSkill( SkillName.Tactics, 89.0, 90.2 );
			SetSkill( SkillName.Anatomy, 81.5, 83.4 );
			SetSkill( SkillName.Wrestling, 106.5, 107.5 );


			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 48;

			// Loot - 30-40gold, magicitem,gem,goblin blood, essence control
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

		public EnslavedGreenGoblin( Serial serial ) : base( serial )
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
