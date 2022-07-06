using EntitledEngine2.Engine.Core.Vec2;
using System;

namespace EntitledEngine2.Engine.Core.Maths
{
    class Mathf
    {
        public static float DegToRad(float deg)
        {
            return deg * (float)Math.PI / 180;
        }
        public static Vector2 Divide(Vector2 a)
        {
            float A = a.x, B = a.y, C = Mathf.sqrt(A * A + B * B);
            A = C / A;
            B = C / B;
            C = C / C;

            return new Vector2(A, B);
        }
        public static float magnitude(Vector2 a)
        {
            float x = a.x, y = a.y;
            return Mathf.sqrt(x * x + y * y);
        }

        public static float pow(float x, int n)
        {
            return (float)Math.Pow(x, n);
        }
        public static float sqrt(float x)
        {
            return (float)Math.Sqrt(x);
        }
    }
}
