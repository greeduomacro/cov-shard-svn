using System;
using Server;

namespace Server.Items
{
	public class PresentBomb1 : BaseExplosionPotion
	{
		public override int MinDamage { get { return 10; } }
		public override int MaxDamage { get { return 30; } }

		[Constructable]
		public PresentBomb1() : base( PotionEffect.ExplosionGreater )
		{
			Stackable = true;
			Name = "A Present From Santa";
			ItemID = 0x232B;
			Hue = 1153;
		}

		public PresentBomb1( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PresentBomb2 : BaseExplosionPotion
	{
		public override int MinDamage { get { return 20; } }
		public override int MaxDamage { get { return 45; } }

		[Constructable]
		public PresentBomb2() : base( PotionEffect.ExplosionGreater )
		{
			Stackable = true;
			Name = "A Present From Santa";
			ItemID = 0x232B;
			Hue = 2;
		}

		public PresentBomb2( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PresentBomb3 : BaseExplosionPotion
	{
		public override int MinDamage { get { return 40; } }
		public override int MaxDamage { get { return 65; } }

		[Constructable]
		public PresentBomb3() : base( PotionEffect.ExplosionGreater )
		{
			Stackable = true;
			Name = "A Present From Santa";
			ItemID = 0x232B;
			Hue = 1157;
		}

		public PresentBomb3( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
}