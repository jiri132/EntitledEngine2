using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using EntitledEngine2.Core.Shapes;
using EntitledEngine2.Engine.Core.Shapes;

namespace EntitledEngine2.Core.Shapes
{
	public class Triangle : Sprite
	{
		private Vector2[] Points;
		public Vector2 Position, Scale;
		public Color color;
		public string Tag;

		public Triangle(Vector2 Position, Vector2 Scale,Color color, string Tag)
		{
			//Assigning the variables
			this.Position = Position;
			this.Scale = Scale;
			this.color = color;
			this.Tag = Tag;

			//getting the points
			Points = CalculatePoints();

			//register
			Engine.Engine.RegisterSprite(this);

		}

		public override Vector2[] GetDrawingPoints()
		{
			Points = CalculatePoints();
			return Points;
		}

		public override Color GetColor()
		{
			return color;
		}

		private Vector2[] CalculatePoints()
		{
			Vector2[] _Points = new Vector2[]
			{
				new Vector2(Position.x + Scale.x * 0.0f,Position.y + Scale.y * -0.5f), //Top Point
				new Vector2(Position.x + Scale.x * 0.5f,Position.y + Scale.y * 0.5f), //Left Point
				new Vector2(Position.x + Scale.x * -0.5f,Position.y + Scale.y * 0.5f)  //Right Point
			};
			return _Points;
		}

		public void DestroySelf()
		{
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}

	}
}
