using System;
using Server;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
    public class RecluseStingAntidotePotion : BasePotion
    {
        //public override TimeSpan DecayTime { get { return TimeSpan.FromSeconds(120.0); } }

        [Constructable]
        public RecluseStingAntidotePotion()
            : base(0xF06, PotionEffect.RecluseStingAntidote)
        {
            Name = "Recluse Sting Antidote";
            Hue = 771;
        }

        public RecluseStingAntidotePotion(Serial serial)
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

        public override void Drink(Mobile from)
        {
            Item am = from.Backpack.FindItemByType(typeof(RecluseStingMarker));
            if (am != null)
            {
                from.BodyMod = 0;
                from.Hue = -1;
                from.YellowHealthbar = false;

                from.PlaySound(0xF6);
                from.PlaySound(0x1F7);
                from.FixedParticles(0x3709, 1, 30, 9963, 13, 3, EffectLayer.Head);

                    BasePotion.PlayDrinkEffect(from);

                    this.Consume();
                    from.SendGump(new RecluseAntidoteGump());
                    //am.Delete();
                }
                else if (am == null )
                {
                    from.SendGump(new RecluseCuredGump());
                    
                }
            }
        }
    }







