using EntitledEngine2.Core;
using EntitledEngine2.Core.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core.Colliders
{
    public abstract class Collider : Component
    {
        public Vector2 position => Position();
        public Vector2 scale => Scale();
        public Vector2 offset => Offset();


        public abstract Vector2 Position();
        public abstract Vector2 Scale();
        public abstract Vector2 Offset();

        public override bool isCollider() => true;
        public override bool isSprite() => false;

    }
}
