using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class CullingTheDeadQuest : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }			

        public override object Title { get { return "Culling The Dead"; } }

        public override object Description { get { return "I see your new around here, and could use some help. If you would go to the Yew cemetary and kill 20 of those pesky skeletons for me, I shall reward you with a full magic book to get you going with magic!"; } }

        /* I quite understand your reluctance.  If you reconsider, I'll be here. */
        public override object Refuse { get { return 1072687; } }

        /* Is all going well? I look forward to the simple comforts in my very own home. */
        public override object Uncomplete { get { return "Is there a problem? I see you haven't killed enough skeletons yet!"; } }

        public override object Complete { get { return "Good Job! Now here is the magic book as I promised, to get you started with magic, here on COV."; } }

        public CullingTheDeadQuest()
            : base()
        {
            AddObjective(new SlayObjective(typeof(Skeleton), "Skeletons", 20));

            AddReward(new BaseReward(typeof(NewCharMagicBag), "New Char Magic Bag"));
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

    public class Rani : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( CullingTheDeadQuest )
			};
            }
        }

        [Constructable]
        public Rani()
            : base("Rani", "the keeper of magics")
        {
        }

        public Rani(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = true;
            CantWalk = true;
            Race = Race.Human;

            Hue = 0x83F6;
            HairItemID = 0x203C;
            HairHue = 0x6B1;
        }

        public override void InitOutfit()
        {
            AddItem(new Backpack());
            AddItem(new Shoes(0x543));
            AddItem(new Robe(0x758));
           
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

    /*public class CarpentersSatchel : Backpack
    {
        [Constructable]
        public CarpentersSatchel()
            : base()
        {
            Hue = BaseReward.SatchelHue();

            AddItem(new NewCharArmorBag());
     
        }

        public CarpentersSatchel(Serial serial)
            : base(serial)
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
}*/