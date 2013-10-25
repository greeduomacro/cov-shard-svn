// Created by Peoharen
using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Engines.Quests
{
	public class BlueBen : MondainQuester
	{	
		public override Type[] Quests
		{
			get
			{
				return new Type[]
				{
					// Misc
					typeof( BlueMageTrainingQuest ), // To Train to 51.0 Forensics
					typeof( FindingQuinaQuest ), // To obtain Forks and learn Frog Drop.

					// Empty Vessal
					typeof( BlueMageStoneSerpentQuest ), // Obtain to become a Blue Mage.
					typeof( BlueMageSpringSerpentQuest ), // Obtain to become a Blue Mage.
					typeof( BlueMageSkySerpentQuest ), // Obtain to become a Blue Mage.
					typeof( BlueMageGaleSerpentQuest ), // Obtain to become a Blue Mage.
					typeof( BlueMageFlameSerpentQuest ), // Obtain to become a Blue Mage.

					// Touched - Slayers
					typeof( BlueMageTierOneSlayerQuest ), // To get Blue Clothing
					typeof( BlueMageTierTwoSlayerQuest ), // To get a Blue Enhance Deed
					typeof( BlueMageTierThreeSlayerQuest ), // To get a Powerful Enhance Deed

					// Battle Quests
					typeof( BattleMatoQuest ),
					typeof( BattleTalimQuest ),
					typeof( BattleMarkovQuest ),
					typeof( BattleRakdosQuest ),
					typeof( BattleKaysaQuest )
				};
			}
		}

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBBlueMage() );
		}

		public override bool CheckVendorAccess( Mobile from )
		{
			if ( !base.CheckVendorAccess( from ) )
				return false;
			else if ( !BlueMageControl.IsBlueMage( from ) )
				return false;
			else
				return true;
		}

		[Constructable]
		public BlueBen() : base( "Ben", "the blue mage" )
		{
			SetSkill( SkillName.Forensics, 100.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.Focus, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );
		}

		public override void Advertise()
		{
			// No one likes a NPC that yells at you for attention.
		}

		public override void OnTalk( PlayerMobile player )
		{
			if ( QuestHelper.DeliveryArrived( player, this ) )
				return;
			else if ( QuestHelper.InProgress( player, this ) )
				return;
			else if ( QuestHelper.QuestLimitReached( player ) )
				return;

			BlueSpellInfo.UpdateTitle( player );

			BaseQuest quest = null;

			if ( player.Skills[SkillName.Forensics].Base < 51.0 )
				quest = QuestHelper.RandomQuest( player, new Type[]{ typeof( BlueMageTrainingQuest ) }, this );
			else if ( !BlueMageControl.IsBlueMage( player ) )
			{
				if ( !QuestHelper.InProgress( player, this ) )
				{
					player.CloseGump( typeof( BlueMageQuestionsGump ) );
					player.SendGump( new BlueMageQuestionsGump( player, this ) );
				}
				else
				{
					Say( "You need to seek your mark." );
				}
			}
			else
			{
				List<Type> types = new List<Type>();
				types.Add( typeof( BlueMageTierOneSlayerQuest ) );
				types.Add( typeof( BlueMageTierTwoSlayerQuest ) );
				types.Add( typeof( BlueMageTierThreeSlayerQuest ) );
				//types.Add( typeof( FindingQuinaQuest ) );

				//if ( BlueSpellInfo.KnowsAllMoves( player ) )
				//{
					//types.Add( typeof( BattleKaysaQuest ) );
					//types.Add( typeof( BattleRakdosQuest ) );

					//if ( BlueSpellInfo.KnowsAllSpells( player ) )
					//{
						// types.Add( typeof( BattleTalimQuest ) );
					//}
				//}

				//if ( BlueSpellInfo.KnowsAllSpells( player ) )
				//{
					//types.Add( typeof( BattleMatoQuest ) );
					//types.Add( typeof( BattleMarkovQuest ) );
				//}

				quest = QuestHelper.RandomQuest( player, types.ToArray(), this );
			}

			if ( quest != null )
			{
				player.CloseGump( typeof( MondainQuestGump ) );
				player.SendGump( new MondainQuestGump( quest ) );
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is BlueClothing )
			{
				from.SendGump( new BlueClothingExchangeGump( (BlueClothing)dropped ) );
				return false;
			}
			else
				return base.OnDragDrop( from, dropped );
		}

		public override void InitBody()
		{
			InitStats( 50, 80, 120 );
			Female = false;
			CantWalk = true;
			Race = Race.Human;
			Hue = 1003;
			HairItemID = 50702;
			HairHue = 2223;
			FacialHairItemID = 50804;
			FacialHairHue = 2223;
		}

		public override void InitOutfit()
		{
			Ability.GiveItem( this, new BlueCloak() );
			Ability.GiveItem( this, new BlueHat() );
			Ability.GiveItem( this, new BlueShirt() );
			Ability.GiveItem( this, new BluePants() );
			Ability.GiveItem( this, new BlueSash() );
			Ability.GiveItem( this, new BlueBoots() );
			Ability.GiveItem( this, new BlueArms() );
			Ability.GiveItem( this, new BlueBelt() );
		}

		public BlueBen( Serial serial ) : base( serial )
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