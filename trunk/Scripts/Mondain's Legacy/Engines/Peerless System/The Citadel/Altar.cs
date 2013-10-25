using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class TheCitadelAltar : PeerlessAltar
	{		
		public override int KeyCount{ get{ return 3; } }
		public override MasterKey MasterKey{ get{ return new TheCitadelKey(); } }
		
		public override Type[] Keys{ get{ return new Type[]
		{
			typeof( TigerClawKey ), typeof( SerpentFangKey ), typeof( DragonFlameKey )
		}; }}
		
		public override BasePeerless Boss{ get{ return new Travesty(); } }		
	
		[Constructable]
		public TheCitadelAltar() : base( 0x207E )
		{			
			BossLocation = new Point3D( 86, 1955, 0 );
			TeleportDest = new Point3D( 111, 1955, 0 );
            ExitDest = new Point3D(1355, 779, 17 );
		}
	
		public TheCitadelAltar( Serial serial ) : base( serial )
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