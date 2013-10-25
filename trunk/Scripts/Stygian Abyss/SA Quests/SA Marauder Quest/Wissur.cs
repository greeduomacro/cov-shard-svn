using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests
{
    public class MarauderQuest : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

      
        public override object Title { get { return "Marauding Gargoyle Quest"; } }


        public override object Description { get { return "Hey! I'm glad your here! We need your help<br>There is a crazy marauding gargoyle running around here killing all the fish! If you go kill him, and come back, I'll make you a copy of his Talons to wear on your feet."; } }


        public override object Refuse { get { return "Fine! Run around without shoes then! Let a whole town suffer! Thanks a lot!"; } }


        public override object Uncomplete { get { return "You didn't kill him yet?"; } }


        public override object Complete { get { return "Good Job! Now use these and cover those ugly feet up!"; } }

        public MarauderQuest() : base()
        {
         
            AddObjective(new SlayObjective(typeof(MaraudingGargoyle), "Marauding Gargoyle", 1 ));    
           
            AddReward(new BaseReward(typeof(MarauderTalons), "Marauder Talons"));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class Wissur : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( MarauderQuest )
			};
            }
        }

        [Constructable]
        public Wissur() : base("Wissur", "distraught fisherman")
        {
        }

       public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = false;
			CantWalk = true;
            //Name = "Naxatillor";
            //Title = "The Seer";

            Body = 666;
			HairItemID = 16987;
			HairHue = 1801;
        }

        public override void InitOutfit()
        {
            AddItem(new Backpack());

            AddItem(new GargishClothChest(Utility.RandomNeutralHue()));
            AddItem(new GargishClothKilt(Utility.RandomNeutralHue()));
            AddItem(new GargishClothLegs(Utility.RandomNeutralHue()));
        }

        public Wissur(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
	
	