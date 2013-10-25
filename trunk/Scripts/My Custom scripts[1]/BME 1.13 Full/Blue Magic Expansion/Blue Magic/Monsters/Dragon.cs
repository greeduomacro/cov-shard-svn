// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BLDragon : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 30.0 ); } }
		public override Type SpellToCast{ get{ return typeof( DragonForceSpell ); } }

		[Constructable]
		public BLDragon () : base( AIType.AI_Necromage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dragon";

			if ( Core.SA )
				Body = 198;
			else
				Body = Utility.RandomList( 12, 59 );

			BaseSoundID = 362;

			SetStr( 816, 845 );
			SetDex( 106, 125 );
			SetInt( 456, 495 );

			SetHits( 2578, 3595 );

			SetDamage( 21, 27 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			SetResistance( ResistanceType.Fire, 65, 75 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Magery, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.MagicResist, 150.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );

			Fame = 28000;
			Karma = -28000;

			VirtualArmor = 70;
		}

		public override void BreathEffect_Callback( object state )
		{
			Mobile target = (Mobile)state;

			if (!target.Alive || !CanBeHarmful(target))
				return;

			BreathPlayEffectSound();

			int damage = (int)(Hits * 0.16);

			if ( damage > 375 ) // 375 - 70% = 112
				damage = 375;

			//Ability.MultiFireball( this, target, damage );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 60; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 20; } }
		public override ScaleType ScaleType{ get{ return ( Utility.RandomBool() ? ScaleType.Yellow : ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public BLDragon( Serial serial ) : base( serial )
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