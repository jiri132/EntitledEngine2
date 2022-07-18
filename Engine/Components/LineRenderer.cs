using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Components;
using System.Drawing;
using System.Collections.Generic;

namespace EntitledEngine2.Engine.Components
{
    public interface LineRenderer : Component , ComponentRenderer
    {
        List<Vector2> GetPoints();
        Color GetLineColor();
        void AddPoint(Vector2 point);
    }
}
