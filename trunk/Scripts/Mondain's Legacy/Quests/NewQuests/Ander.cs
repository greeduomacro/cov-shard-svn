using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class NewNeighborsQuest : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

        public override object Title { get { return "New Neighbors"; } }

        public override object Description { get { return "I see your new to COV, and could use a place to live. I might be able to help you out with a new house. If you would go and get me 100 boards, so I can finish this last house I'm building, I'll reward you with the Deed to it."; } }

        /* I quite understand your reluctance.  If you reconsider, I'll be here. */
        public override object Refuse { get { return 1072687; } }

        public override object Uncomplete { get { return "Is there a problem? I see you don't have enough boards yet!"; } }

        public override object Complete { get { return "Good Job! Now here is the deed I promised. Now you have a place to call home and store things here on COV."; } }

        public NewNeighborsQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(Board), "boards", 100, 0x1BD7));

            AddReward(new BaseReward(typeof(NewCharRewardBag), "New Char Reward Bag"));
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

    public class Ander : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( NewNeighborsQuest )
			};
            }
        }

        [Constructable]
        public Ander()
            : base("Ander", "the housing broker")
        {
        }

        public Ander(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = false;
            CantWalk = true;
            Race = Race.Human;

            Hue = 0x83F6;
            HairItemID = 0x203C;
            HairHue = 0x6B1;
        }

        public override void InitOutfit()
        {
            AddItem(new Backpack());
            AddItem(new Boots(0x543));
            AddItem(new LongPants(0x758));
            AddItem(new FancyShirt(0x53A));
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

     

