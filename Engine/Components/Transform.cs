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
		public float zAxis;
        public Vector2 Scale;

		public void Rotate(float angle)
		{
			this.zAxis = angle;
		}
    }
}
