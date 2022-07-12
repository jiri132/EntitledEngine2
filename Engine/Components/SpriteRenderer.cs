using System.Drawing;

using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;

namespace EntitledEngine2.Engine.Core.Shapes
{
	public enum SpriteType { PLANE, TRIANGLE, CIRCLE, SPRITE }

	public interface SpriteRenderer : Component , ComponentRenderer
	{
		//getters / setters
		Image GetImageSprite();
		SpriteType GetSpriteType();
		Vector2[] GetDrawingPoints();
		Color GetColor();

		//calc functions
		void SetColor(Color color);
	}
}
