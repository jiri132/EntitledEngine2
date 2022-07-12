using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Components;
using System.Drawing;

namespace EntitledEngine2.Engine.Components
{
    public interface LineRenderer : Component , ComponentRenderer
    {
        Vector2[] GetPoints();
        Color GetLineColor();
        void AddPoint(Vector2 point);
    }
}
