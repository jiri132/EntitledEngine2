using System.Drawing;

using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;

namespace EntitledEngine2.Engine.Core.Shapes
{
	public enum SpriteType { PLANE, TRIANGLE, CIRCLE }

	public abstract class Sprite : Component
	{
		public abstract SpriteType GetSpriteType();
		public abstract Vector2[] GetDrawingPoints();
		public abstract Color GetColor();

		public abstract void SetColor(Color color);

		public override bool isCollider() => false;
		public override bool isSprite() => true;
		public override bool isRigidbody() => false;
	}
}
