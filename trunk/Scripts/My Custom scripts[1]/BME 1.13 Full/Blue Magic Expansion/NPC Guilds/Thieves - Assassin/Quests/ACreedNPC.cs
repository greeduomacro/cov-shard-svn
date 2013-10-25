//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class ACreedNPC : BaseCreature
	{
		[Constructable]
		public ACreedNPC() : base( AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			Female = Utility.RandomBool();

			if ( Female )
			{
				Body = 401;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 400;
				Name = NameList.RandomName( "male" );
			}

			SetStr( Utility.RandomMinMax( 10, 80 ) );
			SetDex( Utility.RandomMinMax( 10, 80 ) );
			SetInt( Utility.RandomMinMax( 10, 80 ) );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Tactics, 50.0 );
			SetSkill( SkillName.Wrestling, 50.0 );

			DressUp();
		}

		public void DressUp()
		{
			switch ( Utility.Random( 3 ) )
			{
				case 0: AddItem( new FancyShirt( GetRandomHue() ) ); break;
				case 1: AddItem( new Doublet( GetRandomHue() ) ); break;
				case 2: AddItem( new Shirt( GetRandomHue() ) ); break;
			}

			switch ( Utility.Random( 4 ) )
			{
				case 0: AddItem( new Shoes( GetShoeHue() ) ); break;
				case 1: AddItem( new Boots( GetShoeHue() ) ); break;
				case 2: AddItem( new Sandals( GetShoeHue() ) ); break;
				case 3: AddItem( new ThighBoots( GetShoeHue() ) ); break;
			}

			if ( Female )
			{
				switch ( Utility.Random( 6 ) )
				{
					case 0: AddItem( new ShortPants( GetRandomHue() ) ); break;
					case 1:
					case 2: AddItem( new Kilt( GetRandomHue() ) ); break;
					case 3:
					case 4:
					case 5: AddItem( new Skirt( GetRandomHue() ) ); break;
				}
			}
			else
			{
				switch ( Utility.Random( 2 ) )
				{
					case 0: AddItem( new LongPants( GetRandomHue() ) ); break;
					case 1: AddItem( new ShortPants( GetRandomHue() ) ); break;
				}
			}

			Hue = Utility.RandomSkinHue();
			int hairHue = Utility.RandomHairHue();
			Utility.AssignRandomHair( this, hairHue );
			Utility.AssignRandomFacialHair( this, hairHue );
		}

		public int GetRandomHue()
		{
			switch ( Utility.Random( 5 ) )
			{
				default:
				case 0: return Utility.RandomBlueHue();
				case 1: return Utility.RandomGreenHue();
				case 2: return Utility.RandomRedHue();
				case 3: return Utility.RandomYellowHue();
				case 4: return Utility.RandomNeutralHue();
			}
		}

		public int GetShoeHue()
		{
			if ( 0.1 > Utility.RandomDouble() )
				return 0;

			return Utility.RandomNeutralHue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor, 1 );
		}

		public override void OnKilledBy( Mobile mob )
		{
			base.OnKilledBy( mob );
			AssassinControl.NPCKilled( mob );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public ACreedNPC( Serial serial ) : base( serial )
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
