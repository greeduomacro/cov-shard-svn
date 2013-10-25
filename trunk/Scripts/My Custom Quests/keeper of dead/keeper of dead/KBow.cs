using System; 
using Server; 

namespace Server.Items 
{ 
	public class KBow : Bow 
	{ 
		public override int LabelNumber{ get{ return 1061090; } } // Spirit Of The Totem
		
		public override int PoisonResistance{ get{ return 15; } } 
		// TODO: Random Skill with +5 or +10
		
		public override int InitMinHits{ get{ return 255; } } 
		public override int InitMaxHits{ get{ return 255; } }

		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable] 
		public KBow()
		{ 
			int modifier;
			
			Name = "Bow of Knowledge";
			Hue = 93; 
			StrRequirement = 30;
			WeaponAttributes.SelfRepair = 5;
			Attributes.WeaponSpeed = 25;
            Attributes.AttackChance = 20;
			Attributes.WeaponDamage = 35;
			Attributes.SpellChanneling = 1; 
			
			switch ( Utility.Random( 2 ) ) {
				case 0: modifier = 5; break;
				case 1: modifier = 10; break;
				default: modifier = 5; break;
			}
			
			switch ( Utility.Random( 18 ) ) {
				
				case 1: SkillBonuses.SetValues( 0, SkillName.Anatomy, modifier ); break;
				case 2: SkillBonuses.SetValues( 0, SkillName.ArmsLore, modifier ); break;	
				case 3: SkillBonuses.SetValues( 0, SkillName.Fletching, modifier ); break;
				case 4: SkillBonuses.SetValues( 0, SkillName.Peacemaking, modifier ); break;		
				case 5: SkillBonuses.SetValues( 0, SkillName.Healing, modifier ); break;
				case 6: SkillBonuses.SetValues( 0, SkillName.Hiding, modifier ); break;
				case 7: SkillBonuses.SetValues( 0, SkillName.Provocation, modifier ); break;		
				case 8: SkillBonuses.SetValues( 0, SkillName.Magery, modifier ); break;
				case 9: SkillBonuses.SetValues( 0, SkillName.MagicResist, modifier ); break;
				case 10: SkillBonuses.SetValues( 0, SkillName.Tactics, modifier ); break;	
				case 11: SkillBonuses.SetValues( 0, SkillName.Musicianship, modifier ); break;
				case 12: SkillBonuses.SetValues( 0, SkillName.Poisoning, modifier ); break;
				case 13: SkillBonuses.SetValues( 0, SkillName.Archery, modifier ); break;
				case 14: SkillBonuses.SetValues( 0, SkillName.SpiritSpeak, modifier ); break;
				case 15: SkillBonuses.SetValues( 0, SkillName.Stealth, modifier ); break;
				case 16: SkillBonuses.SetValues( 0, SkillName.Necromancy, modifier ); break;
				case 17: SkillBonuses.SetValues( 0, SkillName.Focus, modifier ); break;
				case 18: SkillBonuses.SetValues( 0, SkillName.Chivalry, modifier ); break;
				default: SkillBonuses.SetValues( 0, SkillName.Archery, modifier ); break;
			}
		} 

		public KBow( Serial serial ) : base( serial ) 
		{ 
		} 
        
		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 
        
		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		} 
	} 
}  
 
