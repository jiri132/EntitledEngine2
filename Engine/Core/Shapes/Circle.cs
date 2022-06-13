using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitledEngine2.Engine.Components;

namespace EntitledEngine2.Core.Shapes
{
    public class Circle : Sprite
    {
		private Vector2[] Points;
		public Vector2 Position;
		public float Radius;
		public float Angle;
		public Color color;
		public string Tag;
		private float segments = 18;
		public Circle(Vector2 Position, float Radius, Color color, string Tag)
		{
			//Assigning the variables
			this.Position = Position;
			this.Radius = Radius;
			this.color = color;
			this.Tag = Tag;

			//getting the points
			Points = CalculatePoints();

			//register
			
			Engine.Engine.RegisterSprite(this);
		}



		public override Color GetColor()
        {
			return color;
        }

        public override Vector2[] GetDrawingPoints()
        {
			Points = CalculatePoints();

			return Points;
		}

		private Vector2[] CalculatePoints()
		{			
			List<Vector2> v = new List<Vector2>();

            for (int i = 0; i < segments; i++)
            {
				v.Add(Evaluate(i / segments));
			}

			return v.ToArray();
		}

		public Vector2 Evaluate(float t)
		{
			float angle = (float)(Math.PI*2) * t;
			float x = (float)Math.Sin(angle) * Radius + Position.x;
			float y = (float)Math.Cos(angle) * Radius + Position.y;	
			//float z = Math.Cos(angle) * Radius;
			return new Vector2(x, y);
		}
		public override void UpdatePos(Vector2 v)
		{
			Position = v;
		}
		public override void Rotate(float angle)
		{
			this.Angle = angle;
		}
		public override float GetAngle()
		{
			return Angle;
		}
		public override Vector2 GetPosition()
		{
			return Position;
		}

		public override void Dispose() => DestroySelf();
		

		public void DestroySelf()
		{
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}

       
	}
}
