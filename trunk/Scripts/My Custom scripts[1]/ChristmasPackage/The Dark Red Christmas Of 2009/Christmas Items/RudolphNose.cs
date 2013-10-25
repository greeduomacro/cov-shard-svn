using System;using Server;namespace Server.Items
{
public class RudolphNose : Item
{
[Constructable]
public RudolphNose() : this( 1 )
{}
[Constructable]
public RudolphNose( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
{}
[Constructable]
public RudolphNose( int amount ) : base( 0xE73 )
{
Stackable = false;
Weight = 0.01;
Amount = amount;
Name = "Rudolph's Red Nose";
Hue = 0x26;
}
public RudolphNose( Serial serial ) : base( serial )
{}
public override void Serialize( GenericWriter writer )
{
base.Serialize( writer );
writer.Write( (int) 0 ); // version
}
public override void Deserialize( GenericReader reader )
{
base.Deserialize( reader ); int version = reader.ReadInt(); }}}
