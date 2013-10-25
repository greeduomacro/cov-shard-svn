// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a bomb corpse" )]
	public class BlueBomb : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 7.0 ); } }
		public override Type SpellToCast{ get{ return typeof( BlowUpSpell ); } }

		[Constructable]
		public BlueBomb() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bomb";
			Body = 22;
			Hue = 1161;
			BaseSoundID = 377;

			SetStr( 116, 145 );
			SetDex( 106, 125 );
			SetInt( 161, 185 );

			SetHits( 158, 175 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 40, 45 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, -10, 0 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.Magery, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 56;

			PackItem( new Nightshade( 4 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_LastCast && Hits < (HitsMax/4) )
			{
				BlueSpellInfo.UseBluePower( this, SpellToCast );
				m_LastCast = DateTime.Now + CastDelay;
			}

			base.OnActionCombat();
		}

		public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

		public BlueBomb( Serial serial ) : base( serial )
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