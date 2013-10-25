using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class SeekerOfTruthQuest : BaseQuest
    {
        /* Seeker Of Truth */
        public override object Title { get { return 1077425; } }

        /*The Book of Truth has been stolen, and we need your help recovering it. I must warn you. Dark entities from beyond our world have replicated it. Monsters in the dungeons guard the books, and only one of the books is the real Book of Truth. If you can find 50 of these books, we can inspect each one and hopefully one of them will be the real Book of Truth. We must recover the Book of Truth so we can stop the dark entities from destroying this reality. Find 50 of these books, and we will reward you with a virtuous prize.*/
        public override object Description { get { return 1077426; } }

        /* *frowns* I understand. It is a perilous task. Please come back to me if 
         * you change your mind. We could really use your help. */
        public override object Refuse { get { return 1077427; } }

        /* You haven't returned enough books yet. Please gather more books. */
        public override object Uncomplete { get { return 1077428; } }

        /* Thank You, Brave Adventurer! We really appreciate your help! As promised, I have a reward for you. */
        public override object Complete { get { return 1077454; } }

        public SeekerOfTruthQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(BookOfTruth), "Book of Truth", 50, 0x1C11));

            AddReward(new BaseReward(typeof(MenzzabaaneasTreasureBox), 1072584 ));
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

    public class Menzzabaanea : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] 
			{ 
				typeof( SeekerOfTruthQuest )
			};
            }
        }

        [Constructable]
        public Menzzabaanea()
            : base("Menzzabaanea", "The Seeker of Truth")
        {
        }
        public Menzzabaanea(Serial serial)
            : base(serial)
        {
        }
        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = true;
            CantWalk = true;
            Race = Race.Elf;

            Hue = 0x83F6;
            HairItemID = 0x203c;
            HairHue = 1118;
        }

        public override void InitOutfit()
        {
            AddItem(new FancyDress(2210));
            AddItem(new Sandals(2210));
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

    public class MenzzabaaneasTreasureBox : RewardBox
	{	
		[Constructable]
		public MenzzabaaneasTreasureBox() : base()
        {
            Name = "Menzzabaanea's Reward Box";

            if (Utility.Random(100) < 100)
                switch (Utility.Random(8))
                {
                    case 0: AddItem( new HonestyGorget() );  break;
                    case 1: AddItem(new ValorGauntlets()); break;
                    case 2: AddItem(new SpiritualityHelm()); break;
                    case 3: AddItem(new HonorLegs()); break;
                    case 4: AddItem(new JusticeBreastplate()); break;
                    case 5: AddItem(new SacrificeSollerets ()); break;
                    case 6: AddItem(new CompassionArms()); break;
                    case 7: AddItem(new HumilityCloak()); break;

                }											
		}
		
		public MenzzabaaneasTreasureBox( Serial serial ) : base( serial )
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







