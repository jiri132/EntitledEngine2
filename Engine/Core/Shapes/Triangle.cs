using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EntitledEngine2.Engine.Components;

namespace EntitledEngine2.Core.Shapes
{
	public class Triangle : Sprite
	{
		private Vector2[] Points;
		public Color color;
		public string Tag;
		public SpriteType TYPE { private set; get; } = SpriteType.TRIANGLE;
		public Triangle(Color color, string Tag)
		{
			//Assigning the variables
			this.color = color;
			this.Tag = Tag;

			//getting the points
			Points = CalculatePoints();

			//register
/*			Engine.Engine.RegisterSprite(this);*/
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
		public override SpriteType GetSpriteType()
		{
			return TYPE;
		}

		private Vector2[] CalculatePoints()
		{
			Vector2[] _Points = new Vector2[]
			{
				new Vector2(0.0f,-0.5f), //Top Point
				new Vector2(0.5f,0.5f), //Left Point
				new Vector2(-0.5f,0.5f)  //Right Point
			};

			return _Points;
		}

		/*public override void Dispose() => DestroySelf();

		public void DestroySelf()
		{
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}*/

		
	}
}
