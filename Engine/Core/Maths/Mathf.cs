using EntitledEngine2.Engine.Core.Vec2;
using System;
using System.Windows;

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
            A = A / C;
            B = B / C;
            C = C / C;

            return new Vector2(A, B);
        }
        public static float Magnitude(Vector2 a)
        {
            float x = a.x, y = a.y;
            return Mathf.sqrt(x * x + y * y);
        }

        public static float InnerProduct(Vector2 a, Vector2 b)
        {
            double product = a.x * b.x + a.y * b.y;

            //Debug.Log(a.y.ToString() + "< a | b >" +  b.y.ToString());

            //Debug.Log((a.x * b.x).ToString() + " | " + (a.y * b.y).ToString());

            double x = Vector.Determinant(new Vector(a.x,a.y),new Vector(b.x,b.y));

            product = product / x;

            return (float)product;
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
