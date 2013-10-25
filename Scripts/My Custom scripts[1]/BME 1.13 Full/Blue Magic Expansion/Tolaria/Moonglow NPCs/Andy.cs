// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class AndyMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				/*
				Tolaria? Blah, what the abyss are you thinking?<br><br>

				Listen up becuase I'm only going to tell you once. The Council of Mages 
				is the best place to study arcane magic. Those other guys don't know what 
				they are doing. I've seen their program and it is a joke. Nightshade 
				them! Sign up here, we know what in the ginsing we are doing.
				*/
				return "Tolaria? Blah, what the abyss are you thinking?<br><br>Listen up becuase I'm only going to tell you once. The Council of Mages is the best place to study arcane magic. Thsoe other guys don't know what they are doing. I've seen their program and it is a joke. Nightshade them! Sign up here, we know what in the ginsing we are doing.";
			}
		}

		[Constructable]
		public AndyMoonglowNPC() : base()
		{
			Name = "Andy";
			Title = "a Tutor of the Council of Mages";
			Female = false;

			EquipItem( new Robe( Utility.RandomGreenHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		public AndyMoonglowNPC( Serial serial ) : base( serial )
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
