using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Chaos dragon corpse" )]
	public class ChaosDragon : BaseCreature
	{
		[Constructable]
		public ChaosDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            //int i_Resource = 0;
            //i_Resource = Utility.RandomMinMax(1, 25);

			Body = 197;
			Name = "a Chaos Dragon";
			BaseSoundID = 362;
            Hue = 0;

			SetStr( 1250, 1500 );
			SetDex( 100, 150 );
			SetInt( 580, 625 );

			SetHits( 1250, 1500 );

			SetDamage( 17, 25 );

			//SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Energy, 100 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 55, 75 );
			SetResistance( ResistanceType.Cold, 55, 75 );
			SetResistance( ResistanceType.Poison, 50, 75 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 99.1, 120.0 );
			SetSkill( SkillName.Magery, 99.1, 120.0 );
			SetSkill( SkillName.MagicResist, 99.1, 120.0 );
			SetSkill( SkillName.Tactics, 97.6, 120.0 );
			SetSkill( SkillName.Wrestling, 90.1, 120.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 75;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 115.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
            //if (i_Resource > 23) PackItem(new sdeggs());
		}

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathEnergyDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 35; } }
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion

        
		public override bool ReacquireOnMovement{ get{ return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override bool EnableMasterHeal { get { return (this.Controlled == true) && (this.Skills[SkillName.Magery].Value >= 90); } }

		public ChaosDragon( Serial serial ) : base( serial )
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