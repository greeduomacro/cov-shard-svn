using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class MonkDecisionQuest : BaseQuest
    {
        /* A Monks Decision */
        public override object Title { get { return "A Monks Decision..."; } }

        public override object Description { get { return "I have seen the wisdom and the fight in you young one. If you'd like to learn something about the monk ways, go and kill the beasts listed on the next page to show your courage. When you have completed this task, come back to me for a gift from the brotherhood..."; } }

        public override object Refuse { get { return "It is such a shame to see such Inner strength and courage go to waste...."; } }

        public override object Uncomplete { get { return "You have not yet completed your task for the brotherhood..."; } }

        public override object Complete { get { return "Well done! Now go back to Miako to recieve a gift from the Master himself."; } }

        public MonkDecisionQuest() : base()
        {
            AddObjective(new SlayObjective(typeof(HighPlainsBoura), "High Plains Boura's", 10));
            AddObjective(new SlayObjective(typeof(RuddyBoura), "Ruddy Boura's", 10));
            AddObjective(new SlayObjective(typeof(LesserHiryu), "LesserHiryu", 10));
            AddObjective(new SlayObjective(typeof(EliteNinja), "Elite Ninja", 10));
            
            AddReward(new BaseReward(typeof(MonkFists), "Monk Gloves" )); // Monk Gloves
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

    public class MiakoNye : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( MonkDecisionQuest )
			};
            }
        }

        [Constructable]
        public MiakoNye()
            : base("Miako Nye", "The Monk Master ")
        {
        }

        public MiakoNye(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = false;
            CantWalk = true;
            Race = Race.Human;

            Hue = 0x83FF;
            HairItemID = 0x2044;
            HairHue = 0x1;
        }

        public override void InitOutfit()
        {
            AddItem(new Backpack());
            AddItem(new Sandals(1));
            AddItem(new Robe(1));
            AddItem(new Shirt());
            AddItem(new ShortPants());

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
	
	