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
            double determinant = (a.x * b.x + a.y * b.y) / 1000;

           // Debug.Log(a.y.ToString() + "< a | b >" +  b.y.ToString());

            //Debug.Log((a.x * b.x).ToString() + " | " + (a.y * b.y).ToString());

            //Debug.Log(determinant.ToString());

            return (float)determinant;
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
