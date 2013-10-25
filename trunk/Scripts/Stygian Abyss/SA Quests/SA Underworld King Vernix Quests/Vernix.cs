using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{			
	public class Vernix : MondainQuester
	{
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
		{ 
			typeof( UntanglingTheWebQuest ),
            typeof( GreenWithEnvyQuest ),
		};    
     }
  } 	
		[Constructable]
		public Vernix() : base( "Vernix", "the Goblin King" )
		{
            if (this is MondainQuester)

            this.Name = "Vernix";
            this.Title = "the Goblin King";
		}
		
		public Vernix( Serial serial ) : base( serial )
		{
		}
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = false;
			Race = Race.Human;
            Body = 723;
			
            CantWalk = true;       
            Blessed = true;
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