using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Core
{
	public class Vector2
	{
		public float x;
		public float y;

		#region Declarations
		public Vector2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2(double x, double y)
		{
			this.x = (float)x;
			this.y = (float)y;
		}

		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}


		#endregion
		#region Quick Variables Vectors
		public static Vector2 Up()
		{
			return new Vector2(0, 1);
		}
		public static Vector2 Down()
		{
			return new Vector2(0, -1);
		}
		public static Vector2 Left()
		{
			return new Vector2(-1, 0);
		}
		public static Vector2 Right()
		{
			return new Vector2(1, 0);
		}
		public static Vector2 Zero()
		{
			return new Vector2(0, 0);
		}
		public static Vector2 One()
		{
			return new Vector2(1, 1);
		}
		#endregion
		#region Comparing

		public override string ToString()
		{
			return $"[ {x}, {y} ]";
		}

		public static bool operator ==(Vector2 v1, Vector2 v2)
		{
			if (v1.x == v2.x && v1.y == v2.y)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool operator !=(Vector2 v1, Vector2 v2)
		{
			if (v1.x == v2.x && v1.y == v2.y)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public override bool Equals(object obj)
		{
			var vector = obj as Vector2;
			return vector != null &&
				   x == vector.x &&
				   y == vector.y;
		}

		#endregion
	}
}
