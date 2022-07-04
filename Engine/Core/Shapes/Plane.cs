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
		public Color color;
		public string Tag;
		public SpriteType TYPE { private set; get; } = SpriteType.PLANE;

		public Plane(Color color, string Tag)
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
		public override void SetColor(Color color)
		{
			this.color = color;
		}
		private Vector2[] CalculatePoints()
		{
			Vector2[] _Points = new Vector2[]
			{
				new Vector2(-0.5f,-0.5f), //Top Left Point
				new Vector2(0.5f,-0.5f), //Top Right Point
				new Vector2(0.5f,0.5f), //Bottom Left Point
				new Vector2(-0.5f,0.5f)  //Bottom Right Point
			};

			return _Points;
		}

		
		/*public override void Dispose() => DestroySelf();

		public void DestroySelf()
		{
			Console.WriteLine("Unregisterd plane");
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}*/

		
	}
}
