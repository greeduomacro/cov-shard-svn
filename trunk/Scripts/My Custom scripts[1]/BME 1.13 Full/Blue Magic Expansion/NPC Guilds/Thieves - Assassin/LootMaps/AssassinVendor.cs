// Created by Peoharen
using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class ACreedVendor : BaseVendor
	{
		[Constructable]
		public ACreedVendor() : base( "" )
		{
			Name = "Yusuf Tazim";
			SetSkill( SkillName.DetectHidden, 150 );
			SetSkill( SkillName.RemoveTrap, 150 );
			SetSkill( SkillName.Hiding, 150 );
			SetSkill( SkillName.Stealth, 150 );
			SetSkill( SkillName.Lockpicking, 150 );
			SetSkill( SkillName.Snooping, 150 );
			SetSkill( SkillName.Stealing, 150 );
			SetSkill( SkillName.Poisoning, 150 );
			SetSkill( SkillName.Swords, 150 );
			SetSkill( SkillName.Tactics, 150 );
		}

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBLootMap() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			//Dress Order: ThighBoots, Shirt, Skirt, Chest, BoneArms, Mempo, Kilt, JinBori, Belt, Coif, Gloves
			Ability.GiveItem( this, new ACreedThighBoots() );
			Ability.GiveItem( this, new ACreedShirt() );
			Ability.GiveItem( this, new ACreedSkirt() );
			Ability.GiveItem( this, new ACreedStuddedChest() );
			Ability.GiveItem( this, new ACreedBoneArms() );
			Ability.GiveItem( this, new ACreedKilt() );
			Ability.GiveItem( this, new ACreedJinBori() );
			Ability.GiveItem( this, new ACreedBelt() );
			Ability.GiveItem( this, new ACreedChainCoif() );
			Ability.GiveItem( this, new ACreedLeafGloves() );
		}

		public ACreedVendor( Serial serial ) : base( serial )
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