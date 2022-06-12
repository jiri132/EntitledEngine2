using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core.Shapes
{
	public abstract class Sprite
	{
		public abstract Vector2[] GetDrawingPoints();
		public abstract Color GetColor();
	}
}
