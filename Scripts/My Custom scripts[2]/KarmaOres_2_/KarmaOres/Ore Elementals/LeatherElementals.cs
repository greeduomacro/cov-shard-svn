using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an daemon leather elemental corpse" )]
	public class DaemonLeatherElemental : BaseCreature
	{
	
		[Constructable]
		public DaemonLeatherElemental() : this( 15 )
		{
		}
		
		[Constructable]
		public DaemonLeatherElemental( int leatherAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Daemon leather elemental";
			Body = 0x65;
			BaseSoundID = 357;
			Hue = 987;

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

			PackItem( new DaemonLeather( leatherAmount ) );
			
			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new RunicDa() );
				
		}

		public override bool AutoDispel{ get{ return true; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Regular; } }

		public DaemonLeatherElemental( Serial serial ) : base( serial )
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
    
    [CorpseName( "a Dragon leather elemental corpse" )]
	public class DragonLeatherElemental : BaseCreature
	{
	
		[Constructable]
		public DragonLeatherElemental() : this( 15 )
		{
		}
		
		[Constructable]
		public DragonLeatherElemental( int leatherAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Dragon leather elemental";
			Body = 0x65;
			BaseSoundID = 362;
			Hue = 1160;

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

			PackItem( new DragonLeather( leatherAmount ) );
			
			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new RunicDr() );
				
		}

		public override bool AutoDispel{ get{ return true; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Regular; } }

		public DragonLeatherElemental( Serial serial ) : base( serial )
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

    
    /*[CorpseName( "an ore elemental corpse" )]
	public class MythrilElemental : BaseCreature
	{
	
		[Constructable]
		public MythrilElemental() : this( 2 )
		{
		}
		
		[Constructable]
		public MythrilElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mythril elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x486;

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

			PackItem( new MythrilOre( oreAmount ) );
			
			if ( 0.5 > Utility.RandomDouble() )
				PackItem( new RunicM() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public MythrilElemental( Serial serial ) : base( serial )
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
	public class ObsidianElemental : BaseCreature
	{
	
		[Constructable]
		public ObsidianElemental() : this( 2 )
		{
		}
		
		[Constructable]
		public ObsidianElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an obsidian elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x455;

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

			PackItem( new ObsidianOre( oreAmount ) );
			
			if ( 0.5 > Utility.RandomDouble() )
				PackItem( new RunicO() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public ObsidianElemental( Serial serial ) : base( serial )
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
	public class JadeElemental : BaseCreature
	{
	
		[Constructable]
		public JadeElemental() : this( 2 )
		{
		}
		
		[Constructable]
		public JadeElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a jade elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x48C;

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

			PackItem( new JadeOre( oreAmount ) );
			
			if ( 0.5 > Utility.RandomDouble() )
				PackItem( new RunicJ() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public JadeElemental( Serial serial ) : base( serial )
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
	public class MoonstoneElemental : BaseCreature
	{
	
		[Constructable]
		public MoonstoneElemental() : this( 2 )
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
			
			if ( 0.5 > Utility.RandomDouble() )
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
		public SunstoneElemental() : this( 2 )
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
			
			if ( 0.5 > Utility.RandomDouble() )
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
    
    	[CorpseName( "an ore elemental corpse" )]
	public class BloodstoneElemental : BaseCreature
	{
	
		[Constructable]
		public BloodstoneElemental() : this( 2 )
		{
		}
		
		[Constructable]
		public BloodstoneElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bloodstone elemental";
			Body = 107;
			BaseSoundID = 268;
			Hue = 0x485;

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

			PackItem( new BloodstoneOre( oreAmount ) );
			
			if ( 0.5 > Utility.RandomDouble() )
				PackItem( new RunicBl() );
				
		}

		public override bool AutoDispel{ get{ return true; } }

		public BloodstoneElemental( Serial serial ) : base( serial )
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
	}*/
}