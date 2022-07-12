using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using EntitledEngine2.Engine.Core.Vec2;

namespace EntitledEngine2.Engine.Core.Shapes
{
    public class Sprite : SpriteRenderer
    {
		public Vector2 Position = null;
		public Vector2 Scale = null;
		public string Directory = "";
		public string Tag = "";
		public Image sprite = null;
		public bool IsRefference = false;

		public Sprite(Vector2 Position, Vector2 Scale, string Directory, string Tag)
		{
			this.Position = Position;
			this.Scale = Scale;
			this.Directory = Directory;
			this.Tag = Tag;

			Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");
			Bitmap sprite = new Bitmap(tmp, (int)this.Scale.x, (int)this.Scale.y);

			this.sprite = sprite;

			Debug.Log($"[SHAPE2D]({Tag}) - has been registerd");
		}
		public Sprite(bool IsReference, string Directory)
		{
			this.IsRefference = IsReference;
			this.Directory = Directory;

			Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");

			Bitmap sprite = new Bitmap(tmp, (int)this.Scale.x, (int)this.Scale.y);
			this.sprite = sprite;

			Debug.Log($"[SHAPE2D]({Tag}) - has been registerd");
		}
		public Sprite(Vector2 Position, Vector2 Scale, Sprite refference, string Tag)
		{
			this.Position = Position;
			this.Scale = Scale;
			this.Tag = Tag;

			this.sprite = refference.sprite;

			Debug.Log($"[SHAPE2D]({Tag}) - has been registerd");
		}

        public SpriteType GetSpriteType()
        {
			return SpriteType.SPRITE;
        }

        public Vector2[] GetDrawingPoints()
        {
			throw new NotImplementedException();
		}

        public Color GetColor()
        {
			return Color.White;
        }

        public void SetColor(Color color)
        {
			Debug.Error($"Can't change sprite color for Sprite to: {color.ToString()}");
        }

        public Image GetImageSprite()
        {
			return sprite;
        }
    }
}
