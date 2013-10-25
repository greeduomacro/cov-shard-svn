using System;using System.Collections;using System.Collections.Generic;using Server.Items;using Server.Targeting;using Server.ContextMenus;using Server.Gumps;using Server.Misc;using Server.Network;using Server.Spells;namespace Server.Mobiles
{[CorpseName( "Rudolph's Corpse" )]public class RudolphQuest : Mobile{public virtual bool IsInvulnerable{ get{ return true; } }
[Constructable]public RudolphQuest(){
//////////////////////////////name
Name = "Rudolph";
/////////////////////////////////title
Title = "The Red Noseless Reighndeer";
////////sex
Body = 0xEA;
//////skincolor
Hue = 0x0;
////////haircolor
int hairHue = 0x47E;
////////clothing and other apperance
AddItem( new ShortHair( hairHue ) );
Blessed = true;CantWalk = true;}
public RudolphQuest( Serial serial ) : base( serial ){}
public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
{ base.GetContextMenuEntries( from, list ); list.Add( new RudolphQuestEntry( from, this ) ); } 
public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( (int) 0 );}
public override void Deserialize( GenericReader reader ){base.Deserialize( reader );int version = reader.ReadInt();}
public class RudolphQuestEntry : ContextMenuEntry{private Mobile m_Mobile;private Mobile m_Giver;
public RudolphQuestEntry( Mobile from, Mobile giver ) : base( 6146, 3 ){m_Mobile = from;m_Giver = giver;}
public override void OnClick(){if( !( m_Mobile is PlayerMobile ) )return;
PlayerMobile mobile = (PlayerMobile) m_Mobile;{
///////////////////////////////////////////////// gumpname
if ( ! mobile.HasGump( typeof( RudolphGump ) ) ){
mobile.SendGump( new RudolphGump( mobile ));}}}}
public override bool OnDragDrop( Mobile from, Item dropped ){               Mobile m = from;PlayerMobile mobile = m as PlayerMobile;
if ( mobile != null){
/////////////////////////////////////////////////////////// item to be dropped
if( dropped is RudolphNose ){if(dropped.Amount!=1)
{this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", mobile.NetState );return false;}
dropped.Delete(); 
///////////////the reward
mobile.AddToBackpack( new Gold( 1000 ) );

////////////////////////////////////////////////////////// thanksmessage
this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Thank you for Finding my Nose, and helping save Christmas!", mobile.NetState );
return true;}else if ( dropped is Whip){this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );return false;}else{this.PrivateOverheadMessage( MessageType.Regular, 1153, false,"I have no need for this...", mobile.NetState );}}return false;}}}
