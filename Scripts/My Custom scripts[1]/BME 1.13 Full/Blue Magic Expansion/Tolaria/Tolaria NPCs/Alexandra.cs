// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class AlexandraTolariaNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				return GetSpeech();
			}
		}

		[Constructable]
		public AlexandraTolariaNPC() : base()
		{
			Name = "Alexandra"; // Roivas
			Title = "Lead Rune Researcher";
			Female = true;

			EquipItem( new Robe( 2207 ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		private string GetSpeech()
		{
			string words = "";

			switch( DateTime.Now.DayOfWeek )
			{
				case DayOfWeek.Monday:
				{
					/*
					Words have power, great power. And we use them every day without care 
					or concern to how they work and sometimes even the repercussions of 
					using them. Today I will pose some inquiries and considerations to 
					ponder.<br><br>

					Consider magery and it's verbal components, Flem simply means fire 
					and you cannot invoke fire without using it. What is lost when the 
					word is written down and unsaid?<br><br>

					By casting a powerful spell you can inscribe a location into a rune 
					and by yet another spell you can read the location and instantly 
					return to it. Why does the location have to be encoded into the 
					rune? Before you pose an answer, is the location truly so complex that 
					a mage can not to memorize the location of his own workshop and must 
					rely on a recall rune?<br><br>

					Finally, house teleporters. Is it the rune, the spell, or both that 
					allow them to work and why is it the symbols must match, if it was
					because nonmages commission for them to be built then why doesn't a mage 
					change things as a show of talent?<br><br>

					Accepting what is without asking what it could be, that is perhaps the blindest state of all.
					*/
					words = "Words have power, great power. And we use them every day without care or concern to how they work and sometimes even the repercussions of using them. Today I will pose some inquiries and considerations to ponder.<br><br>Consider magery and it's verbal components, Flem simply means fire and you cannot invoke fire without using it. What is lost when the word is written down and unsaid?<br><br>By casting a powerful spell you can inscribe a location into a rune and by yet another spell you can read the location and instantly return to it. Why does the location have to be encoded into the rune? Before you pose an answer, is the location truly so complex that a mage can not to memorize the location of his own workshop and must rely on a recall rune?<br><br>Finally, house teleporters. Is it the rune, the spell, or both that allow them to work and why is it the symbols must match, if it was because nonmages commission for them to be built then why doesn't a mage change things as a show of talent?<br><br>Accepting what is without asking what it could be, that is perhaps the blindest state of all.";
					break;
				}
				// For later additions

			}

			return words;
		}

		public AlexandraTolariaNPC( Serial serial ) : base( serial )
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
