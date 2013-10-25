using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{	
	public class FatherJacob1 : MondainQuester
	{		
		public override Type[] Quests{ get{ return new Type[] { typeof( PergatoryPQuest ) }; } }
		
		[Constructable]
		public FatherJacob1() : base( "Father Jacob", "the town friar" )
		{			
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.Focus, 60.0, 83.0 );
		}
		
		public FatherJacob1( Serial serial ) : base( serial )
		{
		}
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = false;
			Race = Race.Human;

            Hue = 0x83F3;
            HairItemID = 0x2047;
            HairHue = 0x393;
            FacialHairItemID = 0x203F;
            FacialHairHue = 0x393;
        }

        public override void InitOutfit()
        {
            AddItem(new Backpack());
            AddItem(new Boots(0x717));
            AddItem(new Robe(0x1BB));

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