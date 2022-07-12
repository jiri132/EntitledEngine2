using EntitledEngine2.Engine.Components;
using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.Maths;

using System.Drawing;
using System.Collections.Generic;

namespace EntitledEngine2.Engine.Core.Shapes
{
    public class Line : LineRenderer
    {
        public Color Color { private set; get; }
        public List<Vector2> Points = new List<Vector2>();

        public Line(Color lineColor)
        {
            this.Color = lineColor;
        }
        public Line(List<Vector2> points)
        {
            Points = points;
        }

        public Line(Color lineColor, List<Vector2> points)
        {
            this.Color = lineColor;
            Points = points;
        }

        public Color GetLineColor()
        {
            return Color;
        }

        public Vector2[] GetPoints()
        {
            return Points.ToArray();
        }

        public void AddPoint(Vector2 point)
        {
            Points.Add(point);
        }
    }
}
