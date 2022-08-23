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
        public Color Color { private set; get; } = Color.White;
        public bool isTrail { private set; get; } = false;
        public int maxPoints { private set; get; } = 15;

        public List<Vector2> Points = new List<Vector2>();

        #region LineRednerer
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

        public List<Vector2> GetPoints()
        {
            return Points;
        }

        public void AddPoint(Vector2 point)
        {
            Points.Add(point);
        }

        public void SetLineColor(Color c)
        {
            this.Color = c;
        }
        #endregion
        public bool IsTrail()
        {
            return isTrail;
        }

        public void SetTrail(bool anser)
        {
            isTrail = anser;
        }

        public void UpdateTrail()
        {
            if (Points.Count > maxPoints)
            {
                Points.RemoveAt(0);
            }
        }

        public void SetTrailVariables(int maxPoints)
        {
            this.maxPoints = maxPoints;
        }

        public void UpdateTrail(Vector2 point)
        {
            AddPoint(point);

            if (Points.Count > maxPoints)
            {
                Points.RemoveAt(0);
            }
        }
    }
}
