using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class WizardOfOzRewardBox : WoodenBox 
	{ 
		[Constructable] 
		public WizardOfOzRewardBox() 
		{
            Hue = 1265;
			DropItem(new EarringsOfTaming());
            DropItem(new SashOfTheForgottenWarrior());
            DropItem(new EnhancedRubyRedSlippers());
            DropItem(new TheAncientBirdSlayer());		
		}

        public WizardOfOzRewardBox (Serial serial) : base(serial) 
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
