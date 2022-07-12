using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;
using System;

namespace EntitledEngine2.Engine.Core.Colliders
{
    public enum ColliderType { Plane, Circle }

    public abstract class Collider : Component
    {
        public ColliderType typeOfCollider => type();
        public Entity ownEntity => OwnEntity();
        public Vector2 position => Position();
        public Vector2 scale => Scale();
        public float radius => Radius();

        public abstract ColliderType type();
        public abstract Entity OwnEntity();
        public abstract Vector2 Position();
        public abstract Vector2 Scale();
        public abstract float Radius();

        public abstract bool TestCollision(Collider other);

    }
}
