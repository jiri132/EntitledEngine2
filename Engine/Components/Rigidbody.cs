using System.Collections.Generic;

using EntitledEngine2.Engine.Core.Colliders;
using EntitledEngine2.Engine.Core.ECS;

namespace EntitledEngine2.Engine.Core.Physics
{
    public class Rigidbody : Component
    {
        public List<Collider> colliders = new List<Collider>();




        #region Ovverides
        public override bool isCollider() => false;
        public override bool isRigidbody() => true;
        public override bool isSprite() => false;
        #endregion
    }
}
