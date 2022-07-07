using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;

namespace EntitledEngine2.Engine.Core.Colliders
{
    public class PlaneCollider : Collider
    {
        public Entity _ownEntity = null;

        public PlaneCollider(Entity e)
        {
            _ownEntity = e;
        }


        public override bool TestCollision(Collider other)
        {
            switch (other.typeOfCollider)
            {
                case ColliderType.Plane:
                    return PlanePlane(other);
                    
                case ColliderType.Circle:
                    return PlaneCircle(other);
                    
                default:
                    break;
            }
            return false;
        }

        public bool PlaneCircle(Collider other)
        {
            Vector2 circleDistance = new Vector2();
            //float cornerDistance_sq;
            circleDistance.x = this.position.x - other.position.x;
            circleDistance.y = this.position.y - other.position.y;

            if (circleDistance.x > (this.scale.x / 2 + other.radius)) { return false; }
            if (circleDistance.y > (this.scale.y / 2 + other.radius)) { return false; }

            if (circleDistance.x <= (this.scale.x / 2)) { return true; }
            if (circleDistance.y <= (this.scale.y / 2)) { return true; }

            double cornerDistance_sq = (int)(circleDistance.x - scale.x / 2) ^ 2 +
                                 (int)(circleDistance.y - scale.y / 2) ^ 2;

            return (cornerDistance_sq <= ((int)other.radius ^ 2));
        }
        public bool PlanePlane(Collider other)
        {
            if (ownEntity.transform.Position.x < other.position.x + other.scale.x &&
                ownEntity.transform.Position.x + ownEntity.transform.Scale.x > other.position.x &&
                ownEntity.transform.Position.y < other.position.y + other.scale.y &&
                ownEntity.transform.Position.y + ownEntity.transform.Scale.y > other.position.y)
            {
                return true;
            }
            return false;
        }


        public override ColliderType type()
        {
            return ColliderType.Plane;
        }
        public override Entity OwnEntity()
        {
            return _ownEntity;
        }

        public override Vector2 Position()
        {
            return _ownEntity.transform.Position;
        }

        public override Vector2 Scale()
        {
            return _ownEntity.transform.Scale;
        }
        public override float Radius()
        {
            return _ownEntity.transform.Scale.xy / 2;
        }

        #region Overrides

        #endregion
    }
}
