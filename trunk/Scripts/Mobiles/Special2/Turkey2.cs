using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a turkey corpse" )]
	public class Turkey2 : BaseCreature
	{
		[Constructable]
		public Turkey2() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a turkey";
			Body = 1026;
			BaseSoundID = 0x6E;
			//Hue = 0x457;

			SetStr( 15 );
			SetDex( 20 );
			SetInt( 5 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 1, 5 );

			SetSkill( SkillName.MagicResist, 4.0 );
			SetSkill( SkillName.Tactics, 7.0 );
			SetSkill( SkillName.Wrestling, 10.0 );

			Fame = 200;
			Karma = 0;

			VirtualArmor = 2;

			//Tamable = true;
			//ControlSlots = 1;
			//MinTameSkill = 5.0;

            PackItem(new TurkeyHock());
		}

		/*public override void OnCarve( Mobile from, Corpse corpse )
		{
			base.OnCarve( from, corpse );

			corpse.DropItem( new TurkeyHock( 1 ) );
		}*/

		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

		public override int Feathers{ get{ return 25; } }

		public Turkey2(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}