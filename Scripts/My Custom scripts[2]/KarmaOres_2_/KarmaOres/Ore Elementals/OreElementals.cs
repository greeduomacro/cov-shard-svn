using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ore elemental corpse" )]
	public class SilverElemental : BaseCreature
	{
	
		[Constructable]
		public SilverElemental() : this( 15 )
		{
		}
		
		[Constructable]
		public SilverElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a silver elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x47E;

			SetStr( 180, 200 );
			SetDex( 180, 200 );
			SetInt( 130, 140 );

			SetHits( 180, 200 );

			SetDamage( 29, 33 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 32;

			PackItem( new SilverOre( oreAmount ) );
			
			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new RunicSil() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public SilverElemental( Serial serial ) : base( serial )
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

    [CorpseName("an ore elemental corpse")]
    public class JadeElemental : BaseCreature
    {

        [Constructable]
        public JadeElemental()
            : this(15)
        {
        }

        [Constructable]
        public JadeElemental(int oreAmount)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a jade elemental";
            Body = 107;
            BaseSoundID = 268;
            Hue = 0x48C;

            SetStr(190, 210);
            SetDex(190, 210);
            SetInt(140, 150);

            SetHits(190, 210);

            SetDamage(32, 36);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 40);
            SetResistance(ResistanceType.Fire, 40, 50);
            SetResistance(ResistanceType.Cold, 40, 50);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.MagicResist, 50.1, 95.0);
            SetSkill(SkillName.Tactics, 60.1, 100.0);
            SetSkill(SkillName.Wrestling, 60.1, 100.0);

            Fame = 3500;
            Karma = -3500;

            VirtualArmor = 32;

            PackItem(new JadeOre(oreAmount));

            if (0.10 > Utility.RandomDouble())
                PackItem(new RunicJ());

        }

        public override bool AutoDispel { get { return true; } }

        public JadeElemental(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    	[CorpseName( "an ore elemental corpse" )]
	public class MoonstoneElemental : BaseCreature
	{
	
		[Constructable]
		public MoonstoneElemental() : this( 15 )
		{
		}
		
		[Constructable]
		public MoonstoneElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a moonstone elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x484;

			SetStr( 190, 210 );
			SetDex( 190, 210 );
			SetInt( 140, 150 );

			SetHits( 190, 210 );

			SetDamage( 32, 36 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 32;

			PackItem( new MoonstoneOre( oreAmount ) );
			
			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new RunicMo() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public MoonstoneElemental( Serial serial ) : base( serial )
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
    
    	[CorpseName( "an ore elemental corpse" )]
	public class SunstoneElemental : BaseCreature
	{
	
		[Constructable]
		public SunstoneElemental() : this( 15 )
		{
		}
		
		[Constructable]
		public SunstoneElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sunstone elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x550;

			SetStr( 190, 210 );
			SetDex( 190, 210 );
			SetInt( 140, 150 );

			SetHits( 190, 210 );

			SetDamage( 32, 36 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 32;

			PackItem( new SunstoneOre( oreAmount ) );
			
			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new RunicSu() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public SunstoneElemental( Serial serial ) : base( serial )
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