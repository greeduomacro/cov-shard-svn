// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class RandomStudentMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				return GetSpeech();
			}
		}

		[Constructable]
		public RandomStudentMoonglowNPC() : base()
		{
			Female = Utility.RandomBool();

			if ( Female )
				Name = NameList.RandomName( "female" );
			else
				Name = NameList.RandomName( "male" );

			int hairhue = Utility.RandomHairHue();
			Utility.AssignRandomHair( this, hairhue );
			Utility.AssignRandomFacialHair( this, hairhue );

			Title = "a Student of the Council of Mages";

			EquipItem( new Robe( Utility.RandomYellowHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		private string GetSpeech()
		{
			string words = "";

			switch( Serial.Value % 8 )
			{
				case 0: words = "I really wanted to study at the new Tolaria Academy I heard about but my parents say I should be in a school that is reliable and well established."; break;
				case 1: words = "Moonglow's council is all right I suppose, they have a lot of confidence up to the point it spills into arrogance. There is also a lot of propaganda about how great they are shoved into every subject.<br><br>You know in Felucca the council is one of the factions that is trying to rule the world? How close is this one to thinking the same thing?"; break;
				case 2: words = "The Council of Mages is great!<br><br>Ugh, why is there an entire session about how great the council is. We already have a session about the council's history.<br><br>I bet it's Tolaria's fault, if that place didn't teach magic then we wouldn't get a sales pitch about how great this place is hourly."; break;
				case 3: words = "Classes in the morning, breakfast, classes, lunch, classes, dinner, classes, I am so tired. Please leave me in peace."; break;
				case 4: words = "Did you know the an Archmagi from the Council of Mages created the first boat? Steel was created in the very Alchemy classes offered here too. The history here is vast and filled with many great deeds."; break;
				case 5: words = "I think this place is great and all but a little overrated. We have seperate guilds and individual people working with various crafts but when it comes to magic, sudddenly the council of mages are the only ones good enough to do anything."; break;
				case 6: words = "Flam Kal Des. ... Um, what what is again? Vas? Grav? Grav Kal Des Vas!<br><br>Damn. You are distracting me, go away."; break;
				case 7: words = "Interesting concept, using necromancy's cursed weapon, vampiric form, and the martial skill of the samurai for virtual immortality. I wonder..."; break;
			}

			return words;
		}

		public RandomStudentMoonglowNPC( Serial serial ) : base( serial )
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
