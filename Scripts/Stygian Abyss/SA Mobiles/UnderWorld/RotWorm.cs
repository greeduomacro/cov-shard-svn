using System;
using Server.Items;
using Server.Targeting;
using System.Collections;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a rotworm corpse" )]
	public class RotWorm : BaseCreature
	{
		[Constructable]
		public RotWorm() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Rotworm";
			Body = 732;

			SetStr( 222, 227 );
			SetDex( 80 );
			SetInt( 16, 20 );

			SetHits( 204, 247 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );
			
			SetResistance( ResistanceType.Physical, 36, 43 );
			SetResistance( ResistanceType.Fire, 30, 39 );
			SetResistance( ResistanceType.Cold, 28, 35 );
			SetResistance( ResistanceType.Poison, 65, 75 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.MagicResist, 25 );
			SetSkill( SkillName.Tactics, 25 );
			SetSkill( SkillName.Wrestling, 50 );

            AddItem(new Gold(30));
            PackItem(new RawRotWormMeat(2));

            if (Utility.RandomDouble() < 0.10)
                
            PackItem(new ArielHavenWritofMembership());
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int GetIdleSound() { return 1503; } 
		public override int GetAngerSound() { return 1500; } 
		public override int GetHurtSound() { return 1502; } 
		public override int GetDeathSound()	{ return 1501; }

		public RotWorm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}