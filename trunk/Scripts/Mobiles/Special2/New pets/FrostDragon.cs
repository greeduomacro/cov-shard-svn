using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a frost dragon corpse" )]
	public class FrostDragon : BaseCreature
	{
		[Constructable]
		public FrostDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            //int i_Resource = 0;
            //i_Resource = Utility.RandomMinMax(1, 25);

			Body = Core.AOS ? 180 : 49;
			Name = "a Frost Dragon";
			BaseSoundID = 362;
            Hue = 1152;

			SetStr( 950, 1100 );
			SetDex( 100, 150 );
			SetInt( 480, 625 );

			SetHits( 950, 1100 );

			SetDamage( 17, 25 );

			//SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 65;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 110.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
            //if (i_Resource > 23) PackItem(new sdeggs());
		}

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathColdDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 1152; } }
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Blue; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override bool EnableMasterHeal { get { return (this.Controlled == true) && (this.Skills[SkillName.Magery].Value >= 90); } }

		public FrostDragon( Serial serial ) : base( serial )
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

			if ( Core.AOS && Body == 49 )
				Body = 180;
		}
	}
}