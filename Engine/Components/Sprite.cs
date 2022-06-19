using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitledEngine2.Core.ECS;
using EntitledEngine2.Core;

namespace EntitledEngine2.Core.Shapes
{
	public enum SpriteType { PLANE, TRIANGLE, CIRCLE }

	public abstract class Sprite : Component
	{

		public abstract SpriteType GetSpriteType();
		public abstract Vector2[] GetDrawingPoints();
		public abstract Color GetColor();
	}
}
