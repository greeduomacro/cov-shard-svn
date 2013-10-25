using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class Protection2Quest : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

        public override object Title { get { return "Protection Quest"; } }

        public override object Description { get { return "I see your new around here, and could use some help. If you would go south-east from the public moongate here in TerMur, and kill 10 chicken lizards, I shall reward you with some  gargish armor to help protect you when fighting."; } }

        /* I quite understand your reluctance.  If you reconsider, I'll be here. */
        public override object Refuse { get { return 1072687; } }

        /* Is all going well? I look forward to the simple comforts in my very own home. */
        public override object Uncomplete { get { return "Is there a problem? I see you haven't killed enough chicken lizards yet!"; } }

        public override object Complete { get { return "Good Job! Now here is the bag of  gargish armor I promised, to get you started here on COV."; } }

        public Protection2Quest()
            : base()
        {
            AddObjective(new SlayObjective(typeof(ChickenLizard), "Chicken Lizards", 10));

            AddReward(new BaseReward(typeof(NewCharGArmorBag), "New Char Gargish Armor Bag"));
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

    public class Bellen : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( Protection2Quest )
			};
            }
        }

        [Constructable]
        public Bellen()
            : base("Baylor", "the hunter")
        {
        }

        public Bellen(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = false;
            CantWalk = true;
            Race = Race.Gargoyle;

            Body = 666;
            HairItemID = 16987;
            HairHue = 1801;
        }

        public override void InitOutfit()
        {
            AddItem(new MaleGargishPlateChest());
            AddItem(new MaleGargishPlateKilt());
            AddItem(new MaleGargishPlateLegs());
            AddItem(new MaleGargishPlateArms());
            AddItem(new PlateTalons());

            AddItem(new GlassSword());
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