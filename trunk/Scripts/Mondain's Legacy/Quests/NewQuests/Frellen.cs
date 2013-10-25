using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class GhostlyPests : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

        public override object Title { get { return "GhostlyPests"; } }

        public override object Description { get { return "I see your new around here, and could use some help. There are to the west of us, a band of wraiths that keep on bothering the Umbra citizens. If you would go find them and kill 10 of them, I will reward you with a Necromancer book."; } }

        /* I quite understand your reluctance.  If you reconsider, I'll be here. */
        public override object Refuse { get { return 1072687; } }

        /* Is all going well? I look forward to the simple comforts in my very own home. */
        public override object Uncomplete { get { return "Is there a problem? I see you haven't killed enough wraiths yet!"; } }

        public override object Complete { get { return "Good Job! Now here is the necromancer book as I promised, to get you started with necromancy, here on COV."; } }
        public GhostlyPests()
            : base()
        {
            AddObjective(new SlayObjective(typeof(Wraith), "Wraiths", 10));

            AddReward(new BaseReward(typeof(NewCharNecroBag), "New Char Necro Bag"));
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

    public class Frellen : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( GhostlyPests )
			};
            }
        }

        [Constructable]
        public Frellen()
            : base("Frellen", "the necro novice")
        {
        }

        public Frellen(Serial serial)
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