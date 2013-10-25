// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[DescriptionAttribute( "a cactuar corpse" )]
	public class BlueCactuar : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 15.0 ); } }
		public override Type SpellToCast{ get{ return typeof( FiftyNeedlesSpell ); } }

		[Constructable]
		public BlueCactuar() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.1, 0.2 )
		{
			Name = "a cactuar";
			Body = 266;
			BaseSoundID = 0x467;

			SetStr( 132, 147 );
			SetDex( 352, 368 );
			SetInt( 251, 272 );

			SetHits( 304, 316 );
			SetStam( 352, 368 );
			SetMana( 251, 272 );

			SetDamage( 10, 18 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Poison, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 80 );
			SetResistance( ResistanceType.Cold, 80 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 80 );

			// High skills means they are hard to hit.
			SetSkill( SkillName.Wrestling, 150 );
			SetSkill( SkillName.Tactics, 150 );
		}

		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			if ( Backpack != null )
				Backpack.Destroy();

			Effects.SendLocationEffect( Location, Map, 0x376A, 10, 1 );
			new GreenThorns().MoveToWorld( Location, Map );
			return true;
		}

		public override bool DeleteCorpseOnDeath{ get{ return true; } }

		public override int GetDeathSound()	{ return 0x57A; }
		public override int GetAttackSound() { return 0x57B; }
		public override int GetIdleSound() { return 0x57C; }
		public override int GetAngerSound() { return 0x57D; }
		public override int GetHurtSound() { return 0x57E; }
		
		public BlueCactuar( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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
