// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class MikeMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				/*
				What is with this Tolaria Acadamy?

				Moonglow is the center of all magery, we are the finest teachers in all 
				the land and with 500 years of arcane study done by countless mages our 
				knowledge is absolute.

				The king's mages study under us and it was us that created the time spell 
				British used in his discovery of Ilshenar. It was us that created a 
				moongate to Malas, us that breached the planar walls to Tokuno, and us 
				that found the elves. No other group and claim so much.

				To hear of another place to study is blasphemy, what could they possible 
				know that we don't?
				*/
				return "What is with this Tolaria Acadamy?<br><br>Moonglow is the center of all magery, we are the finest teachers in all the land and with 500 years of arcane study done by countless mages our knowledge is absolute.<br><br>The king's mages study under us and it was us that created the time spell British used in his discovery of Ilshenar. It was us that created a moongate to Malas, us that breached the planar walls to Tokuno, and us that found the elves. No other group and claim so much.<br><br>To hear of another place to study is blasphemy, what could they possible know that we don't?";
			}
		}

		[Constructable]
		public MikeMoonglowNPC() : base()
		{
			Name = "Mike";
			Title = "an Archmagi of the Council of Mages";
			Female = false;

			EquipItem( new Robe( Utility.RandomRedHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		public MikeMoonglowNPC( Serial serial ) : base( serial )
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
