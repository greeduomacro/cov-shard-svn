/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 1/21/2008
 * Time: 8:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;

namespace Server.Items
{

	public class BookOfTruth : Item
	{
		[Constructable]
		public BookOfTruth() : base( 0x1C11 )
		{
			Weight = 1.0;
		}

		public BookOfTruth( Serial serial ) : base( serial )
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
