// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class JordenMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				/*
				Hey what's up? Tolaria? I'll tell you what, if you can find it I'll 
				believe you you know what are talking about. Otherwise you should 
				just concentrate on your studies here. Unless you are not a mage, in 
				which case why are you even talking to me?
				*/
				return "Hey what's up? Tolaria? I'll tell you what, if you can find it I'll believe you you know what are talking about. Otherwise you should just concentrate on your studies here. Unless you are not a mage, in which case why are you even talking to me?";
			}
		}

		[Constructable]
		public JordenMoonglowNPC() : base()
		{
			Name = "Jorden";
			Title = "a Tutor of the Council of Mages";
			Female = false;

			EquipItem( new Robe( Utility.RandomGreenHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		public JordenMoonglowNPC( Serial serial ) : base( serial )
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
