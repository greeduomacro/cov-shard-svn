// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class DonMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				/*
				I won't recommend that you go searching for Tolaria, we have everything 
				you could ever wish to know right here in Moonglow.<br><br>

				When it comes to researching new spells and teaching young minds. We are 
				the best of the best. Scholars all over the world come here to finish 
				their studies they started from books written by us.
				*/
				return "I won't recommend that you go searching for Tolaria, we have everything you could ever wish to know right here in Moonglow.<br><br>When it comes to researching new spells and teaching young minds. We are the best of the best. Scholars all over the world come here to finish their studies they started from books written by us.";
			}
		}

		[Constructable]
		public DonMoonglowNPC() : base()
		{
			Name = "Don";
			Title = "an Archmagi of the Council of Mages";
			Female = false;

			EquipItem( new Robe( Utility.RandomRedHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		public DonMoonglowNPC( Serial serial ) : base( serial )
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
