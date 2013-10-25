using System;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using System.Collections;
using Server.Commands;

namespace Server.Commands
{
    public class ResMe
    {
        public static void Initialize()
        {
            CommandSystem.Register("ResMe", AccessLevel.Player, new CommandEventHandler(ResMe_OnCommand));
        }

        [Usage("ResMe")]
        [Description("Resme for Player. You must have a ressurection stone in your bankbox.")]

        public static void ResMe_OnCommand(CommandEventArgs e)
        {
            Container bank = e.Mobile.BankBox;

            if (e.Mobile.Alive)
            {
                e.Mobile.SendMessage("You are not dead, you don't need a res!");
                return;
            }

            else if (bank != null && bank.ConsumeTotal(typeof(ResStone), 1))
            {
                e.Mobile.PlaySound(0x214);
                e.Mobile.FixedEffect(0x376A, 10, 16);
                e.Mobile.Resurrect();
                e.Mobile.SendMessage("You feel your life coming back in your body...");
            }
            else
            {
                e.Mobile.SendMessage("You must have a ressurection stone in your bankbox to ressurect yourself!");
            }
        }
    }
}
	
    

			
   	
   
