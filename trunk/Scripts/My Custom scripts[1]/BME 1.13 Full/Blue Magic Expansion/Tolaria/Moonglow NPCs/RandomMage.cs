// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class RandomMageMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				return GetSpeech();
			}
		}

		[Constructable]
		public RandomMageMoonglowNPC() : base()
		{
			Female = Utility.RandomBool();

			if ( Female )
				Name = NameList.RandomName( "female" );
			else
				Name = NameList.RandomName( "male" );

			int hairhue = Utility.RandomHairHue();
			Utility.AssignRandomHair( this, hairhue );
			Utility.AssignRandomFacialHair( this, hairhue );

			Title = "a Mage of the Council of Mages";

			EquipItem( new Robe( Utility.RandomBlueHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		private string GetSpeech()
		{
			string words = "";

			switch( Serial.Value % 5 )
			{
				case 0: words = "I'm focusing on summoning. Energy Vortexes are my favorite but one must remember the lower level spells as well. Summoning even simple animals can serve as a distraction allowing you to slip by unnoticed."; break;
				case 1: words = "The Council of Mages is the greatest mage council in history, 500 years of being the greatest collection of spellcasters ever. I will join their ranks of elite and will one day rule the council and through it, many other things..."; break;
				case 2: words = "Tolaria, blah. I applied there for teaching and they would not have me. Me, a great spellcaster of the Council of Mages. I have taught here for years and many of my students passed with excellent scores. If Tolaria doesn't hire people like me then their academy is the lowest of lows, crap scraped off a mandrakeroot. Anyone who gos to them are a fool."; break;
				case 3: words = "What is all the buzz about Tolaria? We, the Council of Mages, have been to busy researching new spells & concepts and teaching them to students to indulge in the theatrics of a commoner's past time gossip."; break;
				case 4: words = "You there, how would you like to become great? Only a trained member of the Council of Mages is truly skilled so sign up today."; break;
			}

			return words;
		}

		public RandomMageMoonglowNPC( Serial serial ) : base( serial )
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
