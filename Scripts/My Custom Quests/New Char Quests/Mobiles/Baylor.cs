using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class ProtectionQuest : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

        public override object Title { get { return "Protection Quest"; } }

        public override object Description { get { return "I see your new around here, and could use some help. If you would go south-west from here and kill 10 orcs, I shall reward you with some armor to help protect you when fighting."; } }

        /* I quite understand your reluctance.  If you reconsider, I'll be here. */
        public override object Refuse { get { return 1072687; } }

        /* Is all going well? I look forward to the simple comforts in my very own home. */
        public override object Uncomplete { get { return "Is there a problem? I see you haven't killed enough orcs yet!"; } }

        public override object Complete { get { return "Good Job! Now here is the bag of armor I promised, to get you started here on COV."; } }

        public ProtectionQuest()
            : base()
        {
            AddObjective(new SlayObjective(typeof(Orc), "Orcs", 10));

            AddReward(new BaseReward(typeof(NewCharArmorBag), "New Char Armor Bag"));
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

    public class Baylor : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( ProtectionQuest )
			};
            }
        }

        [Constructable]
        public Baylor()
            : base("Baylor", "the hunter")
        {
        }

        public Baylor(Serial serial)
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
            AddItem(new HalfApron(0x6D2));
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