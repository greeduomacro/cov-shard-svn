//Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a knight mare corpse" )]
	public class Knightmare : SpecialPetMount
	{
		[Constructable]
		public Knightmare() : this( "a knightmare" )
		{
		}

		[Constructable]
		public Knightmare( string name ) : base( name, 0x11C, 0x3E92, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0xA8;

			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Anatomy, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 95.1;

			//MaxLevel = 30;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override bool OverrideBondingReqs()
		{
			if ( ControlMaster.Skills[SkillName.Tactics].Base > 99.9 )
				return true;
			else
				return false;
		}

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			if ( ControlMaster.Skills[SkillName.Tactics].Base > 99.9 )
				return 1.0;
			else
				return base.GetControlChance( m, useBaseSkill );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		#region ISpecialPet
		public override string AbilityOneName{ get{ return "Anatomy"; } }
		public override string AbilityTwoName{ get{ return "Tactics"; } }
		public override string AbilityThreeName{ get{ return "Wrestling"; } }
		public override int AbilityOneLimit{ get{ return 125; } }
		public override int AbilityTwoLimit{ get{ return 125; } }
		public override int AbilityThreeLimit{ get{ return 125; } }
		public override int AbilityOneCost{ get{ return 4; } }
		public override int AbilityTwoCost{ get{ return 4; } }
		public override int AbilityThreeCost{ get{ return 4; } }

		public override void CheckChange( int ability )
		{
			if ( ability == 1 )
			{
				Skills[SkillName.Anatomy].Base += 1.0;

				if ( Skills[SkillName.Anatomy].Base > 124.0 )
					Skills[SkillName.Anatomy].Base = 125.0;

				m_AbilityOneValue = Skills[SkillName.Anatomy].Fixed / 10;
			}
			else if ( ability == 2 )
			{
				Skills[SkillName.Tactics].Base += 1.0;

				if ( Skills[SkillName.Tactics].Base > 124.0 )
					Skills[SkillName.Tactics].Base = 125.0;

				m_AbilityTwoValue = Skills[SkillName.Anatomy].Fixed / 10;
			}
			else if ( ability == 3 )
			{
				Skills[SkillName.Wrestling].Base += 1.0;

				if ( Skills[SkillName.Wrestling].Base > 124.0 )
					Skills[SkillName.Wrestling].Base = 125.0;

				m_AbilityThreeValue = Skills[SkillName.Anatomy].Fixed / 10;
			}
		}
		#endregion

		public Knightmare( Serial serial ) : base( serial )
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
