using System;
using System.Collections.Generic;
using Server.Items;
using Server.ContextMenus;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.Haven;

namespace Server.Mobiles
{
	[CorpseName( "The servant's corpse" )]
	public class rolph : BaseCreature
	{
		[Constructable]
		public rolph() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Rolph";
			Title = "The Obidient Servant";
			Body = 0x190;
			Hue = Utility.RandomSkinHue();

			AddItem( new Cloak( 256 ) );
			AddItem( new Robe( 1161 ) );
			AddItem( new Sandals() );

			Dagger weapon = new Dagger();

			weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random( 0, 1 );
			weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random( 5, 6 );
			weapon.Skill = SkillName.Swords;
			weapon.Speed = 75;
			weapon.Hue = 77;
			weapon.Weight = 2;
			weapon.Movable = true;
			weapon.Attributes.SpellChanneling = 1;
			weapon.Quality = WeaponQuality.Exceptional;


			SetStr( 100, 150 );
			SetDex( 200, 300 );
			SetInt( 200, 300 );

			SetHits( 2000, 2500 );

			SetDamage( 30, 35 );

		PackItem( new HallegsArm() );

			SetDamageType( ResistanceType.Physical, 100 );

		

 

			SetResistance( ResistanceType.Physical, 15, 25 );
			SetResistance( ResistanceType.Fire, 5, 15 );
			SetResistance( ResistanceType.Cold, 25, 40 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 300, 300 );
			SetSkill( SkillName.Wrestling, 160, 175 );
			SetSkill( SkillName.Tactics, 300, 300 );
			SetSkill( SkillName.Anatomy, 300, 300 );
			SetSkill( SkillName.Swords, 180, 195 );

			Fame = 100000;
			Karma = 0;

			VirtualArmor = 6;

			
		}
		       
      public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss, 2 );
			
		}
			

		public override bool AlwaysAttackable{ get{ return true; } }

		public override void DisplayPaperdollTo(Mobile to)
		{
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry>list)
		{
			base.GetContextMenuEntries( from, list );

			for ( int i = 0; i < list.Count; ++i )
			{
				if ( list[i] is ContextMenus.PaperdollEntry )
					list.RemoveAt( i-- );
			}
		}

		public rolph( Serial serial ) : base( serial )
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