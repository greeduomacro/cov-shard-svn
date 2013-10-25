//Scripted by Mimi & Kila Ventru

using System;
namespace Server.Items
{
	public class GrandmasEarrings : BaseEarrings
	{
		public override int ArtifactRarity{ get{ return 2; } }

		[Constructable]
		public GrandmasEarrings() : base( 0x1F07 )
		{
			Name = "Grandmas Earrings";
			Hue = 32;
			Attributes.WeaponDamage = 5;
			Attributes.ReflectPhysical = 5;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 2;
			Attributes.RegenStam = 5;
			Attributes.RegenMana = 5;
			Attributes.RegenHits = 5;
			Attributes.NightSight = 1;
		}

		public GrandmasEarrings( Serial serial ) : base( serial )
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