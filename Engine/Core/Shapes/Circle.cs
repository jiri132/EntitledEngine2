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
		//public Vector2 Position;
		//public float Radius;
		public Color color;
		public string Tag;
		private float segments = 12; // low quality circle = 16 high quality circle = 36 16k circle = 78 
		public SpriteType TYPE { private set; get; } = SpriteType.CIRCLE;
		public Circle(/*Vector2 Position,float Radius,*/ Color color, string Tag)
		{
			//Assigning the variables
			//this.Position = Position;
			//this.Radius = Radius;
			this.color = color;
			this.Tag = Tag;

			//getting the points
			Points = CalculatePoints();

			//register
			
/*			Engine.Engine.RegisterSprite(this);*/
		}



		public override Color GetColor()
        {
			return color;
        }
        public override SpriteType GetSpriteType()
        {
			return TYPE;
        }

        public override Vector2[] GetDrawingPoints()
        {
			Points = CalculatePoints();

			return Points;
		}

        public override void SetColor(Color color)
        {
			this.color = color;
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
			float x = (float)Math.Sin(angle);
			float y = (float)Math.Cos(angle);	
			//float z = Math.Cos(angle) * Radius;
			return new Vector2(x, y);
		}
		

		/*public override void Dispose() => DestroySelf();
		

		public void DestroySelf()
		{

			Console.WriteLine("Unregisterd circle");
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}*/

       
	}
}
