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
	public abstract class Sprite : Component
	{
		public abstract void UpdatePos(Vector2 v);
		public abstract void Rotate(float angle);
		public abstract Vector2[] GetDrawingPoints();
		public abstract Color GetColor();
		public abstract float GetAngle();
		public abstract Vector2 GetPosition();
		public abstract void Dispose();
	}
}
