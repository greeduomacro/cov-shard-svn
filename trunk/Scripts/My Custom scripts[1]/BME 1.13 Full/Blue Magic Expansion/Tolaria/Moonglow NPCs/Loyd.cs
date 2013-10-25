// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class LoydMoonglowNPC : TolariaNPC
	{
		public override string m_Speech
		{
			get
			{
				/*
				I can't say I am surpised on this idea of another Acadamy. Many people 
				are upset at some of our work.

				Iilshenar's discovery was a fluke, the by product of British's failure to 
				merge the shards. The members of the council who promoted the idea were 
				immediately replaced with more sensible magi.

				Whispers say we know nothing, they are quick to point out we didn't know 
				about necromancy until Malas was discovered or the elven spellweaving, 
				or the gargoyle mysticism. What those rumors fail to address is each new 
				art has been incorporated by us, expending our knowledge of the arcane.<br><br>

				This, "Tolaria", is misguided. If they think they have discovered something 
				new they should bring it to us. We know all there is to know in this world and 
				have had more practice at learning new concepts than anyone else.
				*/
				return "I can't say I am surpised on this idea of another Acadamy. Many people are upset at some of our work.<br><br>Iilshenar's discovery was a fluke, the by product of British's failure to merge the shards. The members of the council who promoted the idea were immediately replaced with more sensible magi.<br><br>Whispers say we know nothing, they are quick to point out we didn't know about necromancy until Malas was discovered or the elven spellweaving, or the gargoyle mysticism. What those rumors fail to address is each new art has been incorporated by us, expending our knowledge of the arcane.<br><br>This, \"Tolaria\", is misguided. If they think they have discovered something new they should bring it to us. We know all there is to know in this world and have had more practice at learning new concepts than anyone else.";
			}
		}

		[Constructable]
		public LoydMoonglowNPC() : base()
		{
			Name = "Loyd";
			Title = "a Historian of the Council of Mages";
			Female = false;

			EquipItem( new Robe( Utility.RandomRedHue() ) );
			EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
		}

		public LoydMoonglowNPC( Serial serial ) : base( serial )
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
