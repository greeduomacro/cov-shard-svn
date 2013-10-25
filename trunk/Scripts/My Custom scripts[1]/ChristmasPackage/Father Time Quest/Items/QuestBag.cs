/* Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class QuestBag : Bag
	{
		public override string DefaultName
		{
			get { return "Father Time Quest"; }
		}

		[Constructable]
		public QuestBag() : this( 1 )
		{
			Movable = true;
			Hue = 1151;
		}

		[Constructable]
		public QuestBag( int amount )
		{
			DropItem(new RobeOfTheEons());
            DropItem(new StaffOfTime());
            DropItem(new LightOfTheSeasons());
            DropItem(new SandalsOfTimeWalking());
		}

        public QuestBag(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}