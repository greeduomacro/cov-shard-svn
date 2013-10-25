using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DolphinRugEastAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new DolphinRugEastAddonDeed(); } }

		[ Constructable ]
		public DolphinRugEastAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 14556 ), 2, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14555 ), 2, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14554 ), 2, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14553 ), 2, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14559 ), 3, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14558 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14557 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14560 ), 3, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14563 ), 4, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14562 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14561 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14564 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14567 ), 5, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14566 ), 5, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14565 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14568 ), 5, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14571 ), 6, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14574 ), 6, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14569 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14572 ), 6, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14575 ), 7, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14566 ), 7, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14573 ), 7, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14576 ), 7, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14579 ), 8, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14578 ), 8, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14577 ), 8, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14580 ), 8, 5, 0 );


		}

		public DolphinRugEastAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class DolphinRugEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new DolphinRugEastAddon(); } }

		[Constructable]
		public DolphinRugEastAddonDeed()
		{
            Name = "Dolphin Rug East Deed";
		}

		public DolphinRugEastAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class DolphinRugSouthAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new DolphinRugSouthAddonDeed(); } }

		[ Constructable ]
		public DolphinRugSouthAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 14581 ), 1, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14588 ), 1, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14592 ), 1, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14582 ), 2, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14585 ), 2, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14589 ), 2, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14579 ), 3, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14583 ), 3, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14586 ), 3, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14590 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14584 ), 4, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14587 ), 4, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14591 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14596 ), 1, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14600 ), 1, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14604 ), 1, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14608 ), 1, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14593 ), 2, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14597 ), 2, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14601 ), 2, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14605 ), 2, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14594 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14598 ), 3, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14598 ), 3, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14606 ), 3, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14595 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14599 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14603 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14607 ), 4, 7, 0 );


		}

		public DolphinRugSouthAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class DolphinRugSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new DolphinRugSouthAddon(); } }

		[Constructable]
		public DolphinRugSouthAddonDeed()
		{
            Name = "Dolphin Rug South Deed";
		}

		public DolphinRugSouthAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class RoseRugEastAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new RoseRugEastAddonDeed(); } }

		[ Constructable ]
		public RoseRugEastAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 14500 ), 2, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14499 ), 2, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14498 ), 2, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14497 ), 2, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14504 ), 3, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14502 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14501 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14503 ), 3, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14508 ), 4, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14506 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14505 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14507 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14512 ), 5, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14510 ), 5, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14509 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14511 ), 5, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14516 ), 6, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14514 ), 6, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14513 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14515 ), 6, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14520 ), 7, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14501 ), 7, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14517 ), 7, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14519 ), 7, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14524 ), 8, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14522 ), 8, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14521 ), 8, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14523 ), 8, 5, 0 );

		}

		public RoseRugEastAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class RoseRugEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new RoseRugEastAddon(); } }

		[Constructable]
		public RoseRugEastAddonDeed()
		{
            Name = "Rose Rug East Deed";
		}

		public RoseRugEastAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class RoseRugSouthAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new RoseRugSouthAddonDeed(); } }

		[ Constructable ]
		public RoseRugSouthAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 14552 ), 2, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14548 ), 2, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14544 ), 2, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14540 ), 2, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14536 ), 2, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14532 ), 2, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14528 ), 2, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 14550 ), 3, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14546 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14542 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14538 ), 3, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14534 ), 3, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14530 ), 3, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14527 ), 3, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 14549 ), 4, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14545 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14541 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14537 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14533 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14529 ), 4, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14526 ), 4, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 14551 ), 5, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14547 ), 5, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14543 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14539 ), 5, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14535 ), 5, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14531 ), 5, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14525 ), 5, 8, 0 );

		}

		public RoseRugSouthAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class RoseRugSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new RoseRugSouthAddon(); } }

		[Constructable]
		public RoseRugSouthAddonDeed()
		{
            Name = "Rose Rug South Deed";
		}

		public RoseRugSouthAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class SkullRugEastAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new SkullRugEastAddonDeed(); } }

		[ Constructable ]
		public SkullRugEastAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 14444 ), 1, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14443 ), 1, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14442 ), 1, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14441 ), 1, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14447 ), 2, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14446 ), 2, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14461 ), 2, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14448 ), 2, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14451 ), 3, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14450 ), 3, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14449 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14452 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14455 ), 4, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14454 ), 4, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14453 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14456 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14459 ), 5, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14458 ), 5, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14457 ), 5, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14460 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14463 ), 6, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14462 ), 6, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14490 ), 6, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14464 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14467 ), 7, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14466 ), 7, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14465 ), 7, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14469 ), 7, 4, 0 );

		}

		public SkullRugEastAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class SkullRugEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new SkullRugEastAddon(); } }

		[Constructable]
		public SkullRugEastAddonDeed()
		{
            Name = "Skull Rug East Deed";
		}

		public SkullRugEastAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class SkullRugSouthAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new SkullRugSouthAddonDeed(); } }

		[ Constructable ]
		public SkullRugSouthAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 14495 ), 1, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14491 ), 1, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14487 ), 1, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14483 ), 1, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14479 ), 1, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14475 ), 1, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14472 ), 1, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14494 ), 2, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14490 ), 2, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14486 ), 2, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14482 ), 2, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14478 ), 2, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14474 ), 2, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14448 ), 2, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14493 ), 3, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14489 ), 3, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14485 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14481 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14477 ), 3, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14489 ), 3, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14464 ), 3, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 14496 ), 4, 1, 0 );
			AddComponent( new HuedAddonComponent( 0, 14492 ), 4, 2, 0 );
			AddComponent( new HuedAddonComponent( 0, 14488 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 14484 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 14480 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 14476 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 14468 ), 4, 7, 0 );

		}

		public SkullRugSouthAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class SkullRugSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new SkullRugSouthAddon(); } }

		[Constructable]
		public SkullRugSouthAddonDeed()
		{
            Name = "Skull Rug South Deed";
		}

		public SkullRugSouthAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    public class SMRoseRugSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new SMRoseRugSouthAddonDeed(); } }

        [Constructable]
        public SMRoseRugSouthAddon()
        {
            AddComponent(new HuedAddonComponent(0, 18249), 1, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18253), 2, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18245), 1, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18251), 0, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18255), 1, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18250), 2, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18256), 2, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18254), 0, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18248), 0, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18246), 1, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18247), 2, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18259), 0, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18258), 1, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18252), 2, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18257), 0, 5, 0);

        }

        public SMRoseRugSouthAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMRoseRugSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new SMRoseRugSouthAddon(); } }

        [Constructable]
        public SMRoseRugSouthAddonDeed()
        {
            Name = "Small Rose Rug (South) Deed";
        }

        public SMRoseRugSouthAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMRoseRugEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new SMRoseRugEastAddonDeed(); } }

        [Constructable]
        public SMRoseRugEastAddon()
        {
            AddComponent(new HuedAddonComponent(0, 18260), 4, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18270), 5, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18264), 3, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18266), 4, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18269), 5, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18271), 5, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18268), 4, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18265), 3, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18263), 3, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18261), 6, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18272), 2, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18262), 6, 1, 0);
            AddComponent(new HuedAddonComponent(0, 18267), 6, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18273), 2, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18274), 2, 1, 0);


        }

        public SMRoseRugEastAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMRoseRugEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new SMRoseRugEastAddon(); } }

        [Constructable]
        public SMRoseRugEastAddonDeed()
        {
        }

        public SMRoseRugEastAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMSkullRugEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new SMSkullRugEastAddonDeed(); } }

        [Constructable]
        public SMSkullRugEastAddon()
        {
            AddComponent(new HuedAddonComponent(0, 18183), 4, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18184), 2, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18191), 4, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18193), 4, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18188), 3, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18185), 2, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18187), 3, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18195), 3, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18196), 2, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18197), 5, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18189), 5, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18192), 5, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18190), 6, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18194), 6, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18186), 6, 3, 0);


        }

        public SMSkullRugEastAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMSkullRugEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new SMSkullRugEastAddon(); } }

        [Constructable]
        public SMSkullRugEastAddonDeed()
        {
        }

        public SMSkullRugEastAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMSkullRugSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new SMSkullRugSouthAddonDeed(); } }

        [Constructable]
        public SMSkullRugSouthAddon()
        {
            AddComponent(new HuedAddonComponent(0, 18210), 2, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18211), 1, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18236), 3, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18237), 2, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18238), 1, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18239), 3, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18209), 3, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18198), 3, 6, 0);
            AddComponent(new HuedAddonComponent(0, 18199), 2, 6, 0);
            AddComponent(new HuedAddonComponent(0, 18200), 1, 6, 0);
            AddComponent(new HuedAddonComponent(0, 18240), 2, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18241), 1, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18244), 1, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18243), 2, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18242), 3, 2, 0);


        }

        public SMSkullRugSouthAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMSkullRugSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new SMSkullRugSouthAddon(); } }

        [Constructable]
        public SMSkullRugSouthAddonDeed()
        {
        }

        public SMSkullRugSouthAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMDolphinRugEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new SMDolphinRugEastAddonDeed(); } }

        [Constructable]
        public SMDolphinRugEastAddon()
        {
            AddComponent(new HuedAddonComponent(0, 18294), 4, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18295), 4, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18296), 5, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18293), 4, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18290), 5, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18299), 6, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18291), 3, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18300), 6, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18298), 5, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18390), 6, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18391), 3, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18392), 3, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18297), 7, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18292), 7, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18393), 7, 2, 0);


        }

        public SMDolphinRugEastAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMDolphinRugEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new SMDolphinRugEastAddon(); } }

        [Constructable]
        public SMDolphinRugEastAddonDeed()
        {
        }

        public SMDolphinRugEastAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMDolphingRugSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new SMDolphingRugSouthAddonDeed(); } }

        [Constructable]
        public SMDolphingRugSouthAddon()
        {
            AddComponent(new HuedAddonComponent(0, 18279), 3, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18280), 4, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18281), 2, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18278), 2, 3, 0);
            AddComponent(new HuedAddonComponent(0, 18275), 3, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18282), 2, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18277), 3, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18285), 3, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18287), 2, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18286), 4, 2, 0);
            AddComponent(new HuedAddonComponent(0, 18288), 3, 6, 0);
            AddComponent(new HuedAddonComponent(0, 18284), 2, 6, 0);
            AddComponent(new HuedAddonComponent(0, 18283), 4, 4, 0);
            AddComponent(new HuedAddonComponent(0, 18276), 4, 5, 0);
            AddComponent(new HuedAddonComponent(0, 18289), 4, 6, 0);


        }

        public SMDolphingRugSouthAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SMDolphingRugSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new SMDolphingRugSouthAddon(); } }

        [Constructable]
        public SMDolphingRugSouthAddonDeed()
        {
        }

        public SMDolphingRugSouthAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}