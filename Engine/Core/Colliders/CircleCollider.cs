using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core.Colliders
{
    class CircleCollider : Collider
    {
        public Entity _ownEntity = null;

        public CircleCollider(Entity e)
        {
            _ownEntity = e;
        }

        public override bool TestCollision(Collider other)
        {
            switch (other.typeOfCollider)
            {
                case ColliderType.Plane:
                    return CirclePlane(other);

                case ColliderType.Circle:
                    return CircleCircle(other);

                default:
                    break;
            }
            return false;
        }


        public bool CirclePlane(Collider other)
        {
            //Console.Clear();

            Vector2 circleDistance = new Vector2();
            
            circleDistance.x = position.x - other.position.x;
            circleDistance.y = position.y - other.position.y;

            Debug.Log(circleDistance.ToString());
            Debug.Log((other.scale / 2).ToString());
            if (circleDistance.x > (other.scale.x / 2 + this.radius)) { Debug.Log(1.ToString()); return false; }
            if (circleDistance.y > (other.scale.y / 2 + this.radius)) { Debug.Log(2.ToString()); return false; }

            if (circleDistance.x >= (other.scale.x / 2)) { Debug.Log(3.ToString()); return true; }
            if (circleDistance.y >= (other.scale.y / 2)) { Debug.Log(4.ToString()); return true; }


            double cornerDistance_sq = (int)(circleDistance.x - radius) ^2 +
                                 (int)(circleDistance.y - radius ) ^2;

            Debug.Log(cornerDistance_sq.ToString());
            Debug.Log(((int)other.radius ^ 2).ToString());

            Debug.Log((cornerDistance_sq <= ((int)other.radius)).ToString());

            return (cornerDistance_sq <= ((int)other.radius ^ 2));
        }
        public bool CircleCircle(Collider other)
        {
            float distX = this.position.x - other.position.x;
            float distY = this.position.y - other.position.y;
            float distance = (float)System.Math.Sqrt((distX * distX) + (distY * distY));

            if (distance <= this.radius + other.radius)
            {
                return true;
            }
            return false;
        }


        public override ColliderType type()
        {
            return ColliderType.Circle;
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




    }
}
