/* Created by Hammerhand*/

using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class DrumMajor : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public DrumMajor() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "the Drum Major";
			Hue = Utility.RandomSkinHue();

         	Body = 0x190;
			Name = NameList.RandomName( "male" );

			

			SetStr( 556, 600 );
			SetDex( 258, 295 );
			SetInt( 361, 375 );

            SetHits(958, 1711);

			SetDamage( 25, 34 );

			SetSkill( SkillName.Fencing, 96.0, 107.5 );
			SetSkill( SkillName.Macing, 95.0, 107.5 );
			SetSkill( SkillName.MagicResist, 75.0, 87.5 );
			SetSkill( SkillName.Swords, 105.0, 112.5 );
			SetSkill( SkillName.Tactics, 100.0, 107.5 );
			SetSkill( SkillName.Wrestling, 85.0, 97.5 );

			Fame = 1000;
			Karma = -1000;

            VirtualArmor = 50;

			AddItem( new Boots( Utility.RandomNeutralHue() ) );
            AddItem(new ShortPants(Utility.RandomBlueHue()));
			AddItem( new FancyShirt());
            AddItem(new Surcoat(Utility.RandomRedHue()));

			switch ( Utility.Random( 7 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Broadsword() ); break;
				case 3: AddItem( new Axe() ); break;
				case 4: AddItem( new Club() ); break;
				case 5: AddItem( new Dagger() ); break;
				case 6: AddItem( new Spear() ); break;
			}

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
            if (m_Spawning)
            {
                PackItem(new DrumSticks());
            }
		}

		public override bool AlwaysMurderer{ get{ return true; } }

        public DrumMajor(Serial serial)
            : base(serial)
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