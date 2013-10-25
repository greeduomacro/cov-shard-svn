using System;using Server;namespace Server.Items
{
public class SantasHat : Item
{
[Constructable]
public SantasHat() : this( 1 )
{}
[Constructable]
public SantasHat( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
{}
[Constructable]
public SantasHat( int amount ) : base( 0x171C )
{
Stackable = false;
Weight = 0.01;
Amount = amount;
Name = "SantasHat";
Hue = 0x485;
}
public SantasHat( Serial serial ) : base( serial )
{}
public override void Serialize( GenericWriter writer )
{
base.Serialize( writer );
writer.Write( (int) 0 ); // version
}
public override void Deserialize( GenericReader reader )
{
base.Deserialize( reader ); int version = reader.ReadInt(); }}}
