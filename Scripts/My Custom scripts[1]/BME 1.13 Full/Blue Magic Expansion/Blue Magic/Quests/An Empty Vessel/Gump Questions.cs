// Created by Peoharen
using System;
using Server;
using Server.Engines.Quests;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class BlueMageQuestionsGump : Gump
	{
		private BlueBen m_Ben;
		private int m_Question;
		private int[] m_Serpent;

		#region EasierToRead
		public int Sky
		{
			get{ return m_Serpent[0]; }
			set{ m_Serpent[0] = value; }
		}

		private int Flame
		{
			get{ return m_Serpent[1]; }
			set{ m_Serpent[1] = value; }
		}

		private int Gale
		{
			get{ return m_Serpent[2]; }
			set{ m_Serpent[2] = value; }
		}

		private int Stone
		{
			get{ return m_Serpent[3]; }
			set{ m_Serpent[3] = value; }
		}

		private int Spring
		{
			get{ return m_Serpent[4]; }
			set{ m_Serpent[4] = value; }
		}
		#endregion
		
		public BlueMageQuestionsGump( Mobile m, BlueBen ben ) : this( m, ben, 0, new int[]{ 0, 0, 0, 0, 0 } )
		{
		}

		public BlueMageQuestionsGump( Mobile m, BlueBen ben, int question, int[] serpent ) : base( 25, 25 )
		{
			if ( m == null || ben == null )
				return;
			if ( serpent.Length < 5 )
				return;

			m_Ben = ben;
			m_Question = question;
			m_Serpent = serpent;
			int hue = m.SpeechHue;

			Closable = false;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			// Header
			AddBackground( 0, 0, 450, 75, 3600 );
			AddImage( 20, 20, 113 );
			AddImage( 400, 20, 113 );
			AddLabel( 160, 25, 1365, @"An Empty Vessel" );

			// Question Background
			AddBackground( 0, 75, 450, 205, 3600 );



			switch( m_Question )
			{
				case 0:
				{
					AddHtml( 20, 95, 410, 140, 
						"Hello, my name is Ben and I am one of the Masters of Blue Magic. In order to become a blue mage, you must have at least 50 in forensics and you are required to train magic resist if you wish to be worth your weight. There are over twenty spells for you to learn as a blue mage, each one is unique and their effects widely very unlike any spell you have seen before.They can be learned throughout Ilshenar by interacting with various \"special\" monsters. Some spells are learned by being subject to their effects, while others can only be learned by studying the remains of the very special creatures (by using the \"[bm study\" and targeting the corpse). Lastly, for you types that like to get your hands dirty, there are a few moves that can be learned as well.<br><br>If this appeals to you, I'd like to ask you a series of questions in order understand the nature of your soul. Thereby I will be able to tell you which mark is required for you to become a blue mage. Mindful this is a life style and not just a quick pick me up. <BASEFONT COLOR='#AA0000'>Becoming a blue mage will severely inhibit your ability to be a master mage in any other spellcasting ability.</BASEFONT>",
						true, true );

					//AddLabel( 20, 95, 1365, "Hello, I take it you wish to become a Blue Mage? Well then I" );
					//AddLabel( 20, 115, 1365, "need to ask you a series of questions, they are quite simple" );
					//AddLabel( 20, 135, 1365, "but answer them honestly. When I am finished you must go and" );
					//AddLabel( 20, 155, 1365, "search where I told you to go. (search by double clicking" );
					//AddLabel( 20, 175, 1365, "the terrain)" );
					AddButton( 21, 236, 247, 248, 2, GumpButtonType.Reply, 0 );
					AddButton( 101, 236, 242, 241, 10, GumpButtonType.Reply, 0 );
					break;
				}
				case 1:
				{
					AddLabel( 20, 95, 1365, "What is destiny?" );

					AddButton( 21, 176, 209, 208, 2, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Is immutable" );

					AddButton( 21, 206, 209, 208, 1, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "One forges for oneself" );

					AddButton( 21, 236, 209, 208, 3, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Is unknowable" );
					break;
				}
				case 2:
				{
					AddLabel( 20, 95, 1365, "Does the accomplishment of a goal" );
					AddLabel( 20, 115, 1365, "require sacrifice and hardship?" );

					AddButton( 21, 176, 209, 208, 2, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Not if you think hard enough." );

					AddButton( 21, 206, 209, 208, 1, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "Occasionally." );

					AddButton( 21, 236, 209, 208, 4, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Absolutely." );
					break;
				}
				case 3:
				{
					AddLabel( 20, 95, 1365, "You hold in your hands a forbidden" );
					AddLabel( 20, 115, 1365, "scroll. Reading it will bring you" );
					AddLabel( 20, 135, 1365, "untold wisdom, but cost all that you own." );

					AddButton( 21, 176, 209, 208, 0, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Read the scroll?" );

					AddButton( 21, 206, 209, 208, 2, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "Throw the scroll away?" );

					AddButton( 21, 236, 209, 208, 1, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Burn the scroll?" );
					break;
				}
				case 4:
				{
					AddLabel( 20, 95, 1365, "If the loss of one life would save" );
					AddLabel( 20, 115, 1365, "ten thousand, would you offer yourself" );
					AddLabel( 20, 135, 1365, "without hesitation?" );

					AddButton( 21, 176, 209, 208, 3, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Offer another..." );

					AddButton( 21, 206, 209, 208, 4, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "I have no such courage." ); 

					AddButton( 21, 236, 209, 208, 0, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Without hesitation." );
					break;
				}
				case 5:
				{
					AddLabel( 20, 95, 1365, "Would you choose a tumultuous life where fame or" );
					AddLabel( 20, 115, 1365, "fortune were attainable, or atranquil life where both" );
					AddLabel( 20, 135, 1365, "were forever beyond your reach?" );

					AddButton( 21, 176, 209, 208, 1, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "A chaotic life." );

					AddButton( 21, 206, 209, 208, 4, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "A tranquil life." );

					AddButton( 21, 236, 209, 208, 3, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "A mix of both." );
					break;
				}
				case 6:
				{
					AddLabel( 20, 95, 1365, "You stand on the precipice between life and death. Would" );
					AddLabel( 20, 115, 1365, "you choose to live life as a beast if it would save you" );
					AddLabel( 20, 135, 1365, "from falling into the shadowy abyss of the underworld?" );

					AddButton( 21, 176, 209, 208, 3, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "If it keeps me from dying..." );

					AddButton( 21, 206, 209, 208, 0, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "Fall, and keep my humanity." );

					AddButton( 21, 236, 209, 208, 2, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Embrace life as a beast." );
					break;
				}
				case 7:
				{
					AddLabel( 20, 95, 1365, "A companion in battle turns against you, raising a " );
					AddLabel( 20, 115, 1365, "weapon to attack." );
					AddLabel( 20, 135, 1365, "" );

					AddButton( 21, 176, 209, 208, 2, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Brace for the blow?" );

					AddButton( 21, 206, 209, 208, 4, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "Try to reason with him?" );

					AddButton( 21, 236, 209, 208, 1, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Cut him down?" );
					break;
				}
				case 8:
				{
					AddLabel( 20, 95, 1365, "A loved one is afflicted with a terrible illness" );
					AddLabel( 20, 115, 1365, "and has little time left to live. You are asked" );
					AddLabel( 20, 135, 1365, "to end that life by your own hand." );

					AddButton( 21, 176, 209, 208, 4, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Seek a cure?" );

					AddButton( 21, 206, 209, 208, 0, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "Leave the world together?" );

					AddButton( 21, 236, 209, 208, 3, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Grant the request?" );
					break;
				}
				case 9:
				{
					AddLabel( 20, 95, 1365, "You are in the midst of a fierce battle. The" );
					AddLabel( 20, 115, 1365, "enemy lying at your feet was once a friend." );
					AddLabel( 20, 135, 1365, "His breath is ragged and weak." );

					AddButton( 21, 176, 209, 208, 4, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Tend to his wounds?" );

					AddButton( 21, 206, 209, 208, 0, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "End his pain?" );

					AddButton( 21, 236, 209, 208, 3, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Ignore your old friend?" ); 
					break;
				}
				case 10:
				{
					AddLabel( 20, 95, 1365, "A superior to whom you owe a great debt orders" );
					AddLabel( 20, 115, 1365, "you to act in a way that violates your sense of" );
					AddLabel( 20, 135, 1365, "justice." );
					
					AddButton( 21, 176, 209, 208, 1, GumpButtonType.Reply, 0 );
					AddLabel( 44, 175, hue, "Try to remove him from power?" );

					AddButton( 21, 206, 209, 208, 2, GumpButtonType.Reply, 0 );
					AddLabel( 44, 205, hue, "Carry out the order?" );

					AddButton( 21, 236, 209, 208, 0, GumpButtonType.Reply, 0 );
					AddLabel( 44, 235, hue, "Follow your sense of justice?" );
					break;
				}
				case 11:
				{
					AddLabel( 20, 95, 1365, "I see, I understand, I comprehend, I fathom it so." );
					AddLabel( 20, 115, 1365, "And so I shall. ... Tell you what I seen that is. " );
					AddLabel( 20, 135, 1365, "You must journy into the lands of Ilshenar for your" );
					AddLabel( 20, 155, 1365, "Mark." );

					AddButton( 21, 236, 247, 248, 11, GumpButtonType.Reply, 0 );
					AddButton( 101, 236, 242, 241, 10, GumpButtonType.Reply, 0 );
					break;
				}
			}
		}
		
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 10 )
				return;

			if ( m_Question != 0 )
			{
				switch( info.ButtonID )
				{
					case 0: Sky++; break;
					case 1: Flame++; break;
					case 2: Gale++; break;
					case 3: Stone++; break;
					case 4: Spring++; break;
				}
			}

			if ( m_Question < 11 )
			{
				if ( sender.Mobile.HasGump( typeof( BlueMageQuestionsGump ) ) )
					sender.Mobile.CloseGump( typeof( BlueMageQuestionsGump ) );

				sender.Mobile.SendGump( new BlueMageQuestionsGump( sender.Mobile, m_Ben, m_Question + 1, m_Serpent ) );
			}
			else if ( sender.Mobile is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)sender.Mobile;

				int[] highest = { -1, -1 };

				for ( int i = 0; i < m_Serpent.Length; i++ )
				{
					if ( m_Serpent[i] > highest[1] )
					{
						highest[0] = i;
						highest[1] = m_Serpent[i];
					}
				}

				BaseQuest bq = null;

				switch( highest[0] )
				{
					default: bq = new BlueMageSkySerpentQuest( pm ); break;
					case 1: bq = new BlueMageFlameSerpentQuest( pm ); break;
					case 2: bq = new BlueMageGaleSerpentQuest( pm ); break;
					case 3: bq = new BlueMageStoneSerpentQuest( pm ); break;
					case 4: bq = new BlueMageSpringSerpentQuest( pm ); break;
				}

				if ( bq == null )
				{
					pm.SendMessage( 33, "Error: Page a GM and tell him \"BM Questions failed to offer BM Serpent Quest\" immidately." );
					return;
				}
				else
				{
					bq.Owner = pm;
					bq.Quester = m_Ben;

					if ( !QuestHelper.CanOffer( pm, bq, true ) )
					{
						bq.StartingMobile.OnOfferFailed();
						return;
					}
				}
				
				pm.CloseGump( typeof( MondainQuestGump ) );
				pm.SendGump( new MondainQuestGump( bq ) );
			}
		}
	}
}