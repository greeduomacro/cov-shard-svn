//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a quen corpse" )]
	public class BlueQuina : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 15.0 ); } }
		public override Type SpellToCast{ get{ return typeof( FrogDropSpell ); } }

		public override WeaponAbility GetWeaponAbility() { return WeaponAbility.Dismount; }

		[Constructable]
		public BlueQuina() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 400;
			Name = "Quina";
			Title = "Quen";
			Hue = 2219;
			SpeechHue = 2219;
			Female = Utility.RandomBool();

			SetStr( 120 );
			SetDex( 90 );
			SetInt( 200 );

			SetHits( 7000 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.MagicResist, 145.1, 160.0 );

			// Damage Pitchfork 13~14. Str +25%
			SetSkill( SkillName.Fencing, 100 ); // +25%
			SetSkill( SkillName.Tactics, 80.0 ); // +50%
			SetSkill( SkillName.Anatomy, 200.0 ); // +45%
			// Total 145%
			// Output: 31.85~34.3

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 50;

			PackItem( new FrogDropBag() );

			// Weapon
			Pitchfork weapon = new Pitchfork();
			weapon.Name = "<BASEFONT COLOR='#800000'>Fork of Maiming";
			weapon.Attributes.AttackChance = 25;
			weapon.WeaponAttributes.HitLowerDefend = 100;
			weapon.AosElementDamages.Fire = 100;
			Ability.GiveItem( this, 1294, weapon );

			// Hat
			BlueHat hat = new BlueHat();
			hat.ItemID = 5907;
			hat.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				hat.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1436, hat );

			// Chest
			BlueShirt chest = new BlueShirt();
			chest.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				chest.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1194, chest );

			// Belt
			BlueBelt belt = new BlueBelt();
			belt.ItemID = 5435;
			belt.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				belt.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 2017, belt );

			// Legs
			BluePants legs = new BluePants();
			legs.ItemID = 5422;
			legs.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				legs.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1619, legs );

			// Boots
			BlueBoots boots = new BlueBoots();
			boots.ItemID = 5901;
			boots.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				boots.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1436, boots );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 1 );
			AddLoot( LootPack.FilthyRich, 1 );
			AddLoot( LootPack.SuperBoss, 1 );
		}

		private DateTime m_SwapDelay;
		private DateTime m_MustardDelay;
		private DateTime m_SpeechDelay;

		private string[] Speech =
		{
			"I do what I want! You have problem!?",
			"Is stone edible? Or is for barbeque?",
			"Are there yummy-yummies here?",
			"Why you care about small things? World very simple place. World only have two things: Things you can eat and things you no can eat.",
			"Good food not only delicious! Good food made with heart! This very important when cooking for friends!",
			"You stand here say nothing, then you just like other dummy-dummies! No can tell difference!",
			"There no munchies here, sand taste good though.",
			"Frog. Is...talking? Should I eat..? Maybe I eat.",
			"This rock edible, maybe I taste it.....is salty",
			"This flower taste good!",
			"Fish gone...I sad.",
			"Leftovers good!",
			"Something smell bad. I get bad feeling! Flower smell good! You smell flower!"
		};

		public override void OnActionCombat()
		{
			if ( Combatant == null )
			{
				base.OnActionCombat();
				return;
			}

			if ( DateTime.Now > m_SwapDelay && Combatant is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)Combatant;
				Mobile target = bc.ControlMaster;

				if ( target == null )
					target = bc.SummonMaster;

				if ( target != null )
				{
					Point3D moveto = target.Location;
					target.Location = bc.Location;
					bc.Location = moveto;
					Combatant = target;
					Effects.SendLocationParticles( EffectItem.Create( target.Location, target.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
					Effects.SendLocationParticles( EffectItem.Create( bc.Location, bc.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
				}

				m_SwapDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 30 ) );
			}
			else if ( DateTime.Now > m_MustardDelay )
			{
				MustardBomb( this, Combatant );
				m_MustardDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 60 ) );
			}
			else if ( DateTime.Now > m_SpeechDelay )
			{
				Say( Speech[ Utility.Random( Speech.Length ) ] );
				m_SpeechDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 20, 40 ) );
			}

			// Trance Mode
			if ( Hits < HitsMax / 2 && Hue == 2219 )
			{
				Hue = 1284;
				SolidHueOverride = 1284;
				Say( "You hurt me, I now hurt you more." );
				FightMode = FightMode.Weakest;
				ActiveSpeed = 0.05;
			}
			else if ( Hits == HitsMax && Hue == 1284 )
			{
				Hue = 2219;
				SolidHueOverride = -1;
				FightMode = FightMode.Closest;
				ActiveSpeed = 0.2;
			}

			base.OnActionCombat();
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature )
				damage *= 3;
			else
			{
				if ( to.Fame > -14900 )
					to.Fame -= 100;

				if ( to.Karma > -14900 )
					to.Karma -= 100;
			}

			to.Stam -= ( damage / 20 );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
				damage /= 5;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( Utility.RandomDouble() <= 0.25 ) // 25% chance
			{
				switch( Utility.Random( 6 ) )
				{
					case 0: DemonKnight.DistributeArtifact( this, new SilverFork() ); break;
					case 1: DemonKnight.DistributeArtifact( this, new BistroFork() ); break;
					case 2: DemonKnight.DistributeArtifact( this, new GastroFork() ); break;
					case 3: DemonKnight.DistributeArtifact( this, new NeedleFork() ); break;
					case 4: DemonKnight.DistributeArtifact( this, new UpgradeSporkDeed() ); break;
					case 5: DemonKnight.DistributeArtifact( this, new FrogDropBag() ); break;
				}
			}

			if ( Utility.RandomDouble() <= 0.05 ) // 5% chance
				c.DropItem( new AngelSnack() );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public BlueQuina( Serial serial ) : base( serial )
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

			m_SwapDelay = DateTime.Now;
			m_MustardDelay = DateTime.Now;
		}

		public static void MustardBomb( Mobile from, Mobile to )
		{
			if ( !Ability.CanUse( to, from, true ) )
				return;

			Point3D point = to.Location;

			for( int i = -3; i < 4; i++ )
			{
				for( int j = -3; j < 4; j++ )
				{
					point = new Point3D( to.X + i, to.Y + j, to.Z );

					if ( BlueSpell.GetDist( point, to.Location ) < 3.1 )
						Effects.SendLocationEffect( point,to.Map, 0x3728, 13, 1283/*Hue*/, 4 );
				}
			}

			ResistanceMod[] mods = new ResistanceMod[]{ new ResistanceMod( ResistanceType.Fire, -300 ), 
					new ResistanceMod( ResistanceType.Cold, -300 ) };

			for ( int i = 0; i < mods.Length; ++i )
				to.AddResistanceMod( mods[i] );

			TimedResistanceMod.AddMod( 
				to, 
				"Mustard Bomb", 
				mods, 
				TimeSpan.FromSeconds( 60 )
			);

			to.AddSkillMod( new TimedSkillMod( SkillName.MagicResist, true, -120.0, TimeSpan.FromSeconds( 60 ) ) );

			to.SendMessage( "The intense heat scalds your elemental resistance." );
		}

	}
}