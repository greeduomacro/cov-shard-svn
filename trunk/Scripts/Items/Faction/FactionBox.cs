//System Created by Xeonlive
//Check Out http://xeonlive.com
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Necromancy;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Network;
using Server.ContextMenus;
using Server.Factions;
using Server.Gumps; 

namespace Server.Items 
{ 

public class FactionBox : Item 
{ 

[Constructable] 
public FactionBox() : this( null ) 
{ 
} 

[Constructable] 
public FactionBox ( string name ) : base ( 0x9AB ) 
{ 
Name = "Faction Vault"; 
Hue = 1157; 
Movable = false;
} 

public FactionBox ( Serial serial ) : base ( serial ) 
{ 
} 

public override void OnDoubleClick( Mobile from ) 
{ 
from.SendGump( new FactionItemsGump( from, this ) ); 
} 

public override void Serialize ( GenericWriter writer) 
{ 
base.Serialize ( writer ); 

writer.Write ( (int) 0); 
} 

public override void Deserialize( GenericReader reader ) 
{ 
base.Deserialize ( reader ); 

int version = reader.ReadInt(); 
} 
} 
}
