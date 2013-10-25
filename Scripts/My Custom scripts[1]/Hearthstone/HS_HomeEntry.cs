using System;
using Server;
using Server.Mobiles;
using Server.Regions;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		[PropertyObject]
		public sealed class HomeEntry
		{
			private Hearthstone _Link;

			private string _Name;
			private Point3D _Location;
			private Map _Map;

			[CommandProperty(AccessLevel.GameMaster)]
			public Hearthstone Link { get { return _Link; } set { } }

			[CommandProperty(AccessLevel.GameMaster)]
			public string Name
			{
				get { return _Name; }
				set
				{
					_Name = value;
					_Link.InvalidateProperties();
				}
			}

			[CommandProperty(AccessLevel.GameMaster)]
			public Point3D Location
			{
				get { return _Location; }
				set
				{
					_Location = value;
					_Link.InvalidateProperties();
				}
			}

			[CommandProperty(AccessLevel.GameMaster)]
			public Map Map
			{
				get { return _Map; }
				set
				{
					_Map = value;
					_Link.InvalidateProperties();
				}
			}

			[CommandProperty(AccessLevel.GameMaster)]
			public bool Valid { get { return IsValid(); } }

			[CommandProperty(AccessLevel.GameMaster)]
			public Region Region { get { return GetRegion(); } }

			public HomeEntry(Hearthstone link)
				: this(link, Point3D.Zero, Map.Internal)
			{ }

			public HomeEntry(Hearthstone link, Point3D location, Map map)
			{
				_Link = link;

				Set(location, map);
			}

			public void Set(Mobile m)
			{
				string name = "Unknown";

				Region r = GetRegion(m);

				if (r != null && !String.IsNullOrEmpty(r.Name))
					name = r.Name;

				Set(m.Location, m.Map, name);
			}

			public void Set(Point3D location, Map map)
			{
				string name = "Unknown";

				Region r = GetRegion(location, map);

				if (r != null && !String.IsNullOrEmpty(r.Name))
					name = r.Name;

				Set(location, map, name);
			}

			public void Set(Point3D location, Map map, string name)
			{
				_Location = location;
				_Map = map;
				_Name = name;

				_Link.InvalidateProperties();
			}

			public bool IsValid()
			{
				if (_Link == null || _Link.Deleted)
					return false;

				if (_Location == Point3D.Zero || _Map == Map.Internal)
					return false;

				if (GetRegion() == null)
					return false;

				return true;
			}

			public Region GetRegion()
			{
				Region reg = Region.Find(_Location, _Map);

				return GetTopRegion(reg);
			}

			public Region GetRegion(Mobile m)
			{
				return GetTopRegion(m.Region);
			}

			public Region GetRegion(Point3D location, Map map)
			{
				Region reg = Region.Find(location, map);

				return GetTopRegion(reg);
			}

			public Region GetTopRegion(Region reg)
			{
				if (!reg.IsDefault && reg.Parent != null)
				{
					Region parent = reg.Parent;

					while (parent != null)
					{
						reg = parent;
						parent = reg.Parent;
					}
				}

				return reg;
			}

			public void Serialize(GenericWriter writer)
			{
				writer.Write(0);

				writer.Write((Item)_Link);
				writer.Write((string)_Name);
				writer.Write((Point3D)_Location);
				writer.Write((Map)_Map);
			}

			public void Deserialize(GenericReader reader)
			{
				int version = reader.ReadInt();

				_Link = (Hearthstone)reader.ReadItem();
				_Name = reader.ReadString();
				_Location = reader.ReadPoint3D();
				_Map = reader.ReadMap();
			}

			public override string ToString()
			{
				return String.Format("{0} {1}, {2}", _Name, _Location, _Map.Name);
			}
		}
	}
}