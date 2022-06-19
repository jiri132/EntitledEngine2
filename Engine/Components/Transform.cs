using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitledEngine2.Core;
using EntitledEngine2.Core.ECS;

namespace EntitledEngine2.Engine.Components
{
    public class Transform : Component
    {
        public Vector2 Position;
		public float zAxis { private set; get; }
        public Vector2 Scale;

        public Transform()
        {
            Position = Vector2.Zero;
            zAxis = 0;
            Scale = Vector2.One;
        }
        public Transform(Vector2 Position = null, float zAxis = 0f, Vector2 Scale = null)
        {
            if (Position == null) { this.Position = Vector2.Zero; }
            else { this.Position = Position; }

            this.zAxis = zAxis;

            if (Scale == null) { this.Scale = Vector2.One; }
            else { this.Scale = Scale; }
        }

        public void Rotate(float Radiants)
		{
			this.zAxis = Radiants;
		}
        public Vector2 GetForwardVector()
        {
            Vector2 forwardVector;

            float X = (float)(Math.Cos(zAxis) * 1 + Math.Sin(zAxis) * 1);
            float Y = (float)(Math.Cos(zAxis) * 1 - Math.Sin(zAxis) * 1);

            forwardVector = new Vector2(X, Y);
            //forwardVector = Vector2.Normalized(forwardVector);

            return forwardVector;
            /*
             yaw = phi
            X = F
            Y = U

            F' = cos(phi) F + sin(phi) U
            U' = cos(phi) U - sin(phi) F
             */


        }
    }
}
