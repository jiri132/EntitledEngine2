using EntitledEngine2.Engine.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace EntitledEngine2.Core.Shapes
{
	public class Plane : Sprite
	{
		private Vector2[] Points;
		public Vector2 Position, Scale;
		public Color color;
		public string Tag;

		public Plane(Vector2 Position, Vector2 Scale,Color color, string Tag)
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
				new Vector2(Position.x + Scale.x * -0.5f,Position.y + Scale.y * -0.5f), //Top Left Point
				new Vector2(Position.x + Scale.x * 0.5f,Position.y + Scale.y * -0.5f), //Top Right Point
				new Vector2(Position.x + Scale.x * 0.5f,Position.y + Scale.y * 0.5f), //Bottom Left Point
				new Vector2(Position.x + Scale.x * -0.5f,Position.y + Scale.y * 0.5f)  //Bottom Right Point
			};
			return _Points;
		}

		public override void UpdatePos(Vector2 v)
		{
			Position = v;
		}

		public void DestroySelf()
		{
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}
	}
}
