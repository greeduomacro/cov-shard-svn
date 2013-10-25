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
	public class MonkMaJong : MondainQuester // Horse Dummy used in martial arts
	{	
		public override Type[] Quests
		{
			get
			{
				return new Type[]
				{
					typeof( MonkMaJongQuest )
				};
			}
		}

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBMonk() );
		}

		[Constructable]
		public MonkMaJong() : base( "Ma Jong", "the monk" )
		{
			SetSkill( SkillName.Focus, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );
		}

		public override void Advertise()
		{
			// No one likes a NPC that yells at you for attention.
		}

		public override void InitBody()
		{
			InitStats( 100, 100, 100 );
			Female = false;
			CantWalk = true;
			Race = Race.Human;
			Hue = 1003;
			//HairItemID = 50702;
			//HairHue = 2223;
			FacialHairItemID = 8254;
			FacialHairHue = 2500;
		}

		public override void InitOutfit()
		{
			Ability.GiveItem( this, 2500, new MonkFists() );
			Ability.GiveItem( this, 2500, new Kasa() );
			Ability.GiveItem( this, 2500, new JinBaori() );
			Ability.GiveItem( this, 2500, new TattsukeHakama() );
			Ability.GiveItem( this, new Sandals() );
		}

		public MonkMaJong( Serial serial ) : base( serial )
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