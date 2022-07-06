using EntitledEngine2.Engine.Core.Vec2;

namespace EntitledEngine2.Engine.Core.Colliders
{
    public class PlaneCollider : Collider
    {
        public Vector2 position { private set; get; } = Vector2.Zero;
        public Vector2 scale { private set; get; } = Vector2.One;
        public Vector2 offset { private set; get; } = Vector2.Zero;
        public bool isTrigger = false;

        public PlaneCollider(Vector2 position = null,Vector2 scale = null, Vector2 offset = null, bool isTrigger = false)
        {
            this.position = position;
            this.scale = scale;
            this.offset = offset;

            this.isTrigger = isTrigger;
        }

        public bool hasCollided(Collider Other)
        {
            
            if (Other.position.x < this.position.x + this.scale.x &&
                Other.position.x + Other.scale.x > this.position.x &&
                Other.position.y < this.position.y + this.scale.y &&
                Other.position.y + Other.scale.y > this.position.y)
            {
                return true;
            }
            //if didnt return true then just return false
            return false;
        }
        #region Overrides
        public override Vector2 Position()
        {
            return position;
        }

        public override Vector2 Scale()
        {
            return scale;
        }

        public override Vector2 Offset()
        {
            return offset;
        }
        #endregion
    }
}
