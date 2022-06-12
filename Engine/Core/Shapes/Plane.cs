using EntitledEngine2.Engine.Core.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace EntitledEngine2.Core.Shapes
{
	public class Plane : Sprite
	{

		public Vector2 position, size;

		public Plane(Vector2 size, Vector2 position)
		{

		}

		public override Vector2[] GetDrawingPoints()
		{
			throw new NotImplementedException();
		}
	}
}
