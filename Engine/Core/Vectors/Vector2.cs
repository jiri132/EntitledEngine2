using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitledEngine2.Engine.Core.Maths;

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
		public Vector2()
		{
			this.x = 0;
			this.y = 0;
		}

		#endregion
		#region Quick Variables Vectors
		public float xy => _xy();
		private float _xy()
        {
			return x + y;
        }
		public static Vector2 Up => new Vector2(0, 1);
		public static Vector2 Down => new Vector2(0, -1);
		public static Vector2 Left => new Vector2(-1,0);
		public static Vector2 Right => new Vector2(1, 0);
		public static Vector2 Zero => new Vector2(0, 0);
		public static Vector2 One => new Vector2(1, 1);
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

		public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
			return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
		public static Vector2 operator +(Vector2 v1, float v2)
		{
			return new Vector2(v1.x + v2, v1.y + v2);
		}
		public static Vector2 operator -(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x - v2.x, v1.y - v2.y);
		}
		public static Vector2 operator -(Vector2 v1, float v2)
		{
			return new Vector2(v1.x - v2, v1.y - v2);
		}
		public static Vector2 operator *(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x * v2.x, v1.y * v2.y);
		}
		public static Vector2 operator *(Vector2 v1, float v2)
		{
			return new Vector2(v1.x * v2, v1.y * v2);
		}
		public static Vector2 operator /(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x / v2.x, v1.y / v2.y);
		}
		public static Vector2 operator /(Vector2 v1, float v2)
		{
			return new Vector2(v1.x / v2, v1.y / v2);
		}
		public override bool Equals(object obj)
		{
			var vector = obj as Vector2;
			return vector != null &&
				   x == vector.x &&
				   y == vector.y;
		}

		#endregion
		#region Maths
		#region Nromalized - Distance
		public static float Distance(Vector2 p1, Vector2 p2)
		{
			float x1 = p1.x, x2 = p2.x;
			float y1 = p1.y, y2 = p2.y;
			return Mathf.sqrt(Mathf.pow((x1 - x2), 2) + Mathf.pow((y1 - y2), 2));
		}

		public static Vector2 Normalized(Vector2 a)
		{
			if (Mathf.magnitude(a) > 0)
			{
				return Mathf.Divide(a);
			}
			else
			{
				return null;
			}
		}
		#endregion
		#region Matrixes
		public static Vector2 MatMul(float[,] m, Vector2 v)
		{
			float[,] b = vecToMatrix(v);
			return matrixToVec(Matrix.MatMul(m, b));
		}
		public static Vector2 matrixToVec(float[,] m)
		{
			Vector2 v = new Vector2(0,0);
			v.x = m[0, 0];
			v.y = m[1, 0];

			return v;
		}
		public static float[,] vecToMatrix(Vector2 v)
		{
			float[,] m = new float[2, 1];
			m[0, 0] = v.x;
			m[1, 0] = v.y;
			return m;
		}
        #endregion
		#endregion
    }
}
