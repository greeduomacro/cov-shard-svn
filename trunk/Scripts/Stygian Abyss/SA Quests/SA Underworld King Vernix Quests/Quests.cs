using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests
{
    public class UntanglingTheWebQuest : BaseQuest
    {
        public override QuestChain ChainID { get { return QuestChain.KingVernixQuests; } }
        public override Type NextQuest { get { return typeof(GreenWithEnvyQuest); } }

        /* Untangling The Web */
        public override object Title { get { return 1095050; } }///1095051

        public override object Description { get { return 1095052; } }

        public override object Refuse { get { return 1095053; } }

        public override object Uncomplete { get { return 1095054; } }

        public override object Complete { get { return 1095057; } }

        public UntanglingTheWebQuest() : base()//during collection--1095055, 1095056
        {
            AddObjective(new SlayObjective(typeof(AcidSlug), "Acid Slugs", 10));
            AddObjective(new SlayObjective(typeof(ToxicElemental), "Acid/Toxic Elemental's", 10));

            AddReward(new BaseReward(typeof(AcidPopper), 1095058));//Acid Popper
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

    public class GreenWithEnvyQuest : BaseQuest
    {
        public override QuestChain ChainID { get { return QuestChain.KingVernixQuests; } }
      
        /* Green With Envy */
        public override object Title { get { return 1095118; } }///1095119?

        public override object Description { get { return 1095120; } }

        public override object Refuse { get { return 1095121; } }

        public override object Uncomplete { get { return 1095122; } }

        public override object Complete { get { return 1095123; } }

        public GreenWithEnvyQuest() : base()
        {
            AddObjective(new ObtainObjective(typeof(EyeOfNavery), "Eye of Navery Night Eyes", 1));

           AddReward(new BaseReward(typeof(XLargeTreasureBag), " Extra Large treasure bag." ));//Large Bag of Treasure
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
	
	