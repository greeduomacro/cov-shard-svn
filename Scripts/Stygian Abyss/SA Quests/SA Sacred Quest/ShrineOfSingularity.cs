using Server;
using System;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Commands;
using Server.Gumps;

namespace Server.Items
{
	public class ShrineOfSingularity : Item
	{
		[Constructable]
		public ShrineOfSingularity() : base( 0x48A8)
		{
			Movable = false;
			Name = "ShrineOfSingularity";	
		}
		
		public ShrineOfSingularity( Serial serial ) : base( serial )
		{
		}

        public override bool HandlesOnSpeech { get { return true; } }

		public override void OnSpeech(SpeechEventArgs e)
		{

            Item am = e.Mobile.Backpack.FindItemByType(typeof(AbyssMarker));

            if (!e.Handled && e.Mobile.InRange(this.Location, 2))
			{

                    if (am != null)// && e != null)
                    {
                        e.Mobile.SendLocalizedMessage(1112697); 
                        e.Mobile.PlaySound(0xF9);
                       
                    }
					else 
					{
						  if (e.Speech.ToLower() == "unorus")
							  e.Handled = true;
                              e.Mobile.SendGump(new SQGump(e.Mobile));
			                  e.Mobile.PlaySound(0xF9);
								
							}
						}
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