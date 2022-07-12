using System.Drawing;

using EntitledEngine2.Engine.Core.Vec2;

namespace EntitledEngine2.Engine.Core.Shapes
{
	public class Triangle : SpriteRenderer
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

		public Vector2[] GetDrawingPoints()
		{
			Points = CalculatePoints();
			return Points;
		}

		public Color GetColor()
		{
			return color;
		}
		public SpriteType GetSpriteType()
		{
			return TYPE;
		}
		public void SetColor(Color color)
		{
			this.color = color;
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

        public Image GetImageSprite()
        {
            throw new System.NotImplementedException();
        }

        /*public override void Dispose() => DestroySelf();

		public void DestroySelf()
		{
			//unregister
			Engine.Engine.UnRegisterSprite(this);
		}*/


    }
}
