using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.Maths;

namespace EntitledEngine2.Engine.Core.UI
{
    public abstract class UI
    {
        public Vector2 clampedPosition => CalculateClampedPosition();
        public abstract Vector2 Position();
        private Vector2 CalculateClampedPosition()
        {
            Vector2 position = Position();

            return null;

        }
    }
}
